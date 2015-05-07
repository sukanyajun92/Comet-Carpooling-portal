<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchJourney.aspx.cs" Inherits="View_SearchJourney" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <style type="text/css">

        .Map {
        height:500px;
        width: 650px;
        overflow: hidden;
        /*padding : 100px 0px 0px 30px;*/
    }
        .Journey {
            width:40%;
            float:left;
            padding : 100px 0px 0px 30px;
        }

    </style>


    <title>Comet Car Pooling</title>
    <script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAaczGkYJhz_uP1Xo03sWxYnBB7R1NXzZE&sensor=false&libraries=places&language=eng&types=establishment"></script>

<%--<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script> 
<script type="text/javascript" src="http://code.google.com/apis/gears/gears_init.js"></script>--%>


<script language="javascript" type="text/javascript">
  
    // var initialLocation;
    var directionsDisplay;

    var directionsService = new google.maps.DirectionsService();
    function InitializeMap() {
        directionsDisplay = new google.maps.DirectionsRenderer();
        var latlng = new google.maps.LatLng(17.425503, 78.47497);
        var myOptions = {
            zoom: 13,
            center: latlng,
            mapTypeId: google.maps.MapTypeId.ROADMAP
        };
        var map = new google.maps.Map(document.getElementById("divGoogleMap"), myOptions);


        // Geo Location
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(function (position) {
                initialLocation = new google.maps.LatLng(position.coords.latitude, position.coords.longitude);
                map.setCenter(initialLocation);
            });

        } else if (google.gears) {

            var geo = google.gears.factory.create('beta.geolocation');
            geo.getCurrentPosition(function (position) {
                initialLocation = new google.maps.LatLng(position.latitude, position.longitude);
                map.setCenter(initialLocation);
                
            });
        }

        //var marker = new google.maps.Marker({
        //    map: map,
        //    position: initialLocation
        //});
            //  markers.push(new google.maps.Marker({
            //map: map,
            //position: current,
            //title: myloc
        //}));
        

        directionsDisplay.setMap(map);

    }
    function changeColor(row)
    {
       // row.style.color = "#d3d3d3";
        row.style.background = "#d3d3d3";
    }
    function calcRoute(row) {
        
        
        childrow = row.getElementsByTagName("div")[0];
        if (childrow.style.display == "none") {
            childrow.style.display = "block"
        }
        //else
        //    childrow.style.display = "none"
        
       // var row = lnk.parentNode;
        var start = row.getElementsByTagName("span")[0].innerHTML;
        var end = row.getElementsByTagName("span")[1].innerHTML;
        
       // row.style.backgroundColor = "#d3d3d3";

        
        var request = {
            origin: start,
            destination: end,
            travelMode: google.maps.DirectionsTravelMode.DRIVING
        };
        directionsService.route(request, function (response, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(response);
            }
        });

        return false;

    }

    window.onload = InitializeMap;//Load defult map
</script>



</head>
<body>
    <form id="form1" runat="server">


        <div style="float:right">
           <asp:LinkButton ID="LnkBtnUserProfile" runat="server" PostBackUrl="~/View/UserProfile.aspx">View/Edit Profile</asp:LinkButton>
            
       </div>
    <span>Search Filters </span>
    <div id="filter">
        From Date: <asp:TextBox ID="TextFromDate" runat="server" TextMode="Date"/>
        To Date :<asp:TextBox ID="TextToDate" runat="server" TextMode="Date"/>
        <asp:Button ID="BtnSearch" runat="server" Text="Search" OnClick="BtnSearch_Click" />
    </div>

    
    <div class="Journey">
        <span>Search Results</span>  
        <asp:ListView ID="ListViewJourneyResult" runat="server" >
            
            <ItemTemplate>
                <div style="padding-top:10px" onmouseover='javascript: {this.style.background="#d3d3d3"}' onmouseout='javascript: {this.style.background="#ffffff"}' onclick="calcRoute(this)">
                <%--<asp:LinkButton ID="lnkSelect" runat="server" Text="Select" OnClientClick="return calcRoute(this)" />--%>
                From: <asp:Label ID="LblFromLocation" runat="server" Text='<%#Eval("FromLocation")%>'></asp:Label>
                To: <asp:Label ID="LblToLocation" runat="server" Text='<%#Eval("ToLocation")%>'></asp:Label>
                <%--From Date: <asp:Label ID="LblFromDate" runat="server" Text='<%#Eval("FromDate")%>'></asp:Label>
                To Date: <asp:Label ID="LblToDate" runat="server" Text='<%#Eval("ToDate")%>'></asp:Label>
                Time: <asp:Label ID="LblTravelTime" runat="server" Text='<%#Eval("TreavelTime")%>'></asp:Label>--%>
                No. of Available Seats: <asp:Label ID="Label1" runat="server" Text='<%#Eval("AvailableSeats")%>'></asp:Label>
                
                
                <div style="display:none">
                From Date: <asp:Label ID="Label2" runat="server" Text='<%#Eval("FromDate")%>'></asp:Label>
                To Date: <asp:Label ID="Label3" runat="server" Text='<%#Eval("ToDate")%>'></asp:Label>
                Time: <asp:Label ID="Label4" runat="server" Text='<%#Eval("TreavelTime")%>'></asp:Label>
                <asp:LinkButton ID="LinkBtnDetail" runat="server" PostBackUrl='<%#Eval("DetailPageUrl")%>'>Details</asp:LinkButton>
                </div>
                </div>
            </ItemTemplate>
            
            <EmptyDataTemplate>There is no available Journeys</EmptyDataTemplate>
        </asp:ListView>
    </div>
    
     <div class="Map" id="divGoogleMap">
     </div>
      

    </form>
</body>
</html>
