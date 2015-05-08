using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for JourneyEntity
/// </summary>
public class JourneyEntity
{
    //[journeyid]      INT           IDENTITY (1, 1) NOT NULL,
    //[uid]            INT           NOT NULL,
    //[fromdate]       DATE          NOT NULL,
    //[todate]         DATE          NOT NULL,
    //[fromlocation]   VARCHAR (100) NULL,
    //[tolocation]     VARCHAR (100) NULL,
    //[traveltime]     VARCHAR (10)  NULL,
    //[availableseats] INT           NULL,
    //[smoking_pref]   BIT           NULL,
    //[drinking_pref]  BIT           NULL,
    //[notes]          VARCHAR (200) NULL,

    int journeyID;

    public int JourneyID
    {
        get { return journeyID; }
        set { journeyID = value; }
    }

    int uid;

    public int Uid
    {
        get { return uid; }
        set { uid = value; }
    }
    DateTime fromDate;

    public DateTime FromDate
    {
        get { return fromDate; }
        set { fromDate = value; }
    }
    DateTime toDate;

    public DateTime ToDate
    {
        get { return toDate; }
        set { toDate = value; }
    }
    string fromLocation;

    public string FromLocation
    {
        get { return fromLocation; }
        set { fromLocation = value; }
    }

    string toLocation;

    public string ToLocation
    {
        get { return toLocation; }
        set { toLocation = value; }
    }

    string treavelTime;

    public string TreavelTime
    {
        get { return treavelTime; }
        set { treavelTime = value; }
    }
    int availableSeats;

    public int AvailableSeats
    {
        get { return availableSeats; }
        set { availableSeats = value; }
    }

    bool smokingPref;

    public bool SmokingPref
    {
        get { return smokingPref; }
        set { smokingPref = value; }
    }

    bool drinkingPref;

    public bool DrinkingPref
    {
        get { return drinkingPref; }
        set { drinkingPref = value; }
    }

    string notes;

    public string Notes
    {
        get { return notes; }
        set { notes = value; }
    }
    string detailPageUrl;

    public string DetailPageUrl
    {
        get { return detailPageUrl; }
        set { detailPageUrl = value; }
    }
    CarDetailEntity car;

    public CarDetailEntity Car
    {
        get { return car; }
        set { car = value; }
    }
    UserProfileEntity driver;

    public UserProfileEntity Driver
    {
        get { return driver; }
        set { driver = value; }
    }

    public JourneyEntity()
	{
        Car = new CarDetailEntity();
        Driver = new UserProfileEntity();
	}

}
