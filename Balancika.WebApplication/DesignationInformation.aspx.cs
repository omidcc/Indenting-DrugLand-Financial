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
            this.LoadDepartmentDropDownList();
            if (!IsPostBack)
            {
                if (Session["colDesignationId"] != null)
                {
                    string designationID = Session["colDesignationId"].ToString();
                    Designation objDesignation=new Designation().GetDesignationByDesignationId(int.Parse(designationID),_company.CompanyId);
                    if (objDesignation != null || objDesignation.DepartmentId != 0)
                    {
                        Department aDepartment=new Department().GetDepartmentByDepartmentId(objDesignation.DesignationId,_company.CompanyId);
                    }
                    txtDesignationName.Value = objDesignation.Designation;
                    SetIndex(departmentIdRadDropDownList,objDesignation.DepartmentId.ToString());

                    

                }
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
                aDesignation.Designation = txtDesignationName.Value;
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
            try
            {
                GridDataItem item = (GridDataItem)e.Item;
                string id = item["colId"].Text;
                switch (e.CommandName)
                {
                    case "btnSelect":
                    {
                        Session["colDesignationId"] = id;
                        Response.Redirect(Request.RawUrl);
                        break;
                    }
                    case "btnDelete":
                        int del = new Department().DeleteDepartmentByDepartmentId(int.Parse(id));
                        if(del==0)
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