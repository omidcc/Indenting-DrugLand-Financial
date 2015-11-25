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
    public partial class SupplierList : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private Users user;
        private int userId;
        private List<Supplier> objSupplierList=new List<Supplier>(); 
        private Company _company= new Company();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company) Session["Company"];
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
                this.LoadSupplierTable();
            }
        }

        private void LoadSupplierTable()
        {
            try
            {
                Supplier newSupplier= new Supplier();
                objSupplierList = newSupplier.GetAllSupplier(_company.CompanyId);
                List<string> countryList = Country.CountryList();
                List<Addresses> addresses=new Addresses().GetAllAddresses(_company.CompanyId);
                foreach (Supplier supplier in objSupplierList)
                {
                    
                    foreach (Addresses aAddress in addresses)
                    {
                        if (aAddress.SourceType == "Supplier" && aAddress.SourceId == supplier.SupplierId)
                        {
                            supplier.AddressLine1 = aAddress.AddressLine1;
                            supplier.AddressLine2 = aAddress.AddressLine2;
                            supplier.City = aAddress.City;
                            supplier.ZipCode = aAddress.ZipCode;
                            supplier.Phone = aAddress.Phone;
                            supplier.Email = aAddress.Email;
                            supplier.Web = aAddress.Web;
                            supplier.Mobile = aAddress.Mobile;
                            supplier.CountryName = countryList[aAddress.CountryId];
                        }
                    }
                }
                RadGrid1.DataSource = objSupplierList;
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
                return false;
            user = (Users) Session["user"];
            return user.UserId != 0;
        }
        private long GetAddressID(int parse)
        {
            long p = 0;
            Addresses newAddress = new Addresses();
            List<Addresses> liAddress = newAddress.GetAllAddresses(_company.CompanyId);
            foreach (Addresses addressese in liAddress)
            {
                if (addressese.SourceType == "Supplier" && addressese.SourceId == parse)
                {
                    p = addressese.AddressId;
                    break;
                }

            }
            return p;
        }

        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("SupplierInfo.aspx",true);
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
                    {
                        Response.Redirect("SupplierInfo.aspx?id="+id);
                        break;
                    }
                    case "btnDelete":
                    {
                        int del = new Supplier().DeleteSupplierBySupplierId(int.Parse(id));
                        long addId = GetAddressID(int.Parse(id));
                        int del2 = new Addresses().DeleteAddressesByAddressId(addId);
                        if (del2 == 0 && del == 0)
                        {
                            Alert.Show("Data is not deleted");
                        }
                        else
                        {
                            this.LoadSupplierTable();
                        }
                        break;
                    }
                }

            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
    }
}