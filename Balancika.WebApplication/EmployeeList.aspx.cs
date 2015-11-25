using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class EmployeeList : System.Web.UI.Page
    {
        private static bool isNewEntry;
        private static int userId;
        private Users user;
        private List<Employee> objEmployees=new List<Employee>(); 
        private Company _company=new Company();

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
                    Response.Redirect("LogIn.aspx?refPage=index.aspx" +str);
                }
            }
            if (!IsPostBack)
            {
                this.LoadEmployeeListTable();
            }

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

        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
           Response.Redirect("EmployeeInfo.aspx",true);
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
                        Response.Redirect("EmployeeInfo.aspx?id="+id,true);
                        break;
                    case "btnDelete":
                        int success = new Employee().DeleteEmployeeByEmployeeId(int.Parse(id));
                        long addId = GetAddressID(int.Parse(id));
                        int chk1 = new Addresses().DeleteAddressesByAddressId(addId);
                        if (success == 0 || chk1==0)
                            Alert.Show("Data is not deleted");
                        else
                        {
                            this.LoadEmployeeListTable();
                        }

                        break;
                }


            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
           
        }

        private void LoadEmployeeListTable()
        {
            try
            {
                Addresses tempAddres = new Addresses();
                Designation tempDesignation = new Designation();
                Department tempDepartment = new Department();
                Employee objEmployee = new Employee();
                List<Employee> objEmployeeList = objEmployee.GetAllEmployee(_company.CompanyId);
                foreach (Employee employee in objEmployeeList)
                {

                    List<Addresses> objAddressList = tempAddres.GetAllAddresses(_company.CompanyId);
                    Designation aDesignation = tempDesignation.GetDesignationByDesignationId(employee.DesignationId,_company.CompanyId);
                    Department aDepartment = tempDepartment.GetDepartmentByDepartmentId(employee.DepartmentId,
                        _company.CompanyId);
                    employee.DepartmentName = aDepartment.DepartmentName;
                    employee.DesignationName = aDesignation.Designation;
                    employee.DOB = DateTime.Parse(employee.DOB).ToShortDateString();
                    employee.JoinDate = DateTime.Parse(employee.JoinDate).ToShortDateString();
                    List<string> countrList = Country.CountryList();
                    

                    foreach (Addresses anAddresses in objAddressList)
                    {
                        if (anAddresses.SourceType == "Employee" && anAddresses.SourceId == employee.EmployeeId)
                        {
                            employee.AddressLine1 = anAddresses.AddressLine1;
                            employee.AddressLine2 = anAddresses.AddressLine2;
                            employee.City = anAddresses.City;
                            employee.ZipCode = anAddresses.ZipCode;
                            employee.Phone = anAddresses.Phone;
                            employee.Mobile = anAddresses.Mobile;
                            employee.Email = anAddresses.Email;
                            employee.CountryName = countrList[anAddresses.CountryId];
                            break;
                            
                        }
                        

                    }
                    RadGrid1.DataSource = objEmployeeList;
                    RadGrid1.Rebind();


                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }

        }
        private long GetAddressID(int parse)
        {
            Addresses newAddress = new Addresses();
            List<Addresses> liAddress = newAddress.GetAllAddresses(_company.CompanyId);
            return (from addressese in liAddress where addressese.SourceType == "Employee" && addressese.SourceId == parse select addressese.AddressId).FirstOrDefault();
        }
    }
}