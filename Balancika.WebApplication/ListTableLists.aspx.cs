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
    public partial class ListTableLists : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;
        List<ListTable> objListTables = new List<ListTable>();
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
                this.LoadListTable();
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
        private void LoadListTable()
        {
            try
            {


                ListTable listTable = new ListTable();
                objListTables = listTable.GetAllListTable(_company.CompanyId);
                if (objListTables.Count == 0)
                    objListTables.Add(new ListTable());

                RadGrid1.DataSource = objListTables;
                RadGrid1.Rebind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ListTableInfo.aspx", true);
        }

        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = (GridDataItem)e.Item;

            string id = item["colId"].Text;

            switch (e.CommandName)
            {
                case "btnSelect":
                    Response.Redirect("ListTableInfo.aspx?id=" + id, true);
                    break;
                case "btnDelete":
                    int delete = new ListTable().DeleteListTableById(int.Parse(id));

                    if (delete == 0)
                    {
                        Alert.Show("Data was not delete..");
                    }
                    else
                        LoadListTable();
                    break;
            }
        }
    }
}