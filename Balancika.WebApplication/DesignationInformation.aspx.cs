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
    public partial class DesignationInformation : System.Web.UI.Page
    {

        private bool isNewEntry;
        private Users user;
        private static int userId;
        private List<Designation> objDesignationList = new List<Designation>();
        private Company _company = new Company();

        protected void Page_Load(object sender, EventArgs e)
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
            if (!IsPostBack)
            {
                user = (Users)Session["user"];

                this.Clear();
                
              
               
            }
            this.LoadDesignationTable();

        }

        private void LoadDesignationTable()
        {
            Designation newDesignation = new Designation();
            objDesignationList = newDesignation.GetAllDesignation(_company.CompanyId);
            RadGrid1.DataSource = objDesignationList;
            RadGrid1.Rebind();

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
                aDesignation.Designation = txtDesignation.Value;
                aDesignation.CompanyId = _company.CompanyId;
                aDesignation.DepartmentId = departmentIdRadDropDownList.SelectedIndex >= -1 ? int.Parse(departmentIdRadDropDownList.SelectedItem.Value) : 0;
                aDesignation.UpdateDate = DateTime.Now;
                aDesignation.UpdateBy = user.UserId;
               // aDesignation.UpdateBy = user.User;
                aDesignation.IsActive = chkIsActive.Checked;
               int success= aDesignation.InsertDesignation();
                Alert.Show(success>0?"Designation Saved Successfully":"Something Error Happened");
                this.LoadDesignationTable();



            }
            catch (Exception exception)
            {
                Alert.Show(exception.Message);
            }

        }

        public void Clear()
        {

        }

       
        
        public void LoadDepartmentDropDownList()
        {
            List<Department> departmentList=new List<Department>();
            Department aDepartment=new Department();
            
            departmentList= aDepartment.GetAllDepartment(0);
            departmentIdRadDropDownList.DataSource = departmentList;
            departmentIdRadDropDownList.DataTextField = "DepartmentName";
            departmentIdRadDropDownList.DataValueField = "DepartmentId";
            departmentIdRadDropDownList.DataBind();
        }

        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}