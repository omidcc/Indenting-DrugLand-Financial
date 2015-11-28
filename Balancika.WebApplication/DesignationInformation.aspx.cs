using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class DesignationInformation : System.Web.UI.Page
    {

        private bool isNewEntry;
        private Users user;
        private static int userId;
        private List<Designation> objDesignationList = new List<Designation>();
        private Company _company = new Company();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                _company = (Company) Session["Company"];
                if (!isValidSession())
                {
                    string str = Request.QueryString.ToString();
                    if (str == string.Empty)
                        Response.Redirect("LogIn.aspx?refPage=index.aspx");
                    else
                        Response.Redirect("LogIn.aspx?refPage=index.aspx?" + str);
                }

                this.LoadDesignationTable();
                this.LoadDepartmentDropDownList();
                if (!IsPostBack)
                {
                    if (Request.QueryString["id"] != null)
                    {
                        string designationID = Request.QueryString["id"].ToString();
                        Designation objDesignation =
                            new Designation().GetDesignationByDesignationId(int.Parse(designationID), _company.CompanyId);
                        lblId.Text = objDesignation.DesignationId.ToString();
                        if (objDesignation != null || objDesignation.DepartmentId != 0)
                        {
                            Department aDepartment =
                                new Department().GetDepartmentByDepartmentId(objDesignation.DesignationId,
                                    _company.CompanyId);

                            txtDesignationName.Value = objDesignation.Designation;
                            SetIndex(departmentIdRadDropDownList, objDesignation.DepartmentId.ToString());
                            chkIsActive.Checked = objDesignation.IsActive;
                        }



                    }
                }
                if (Session["designationInfoMsg"] != null)
                {
                    string str = Session["designationInfoMsg"].ToString();
                    Alert.Show(str);
                    Session["designationInfoMsg"] = null;
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }

        }

        public void SetIndex(Telerik.Web.UI.RadDropDownList aDowList, string val)
        {

            for (int i = 0; i < aDowList.Items.Count; i++)
            {
                var li = aDowList.Items[i];
                if (li.Value == val)
                {
                    aDowList.SelectedIndex = i;
                    break;
                }
            }
        }

        private void LoadDesignationTable()
        {
            Designation newDesignation = new Designation();
            objDesignationList = newDesignation.GetAllDesignation(_company.CompanyId);
            //RadGrid1.DataSource = objDesignationList;
            //RadGrid1.Rebind();

        }

        private bool isValidSession()
        {
            if (Session["user"] == null)
            {
                return false;
            }
            user = (Users) Session["user"];
            return user.UserId != 0;
        }
        protected void RadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }
        protected void RadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            this.LoadDepartmentDropDownList();
        }
        protected void departmentIdRadDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           

        }
        protected void departmentIdRadDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                this.SaveDesignation();

            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
            }


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();

        }

        private void SaveDesignation()
        {
            try
            {
                Designation aDesignation = new Designation();
                aDesignation.Designation = txtDesignationName.Value;
                aDesignation.CompanyId = _company.CompanyId;
                aDesignation.DepartmentId = departmentIdRadDropDownList.SelectedIndex > -1 ? int.Parse(departmentIdRadDropDownList.SelectedItem.Value) : int.Parse("0");
                aDesignation.UpdateDate = DateTime.Now;
                aDesignation.UpdateBy = user.UserId;
                
               // aDesignation.UpdateBy = user.User;
                aDesignation.IsActive = chkIsActive.Checked;
                if (lblId.Text == "" || lblId.Text == "0")
                {
                    aDesignation.DesignationId = new Designation().GetMaxdesignationID() + 1;
                    int success = aDesignation.InsertDesignation();
                    string msg=(success > 0 ? "Designation Saved Successfully" : "Something Error Happened");
                    Session["designationInfoMsg"] = msg;
                    this.Clear();
                    Response.Redirect(Request.RawUrl);
                    
                }
                else
                {
                    aDesignation.DesignationId = int.Parse(lblId.Text);
                    int check = aDesignation.UpdateDesignation();
                    if (check > 0)
                    {
                        Response.Redirect("DesignationList.aspx", true);

                    }
                    else
                    {
                        Alert.Show("Updated is not successfully done");
                    }
                }



            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
            }

        }

        public void Clear()
        {
            lblId.Text = "";
            txtDesignationName.Value = "";
            departmentIdRadDropDownList.SelectedIndex = -1;
            chkIsActive.Checked = true;
        }

       
        
        public void LoadDepartmentDropDownList()
        {
            List<Department> departmentList=new List<Department>();
            Department aDepartment=new Department();
            departmentList.Add(aDepartment);
            
            departmentList= aDepartment.GetAllDepartment(_company.CompanyId);
            departmentIdRadDropDownList.DataSource = departmentList;
            departmentIdRadDropDownList.DataTextField = "DepartmentName";
            departmentIdRadDropDownList.DataValueField = "DepartmentId";
            departmentIdRadDropDownList.DataBind();
        }

      
    }
}