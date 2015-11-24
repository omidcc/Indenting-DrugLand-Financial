using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        private static bool isNewEntry;
        private static int userId;
        private Users user;
        private List<Employee> objEmployees=new List<Employee>(); 
        private Company _company=new Company();

        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company) Session["Company"];
        
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                {
                    Response.Redirect("LogIn.aspx?refPage=index.aspx");
                }
                else
                {
                    Response.Redirect("LogIn.aspx?refPage=index.aspx" +str);
                }
            }
            if (!IsPostBack)
            {
                
            }

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

        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
           Response.Redirect("EmployeeInfo.aspx",true);
        }

        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem item = (GridDataItem) e.Item;
                string id = item["colId"].Text;
                switch (e.CommandName)
                {
                    case "btnSelect":
                        Response.Redirect("EmployeeInfo.aspx?id="+id,true);
                        break;
                    case "btnDelete":
                        int success = new Employee().DeleteEmployeeByEmployeeId(int.Parse(id));
                        if (success == 0)
                            Alert.Show("Data is not deleted");
                        else
                        {
                            this.LoadEmployeeListTable();
                        }

                        break;
                }


            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
           
        }

        private void LoadEmployeeListTable()
        {
           
        }
    }
}