using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using BALANCIKA.BLL;
using Telerik.Web.UI;

namespace Balancika
{
    public partial class CostCenterList : System.Web.UI.Page
    {
        private static bool isNewEntry = true;
        private static int userId;
        private Users _user;
        List<CostCenter> objCostCenterList = new List<CostCenter>();
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
                this.LoadCostCentreTable();
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
        private void LoadCostCentreTable()
        {
            try
            {


               
                CostCenter costCenter=new CostCenter();
                objCostCenterList = costCenter.GetAllCostCenter(_company.CompanyId);
                if (objCostCenterList.Count == 0)
                    objCostCenterList.Add(new CostCenter());

                RadGrid1.DataSource = objCostCenterList;
                RadGrid1.Rebind();
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }
        protected void btnAddNew_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CostCenterInfo.aspx", true);
        }

        protected void RadGrid1_OnItemCommand(object sender, GridCommandEventArgs e)
        {
            GridDataItem item = (GridDataItem)e.Item;

            string id = item["colId"].Text;

            switch (e.CommandName)
            {
                case "btnSelect":
                    Response.Redirect("CostCenterInfo.aspx?id=" + id, true);
                    break;
                case "btnDelete":
                    int delete = new CostCenter().DeleteCostCenterByCostCenterId(int.Parse(id));

                    if (delete == 0)
                    {
                        Alert.Show("Data was not delete..");
                    }
                    else
                        LoadCostCentreTable();
                    break;
            }
        }
    }
}