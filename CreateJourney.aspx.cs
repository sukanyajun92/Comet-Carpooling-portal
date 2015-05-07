using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_GoogleMap : System.Web.UI.Page
{
    DataAccessClass dc = null;
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void LinkBtnCreate_Click(object sender, EventArgs e)
    {
        try
        {
            dc = new DataAccessClass();
            int UserID = Convert.ToInt32(Session["UserID"].ToString());
            int Seats = 0; //Need to handle later
            string FromLocation = txtAddressFrom.Text;
            string ToLocation = txtAddressTo.Text;
            string TravelTime = TextJourneyTime.Text;
            string Notes = TextNotes.Text;

            bool Smoking_Pref = RadioBtnListSmoking.SelectedItem.Value == "Y" ? true : false;
            bool Drinking_Pref = RadioBtnListDrinking.SelectedItem.Value == "Y" ? true : false;

            DateTime FromDate = Convert.ToDateTime(TextFromDate.Text);
            DateTime ToDate = Convert.ToDateTime(TextToDate.Text);

            if (dc.CreateJourneyDetails(UserID, FromDate, ToDate, FromLocation, ToLocation, TravelTime, Seats, Smoking_Pref, Drinking_Pref, Notes))
            {
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

    protected void SearchAddress(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            txtAddressFrom.Attributes.Add("onkeyUp", "SearchAddressByGoogle('" + txtAddressFrom.ClientID + "',event);");
            txtAddressTo.Attributes.Add("onkeyUp", "SearchAddressByGoogle('" + txtAddressTo.ClientID + "',event);");
        }
    }
}