using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Balancika
{
    public partial class Temp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RadGrid1_NeedDataSource1(object source, Telerik.Web.UI.GridNeedDataSourceEventArgs e)
        {
            ArrayList list = new ArrayList();
            list.Add(new MyObj("1"));
            list.Add(new MyObj("2"));
            list.Add(new MyObj("3"));
            list.Add(new MyObj("4"));
            list.Add(new MyObj("1"));
            RadGrid1.DataSource = list;
        }

        public class MyTech
        {
            public string Name { get; set; }
        }

        public class MyObj:MyTech
        {
            public string _innerText = "";
            public MyObj()
            {
            }

           
            public MyObj(string text)
            {
                _innerText = text;
                this.Name = text+"----" + text;
            }
            public MyObj Inner1
            {
                get
                {
                    return new MyObj(this._innerText + "Inner1");
                }
            }
            public MyObj Inner2
            {
                get
                {
                    return new MyObj(this._innerText + "Inner2");
                }
            }
            public string TestProp
            {
                get
                {
                    return this._innerText;
                }
            }
        }
    }
}