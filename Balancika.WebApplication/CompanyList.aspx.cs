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
    public partial class CompanyList : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;
        private List<Company> objCompany= new List<Company>(); 
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {

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
                this.LoadCompanyListTable();
            }
        }

        private void LoadCompanyListTable()
        {
            try
            {
                Company objCompany = new Company();
                List<string> countryList = Country.CountryList();
                List<Company> objCompanyList= new Company().GetAllCompany();
                if (objCompanyList.Count == 0)
                {
                    objCompanyList.Add(new Company());
                }
                foreach (Company objCst in objCompanyList)
                {
                   
                    Addresses address= new Addresses().GetAddressesBySourceTypeAndId("Company",objCst.CompanyId);
                    
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

                          
                        
                }
                RadGrid1.DataSource = objCompanyList;
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
            {
                return false;
            }

            _user = (Users)Session["user"];

            return _user.UserId != 0;

        }

        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
                    Response.Redirect("CompanyInfo.aspx",true);
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
                        Response.Redirect("CompanyInfo.aspx?id=" + id, true);
                        break;
                    case "btnDelete":
                        int delete = new Company().DeleteCompanyByCompanyId(int.Parse(id));
                        long addressid = GetAddressID(int.Parse(id));
                        int deleteAddress = new Addresses().DeleteAddressesByAddressId(addressid);
                        if (delete == 0)
                            Alert.Show("Data was not deleted");
                        else
                        {
                            this.LoadCompanyListTable();
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
            long p = 0;
            Addresses newAddress = new Addresses();
            List<Addresses> liAddress = newAddress.GetAllAddresses(_company.CompanyId);
            foreach (Addresses addressese in liAddress)
            {
                if (addressese.SourceType == "Company" && addressese.SourceId == parse)
                {
                    p = addressese.AddressId;
                    break;
                }

            }
            return p;
        }
    }
}