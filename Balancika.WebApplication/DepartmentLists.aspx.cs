using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class DepartmentLists : System.Web.UI.Page
    {
        
        private Users _user;
        private Company _company= new Company();
        List<Department>departmentsList=new List<Department>(); 
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];

            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=index.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=index.aspx?" + str);
            }
            if (!IsPostBack)
            {
                this.LoadDepartmentTable();
            }
        }
        private bool isValidSession()
        {
            if (Session["user"] == null)
            {
                return false;
            }

            _user = (Users)Session["user"];

            return _user.UserId != 0;
        }
        private void LoadDepartmentTable()
        {
            try
            {


                Department objDepartment = new Department();
                departmentsList = objDepartment.GetAllDepartment(_company.CompanyId);
                if (departmentsList.Count == 0)
                    departmentsList.Add(new Department());

                RadGrid1.DataSource = departmentsList;
                RadGrid1.Rebind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("DepartmentInfo.aspx", true);
        }

        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = (GridDataItem)e.Item;

            string id = item["colId"].Text;

            switch (e.CommandName)
            {
                case "btnSelect":
                    Response.Redirect("DepartmentInfo.aspx?id=" + id, true);
                    break;
                case "btnDelete":
                    int delete = new Department().DeleteDepartmentByDepartmentId(int.Parse(id));

                    if (delete == 0)
                    {
                        Alert.Show("Data was not delete..");
                    }
                    else
                        LoadDepartmentTable();
                    break;
            }
        }
    }
}