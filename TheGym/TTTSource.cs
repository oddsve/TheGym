using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace TheGym
{
	public static class TTTSource 
	{
		private static  List<GymClass> schedules;
		
		public static List<GymClass> getSchedules()
		{
			if ( schedules == null ) 
			{
				populateSchedules();
			}
			
			if ( GymState.PerViewType == GymState.PER_CLASS )
			{
				schedules.Sort();
			}
			
			return schedules;
			
		}

						                                        
				                                        
				                                        
				                        
		
		
		private static void populateSchedules()
		{
			
			schedules = new List<GymClass>();

			HtmlDocument document = TTTHttp.GroupActivities();
			
			HtmlDocument rowDocument= new HtmlDocument();
									
			HtmlNodeCollection tables = document.DocumentNode.SelectNodes( "//table[@class='schedule']" ) ;
			foreach ( HtmlNode table in tables )
			{
				if ( table.GetAttributeValue("class","") == "schedule" )
				{
					string date = "";
					HtmlNodeCollection rows = table.SelectNodes( "//tr" );
					
					foreach  (HtmlNode row in rows )
					{
						
						HtmlNodeCollection cells;
						HtmlNode cell;
						HtmlNode link;
											
						
						if ( row.GetAttributeValue( "class","" ).ToString().Trim() == "date" )
						{
							rowDocument.LoadHtml(  row.OuterHtml  );
							cells = document.DocumentNode.SelectNodes( "//td" );
							cell  = cells[0];
							date = cell.InnerText.Trim();
						}
						    
							
						if ( row.GetAttributeValue( "class","" ).ToString() == "row"  || 
						     row.GetAttributeValue( "class","" ).ToString() == "row alternateRow" ) 
						{
							GymClass gymClass = new GymClass();
							rowDocument.LoadHtml(  row.OuterHtml  );
							cells = rowDocument.DocumentNode.SelectNodes( "//td" );
							
							gymClass.date = date;
							
							cell = cells[0];
							gymClass.time = cell.InnerText.Trim();

							cell = cells[1];
							gymClass.gym = cell.InnerText.Trim();
							
							cell = cells[2];
							gymClass.title = cell.InnerText.Trim();
							
							cell = cells[3];
							gymClass.instructor = cell.InnerText.Trim();
							
							cell = cells[4];
							gymClass.vacant = cell.InnerText.Trim();
							
							cell = cells[5];
							gymClass.status = cell.InnerText.Trim();
							
							cell = cells[6];
							if (cell.InnerText.Trim() == "Velg")
							{
								link = cell.SelectNodes( "//a" )[0];
								gymClass.action = link.GetAttributeValue("href","");
							}
							
							schedules.Add( gymClass );				
						}
					}
				}				 
			}		
			
			
		}	
		
		
		
	}
}
