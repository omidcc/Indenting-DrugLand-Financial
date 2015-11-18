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
    public partial class JournalInformationDetail : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users user;
        private Company _company=new Company();
        protected void Page_Load(object sender, EventArgs e)    
        {
            _company = (Company)Session["Company"];
            if (!IsPostBack)
            {
                user = (Users) Session["user"];
                this.LoadJournalDropDownList();
                this.LoadCostCenterDropDownList();
                this.LoadJournalAccountNo();
            }
        }

        private void LoadJournalDetailsDataTable()
        {
            try
            {
                JournalDetails aJournal=new JournalDetails();
                string htmlContent = "";
                List<JournalDetails> aJournalList = aJournal.GetAllJournalDetails(_company.CompanyId);

                journalDetailsTableBody.InnerHtml = "";
                foreach (JournalDetails Journal in aJournalList)
                {
                    htmlContent += String.Format(@"<tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th></tr>",Journal.MasterId,Journal.AccountNo,Journal.Debit,Journal.Credit,Journal.Description,Journal.VoucherNo );

                }
                journalDetailsTableBody.InnerHtml += htmlContent;

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }

        

        private void LoadJournalAccountNo()
        {
            BankAccounts anAccount=new BankAccounts();
            List<BankAccounts> accountList = anAccount.GetAllBankAccounts(_company.CompanyId);
            accountNoDropDownList.DataSource = accountList;
            accountNoDropDownList.DataTextField = "AccountNo";
            accountNoDropDownList.DataValueField = "AccountNo";
            accountNoDropDownList.DataBind();


        }

        private void LoadJournalDropDownList()
        {
            try
            {
                ListTable aNewListTable = new ListTable();
                List<ListTable> myList = aNewListTable.GetAllListTable(_company.CompanyId);
                journalTypeDropDownList.DataSource = myList;
                journalTypeDropDownList.DataTextField = "ListType";
                journalTypeDropDownList.DataValueField = "ListType";
                journalTypeDropDownList.DataBind();

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }
        private void LoadCostCenterDropDownList()
        {
            try
            {
                CostCenter aCost = new CostCenter();
                List<CostCenter> costCenterList = aCost.GetAllCostCenter(_company.CompanyId);
                costCenterDropDownList.DataSource = costCenterList;
                costCenterDropDownList.DataTextField = "CostCenterName";
                costCenterDropDownList.DataValueField = "CostCenterId";
                costCenterDropDownList.DataBind();

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }

        protected void journalTypeDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
            
        }

        protected void btnJournalMasterClear_Click(object sender, EventArgs e)
        {
            txtJournalDescription.Value = "";
            
        }

        protected void btnJournalMasterInformationSave_Click(object sender, EventArgs e)
        {
            try
            {
                JournalMaster aJournal=new JournalMaster();
                aJournal.JournalDate = RadDatePicker1.SelectedDate.ToString();
                aJournal.JournalDescription = txtJournalDescription.Value;
                aJournal.JournalType = journalTypeDropDownList.SelectedItem.Value;
                aJournal.CostCenterId = int.Parse(costCenterDropDownList.SelectedItem.Value);
                aJournal.UpdateBy = user.UserId;
                aJournal.UpdateDate = DateTime.Now.Date;
                aJournal.CompanyId = _company.CompanyId;
                int success = aJournal.InsertJournalMaster();
                Alert.Show(success>0?"Saved Journal Master Information Successfully":"Error occured while saving journal information");

            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
           
        }

        protected void btnSaveJournalDetails_Click(object sender, EventArgs e)
        {
            try
            {
                JournalDetails aJournal=new JournalDetails();
                List<JournalDetails> journalList = aJournal.GetAllJournalDetails(_company.CompanyId);
                JournalDetails lastJournal = journalList[journalList.Count - 1];
                long id = lastJournal.MasterId + 1;
                aJournal.MasterId = id;
                aJournal.AccountNo = int.Parse(accountNoDropDownList.SelectedItem.Value);
                aJournal.Debit = Convert.ToDecimal(txtJournalDetailsDebit.Value);
                aJournal.Credit = Convert.ToDecimal(txtJournalDetailsCredit.Value);
                aJournal.Description = txtJorunalDetailsDescription.Value;
                aJournal.VoucherNo = "JV-" + Convert.ToString(lastJournal.JournalDetailsId + 1)+"-" + DateTime.Now.Year.ToString();
                int success = aJournal.InsertJournalDetails();
                Alert.Show(success>0?"Saved Journal Details Information Successfully":"Error occured while saving journal information");


            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }
        }

        protected void btnJournalDetailsInformationClear_Click(object sender, EventArgs e)
        {
            txtJournalDetailsCredit.Value = "";
            txtJournalDetailsDebit.Value = "";
            txtJorunalDetailsDescription.Value = "";
        }
    }
}