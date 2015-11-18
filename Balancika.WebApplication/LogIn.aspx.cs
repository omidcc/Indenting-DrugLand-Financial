using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;

namespace Balancika
{
    public partial class LogIn : System.Web.UI.Page
    {
        private void LoadAllCompany()
        {
            try
            {
                List<Company> companyList = new Company().GetAllCompany();
                if (companyList.Count > 1) companyList.Insert(0, new Company());

                ddlCompany.DataValueField = "CompanyId";
                ddlCompany.DataTextField = "CompanyName";

                ddlCompany.DataSource = companyList;
                ddlCompany.DataBind();

                ddlCompany.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    //string IP = Request.UserHostName;
                    //string compName = DetermineCompName(IP);
                    //lblText.Text = "IP: " + IP + " Name: " + compName + " SessionID: " + Session.SessionID.ToString();
                    string _refPage = Request.QueryString["action"] != null
                                ? Request.QueryString["action"].ToString()
                                : string.Empty;

                    if (_refPage.ToLower() == "logout")
                    {
                        Users user = (Users)Session["user"];

                        Session["user"] = null;
                        Session.Clear();
                        Session.RemoveAll();
                        Session.Abandon();

                        //UserLoginLog log = new UserLoginLog().GetUserLastLogin(user.UserId);
                        //if (log.Id != 0)
                        //{
                        //    new UserLoginLog().UpdateStatus(log.Id, "Logged Out");
                        //    user = new Users();
                        //}
                        return;
                    }

                    if (Session["user"] != null)
                    {
                        Users user = (Users)Session["user"];

                        if (user.UserId != 0)
                        {
                            //Company company = ;
                            Response.Redirect("HomePage.aspx");
                        }
                    }

                    this.LoadAllCompany();
                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error during page load. Error: " + ex.Message);
            }
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {

                Users user = new Users().GetUserByUserName(txtUserName.Value);
                if (user.UserId != 0)
                {
                    if (user.UserPassword != txtPassword.Value)
                    {
                        Alert.Show("User and password didn't match. Please re-enter the correct password.");
                        txtPassword.Focus();
                        return;
                    }

                    int companyId = int.Parse(ddlCompany.SelectedValue);

                    Session["user"] = user;
                    UserRoleMapping userRole = new UserRoleMapping().GetUserRoleMappingByUserId(user.UserId);
                    UserRole role = new UserRole().GetUserRoleById(userRole.RoleId, companyId);
                    Session["Role"] = role;

                    //Get host and port from the url;
                    string host = HttpContext.Current.Request.Url.Host;
                    string port = HttpContext.Current.Request.Url.Port.ToString();

                    string path = "http://" + host + ":" + port + "/";
                    this.GenerateMenu(user, path, companyId);

                    Company company= new Company().GetCompanyByCompanyId(companyId);
                    Session["company"] = company;


                    if (user.EmployeeId != 0)
                    {
                        Employee employee = new Employee().GetEmployeeByEmployeeId(user.EmployeeId,
                            user.CompanyId);
                        Session["Employee"] = employee;

                        //Department objDepartment = new Department().GetEmployeeDepartment(user.EmployeeId);
                        //Session["Department"] = objDepartment.DepartmentName;
                    }
                    else
                        Session["Department"] = "All";

                    string refPage = (Request.QueryString["refPage"] == null) ? string.Empty : Request.QueryString["refPage"].ToString();
                    Response.Redirect(((refPage == string.Empty || refPage.ToLower() == "logout") ? "index.aspx" : refPage), false);
                }
                else
                {
                    Alert.Show("The user is not exist in the database. Please check the username.");
                    txtUserName.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                Alert.Show("Error during process user authentication. Error: " + ex.Message);
            }
        }


        private void GenerateMenu(Users _user, string url, int companyId)
        {
            StringBuilder str = new StringBuilder();

            int parentId = 0;
            bool parentUlOpen = false;
            List<AppPermission> permissionList = new AppPermission().GelAppFunctionalityForMenu(companyId, _user.UserId);
            List<AppModule> moduleList = new AppModule().GetAllAppModule(companyId, _user.UserId);

            foreach (AppModule module in moduleList)
            {
                List<AppPermission> modulePermission = permissionList.FindAll(x => x.ModuleName == module.Module);

                if (modulePermission.Count == 0) continue;

                modulePermission = modulePermission.OrderBy(x => x.Sequence).ToList();
                if (modulePermission[0].IsView)
                {
                    foreach (AppPermission appPermission in modulePermission)
                    {
                        if (appPermission.IsView)
                        {
                            if (appPermission.Url == "#")
                            {
                                if (parentUlOpen)
                                {
                                    str.Append("</ul>\n");
                                    str.Append("</li>\n");
                                }
                                str.Append("<li class='treeview'>\n");
                                str.Append("<a href='#'><i class='fa fa-pie-chart'></i><span>" + appPermission.FunctionalityName + "</span><i class='fa fa-angle-left pull-right'></i></a>\n");
                                str.Append("<ul class='treeview-menu'>\n");

                                parentId = appPermission.FunctionalityId;
                                parentUlOpen = true;
                            }
                            else
                            {

                                if (appPermission.ParentId != parentId)
                                {
                                    if (parentUlOpen)
                                    {
                                        str.Append("</ul>\n");
                                        str.Append("</li>\n");
                                    }

                                    if (appPermission.ParentId == 0)
                                        parentUlOpen = false;
                                }

                                str.Append("<li><a href='" + url + appPermission.Url +
                                           "'><i class='fa fa-circle-o'></i>" + appPermission.FunctionalityName + "</a></li>\n");
                                //str.Append("<li><a target=\"_self\" href=\"" + url + appPermission.Url + "\">" + appPermission.FunctionalityName + "</a> </li>\n");


                            }
                        }
                    }

                }
            }

            if (parentUlOpen)
            {
                str.Append("</ul>\n");
                str.Append("</li>\n");
            }

            str.Append("</ul>\n");

            Session["Menu"] = str.ToString();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="IP"></param>
        /// <returns></returns>
        private string DetermineCompName(string IP)
        {
            IPAddress myIP = IPAddress.Parse(IP);
            IPHostEntry GetIPHost = Dns.GetHostEntry(myIP);
            List<string> compName = GetIPHost.HostName.ToString().Split('.').ToList();
            return compName.First();
        }
    }
}