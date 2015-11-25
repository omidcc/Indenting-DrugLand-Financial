using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Licensing;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class CustomerInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private static int userId;
        List<Company> companyList = new List<Company>();
        private Company _company = new Company();

        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];

            if (Session["savedCutomerMessage"] != null)
            {
                string msg = Session["savedCutomerMessage"].ToString();
                Alert.Show(msg);
                Session["savedCutomerMessage"] = null;
            }
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=index.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=index.aspx?" + str);
            }

            this.LoadCountryDropdown();
            this.LoadSalesPersonDropDown();
            
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string customerID = Request.QueryString["id"].ToString();
                    Customer objCustomer = new Customer().GetCustomerByCustomerId(int.Parse(customerID), _company.CompanyId);
                    if (objCustomer != null || objCustomer.CustomerId != 0)
                    {
                        Addresses tempAddress = new Addresses();
                        List<Addresses> listAdddress = tempAddress.GetAllAddresses(_company.CompanyId);
                        foreach (Addresses addressese in listAdddress.Where(addressese => addressese.SourceId == objCustomer.CustomerId && addressese.SourceType == "Customer"))
                        {
                            tempAddress = addressese;
                            break;
                        }
                        addlblId.Text = tempAddress.AddressId.ToString();
                        lblId.Text = objCustomer.CustomerId.ToString();
                        txtCustomerName.Value = objCustomer.CustomerName;
                        txtCustomerCategory.Value = objCustomer.CustomerCategoryId.ToString();
                        SetIndex(salesPersonDropDownList, objCustomer.SalesPersonId.ToString());
                        countryDropDownList.SelectedIndex = tempAddress.CountryId;
                        chkIsActive.Checked = objCustomer.IsActive;
                        txtCreditLimit.Value = objCustomer.CreditLimit.ToString();
                        txtAddressLine1.Value = tempAddress.AddressLine1;
                        txtAddressLine2.Value = tempAddress.AddressLine2;
                        txtCity.Value = tempAddress.City;
                        txtZipCode.Value = tempAddress.ZipCode;
                        txtPhoneNo.Value = tempAddress.Phone;
                        txtMobile.Value = tempAddress.Mobile;
                        txtEmail.Value = tempAddress.Email;
                        txtWeb.Value = tempAddress.Web;
                    }
                }
            }
        }

        public void ClearAll()
        {
            addlblId.Text =
                lblId.Text =
                    txtCustomerName.Value =
                        txtCustomerCategory.Value =
                                txtCreditLimit.Value =
                                    txtAddressLine1.Value =
                                        txtAddressLine2.Value =
                                            txtCity.Value =
                                                txtZipCode.Value =
                                                    txtPhoneNo.Value =
                                                        txtMobile.Value =
                                                            txtEmail.Value =
                                                                txtWeb.Value = "";
            chkIsActive.Checked = false;
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
        private bool isValidSession()
        {
            if (Session["user"] == null)
            {
                return false;
            }

            _user = (Users)Session["user"];

            return _user.UserId != 0;
        }
        void LoadCountryDropdown()
        {
            countryDropDownList.DataSource = Country.CountryList();
            countryDropDownList.DataBind();
        }

        public void LoadSalesPersonDropDown()
        {
            Employee newEmp = new Employee();
            List<Employee> empList = newEmp.GetAllEmployee(_company.CompanyId);
            salesPersonDropDownList.DataSource = empList;
            salesPersonDropDownList.DataTextField = "EmployeeName";
            salesPersonDropDownList.DataValueField = "EmployeeId";
            salesPersonDropDownList.DataBind();

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            Customer objCustomer = new Customer();
          

           
            
            objCustomer.CustomerName = txtCustomerName.Value;
            objCustomer.CustomerCategoryId = int.Parse(txtCustomerCategory.Value);
            objCustomer.SalesPersonId = int.Parse(salesPersonDropDownList.SelectedItem.Value);
            objCustomer.IsActive = chkIsActive.Checked;
            objCustomer.CompanyId = _company.CompanyId;
            objCustomer.CreditLimit = int.Parse(txtCreditLimit.Value);
            objCustomer.UpdateBy = _user.UserId;
            objCustomer.UpdateDate = DateTime.Now;



            Addresses address = new Addresses();
           
          
           
            address.SourceType = "Customer";
            
            address.AddressType = "Main Address";
            address.AddressLine1 = txtAddressLine1.Value;
            address.AddressLine2 = txtAddressLine2.Value;
            address.CountryId = countryDropDownList.SelectedIndex;
            address.City = txtCity.Value;
            address.ZipCode = txtZipCode.Value;
            address.Phone = txtPhoneNo.Value;
            address.Mobile = txtMobile.Value;
            address.Email = txtEmail.Value;
            address.Web = txtWeb.Value;
            address.CompanyId = _company.CompanyId;
            if ((lblId.Text == "" || lblId.Text == "0") && (addlblId.Text == "" || addlblId.Text == "0"))
            {
                objCustomer.CustomerId = new Customer().GetMaxCustomerID() + 1;
                address.SourceId = objCustomer.CustomerId;
                address.AddressId = new Addresses().GetMaxAddressId() + 1;
                int chk1 = objCustomer.InsertCustomer();
                int chk2 = address.InsertAddresses();
                if (chk1 > 0 && chk2 > 0)
                {
                   
                    Session["savedCutomerMessage"] = "Saved Successfully";
                    Response.Redirect(Request.RawUrl);

                }
                else
                {
                    Alert.Show("Error occured while inserting customer information");
                }
            }
            else
            {
                address.AddressId =long.Parse( addlblId.Text);
                objCustomer.CustomerId = long.Parse(lblId.Text);
                int check = address.UpdateAddresses();
                check = objCustomer.UpdateCustomer();

                if (check > 0)
                {
                    Response.Redirect("CustomerList.aspx", true);
                }

            }

           

        }

       

        private void Clear()
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

        protected void companyIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {

        }

        protected void companyIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }

        protected void countryDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {

        }

        protected void countryDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }
    }
}