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
    public partial class ChartOfAccountGroupInfo : System.Web.UI.Page
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
                    string CoaGroupId = Request.QueryString["id"].ToString();

                    ChartOfAccountGroup coa = new ChartOfAccountGroup().GetChartOfAccountGroupByCoaGroupId(int.Parse(CoaGroupId), _company.CompanyId);
                    if (coa != null || coa.CoaGroupId != 0)
                    {
                        
                        lblId.Text = coa.CoaGroupId.ToString();
                        txtGroupName.Value = coa.CoaGroupName;
                        chkIsActive.Checked = true;
                    }
                }
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
        protected void companyIdRadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void companyIdRadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }
      ChartOfAccountGroup agroup=new ChartOfAccountGroup();
        List<ChartOfAccountGroup> coaList=new List<ChartOfAccountGroup>();
        protected void btnSave_Click(object sender, EventArgs e)
        {
            ChartOfAccountGroup coaGroup=new ChartOfAccountGroup();
            List<ChartOfAccountGroup> coaList = coaGroup.GetAllChartOfAccountGroup(_company.CompanyId);
            int id = 0;
            if (coaList.Count > 0)
            {
                id = coaList.Count;
            }

            coaGroup.CoaGroupId = id;
            coaGroup.CoaGroupName = txtGroupName.Value;
            coaGroup.ParentId = coaGroup.CoaGroupId;
            coaGroup.IsActive = true;
            coaGroup.UpdateBy = _user.UserId;
            coaGroup.UpdateDate=DateTime.Now;
            coaGroup.CompanyId = _user.CompanyId;

            int sucess = 0;
            if (lblId.Text == "" || lblId.Text == "0")
            {
                coaGroup.CoaGroupId = new ChartOfAccountGroup().GetMaxCoaGroupId() + 1;

                sucess = coaGroup.InsertChartOfAccountGroup();

                if (sucess > 0)
                {
                    Alert.Show("Chart Of Account Group saved successfully");
                    this.Clear();
                }
            }
            else
            {
                coaGroup.CoaGroupId = int.Parse(lblId.Text);
                sucess = coaGroup.UpdateChartOfAccountGroup();

                if (sucess > 0)
                {
                    Response.Redirect("ChartOfAccountList.aspx", true);
                }
            }

        }

       

      
        private void Clear()
        {
            txtGroupName.Value = "";
        }

        

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }
    }
}