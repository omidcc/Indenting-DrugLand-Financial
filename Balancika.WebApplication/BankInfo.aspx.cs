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
    public partial class BankInfo : System.Web.UI.Page
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
                    string bankId = Request.QueryString["id"].ToString();

                    Bank bank = new Bank().GetBankByBankId(int.Parse(bankId), _company.CompanyId);
                    if (bank != null || bank.BankId != 0)
                    {
                        lblId.Text = bank.BankId.ToString();
                        txtBankCode.Value = bank.BankCode;
                        txtBankName.Value = bank.BankName;
                        txtContactPerson.Value = bank.ContactPerson;
                        txtDesignation.Value = bank.ContactDesignation;
                        txtContactNo.Value = bank.ContactNo;
                        txtEmail.Value = bank.ContactEmail;
                        chkIsActive.Checked = bank.IsActive;
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

        protected void btnSave_Click(object sender, EventArgs e)
        {

            try
            {


                Bank objBank = new Bank();

                objBank.BankCode = txtBankCode.Value;
                objBank.BankName = txtBankName.Value;
                objBank.ContactPerson = txtContactPerson.Value;
                objBank.ContactDesignation = txtDesignation.Value;
                objBank.ContactNo = txtContactNo.Value;
                objBank.ContactEmail = txtEmail.Value;
                objBank.CompanyId = _company.CompanyId;
                objBank.UpdatedBy = _user.UserId;
                objBank.UpdatedDate = DateTime.Today;
                objBank.IsActive = chkIsActive.Checked;

                int sucess = 0;
                if (lblId.Text == "" || lblId.Text == "0")
                {
                    objBank.BankId = new Bank().GetMaxBankId() + 1;

                    sucess = objBank.InsertBank();

                    if (sucess > 0)
                    {
                        Alert.Show("Bank info saved successfully");
                        this.Clear();
                    }
                }
                else
                {
                    objBank.BankId = int.Parse(lblId.Text);
                    sucess = objBank.UpdateBank();

                    if (sucess > 0)
                    {
                        Response.Redirect("BankLists.aspx", true);
                    }
                }
            }
            catch (Exception ex)
            {
                Alert.Show(ex.Message);
            }
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.Clear();
        }

        private void Clear()
        {
            lblId.Text = "";
            txtBankCode.Value = "";
            txtBankName.Value = "";
            txtContactPerson.Value = "";
            txtDesignation.Value = "";
            txtContactNo.Value = "";
            txtEmail.Value = "";
            

            chkIsActive.Checked = true;
        }

        protected void RadDropDownList1_ItemSelected(object sender, DropDownListEventArgs e)
        {

        }
        protected void RadDropDownList1_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {

        }



    }
}