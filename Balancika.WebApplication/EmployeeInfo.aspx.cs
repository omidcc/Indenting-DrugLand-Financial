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
    public partial class EmployeeInfo : System.Web.UI.Page
    {

        private static bool isNewEntry;
        private static int userId;
        private List<Employee>  objEmployee=new List<Employee>();
        private Users user;
        private Company _company;

        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            user = (Users)Session["user"];

            this.LoadCountryDropDownList();
            this.LoadDepartmentDropDownList();
            
            
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                {
                    Response.Redirect("LogIn.aspx?refPage=index.aspx");
                }
                else
                {
                    Response.Redirect("LogIn.aspx?regPage=index.aspx"+str);
                }
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    Employee tempEmployee= new Employee().GetEmployeeByEmployeeId(int.Parse(id),_company.CompanyId);
                    if (tempEmployee != null || tempEmployee.EmployeeId != 0)
                    {
                        List<string> countryList = Country.CountryList();
                        List<Addresses> addressList = new Addresses().GetAllAddresses(_company.CompanyId);
                        Designation designation =
                            new Designation().GetDesignationByDesignationId(tempEmployee.DesignationId,
                                _company.CompanyId);
                        Department department;
                        if (tempEmployee.DepartmentId != 0)
                        {
                            department = new Department().GetDepartmentByDepartmentId(tempEmployee.DepartmentId,
                                _company.CompanyId);
                            SetIndex(departmentDropDownList, department.DepartmentId.ToString());
                            LoadDesignationDropDownList(tempEmployee.DepartmentId);
                           

                        }
                        else
                        {
                            department = new Department();
                            departmentDropDownList.SelectedIndex = -1;
                            LoadDesignationDropDownList(0);
                        }
                        SetIndex(designationDropDownList,tempEmployee.DesignationId.ToString());
                        lblId.Text = tempEmployee.EmployeeId.ToString();
                        txtEmployeeCode.Value = tempEmployee.EmployeeCode;
                        txtEmployeeName.Value = tempEmployee.EmployeeName;
                        JoinRadDatePicker.SelectedDate = DateTime.Parse(tempEmployee.JoinDate);
                        RadDatePicker1.SelectedDate = DateTime.Parse(tempEmployee.DOB);
                        chkIsActive.Checked = tempEmployee.IsActive;
                        
                       //SetIndex(designationDropDownList,designation.DesignationId.ToString());
                        foreach (Addresses tAddress in addressList)
                        {
                            if (tAddress.SourceType == "Employee" && tAddress.SourceId == tempEmployee.EmployeeId)
                            {
                                addlblId.Text = tAddress.AddressId.ToString();
                                txtAddressLine1.Value = tAddress.AddressLine1;
                                txtAddressLine2.Value = tAddress.AddressLine2;
                                txtCity.Value = tAddress.City;
                                txtEmail.Value = tAddress.Email;
                                txtZipCode.Value = tAddress.ZipCode;
                                txtPhoneNo.Value = tAddress.Phone;
                                countryDropDownList.SelectedIndex = tAddress.CountryId;
                                break;


                            }

                        }
                    }


                }
            }
            if (Session["empMessage"] != null)
            {
                string message = Session["empMessage"].ToString();
                Session["empMessage"] = null;
                Alert.Show(message);
            }
           
            

        }

        public void Clear()
        {
            lblId.Text =
                txtEmployeeCode.Value =
                    txtEmployeeName.Value =
                    addlblId.Text =
                                txtAddressLine1.Value =
                                    txtAddressLine2.Value =
                                        txtCity.Value =
                                            txtEmail.Value =
                                                txtZipCode.Value =
                                                    txtPhoneNo.Value = "";
            countryDropDownList.SelectedIndex = -1;
            chkIsActive.Checked = true;
        }

        private void LoadDesignationDropDownList(int id)
        {
            designationDropDownList.ClearSelection();
            int departmentId = id ;
            List<Designation> oDesignationList = new Designation().GetDesignationbyDepartmentId(departmentId);
            designationDropDownList.DataSource = oDesignationList;
            designationDropDownList.DataTextField = "Designation";
            designationDropDownList.DataValueField = "DesignationId";
            designationDropDownList.DataBind();

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

        public bool isValidSession()
        {

            if (Session["user"] == null)
            {

                return false;
            }

            user = (Users) Session["user"];
            return user.UserId != 0;

        }
        private void LoadCountryDropDownList()
        {
            countryDropDownList.DataSource = Country.CountryList();

            countryDropDownList.DataBind();
        }

      

        public void LoadDepartmentDropDownList()
        {
            Department newDeg = new Department();
            List<Department> newDegList = newDeg.GetAllDepartment(_company.CompanyId);
            departmentDropDownList.DataSource = newDegList;
            departmentDropDownList.DataTextField = "DepartmentName";
            departmentDropDownList.DataValueField = "DepartmentId";
            departmentDropDownList.DataBind();
        }

        protected void countryDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void countryDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }

       

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Designation newDesignation = new Designation();
                

                bool chk = false;
                Employee aEmployee = new Employee();
                Addresses aAddresses=new Addresses();
                List<Employee> employeeListC =aEmployee.GetAllEmployee(_company.CompanyId);
                if (lblId.Text == "" || lblId.Text == "0")
                foreach (Employee anEmployee in employeeListC)
                {
                    if (anEmployee.EmployeeCode == txtEmployeeCode.Value)
                    {
                        Session["empMessage"] = "Employee Code is exist! Try Again";
                        chk = true;
                        break;
                    }
                }
                 if (chk == true)
                {
                    Response.Redirect(Request.RawUrl);
                }
                Employee tempEmployee = new Employee();
               
                 

               
               
                aEmployee.EmployeeCode = txtEmployeeCode.Value;
                aEmployee.EmployeeName = txtEmployeeName.Value;
                aEmployee.DOB = RadDatePicker1.SelectedDate.ToString();
                aEmployee.JoinDate = JoinRadDatePicker.SelectedDate.ToString();
                
                aEmployee.DepartmentId = int.Parse(departmentDropDownList.SelectedIndex>-1?departmentDropDownList.SelectedItem.Value:"0");
                aEmployee.DesignationId = int.Parse(designationDropDownList.SelectedItem.Value);
                aEmployee.Address = "Main Address";
                aAddresses.SourceType = "Employee";
                aAddresses.AddressLine1 = txtAddressLine1.Value;
                aAddresses.AddressLine2 = txtAddressLine2.Value;
                aAddresses.AddressType = "Main Address";
                aAddresses.CountryId = int.Parse(countryDropDownList.SelectedIndex.ToString());
                aAddresses.City = txtCity.Value;
                aAddresses.ZipCode = txtZipCode.Value;
                aAddresses.Email = txtEmail.Value;
                aAddresses.Web = "";
                aAddresses.Phone = txtPhoneNo.Value;
                aAddresses.Mobile = txtMobile.Value;
                aAddresses.CompanyId = _company.CompanyId;
                aEmployee.CompanyId = _company.CompanyId;
                aEmployee.IsActive = true;
                aEmployee.UpdateBy = user.UserId;
                aEmployee.UpdateDate = DateTime.Now;
                if (lblId.Text == "" || lblId.Text == "0")
                {
                    aEmployee.EmployeeId = new Employee().GetMaxEmployeeId() + 1;
                    aAddresses.SourceId = aEmployee.EmployeeId;
                    aAddresses.AddressId = new Addresses().GetMaxAddressId() + 1;

                    int chkEmployee = aEmployee.InsertEmployee();
                    int chkAddress = aAddresses.InsertAddresses();
                    if (chkAddress > 0 && chkEmployee > 0)
                    {
                        Session["empMessage"] = "Saved Successfully";
                        Response.Redirect(Request.RawUrl);

                    }
                    else
                    {
                        Alert.Show("Error occured while inserting employee information");
                    }
                }
                else
                {
                    aEmployee.EmployeeId = int.Parse(lblId.Text);
                    aAddresses.SourceId = aEmployee.EmployeeId;
                    aAddresses.AddressId = long.Parse(addlblId.Text);
                   int chk3= aEmployee.UpdateEmployee();
                    int chk1=aAddresses.UpdateAddresses();
                    if(chk3>0&&chk1>0)
                        Response.Redirect("EmployeeList.aspx",true);


                }
                


            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
           
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        protected void departmentDropDownList_IndexChanged(object sender, DropDownListEventArgs e)
        {
            int id = int.Parse(departmentDropDownList.SelectedItem.Value);
            this.LoadDesignationDropDownList(id);
        }
    }
}