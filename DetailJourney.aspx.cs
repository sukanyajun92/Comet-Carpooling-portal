using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_DetailJourney : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Request.QueryString["jid"] != null)
            {
                DisplayJourneyDetail(Convert.ToInt32(Request.QueryString["jid"].ToString()));
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }

    protected void DisplayJourneyDetail(int jid)
    {
        try
        {
            DataAccessClass dc = new DataAccessClass();
            JourneyEntity Je= dc.GetJourneyDetail(jid);
            
            LblFromLocation.Text = Je.FromLocation;
            LblToLocation.Text = Je.ToLocation;
            LblFromDate.Text =Convert.ToString(Convert.ToDateTime(Je.FromDate).Date);
            LblToDate.Text = Convert.ToString(Convert.ToDateTime(Je.ToDate).Date);
            LblTravelTime.Text = Je.TreavelTime;
            LblNumSeats.Text =Convert.ToString(Je.AvailableSeats);
            LblSmoking_Pref.Text = Je.SmokingPref==true?"Yes": "No";
            LblDrinking_Pref.Text = Je.DrinkingPref==true?"Yes": "No";
            LblNotes.Text=Je.Notes;

            LblFName.Text=Je.Driver.FName;
            LblLName.Text=Je.Driver.LName;
            LblGender.Text=Je.Driver.Gender;
            LblEmail.Text=Je.Driver.EmailID;

            LblCarModel.Text=Je.Car.CarModel;
            LblCarNum.Text=Je.Car.CarNumber;
    //<div id="userdetail">
    //    First Name: <asp:Label ID="LblFName" runat="server" Text=""></asp:Label>
    //    Last Name : <asp:Label ID="LblLName" runat="server" Text=""></asp:Label>
    //    Gender    : <asp:Label ID="LblGender" runat="server" Text=""></asp:Label>
    //    Email ID  : <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label>
        
    //</div>
    //<div id="cardetial">
    //    Car Model  : <asp:Label ID="Label2" runat="server" Text=""></asp:Label>
    //    Car Number : <asp:Label ID="Label3" runat="server" Text=""></asp:Label>


        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }
    }


}