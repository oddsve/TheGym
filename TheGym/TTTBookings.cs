using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.Text.RegularExpressions;

namespace TheGym
{
	public static class TTTBookings
	{
		
		public static List<GymClass> getMyBookings()
		{
			
			List<GymClass> myBookings = new List<GymClass>();

			HtmlDocument document = new HtmlDocument();
			HtmlNode.ElementsFlags.Remove( "option" );
			string html = TTTHttp.getHTTP("http://brp.netono.se/3t/mesh/showBookings.action"  );
			
			document.LoadHtml( html  );
			
			
			
			HtmlDocument rowDocument= new HtmlDocument();
									
			HtmlNodeCollection tables = document.DocumentNode.SelectNodes( "//table[@class='bookingsList groupActivityBookings']" ) ;
			if ( tables != null ) 
			{
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
								if ( cell.InnerText.Trim() == "Avbooke" )
								{
									link = cell.SelectNodes( "//a" )[0];
									string href = link.GetAttributeValue( "href" , "" );
								
									string pattern = "bookingId=(.*?)'";
									// Instantiate the regular expression object.
									Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
									
									// Match the regular expression pattern against a text string.
									Match m = r.Match(href);
									while (m.Success) 
									{
										gymClass.unbookAction = "debook.action?bookingId=" + m.Groups[1].ToString() ;
									 	m = m.NextMatch();										
									}
								}		
								gymClass.status = "Booket";								
								myBookings.Add( gymClass );				
							}
						}
					}
				}				 
			}		
			
			return myBookings;
		}	

	}
}

