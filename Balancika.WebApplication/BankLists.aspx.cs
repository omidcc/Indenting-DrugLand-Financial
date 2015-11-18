using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Management;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class BankLists : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;
        List<Bank> objBankList = new List<Bank>();
        private Company _company=new Company();
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
                this.LoadBankTable();
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
        private void LoadBankTable()
        {
            try
            {

            
            Bank objBank = new Bank();
            objBankList = objBank.GetAllBank(_company.CompanyId);
            if (objBankList.Count == 0)
                objBankList.Add(new Bank());
 
            RadGrid1.DataSource = objBankList;
            RadGrid1.Rebind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
        

       

        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = (GridDataItem)e.Item;

            string id = item["colId"].Text;

            switch (e.CommandName)
            {
                case "btnSelect":
                    Response.Redirect("BankInfo.aspx?id=" + id, true);
                    break;
                case "btnDelete":
                    int delete = new Bank().DeleteBankByBankId(int.Parse(id));

                    if (delete == 0)
                    {
                        Alert.Show("Data was not delete..");
                    }
                    else
                        LoadBankTable();
                    break;
            }
        }

        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("BankInfo.aspx", true);
        }
    }
}