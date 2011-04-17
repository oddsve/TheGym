using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace TheGym
{
	public static class TTTBookings
	{
		
		public static List<GymClass> getMyBookings()
		{
			
			List<GymClass> myBookings = new List<GymClass>();

			HtmlDocument document = new HtmlDocument();
			HtmlNode.ElementsFlags.Remove( "option" );
			document.LoadHtml( TTTHttp.getHTTP( "http://brp.netono.se/3t/mesh/showBookings.action" ) );
		
			
			HtmlDocument rowDocument= new HtmlDocument();
									
			HtmlNodeCollection tables = document.DocumentNode.SelectNodes( "//table[@class='bookingsList groupActivityBookings']" ) ;
			foreach ( HtmlNode table in tables )
			{
				if ( table.GetAttributeValue("class","") == "bookingsList groupActivityBookings" )
				{
					string date = "";
					string time = "";
					string title = "";
					HtmlNodeCollection rows = table.SelectNodes( "//tr" );
					
					foreach  (HtmlNode row in rows )
					{
						
						HtmlNodeCollection cells;
						HtmlNode cell;
						HtmlNode link;
											
												    
							
						if ( row.GetAttributeValue( "class","" ).ToString() == "normalRow"  || 
						     row.GetAttributeValue( "class","" ).ToString() == "alternateRow" ) 
						{
							rowDocument.LoadHtml(  row.OuterHtml  );
							cells = rowDocument.DocumentNode.SelectNodes( "//td" );
							
							
							cell = cells[0];
							time = cell.InnerText.Trim();

							cell = cells[1];
							title = cell.InnerText.Trim();
			
							GymClass gymClass = new GymClass( title, date, time );
							
							cell = cells[2];
							gymClass.gym = cell.InnerText.Trim();
							
							cell = cells[3];
							gymClass.instructor = cell.InnerText.Trim();
														
							cell = cells[4];
							link = cell.SelectNodes( "//a" )[0];
							gymClass.action = link.GetAttributeValue( "href" , "" );
							
							gymClass.status = "Booket";
							
							
							myBookings.Add( gymClass );				
						}
					}
				}				 
			}		
			
			return myBookings;
		}	

	}
}

