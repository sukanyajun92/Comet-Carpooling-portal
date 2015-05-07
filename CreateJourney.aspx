<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CreateJourney.aspx.cs" Inherits="View_GoogleMap" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
<script type="text/javascript" src="http://maps.googleapis.com/maps/api/js?key=AIzaSyAaczGkYJhz_uP1Xo03sWxYnBB7R1NXzZE&sensor=false&libraries=places&language=eng&types=establishment"></script>

<%--<script type="text/javascript" src="http://maps.google.com/maps/api/js?sensor=false"></script> 
<script type="text/javascript" src="http://code.google.com/apis/gears/gears_init.js"></script>--%>


<script language="javascript" type="text/javascript">
    function SearchAddressByGoogle(ControlName, e) {//this function will use to get search address from google
        var options = {
            // types: ['(cities)'],
            componentRestrictions: { country: "bd" }
        };
        var control = document.getElementById(ControlName);
        var autocomplete = new google.maps.places.Autocomplete(control, options);
    }

   // var initialLocation;
    var directionsDisplay;
    
    var directionsService = new google.maps.DirectionsService();
    function InitializeMap() {
        directionsDisplay = new google.maps.DirectionsRenderer();
        var latlng = new google.maps.LatLng(32.984347, -96.74593);
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

        //
        var input = document.getElementById('txtAddressFrom');
        var secondInput = document.getElementById('txtAddressTo');
        var btn = document.getElementById('btnDirections');



        map.controls[google.maps.ControlPosition.TOP_LEFT].push(input);
        map.controls[google.maps.ControlPosition.TOP_LEFT].push(secondInput);
        map.controls[google.maps.ControlPosition.TOP_LEFT].push(btn);



        var autocomplete1 = new google.maps.places.Autocomplete(input);
        autocomplete1.bindTo('bounds', map);

        var autocomplete2 = new google.maps.places.Autocomplete(secondInput);
        autocomplete2.bindTo('bounds', map);
        //


        directionsDisplay.setMap(map);

    }
    function calcRoute() {//this function will use to get direction
        var start = document.getElementById('txtAddressFrom').value;
        var end = document.getElementById('txtAddressTo').value;
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
        
    }

    function btnDirections_onclick() {
        calcRoute();
    }
    
    window.onload = InitializeMap;//Load defult map
</script>
<style type="text/css">
    .textBox {
        width: 250px;
        overflow: auto;
    }
</style>
</head>
<body>
   
<form id="form1" runat="server">
<div>
  <table id="tblControl">
  <tr>
     <td>
       <table>
         <tr>
         <td>&nbsp;</td>
         <td><asp:TextBox ID="txtAddressFrom" runat="server" CssClass="textBox"></asp:TextBox></td>
         </tr>
         <tr>
            <td>&nbsp;</td>
            <td><asp:TextBox ID="txtAddressTo" runat="server" CssClass="textBox"></asp:TextBox></td>
          </tr>
          <tr>
            <td align="right">
            <input id="btnDirections" type="button" value="GetDirections" class="textbox" onclick="return btnDirections_onclick()" />
            </td>
          </tr>
       </table>
      </td>
     </tr>
      <tr>
     <td rowspan="2">
                    
                   <table id="journey">
                    <tr>
                        <td>
                            <asp:Label ID="LblFromDate" Text="From Date:" runat="server"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="TextFromDate" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblToDate" Text="To Date" runat="server"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="TextToDate" runat="server" TextMode="Date"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LblJourneyTime" Text="Time (HH:MM):" runat="server"></asp:Label>
                        </td>
                        <td>
                        <asp:TextBox ID="TextJourneyTime" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:ListBox ID="ListBoxJourneyTime" runat="server" Rows="1">
                                <asp:ListItem Selected="True">AM</asp:ListItem>
                                <asp:ListItem>PM</asp:ListItem>
                            </asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelPreferences" Text="Preferences:" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelSmoking" Text="Smoking Allowed" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:RadioButtonList ID="RadioBtnListSmoking" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Value="Y">Yes</asp:ListItem>
                                <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="Label1" Text="Drinking Allowed" runat="server"></asp:Label>
                        </td>
                        <td>
                        <asp:RadioButtonList ID="RadioBtnListDrinking" runat="server" RepeatDirection="Horizontal">
                            <asp:ListItem Value="Y">Yes</asp:ListItem>
                            <asp:ListItem Value="N">No</asp:ListItem>
                            </asp:RadioButtonList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="LabelNotes" Text="Notes:" runat="server"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox ID="TextNotes" runat="server" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>

                            <asp:LinkButton ID="LinkBtnCreate" runat="server" OnClick="LinkBtnCreate_Click">Create Journey</asp:LinkButton>
      </td>
                        <td>

                            <asp:LinkButton ID="LinkBtnClear" runat="server">Clear</asp:LinkButton>

                        </td>
                    </tr>
                       <tr>
                           <td>
                               <asp:LinkButton ID="LnkBtnSearch" runat="server" PostBackUrl="~/View/SearchJourney.aspx">Search Journey</asp:LinkButton>
                           </td>
                       </tr>

                    </table>
                    
                </td>  
          </tr>   
     <tr>
      <td valign="top">
       <div id="divGoogleMap" style="height: 600px; width: 800px">
       </div>
      </td>
     </tr>
   </table>
 </div>
