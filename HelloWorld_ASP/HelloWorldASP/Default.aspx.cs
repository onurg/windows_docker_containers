using System;
using System.Web;
using System.Web.UI;

namespace HelloWorldASP
{

    public partial class Default : System.Web.UI.Page
    {
        public void Page_Load(object sender, EventArgs args)
        {
            HelloWorldLabel.Text = "Hello, world!";
        }
    }
}
