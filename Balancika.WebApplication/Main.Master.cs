using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Balancika.BLL;

namespace Balancika
{
    public partial class Main : System.Web.UI.MasterPage
    {
        public Company company;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["Menu"] != null)
                {
                    string menu = Session["Menu"].ToString();
                    ltrlMenu.Text = menu;
                }

                if (Session["company"] != null)
                {
                    company = (Company) Session["company"];
                    ltrlCompany.Text = company.CompanyName;
                }
            }
        }
    }

}