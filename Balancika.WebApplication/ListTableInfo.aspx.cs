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
    public partial class ListTableInfo : System.Web.UI.Page
    {
        private bool isNewEntry;
        private Users _user;
        private Company _company = new Company();
        protected void Page_Load(object sender, EventArgs e)
        {
            _company = (Company)Session["Company"];
              _user =(Users) Session["user"];
              if (Session["savedListMessage"] !=null)
              {
                  string msg = Session["savedListMessage"].ToString();
                  Alert.Show(msg);
                  Session["savedListMessage"] = null;
              }
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
                      string listId = Request.QueryString["id"].ToString();

                      ListTable objTable = new ListTable().GetListTableById(int.Parse(listId), _company.CompanyId);
                      if (objTable != null || objTable.Id != 0)
                      {
                          lblId.Text = objTable.Id.ToString();
                          txtListType.Value = objTable.ListType;
                          txtListValue.Value = objTable.ListValue;
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


                ListTable myListTable = new ListTable();
                List<ListTable> aList = myListTable.GetAllListTable(_company.CompanyId);
                
                    ListTable tempListTable = aList[aList.Count - 1];
                   int id = tempListTable.Id + 1;
               
               


                myListTable.ListType = txtListType.Value;
                myListTable.ListId = id ;
                
                myListTable.ListValue = txtListValue.Value;
                myListTable.CompanyId = _company.CompanyId;

                myListTable.IsActive = true;
                myListTable.UpdateBy = _user.UserId;
                myListTable.UpdateDate = DateTime.Now;

                int sucess = 0;
                if (lblId.Text == "" || lblId.Text == "0")
                {
                    myListTable.Id = new ListTable().GetMaxListTableId() + 1;

                    sucess = myListTable.InsertListTable();

                    if (sucess > 0)
                    {
                        Alert.Show("List Table saved successfully");
                        this.Clear();
                    }
                }
                else
                {
                    myListTable.Id = int.Parse(lblId.Text);
                    sucess = myListTable.UpdateListTable();

                    if (sucess > 0)
                    {
                        Response.Redirect("ListTableLists.aspx", true);
                    }
                }
            }
            catch (Exception exp)
            {
                Alert.Show(exp.Message);
            }



        }


        private void Clear()
        {
            lblId.Text = "";
            txtListType.Value = "";
            txtListValue.Value = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            
        }

        protected void listIdDropDownList_ItemSelected(object sender, DropDownListEventArgs e)
        {
           
        }

        protected void listIdDropDownList_SelectedIndexChanged(object sender, DropDownListEventArgs e)
        {
           
        }
    }
}