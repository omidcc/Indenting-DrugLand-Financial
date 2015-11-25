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
    public partial class DepartmentInfo : System.Web.UI.Page
    {

        private bool isNewEntry;
        private Users _user;
     
        private Company _company=new Company();

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
                if (Request.QueryString["id"] != null)
                {
                    string deptId = Request.QueryString["id"].ToString();

                    Department dept = new Department().GetDepartmentByDepartmentId(int.Parse(deptId), _company.CompanyId);
                    if (dept != null || dept.DepartmentId != 0)
                    {
                        lblId.Text = dept.DepartmentId.ToString();
                        txtDepartmentName.Value = dept.DepartmentName;

                    }
                }
            }
            LoadParentDepartmentIdDropDown();
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


       
        

     

        protected void RadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {

        }
        protected void RadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }
        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                Department aDepartmnent = new Department();
                




                aDepartmnent.DepartmentName = txtDepartmentName.Value;

                aDepartmnent.UpdateDate = DateTime.Now;
                aDepartmnent.UpdateBy = _user.UserId;

                aDepartmnent.IsActive = true;
                aDepartmnent.CompanyId = _company.CompanyId;

                int sucess = 0;
                if (lblId.Text == "" || lblId.Text == "0")
                {
                    aDepartmnent.DepartmentId = new Department().GetMaxDepartmentId() + 1;
                    aDepartmnent.ParentDepartmentId = ParentDepartmentDropDownList.SelectedIndex > -1
                        ? int.Parse(ParentDepartmentDropDownList.SelectedIndex.ToString())
                        : aDepartmnent.DepartmentId;

                    sucess = aDepartmnent.InsertDepartment();

                    if (sucess > 0)
                    {
                        Alert.Show("Department info saved successfully");
                        this.Clear();
                    }
                }
                else
                {
                    aDepartmnent.DepartmentId = int.Parse(lblId.Text);
                    aDepartmnent.ParentDepartmentId = ParentDepartmentDropDownList.SelectedIndex > -1
                        ? int.Parse(ParentDepartmentDropDownList.SelectedIndex.ToString())
                        : aDepartmnent.DepartmentId;
                    sucess = aDepartmnent.UpdateDepartment();

                    if (sucess > 0)
                    {
                        Response.Redirect("DepartmentLists.aspx", true);
                    }
                }
                this.Clear();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }


        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();

        }

        public void Clear()
        {
            txtDepartmentName.Value =
                "";

            chkIsActive.Checked = false;
        }

        void LoadParentDepartmentIdDropDown()
        {
            Department dep=new Department();
            List<Department> depList = dep.GetAllDepartment(_company.CompanyId);
            List<string> idList = new List<string>();

            foreach (Department depoo in depList)
            {
               
                idList.Add(depoo.DepartmentName);
            }
            ParentDepartmentDropDownList.DataSource = idList.Distinct();
            ParentDepartmentDropDownList.DataBind();
        }

    }
}