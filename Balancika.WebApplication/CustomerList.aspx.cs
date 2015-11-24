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
    public partial class CustomerList : System.Web.UI.Page
    {

        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;
        private List<Customer> objCustomerList = new List<Customer>();
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
                this.LoadCustomerTable();

            }

        }

        private void LoadCustomerTable()
        {
            try
            {
                Customer objCustomer = new Customer();
                objCustomerList = objCustomer.GetAllCustomer(_company.CompanyId);
                if (objCustomerList.Count == 0)
                {
                    objCustomerList.Add(new Customer());
                }
                foreach (Customer objCst in objCustomerList)
                {
                    List<string> countryList = Country.CountryList();
                    List<Addresses> addressList =new Addresses().GetAllAddresses(_company.CompanyId);
                    foreach (Addresses address in addressList)
                    {
                        if (address.SourceType == "Customer" && address.SourceId == objCst.CustomerId)
                        {
                            objCst.AddressId = address.AddressId;
                            objCst.AddressLine1 = address.AddressLine1;
                            objCst.AddressLine2 = address.AddressLine2;
                            objCst.AddressType = address.AddressType;
                            objCst.City = address.City;
                            objCst.ZipCode = address.ZipCode;
                            objCst.Phone = address.Phone;
                            objCst.Mobile = address.Mobile;
                            objCst.Email = address.Email;
                            objCst.Web = address.Web;
                            objCst.CountryName = countryList[address.CountryId];
                            
                            break;
                        }
                            
                    }

                }
                RadGrid1.DataSource = objCustomerList;
                RadGrid1.Rebind();

            }
            catch (Exception ex)
            {
                
                
                Alert.Show(ex.Message);

            }
            
        }
    

        private bool isValidSession()
        {
            if (Session["user"]==null)
            {
                return false;
            }

            _user = (Users) Session["user"];

            return _user.UserId != 0;

        }

        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CustomerInfo.aspx", true);
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
                        Response.Redirect("CustomerInfo.aspx?id=" + id, true);
                        break;
                    case "btnDelete":
                        int delete = new Customer().DeleteCustomerByCustomerId(int.Parse(id));
                        long addressid = GetAddressID(int.Parse(id));
                        int deleteAddress = new Addresses().DeleteAddressesByAddressId(addressid);
                        if (delete == 0)
                            Alert.Show("Data was not deleted");
                        else
                        {
                            this.LoadCustomerTable();
                        }
                        break;


                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }

        }

        private long GetAddressID(int parse)
        {
            long p=0;
           Addresses newAddress = new Addresses();
            List<Addresses> liAddress = newAddress.GetAllAddresses(_company.CompanyId);
            foreach (Addresses addressese in liAddress)
            {
                if (addressese.SourceType == "Customer" && addressese.SourceId == parse)
                {
                    p = addressese.AddressId;
                    break;
                }

            }
            return p;
        }
    }
    }
