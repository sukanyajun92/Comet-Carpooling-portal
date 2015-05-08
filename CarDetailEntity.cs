using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CarDetailEntity
/// </summary>
public class CarDetailEntity
{

    int userID;

    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    string carNumber;

    public string CarNumber
    {
        get { return carNumber; }
        set { carNumber = value; }
    }

    string carModel;

    public string CarModel
    {
        get { return carModel; }
        set { carModel = value; }
    }
    int numOfSeats;

    public int NumOfSeats
    {
        get { return numOfSeats; }
        set { numOfSeats = value; }
    }


	public CarDetailEntity()
	{
		
	}
}
