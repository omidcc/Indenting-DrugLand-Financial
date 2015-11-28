using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Balancika.BLL;
using Telerik.Web.UI;


namespace Balancika
{
    public partial class CompanyInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private static int userId;
        List<Company> companyList = new List<Company>();
        private Company _company=new Company();

       
        protected void Page_Load(object sender, EventArgs e)
        {

            _company = (Company) Session["Company"];
            this.LoadAllCompany();
            
            this.LoadCountryDropdown();
           
           
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=default.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string companyId = Request.QueryString["id"].ToString();
                    Company tempCompany= new Company().GetCompanyByCompanyId(int.Parse(companyId));
                    if (tempCompany != null || tempCompany.CompanyId != 0)
                    {
                        Addresses tempAddress = new Addresses();
                        List<Addresses> listAdddress = tempAddress.GetAllAddresses(_company.CompanyId);
                        foreach (Addresses addressese in listAdddress.Where(addressese => addressese.SourceId == tempCompany.CompanyId && addressese.SourceType == "Company"))
                        {
                            tempAddress = addressese;
                            break;
                        }
                        lblId.Text = tempCompany.CompanyId.ToString();
                        addlblId.Text = tempAddress.AddressId.ToString();
                        txtCompanyName.Value=tempCompany.CompanyName;

                         
                        txtPhoneNo.Value=tempAddress.Phone;
                      txtEmail.Value=tempAddress.Email;
                        txtWeb.Value=tempAddress.Web;
                       txtLogoPath.Value=tempCompany.LogoPath;


                        // newCompany.UpdateBy = user.UserId;
                        
                      chkIsActive.Checked=tempCompany.IsActive;

                        txtAddressLine1.Value=tempAddress.AddressLine1;
                        txtAddressLine2.Value=tempAddress.AddressLine2;
                        countryDropDownList.SelectedIndex=tempAddress.CountryId;
                        txtCity.Value=tempAddress.City;
                        txtZipCode.Value=tempAddress.ZipCode;
                        
                       
                       

                    }
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
        public void LoadAllCompany()
        {
            try
            {
                Company aCompany = new Company();
                companyList = aCompany.GetAllCompany();
            }
            catch (Exception exc)
            {
                Alert.Show(exc.Message);
            }
        }

      



  

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
            if (txtCompanyName.Value == string.Empty)
            {
                Alert.Show("Please enter the company name.");
                txtCompanyName.Focus();
                return;
            }

            Company newCompany = new Company();

            newCompany.CompanyName = txtCompanyName.Value;

            newCompany.Address = "";
            newCompany.Phone = "";
            newCompany.Email = "";
            newCompany.Web = "";
            newCompany.LogoPath = txtLogoPath.Value;


            // newCompany.UpdateBy = user.UserId;
            newCompany.UpdateBy = _user.UserId;
            newCompany.UpdateDate = DateTime.Now;
            newCompany.IsActive = chkIsActive.Checked;

            Addresses address = new Addresses();
            address.SourceType = "Company";
            
            address.AddressType = "Main Address";
            address.AddressLine1 = txtAddressLine1.Value;
            address.AddressLine2 = txtAddressLine2.Value;
            address.CountryId = countryDropDownList.SelectedIndex;
            address.City = txtCity.Value;
            address.ZipCode = txtZipCode.Value;
            address.Phone = txtPhoneNo.Value;
            address.Mobile = txtPhoneNo.Value;
            address.Email = txtEmail.Value;
            address.Web = txtWeb.Value;
            address.CompanyId = _user.CompanyId;


                if (lblId.Text == "" || lblId.Text == "0")
                {
                    newCompany.CompanyId = new Company().GetMaxCompanyId() + 1;
                    address.SourceId = newCompany.CompanyId;
                    address.AddressId = new Addresses().GetMaxAddressId() + 1;
                    int success = newCompany.InsertCompany();
                    address.InsertAddresses();
                    if (success > 0)
                    {
                        Alert.Show("Saved Company Information Successfully!");
                        this.LoadAllCompany();
                        this.Clear();

                    }
                    else
                    {
                        Alert.Show("Error occured !");
                    }
                }
                else
                {
                    newCompany.CompanyId = int.Parse(lblId.Text);
                    address.SourceId = newCompany.CompanyId;
                    address.AddressId = long.Parse(addlblId.Text);
                    int chk1 = newCompany.UpdateCompany();
                    int chk2 = address.UpdateAddresses();
                    

                    if (chk1 > 0||chk2>0)
                    {
                        Response.Redirect("CompanyList.aspx", true);
                    }
                }

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
        protected void btnNext_Click(object sender, EventArgs e)
        {

        }

        protected void txtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {

        }

        public void Clear()
        {
            lblId.Text = "";
            txtCompanyName.Value = "";
            
            txtEmail.Value = "";
            txtWeb.Value = "";
            txtPhoneNo.Value = "";
            txtLogoPath.Value = "";
            chkIsActive.Checked = true;
            isNewEntry = true;
            countryDropDownList.SelectedIndex = -1;
        }

        protected void countryDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {

        }

        protected void countryDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }

        protected void cityDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
        }

        protected void cityDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }
    }
}