</form>
</body>
</html>
 <%--    <div id="map-canvas"></div>
      
      <div id="MapForm" runat="server">
     <form runat="server" id="MapForm1">
      <asp:ScriptManager  ID="ScriptManager1" runat="server"></asp:ScriptManager>
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
      
          <asp:TextBox runat="server" id="pac_input" class="controls" 
        ></asp:TextBox>
    <br/>    
    <asp:TextBox runat="server" id="second" class="controls" 
        ></asp:TextBox>
    <asp:Button class="pac_input" runat="server" Text="Submit" OnClientClick="calcRoute();" ></asp:Button>
         
              </ContentTemplate>
          </asp:UpdatePanel>
           </form>
          </div>
     <%--<input type="submit" value="Submit" onclick="calcRoute();"> 

           //google.maps.event.addListener(autocomplete1, 'place_changed', function () {
            //    infowindow.close();
            //    marker.setVisible(false);
            //    var place = autocomplete1.getPlace();
            //    if (!place.geometry) {
            //        return;
            //    }

            //    if (place.geometry.viewport) {
            //        map.fitBounds(place.geometry.viewport);
            //    }
            //    else {
            //        map.setCenter(place.geometry.location);
            //        map.setZoom(17);  // Why 17? Because it looks good.
            //    }
            //    var address = '';
            //    if (place.address_components) {
            //        address = [
        	//			(place.address_components[0] && place.address_components[0].short_name || ''),
        	//			(place.address_components[1] && place.address_components[1].short_name || ''),
        	//			(place.address_components[2] && place.address_components[2].short_name || '')
            //        ].join(' ');
            //    }

            //    infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
            //    infowindow.open(map, marker);
            //});

            //google.maps.event.addListener(autocomplete2, 'place_changed', function () {
            //    infowindow.close();
            //    marker.setVisible(false);
            //    var place = autocomplete2.getPlace();
            //    if (!place.geometry) {
            //        return;
            //    }

            //    if (place.geometry.viewport) {
            //        map.fitBounds(place.geometry.viewport);
            //    }
            //    else {
            //        map.setCenter(place.geometry.location);
            //        map.setZoom(17);  // Why 17? Because it looks good.
            //    }
            //    var address = '';
            //    if (place.address_components) {
            //        address = [
        	//			(place.address_components[0] && place.address_components[0].short_name || ''),
        	//			(place.address_components[1] && place.address_components[1].short_name || ''),
        	//			(place.address_components[2] && place.address_components[2].short_name || '')
            //        ].join(' ');
            //    }

            //    infowindow.setContent('<div><strong>' + place.name + '</strong><br>' + address);
            //    infowindow.open(map, marker);
            //});
        }

        //function calcRoute() {

            
        //    var start = document.getElementById('pac_input').value;
        //    var end = document.getElementById('second').value;
        //    alert(start);
        //    alert(end);

        //    var request =
        //    {
        //        origin: start,
        //        destination: end,
        //        travelMode: google.maps.TravelMode.DRIVING
        //    };
        //    directionsService.route(request, function (response, status) {
        //        alert(status);

        //        if (status == google.maps.DirectionsStatus.OK) {
        //            directionsDisplay.setDirections(response);
        //            var route = response.routes[0];
        //            alert(route);
        //          //  var summaryPanel = document.getElementById('directions_panel');
        //           // summaryPanel.innerHTML = '';
        //            // For each route, display summary information.
        //            for (var i = 0; i < route.legs.length; i++) {
        //                var routeSegment = i + 1;
        //                summaryPanel.innerHTML += '<b>Route Segment: ' + routeSegment + '</b><br>';
        //                summaryPanel.innerHTML += route.legs[i].start_address + ' to ';
        //                summaryPanel.innerHTML += route.legs[i].end_address + '<br>';
        //                summaryPanel.innerHTML += route.legs[i].distance.text + '<br><br>';
        //            }
        //        }
        //    });
            
        //}
--%>
<%--
       #pac_input {
        background-color: #fff;
        padding: 0 11px 0 13px;
        width: 400px;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        text-overflow: ellipsis;
      }
     .pac-container {
        font-family: Roboto;
      }
      #pac_input:focus {
        border-color: #4d90fe;
        margin-left: -1px;
        padding-left: 14px;  /* Regular padding-left + 1. */
        width: 401px;
      }

       #second {
        background-color: #fff;
        padding: 0 11px 0 13px;
        width: 400px;
        font-family: Roboto;
        font-size: 15px;
        font-weight: 300;
        text-overflow: ellipsis;
      }--%>