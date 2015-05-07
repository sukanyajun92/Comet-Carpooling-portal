<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailJourney.aspx.cs" Inherits="View_DetailJourney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">

    .Journey {
            width:50%;
            
            padding : 50px 10px 0px 300px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div id="journey" class="Journey">
        From: <asp:Label ID="LblFromLocation" runat="server" Text=""></asp:Label><br />
        To: <asp:Label ID="LblToLocation" runat="server" Text=""></asp:Label><br />
        From Date: <asp:Label ID="LblFromDate" runat="server" Text=""></asp:Label><br />
        To Date: <asp:Label ID="LblToDate" runat="server" Text=""></asp:Label><br />
        Time: <asp:Label ID="LblTravelTime" runat="server" Text=""></asp:Label><br />
        No. of Available Seats: <asp:Label ID="LblNumSeats" runat="server" Text=""></asp:Label><br />
        Smoking Preference  : <asp:Label ID="LblSmoking_Pref" runat="server" Text=""></asp:Label><br />
        Drinking Preference : <asp:Label ID="LblDrinking_Pref" runat="server" Text=""></asp:Label><br />
        Notes : <asp:Label ID="LblNotes" runat="server" Text=""></asp:Label><br />
    </div>
    <div id="userdetail" class="Journey">
        First Name: <asp:Label ID="LblFName" runat="server" Text=""></asp:Label><br />
        Last Name : <asp:Label ID="LblLName" runat="server" Text=""></asp:Label><br />
        Gender    : <asp:Label ID="LblGender" runat="server" Text=""></asp:Label><br />
        Email ID  : <asp:Label ID="LblEmail" runat="server" Text=""></asp:Label><br />
        
    </div>

    <div id="cardetial" class="Journey">
        Car Model  : <asp:Label ID="LblCarModel" runat="server" Text=""></asp:Label><br />
        Car Number : <asp:Label ID="LblCarNum" runat="server" Text=""></asp:Label><br />
    </div>
        <div id="submission" class="">
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <br />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LnkBtnRequest" runat="server">Request</asp:LinkButton>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="LnkBtnBack" runat="server" OnClientClick="javascript: {window.history.back(-1);return false;}">back to search</asp:LinkButton>
            
        </div>
    </form>
</body>
</html>
