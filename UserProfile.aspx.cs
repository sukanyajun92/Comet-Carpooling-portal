using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_UserProfile : System.Web.UI.Page
{
    DataAccessClass dc = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
                dc = new DataAccessClass();
                UserProfileEntity UP = new UserProfileEntity();
                if (!String.IsNullOrEmpty(Session["UserID"].ToString()))
                {
                    int UserID = Convert.ToInt32(Session["UserID"].ToString());
                    UP = dc.GetuserProfile(UserID);

                    TextEmailID.Text = UP.EmailID;
                    TextFName.Text = UP.FName;
                    TextLName.Text = UP.LName;
                    if (UP.Gender == "M")
                    {
                        RadioBtnListGender.Items[0].Selected = true;
                        RadioBtnListGender.Items[1].Selected = false;
                    }
                    else
                    {
                        RadioBtnListGender.Items[1].Selected = true;
                        RadioBtnListGender.Items[0].Selected = false;
                    }


                    TextAddress.Text = UP.Address;
                    TextCity.Text = UP.City;
                    TextState.Text = UP.State;
                    TextCountry.Text = UP.Country;

                    if (UP.IsOwner)
                    {
                        RadioBtnListIsOwnCar.Items[0].Selected = true;

                        // DivCarDetail.Style.Add("display", "block");

                        CarDetailEntity CD = dc.GetCarDetail(UserID);

                        TextCarNumber.Text = CD.CarNumber;
                        TextCarModel.Text = CD.CarModel;
                        TextSeatCapacity.Text = Convert.ToString(CD.NumOfSeats);

                        RadioBtnListIsOwnCar.Items[1].Selected = false;
                    }
                    else
                    {
                        RadioBtnListIsOwnCar.Items[1].Selected = true;

                        // DivCarDetail.Style.Add("display","none");

                        RadioBtnListIsOwnCar.Items[0].Selected = false;
                    }
                }
            }



        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
        }

    }
    protected void LnkbtnSave_Click(object sender, EventArgs e)
    {
        try
        {
            int UserID = Convert.ToInt32(Session["UserID"].ToString());
            dc = new DataAccessClass();

            string EmailID = string.Empty, FName = string.Empty, LName = string.Empty,
                Gender = string.Empty, Address = string.Empty, City = string.Empty,
                State = string.Empty, Country = string.Empty,
                CarNum = string.Empty, CarModel = string.Empty;
            bool IsOwner = false;
            int? No_of_Seats;
            EmailID = TextEmailID.Text;
            FName = TextFName.Text;
            LName = TextLName.Text;
            Gender = RadioBtnListGender.SelectedItem.Value;
            Address = TextAddress.Text;
            City = TextCity.Text;
            State = TextState.Text;
            Country = TextCountry.Text;
            IsOwner = RadioBtnListIsOwnCar.SelectedItem.Value == "N" ? false : true;

            if (dc.UpdateUserProfile(EmailID, FName, LName, Gender, Address, City, State, Country, IsOwner))
            {
                if (IsOwner)
                {
                    CarNum = TextCarNumber.Text;
                    CarModel = TextCarModel.Text;
                    No_of_Seats = Convert.ToInt32(TextSeatCapacity.Text);
                    if (dc.InsertOrUpdateCarDetails(UserID, CarNum, CarModel, No_of_Seats))
                        Response.Write("Saved Successfully...");
                }
                else
                {
                    //CarNum = TextCarNumber.Text;
                    //CarModel = null;
                    //No_of_Seats = null;
                    TextCarNumber.Text = "";
                    TextCarModel.Text = "";
                    TextSeatCapacity.Text = "";


                    if (dc.DeleteCarDetail(UserID))
                        Response.Write("Saved Successfully...");
                }

            }
        }
        catch (Exception ex)
        {

            Response.Write("Error occured while updating...!!!" + ex.Message);
        }

    }

}