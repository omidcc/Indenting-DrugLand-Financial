using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;
using BALANCIKA.BLL;

namespace Balancika
{
    public partial class CostCenterInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            _user = (Users)Session["user"];
            if (!isValidSession())
            {
                string str = Request.QueryString.ToString();
                if (str == string.Empty)
                    Response.Redirect("LogIn.aspx?refPage=default.aspx");
                else
                    Response.Redirect("LogIn.aspx?refPage=default.aspx?" + str);
            }
            if (!IsPostBack)
            {
                
                if (Request.QueryString["id"] != null)
                {
                    string costCenterId = Request.QueryString["id"].ToString();

                    CostCenter costCenter = new CostCenter().GetCostCenterByCostCenterId(int.Parse(costCenterId), _company.CompanyId);
                    if (costCenter != null || costCenter.CostCenterId != 0)
                    {
                        lblId.Text = costCenter.CostCenterId.ToString();
                        txtCostCenterType.Value = costCenter.CostCenterType;
                        txtCostCentreName.Value = costCenter.CostCenterName;
                    }
                }
            }
            this.GetAllCostCentre();
           
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

        private List<CostCenter> listCenter=new List<CostCenter>();

        void GetAllCostCentre()
        {
            CostCenter center=new CostCenter();
            listCenter = center.GetAllCostCenter(_user.CompanyId);


        }

       
        protected void btnSave_Click(object sender, EventArgs e)
        {
            CostCenter objCenter=new CostCenter();

           
            objCenter.CostCenterType = txtCostCenterType.Value;
            objCenter.CostCenterName = txtCostCentreName.Value;
            objCenter.IsActive = chkIsActive.Checked;
            objCenter.CompanyId = _company.CompanyId;
            objCenter.UpdateBy = _user.UserId;
            objCenter.UpdateDate=DateTime.Now.Date;

            int sucess = 0;
            if (lblId.Text == "" || lblId.Text == "0")
            {
                objCenter.CostCenterId = new CostCenter().GetMaxCostCenterId() + 1;

                sucess = objCenter.InsertCostCenter();

                if (sucess > 0)
                {
                    Alert.Show("Cost Center saved successfully");
                    
                }
            }
            else
            {
                objCenter.CostCenterId = int.Parse(lblId.Text);
                sucess = objCenter.UpdateCostCenter();

                if (sucess > 0)
                {
                    Response.Redirect("CostCenterList.aspx", true);
                }
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Clear();

        }

        private void Clear()
        {
            lblId.Text = "";
            txtCostCenterType.Value = "";
            txtCostCentreName.Value = "";

        }
    }
}