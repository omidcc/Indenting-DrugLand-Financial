using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class BankAccoutsList : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;
        List<BankAccounts> objAccountList = new List<BankAccounts>();
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];

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
                this.LoadAccountsTable();
            }
        }

        private void LoadAccountsTable()
        {
            try
            {
                BankAccounts objAccounts=new BankAccounts();
                objAccountList = objAccounts.GetAllBankAccounts(_company.CompanyId);

                if(objAccountList.Count==0)
                    objAccountList.Add(new BankAccounts());

                RadGrid1.DataSource = objAccountList;
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
            Response.Redirect("BankAccountsInfo.aspx", true);
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
                        Response.Redirect("BankAccountsInfo.aspx?id=" + id, true);
                        break;
                    case "btnDelete":
                        //int delete = new Bank().DeleteBankByBankId(int.Parse(id));
                        int delete = new BankAccounts().DeleteBankAccountsByBankAccountId(int.Parse(id));

                        if (delete == 0)
                        {
                            Alert.Show("Data was not delete..");
                        }
                        else
                            LoadAccountsTable();
                        break;
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

    }
}