using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class View_SearchJourney : System.Web.UI.Page
{
    DataAccessClass dc = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchJourneys();
    }

    protected void SearchJourneys()
    {
        try
        {
            dc = new DataAccessClass();

            List<JourneyEntity> Journeys = dc.SearchJourneys();

            ListViewJourneyResult.DataSource = Journeys;
            ListViewJourneyResult.DataBind();

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    //protected void ListViewjourneyResult_SelectedIndexChanged(object sender, EventArgs e)
    //{
        
    //    //foreach (var item in )
    //    //{
            
    //    //}
    //}
    protected void BtnSearch_Click(object sender, EventArgs e)
    {
            dc = new DataAccessClass();

            DateTime FromDate = Convert.ToDateTime(TextFromDate.Text).Date;
            DateTime ToDate = Convert.ToDateTime(TextToDate.Text).Date;

            List<JourneyEntity> Journeys = dc.SearchJourneys(FromDate,ToDate);

            ListViewJourneyResult.DataSource = Journeys;
            ListViewJourneyResult.DataBind();
    }
}