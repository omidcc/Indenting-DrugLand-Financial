using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class DesignationList : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users user;
        private List<Designation> objDesignationList= new List<Designation>();
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company) Session["Company"];
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if(str==string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=index.aspx");
                else
                {
                    Response.Redirect("LogIn.aspx?refPage=index.aspx?"+str);
                }
            }
            if (!IsPostBack)
                this.LoadDesignationTable();


        }

        private void LoadDesignationTable()
        {
            try
            {
                Designation objDesignation =new Designation();
                List<Designation> objDesignationList = objDesignation.GetAllDesignation(_company.CompanyId);
                foreach (Designation aDesignation in objDesignationList)
                {
                    if (aDesignation.DepartmentId != 0)
                    {
                        Department aDepartment = new Department().GetDepartmentByDepartmentId(
                            aDesignation.DepartmentId, _company.CompanyId);
                        aDesignation.DepartmentName = aDepartment.DepartmentName;
                    }
                    else
                    {
                        aDesignation.DepartmentName = "None";
                    }
                }
                RadGrid1.DataSource = objDesignationList;
                RadGrid1.Rebind();

            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        private bool isValidSession()
        {
            if (Session["user"] == null)
                return false;
            user = (Users) Session["user"];
            return user.UserId != 0;

        }

        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("DesignationInformation.aspx",true);
        }
        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                GridDataItem item = (GridDataItem)e.Item;
                string id = item["colId"].Text;
                switch (e.CommandName)
                {
                    case "btnSelect":
                        {
                           Response.Redirect("DesignationInformation.aspx?id="+id,true);
                            break;
                        }
                    case "btnDelete":
                        int del = new Designation().DeleteDesignationByDesignationId(int.Parse(id));
                        if (del == 0)
                            Alert.Show("Data is not deleted");
                        else
                        {
                            this.LoadDesignationTable();
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }
}