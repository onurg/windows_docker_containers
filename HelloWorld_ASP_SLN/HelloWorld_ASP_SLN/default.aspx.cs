using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HelloWorld_ASP_SLN
{
    public partial class _default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HelloWorldLabel.Text = "Hello World ! I run on ASP.NET 4.7.2";
        }
    }
}