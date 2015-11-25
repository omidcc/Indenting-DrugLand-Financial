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
    public partial class ChartOfAccountingInfoList : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;

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
                this.LoadChartOfAccountTable();
            }
        }
        private void LoadChartOfAccountTable()
        {
            try
            {
                ChartOfAccount coa = new ChartOfAccount();
                List<ChartOfAccount> coaList = new List<ChartOfAccount>();


                coaList = coa.GetAllChartOfAccount(_company.CompanyId);
                if (coaList.Count == 0)
                    coaList.Add(new ChartOfAccount());

                RadGrid1.DataSource = coaList;
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
            Response.Redirect("ChartOfAccounting.aspx", true);
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
                        Response.Redirect("ChartOfAccounting.aspx?id=" + id, true);
                        break;
                    case "btnDelete":
                        //int delete = new Bank().DeleteBankByBankId(int.Parse(id));
                        int delete = new ChartOfAccount().DeleteChartOfAccountByCoaId(int.Parse(id));

                        if (delete == 0)
                        {
                            Alert.Show("Data was not delete..");
                        }
                        else
                            LoadChartOfAccountTable();
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