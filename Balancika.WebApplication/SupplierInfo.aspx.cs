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
    public partial class SupplierInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users user;
        private static int userId;
        List<Supplier> objSupplierList= new List<Supplier>(); 
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            user = (Users)Session["user"];
            this.LoadCountryDropDownList();
            if (Session["savedSupplicerMessage"] != null)
            {
                string msg = Session["savedSupplicerMessage"].ToString();
                Alert.Show(msg);
                Session["savedSupplicerMessage"] = null;
            }
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                {
                    Response.Redirect("LogIn.aspx?refPage=index.aspx");
                }
                else
                {
                    Response.Redirect("LogIn.aspx?refPage=index.aspx?"+str);
                }
            }
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null)
                {
                    string id = Request.QueryString["id"].ToString();
                    Supplier tempSupplier= new Supplier().GetSupplierBySupplierId(int.Parse(id),_company.CompanyId);
                    if (tempSupplier != null || tempSupplier.SupplierId != 0)
                    {
                        List<Addresses> addressList = new Addresses().GetAllAddresses(_company.CompanyId);
                        Addresses tempAddress = new Addresses();
                        foreach (Addresses address in addressList)
                        {
                            if (address.SourceType == "Supplier" && address.SourceId == int.Parse(id))
                            {
                                tempAddress = address;
                                break;
                            }
                        }
                        lblId.Text = id;
                        addlblId.Text = tempAddress.AddressId.ToString();
                        txtSupplierName.Value = tempSupplier.SupplierName;
                        txtAddressLine1.Value = tempAddress.AddressLine1;
                        txtAddressLine2.Value = tempAddress.AddressLine2;
                        txtCity.Value = tempAddress.City;
                        txtZipCode.Value = tempAddress.ZipCode;
                        txtEmail.Value = tempAddress.Email;
                        txtPhone.Value = tempAddress.Phone;
                        txtMobile.Value = tempAddress.Mobile;
                        txtWeb.Value = tempAddress.Web;
                        txtTotalCredit.Value = tempSupplier.TotalCredit.ToString();
                        txtTotalDebit.Value = tempSupplier.TotalDebit.ToString();
                        chkIsActive.Checked = tempSupplier.IsActive;
                        countryDropDownList.SelectedIndex = tempAddress.CountryId;
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
            user = (Users) Session["user"];
            return user.UserId!=0;
        }

        private void LoadCountryDropDownList()
        {
            countryDropDownList.DataSource = Country.CountryList();
            countryDropDownList.DataBind();
        }

     

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool chk = false;
                Supplier aSupply = new Supplier();
                List<Supplier> aSuppierList = aSupply.GetAllSupplier(_company.CompanyId);
                long id;
               
                    
                
                Supplier newSupply = new Supplier();
                
                newSupply.SupplierName = txtSupplierName.Value;
                newSupply.IsActive = true;
                newSupply.CompanyId = _company.CompanyId;
                newSupply.UpdateBy = user.UserId;
                newSupply.UpdateDate = DateTime.Now;
                newSupply.TotalDebit = decimal.Parse(txtTotalDebit.Value);
                newSupply.TotalCredit = decimal.Parse(txtTotalCredit.Value);
                
                Addresses address = new Addresses();
                address.SourceType = "Supplier";

                address.AddressType = "Main Address";
                address.AddressLine1 = txtAddressLine1.Value;
                address.AddressLine2 = txtAddressLine2.Value;
                address.CountryId = int.Parse(countryDropDownList.SelectedIndex.ToString());
                address.City = txtCity.Value;
                address.Email = txtEmail.Value;
                address.Phone = txtPhone.Value;
                address.Web = txtWeb.Value;
                address.Mobile = txtMobile.Value;

                address.ZipCode = txtZipCode.Value;

                address.CompanyId = _company.CompanyId;
                if (lblId.Text == "" || lblId.Text == "0")
                {
                    newSupply.SupplierId = new Supplier().GetMaxSupplierID() + 1;
                    address.SourceId = newSupply.SupplierId;
                    address.AddressId = new Addresses().GetMaxAddressId() + 1;
                    int chk1 = newSupply.InsertSupplier();
                    int chk2 = address.InsertAddresses();
                    if (chk1 > 0 && chk2 > 0)
                    {
                        Session["savedSupplicerMessage"] = "Saved Successfully";
                        Response.Redirect(Request.RawUrl);

                    }
                    else
                    {
                        Alert.Show("Error occured while inserting supplier information,please check the input data again. Don't use special character in Debit or Credit Section . Use the amount number there.");
                    }
                }
                else
                {
                    address.AddressId = long.Parse(addlblId.Text);
                    newSupply.SupplierId = int.Parse(lblId.Text);
                    address.SourceId = newSupply.SupplierId;
                    int chk1 = newSupply.UpdateSupplier();
                    int chk2 = address.UpdateAddresses();
                    if(chk1>0&&chk2>0)
                        Response.Redirect("SupplierList.aspx");

                }

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
            
        }

        public void Clear()
        {
            lblId.Text =
                addlblId.Text =
                    txtSupplierName.Value =
                        txtAddressLine1.Value =
                            txtAddressLine2.Value =
                                txtCity.Value =
                                    txtZipCode.Value =
                                        txtEmail.Value =
                                            txtPhone.Value =
                                                txtMobile.Value =
                                                    txtWeb.Value =
                                                        txtTotalCredit.Value =
                                                            txtTotalDebit.Value = "";
                                                                chkIsActive.Checked = true;
            countryDropDownList.SelectedIndex = -1;
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
                this.Clear();
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