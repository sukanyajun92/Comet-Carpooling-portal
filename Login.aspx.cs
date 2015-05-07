using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page

{
    DataAccessClass dc = null;
    protected void Page_Load(object sender, EventArgs e)
    {
         
    }
    protected void LnkBtnLogin_Click(object sender, EventArgs e)
    {
        

        string Pwd = string.Empty, EmailId = string.Empty;
        int UserID ;
        try
        {
            dc = new DataAccessClass(); 

            EmailId = TextUserID.Text;
            Pwd = TextPwd.Text;
            UserID = dc.LoginValidation(EmailId, Pwd);
            if (UserID != 0)
            {
                Session["UserID"] = Convert.ToString(UserID);
                Response.Redirect("/View/SearchJourney.aspx");
            }
            else
            {
                Response.Write("Error");
            }

        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }
}