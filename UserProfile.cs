using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for UserProfileEntity
/// </summary>
public class UserProfileEntity
{
    int userID;

    public int UserID
    {
        get { return userID; }
        set { userID = value; }
    }

    string emailID;

    public string EmailID
    {
        get { return emailID; }
        set { emailID = value; }
    }

    string fName;

    public string FName
    {
        get { return fName; }
        set { fName = value; }
    }
    string lName;

    public string LName
    {
        get { return lName; }
        set { lName = value; }
    }
    string gender;

    public string Gender
    {
        get { return gender; }
        set { gender = value; }
    }

    string address;

    public string Address
    {
        get { return address; }
        set { address = value; }
    }

    string city;

    public string City
    {
        get { return city; }
        set { city = value; }
    }

    string state;

    public string State
    {
        get { return state; }
        set { state = value; }
    }
    string country;

    public string Country
    {
        get { return country; }
        set { country = value; }
    }

    bool isOwner;

    public bool IsOwner
    {
        get { return isOwner; }
        set { isOwner = value; }
    }

	public UserProfileEntity()
	{
		
	}
}
