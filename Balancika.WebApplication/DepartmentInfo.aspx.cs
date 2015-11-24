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
        private Users user;
        List<Company> companyList = new List<Company>();
        private Company _company=new Company();

        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                {
                    Response.Redirect("LogIn.aspx?refPage=index.aspx");

                }
                else
                {
                    Response.Redirect("LogIn.aspx?refPage=index.aspx?" + str);
                }
            }

            if (Session["savedDepartmentMessage"] != null)
            {
                string msg = Session["savedDepartmentMessage"].ToString();
                Session["savedDepartmentMessage"] = null;
                Alert.Show(msg);
            }
            user = (Users)Session["user"];


            this.LoadDepartmentDropDownList();
            this.LoadParentDepartmentIdDropDown();
        }

        public bool isValidSession()
        {
            if (Session["user"] == null)
                return false;
            user = (Users) Session["user"];
            return user.UserId != 0;
        }



       

        public void LoadDepartmentDropDownList()
        {
            try
            {
                DepartmentTableBody.InnerHtml = "";
                string htmlContent = "";
                List<Department> departmentList = new List<Department>();
                Department aDepartment = new Department();
                departmentList = aDepartment.GetAllDepartment(_company.CompanyId);
                foreach (Department aDepo in departmentList)
                {
                    string CompanyName = "";
                    htmlContent += "<tr>";
                    foreach (Company acompany in companyList)
                    {
                        if (acompany.CompanyId == aDepo.CompanyId)
                        {
                            CompanyName += acompany.CompanyName;
                            break;
                        }
                    }

                    htmlContent += String.Format(@"<th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th></tr>", aDepo.DepartmentName, aDepo.ParentDepartmentId, aDepo.IsActive, aDepo.UpdateBy, aDepo.UpdateDate);
                }
                DepartmentTableBody.InnerHtml += htmlContent;

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
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
                List<Department> departmentList = aDepartmnent.GetAllDepartment(_company.CompanyId);
                Department tempDepartment = departmentList[departmentList.Count - 1];
                int id = tempDepartment.DepartmentId + 1;
                aDepartmnent.DepartmentId = id;
                if (ParentDepartmentDropDownList.SelectedItem.Value != null)
                    aDepartmnent.ParentDepartmentId = int.Parse(ParentDepartmentDropDownList.SelectedItem.Value);
                else
                    aDepartmnent.ParentDepartmentId = id;

                aDepartmnent.DepartmentName = txtDepartmentName.Value;

                aDepartmnent.UpdateDate = DateTime.Now;
                aDepartmnent.UpdateBy = user.UserId;

                aDepartmnent.IsActive = true;
                aDepartmnent.CompanyId = _company.CompanyId;
                int success = aDepartmnent.InsertDepartment();
                if (success > 0)
                {
                    Session["savedDepartmentMessage"] = "Saved Department Information successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error Occured while inserting a new user");
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
            List<int> idList = new List<int>();

            foreach (Department depoo in depList)
            {
               
                idList.Add(depoo.ParentDepartmentId);
            }
            ParentDepartmentDropDownList.DataSource = idList.Distinct();
            ParentDepartmentDropDownList.DataBind();
        }

    }
}