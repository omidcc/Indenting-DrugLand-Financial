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
    public partial class BankAccountsInfo : System.Web.UI.Page
    {
        private Users _user;
        private Company _company;
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
            _user = (Users)Session["User"];

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
                if (Request.QueryString["id"] != null)
                {
                    string bankAccountId = Request.QueryString["id"].ToString();

                    BankAccounts objBankAccounts = new BankAccounts().GetBankAccountsByBankAccountId(int.Parse(bankAccountId), _company.CompanyId);
                    
                    if (objBankAccounts != null || objBankAccounts.BankAccountId != 0)
                    {


                        List<Bank> bankList = new List<Bank>();
                        Bank bank = new Bank();

                        lblId.Text = objBankAccounts.BankAccountId.ToString();

                        bankIdRadDropDownList1.Items.Clear();
                        bankList = bank.GetAllBank(_company.CompanyId);

                        List<string> bankName = new List<string>();
                        foreach (Bank bankNew in bankList)
                        {
                            if (bankNew.BankId == objBankAccounts.BankId)
                                bankName.Add(bankNew.BankName);
                        }
                        bankIdRadDropDownList1.DataSource = bankName;
                        bankIdRadDropDownList1.DataBind();

                        txtBranchName.Value = objBankAccounts.BranchName;
                        txtAccountNo.Value = objBankAccounts.AccountNo;
                        txtTitle.Value = objBankAccounts.AccountTitle;

                        accountTypeRadDropDownList1.Items.Clear();
                        List<string> list = new List<string>();
                        list.Add(objBankAccounts.AccountType);
                        accountTypeRadDropDownList1.DataSource = list;
                        accountTypeRadDropDownList1.DataBind();

                        RadDatePicker2.SelectedDate = DateTime.Parse(objBankAccounts.OpeningDate);
                        chkIsActive.Checked = objBankAccounts.IsActive;


                    }
                }
            }
            this.LoadBankNames();
            this.LoadAccountTypeDropDown();
       
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
        void LoadBankNames()
        {
            
            List<Bank>allBanks=new Bank().GetAllBank(_company.CompanyId);
            List<string>nameList=new List<string>();
            foreach (Bank bank in allBanks)
            {
                nameList.Add(bank.BankName);
            }
            bankIdRadDropDownList1.DataSource = nameList;
            bankIdRadDropDownList1.DataBind();
        }
        void LoadAccountTypeDropDown()
        {
            List<string>myList=new List<string>();

            myList.Add("Current");
            myList.Add("Savings");
            myList.Add("Marchent");

            accountTypeRadDropDownList1.DataSource = myList;
            accountTypeRadDropDownList1.DataBind();
        }

       
        
        protected void accountTypeRadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void accountTypeRadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                BankAccounts objAccounts = new BankAccounts();


                List<BankAccounts> myList = objAccounts.GetAllBankAccounts(_user.CompanyId);

                objAccounts.BankAccountId = myList.Count;
                objAccounts.BranchName = txtBranchName.Value;
                objAccounts.AccountNo = txtAccountNo.Value;
                objAccounts.AccountTitle = txtTitle.Value;
                objAccounts.AccountType = accountTypeRadDropDownList1.SelectedItem.Text;
                objAccounts.OpeningDate = (RadDatePicker2.SelectedDate.ToString());
                objAccounts.CompanyId = _company.CompanyId;
                objAccounts.IsActive = chkIsActive.Checked;

                int sucess = 0;
                if (lblId.Text == "" || lblId.Text == "0")
                {
                    
                    objAccounts.BankAccountId=new BankAccounts().GetMaxAccountId()+1;
                    
                    sucess = objAccounts.InsertBankAccounts();

                    if (sucess > 0)
                    {
                        Alert.Show("Bank Accounts info saved successfully");
                        this.Clear();
                    }
                }
                else
                {
                    objAccounts.BankAccountId = int.Parse(lblId.Text);

                    sucess = objAccounts.UpdateBankAccounts();

                    if (sucess > 0)
                    {
                        Response.Redirect("BankAccoutsList.aspx", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
            

        }

        private void Clear()
        {
            lblId.Text = "";
            txtBranchName.Value = "";
            txtAccountNo.Value = "";
            txtTitle.Value = "";
            chkIsActive.Checked = true;

        }

       

        protected void btnClear_Click(object sender, EventArgs e)
        {
           
        }

        protected void bankIdRadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void bankIdRadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void RadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void RadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
        }
    }
}