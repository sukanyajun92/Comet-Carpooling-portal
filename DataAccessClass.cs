using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

public class DataAccessClass
{

    SqlConnection Connection = null;
    public DataAccessClass()
    {
        try
        {
            string ConnectionString = ConfigurationManager.ConnectionStrings["CarPoolDatabaseConnectionString"].ToString();
            Connection = new SqlConnection(ConnectionString);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    public int LoginValidation(string EmailId, string Pwd)
    {
        int UID = 0;
        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                var ResultSet = CPData.LoginValidation(EmailId, Pwd);
                foreach (var item in ResultSet)
                {
                    UID = Convert.ToInt32(item.uid);
                }
            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return UID;
    }

    public bool UpdateUserProfile(string EmailID, string FName, string LName, string Gender, string Address, string City, string State, string Country, bool IsOwner)
    {
        
        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                 CPData.UpdateUserProfile(EmailID, FName, LName, Gender, Address, City,State,Country,IsOwner);
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }

    public bool InsertOrUpdateCarDetails(int UserID,string CarNum,string CarModel,int? NumOfSeats)
    {

        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                CPData.InsertOrUpdateCarDetails(UserID,CarNum,CarModel,NumOfSeats);
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }


    public UserProfileEntity GetuserProfile(int UserID)
    {
        UserProfileEntity UP = new UserProfileEntity();
        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                var ResultSet=CPData.GetUserProfile(UserID);
                foreach (var item in ResultSet)
                {
                    UP.EmailID = item.emailid;
                    UP.FName = item.fname;
                    UP.LName = item.lname;
                    UP.Gender = item.gender;
                    UP.Address = item.address;
                    UP.City = item.city;
                    UP.State = item.state;
                    UP.Country = item.country;
                    UP.IsOwner = Convert.ToBoolean(item.isowner);
                }

            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return UP;
    }


    public CarDetailEntity GetCarDetail(int UserID)
    {
        CarDetailEntity CD = new CarDetailEntity();
        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                var ResultSet = CPData.GetCarDetails(UserID);
                foreach (var item in ResultSet)
                {
                    CD.UserID = item.uid;
                    CD.CarNumber = item.carnumber;
                    CD.CarModel = item.carmodel;
                    CD.NumOfSeats = Convert.ToInt32(item.no_of_seats);
                }

            }
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return CD;
    }

    public bool CreateJourneyDetails(int UserID, DateTime FromDate, DateTime ToDate, string FromLocation, string ToLocation, string TravelTime, int Seats, bool Smoking_Pref, bool Drinking_Pref,string Notes)
    {

        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                CPData.CreateJourneyDetails(UserID, FromDate, ToDate, FromLocation, ToLocation, TravelTime, Seats, Smoking_Pref, Drinking_Pref, Notes);
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }
    public bool DeleteCarDetail(int UserID)
    {

        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                CPData.DeleteCarDetail(UserID);
            }
        }
        catch (Exception ex)
        {
            return false;
        }
        return true;
    }




    public List<JourneyEntity> SearchJourneys()
    {
        List<JourneyEntity> Journeys=new List<JourneyEntity>();
        try
        {
            using(CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                var ResulSet = CPData.SearchTopJourneys();

                foreach (var item in ResulSet)
                {
                    JourneyEntity JE = new JourneyEntity();
                    JE.JourneyID = item.journeyid;
                    JE.Uid = item.uid;
                    JE.FromDate = item.fromdate;
                    JE.ToDate = item.todate;
                    JE.FromLocation = item.fromlocation;
                    JE.ToLocation = item.tolocation;
                    JE.TreavelTime = item.traveltime;
                    JE.SmokingPref = Convert.ToBoolean(item.smoking_pref);
                    JE.SmokingPref = Convert.ToBoolean(item.drinking_pref);
                    JE.AvailableSeats = Convert.ToInt32(item.availableseats);
                    JE.Notes = item.notes;
                    JE.DetailPageUrl = "/View/DetailJourney.aspx?jid=" + JE.JourneyID.ToString();
                    Journeys.Add(JE);
                }

            }
            
        }
        catch (Exception ex)
        {
            throw new Exception (ex.Message);
        }
        return Journeys;
    }

    public JourneyEntity GetJourneyDetail(int jid)
    {
        JourneyEntity JE = new JourneyEntity();
        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                var JourneyResult = CPData.GetJourneyDetail(jid);
                foreach (var item in JourneyResult)
                {
                    JE.JourneyID = item.journeyid;
                    JE.Uid = item.uid;
                    JE.FromDate = item.fromdate;
                    JE.ToDate = item.todate;
                    JE.FromLocation = item.fromlocation;
                    JE.ToLocation = item.tolocation;
                    JE.TreavelTime = item.traveltime;
                    JE.SmokingPref = Convert.ToBoolean(item.smoking_pref);
                    JE.SmokingPref = Convert.ToBoolean(item.drinking_pref);
                    JE.AvailableSeats = Convert.ToInt32(item.availableseats);
                    JE.Notes = item.notes;
                    
                }

            }

            JE.Car = GetCarDetail(JE.Uid);
            JE.Driver = GetuserProfile(JE.Uid);

        }catch(Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return JE;
    }

    public List<JourneyEntity> SearchJourneys(DateTime FromDate, DateTime ToDate)
    {
        List<JourneyEntity> Journeys = new List<JourneyEntity>();
        try
        {
            using (CarPoolDBLayoutDataContext CPData = new CarPoolDBLayoutDataContext())
            {
                var ResulSet = CPData.SearchJourney(FromDate,ToDate);

                foreach (var item in ResulSet)
                {
                    JourneyEntity JE = new JourneyEntity();
                    JE.JourneyID = item.journeyid;
                    JE.Uid = item.uid;
                    JE.FromDate = item.fromdate;
                    JE.ToDate = item.todate;
                    JE.FromLocation = item.fromlocation;
                    JE.ToLocation = item.tolocation;
                    JE.TreavelTime = item.traveltime;
                    JE.SmokingPref = Convert.ToBoolean(item.smoking_pref);
                    JE.SmokingPref = Convert.ToBoolean(item.drinking_pref);
                    JE.AvailableSeats = Convert.ToInt32(item.availableseats);
                    JE.Notes = item.notes;
                    JE.DetailPageUrl = "/View/DetailJourney.aspx?jid=" + JE.JourneyID.ToString();
                    Journeys.Add(JE);
                }

            }

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
        return Journeys;
    }
}
