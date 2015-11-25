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
    public partial class ChartOfAccounting : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private List<Company> allCompanyList = new List<Company>();
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

                    ChartOfAccount coa = new ChartOfAccount().GetChartOfAccountByCoaId(int.Parse(CoaGroupId), _company.CompanyId);
                    if (coa != null || coa.CoaGroupId != 0)
                    {

                        lblId.Text = coa.CoaId.ToString();

                        this.LoadAllCompany();
                        this.LoadAccountGroup();
                        this.LoadType();
                        txtChartOfAccountCode.Value = coa.CoaCode;
                        txtChartOfAccountTitle.Value = coa.CoaTitle;

                    }
                }
            }
            this.LoadAllCompany();
            this.LoadAccountGroup();
            this.LoadType();
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
     
        private void LoadAllCompany()
        {
            Company company = new Company();
            allCompanyList = company.GetAllCompany();
            List<string> nameList = new List<string>();
            foreach (Company com in allCompanyList)
            {
                nameList.Add(com.CompanyName);
            }
            

        }
        private List<ChartOfAccountGroup>accountGroups=new List<ChartOfAccountGroup>(); 
        private void LoadAccountGroup()
        {
            ChartOfAccountGroup group=new ChartOfAccountGroup();
            List<string> nameList =new List<string>();
            accountGroups = group.GetAllChartOfAccountGroup(_company.CompanyId);
            foreach (ChartOfAccountGroup acc in accountGroups)
            {
                nameList.Add(acc.CoaGroupName);
            }
            chartOfAccountGroupIdDropDownList.DataSource = nameList;
            chartOfAccountGroupIdDropDownList.DataBind();
        }

       

        protected void chartOfAccountTypeDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void chartOfAccountTypeDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
         
        }

        protected void chartOfAccountGroupIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void chartOfAccountGroupIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void parentIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
          
        }

        protected void parentIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void companyIdRadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void companyIdRadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            
            ChartOfAccount objChartOfAccount=new ChartOfAccount();
            List<ChartOfAccount> myAccounts = objChartOfAccount.GetAllChartOfAccount(_company.CompanyId);

            objChartOfAccount.CoaId = myAccounts.Count;
            objChartOfAccount.CoaType = chartOfAccountTypeDropDownList.SelectedItem.Text;
           

            objChartOfAccount.CoaGroupId = chartOfAccountGroupIdDropDownList.SelectedIndex;
            objChartOfAccount.CoaCode = txtChartOfAccountCode.Value;
            objChartOfAccount.CoaTitle = txtChartOfAccountTitle.Value;
            objChartOfAccount.ParentId = objChartOfAccount.CoaId;
            objChartOfAccount.IsActive = chkIsActive.Checked;
            objChartOfAccount.UpdateBy = _user.UserId;
            objChartOfAccount.UpdateDate = DateTime.Now;
            objChartOfAccount.CompanyId = _company.CompanyId;

            int sucess = 0;
            if (lblId.Text == "" || lblId.Text == "0")
            {
                objChartOfAccount.CoaId = new ChartOfAccount().GetMaxCoaId() + 1;

                sucess = objChartOfAccount.InsertChartOfAccount();

                if (sucess > 0)
                {
                    Alert.Show("Chart Of Account saved successfully");
                    this.Clear();
                }
            }
            else
            {
                objChartOfAccount.CoaId = int.Parse(lblId.Text);
                sucess = objChartOfAccount.UpdateChartOfAccount();

                if (sucess > 0)
                {
                    Response.Redirect("ChartOfAccountingInfoList.aspx", true);
                }
            }

        }

        void LoadType()
        {
            List<BankAccounts>accList=new List<BankAccounts>();
            BankAccounts acc=new BankAccounts();

            accList = acc.GetAllBankAccounts(_company.CompanyId);
            List<string>accTypeList=new List<string>();

            foreach (BankAccounts bankAccounts in accList)
            {
                accTypeList.Add(bankAccounts.AccountType);
            }
            chartOfAccountTypeDropDownList.DataSource = accTypeList;
            chartOfAccountTypeDropDownList.DataBind();
        }
        private void Clear()
        {
            txtChartOfAccountCode.Value = "";
            txtChartOfAccountTitle.Value = "";
        }
        

        protected void btnClear_Click(object sender,EventArgs e)
        {
            
        }
    }
}