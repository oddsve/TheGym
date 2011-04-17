using System;
using System.Collections.Generic;
using HtmlAgilityPack;

namespace TheGym
{
	public static class TTTSchedules 
	{
		
		
		//private static Dictionary< string, List<GymClass> > schedules;
		
		public static List<GymClass> getSchedules( DateTime scheduleDate )
		{
			string scheduleDateString = scheduleDate.Year.ToString() + "-" 
										+ scheduleDate.Month.ToString() + "-" 
										+ scheduleDate.Day.ToString();
			//if ( schedules == null ) schedules = new Dictionary<string, List<GymClass>>();
			
			
			//if ( !schedules.ContainsKey( scheduleDateString )  ) 
			//{
				
			//}
			//*/			

			
			List<GymClass>schedules = new List<GymClass>();
			
 			string postData = "";
			
			for ( int i = 0 ; i < GymSettingsDataSource.selectedGymKeys.Count ; i ++ )
			{
				postData += "&selectableUnits%5B" 
			                	+ GymSettingsDataSource.selectedGymKeys[i] 
			                	+ "%5D.chosen=true" ;
			}
			
			postData += "&group=all&date="+ scheduleDateString +" &group=all&";
			postData = postData.Substring(1);	
				
				
		/*		= String.Format(  
		               "selectableUnits%5B0%5D.chosen=true&selectableUnits%5B1%5D.chosen=true&"+
                         "selectableUnits%5B2%5D.chosen=true&selectableUnits%5B3%5D.chosen=true&"+
                         "selectableUnits%5B4%5D.chosen=true&selectableUnits%5B5%5D.chosen=true&"+
                         "selectableUnits%5B6%5D.chosen=true&selectableUnits%5B7%5D.chosen=true&"+
                         "selectableUnits%5B8%5D.chosen=true&selectableUnits%5B9%5D.chosen=true&"+
                         "selectableUnits%5B10%5D.chosen=true&group=all&date="+ scheduleDateString +
                         "&group=all&");
                         */

			string activityUrl = "http://brp.netono.se/3t/mesh/showGroupActivities.action?businessUnit=1";

			HtmlDocument document = new HtmlDocument();
			HtmlNode.ElementsFlags.Remove( "option" );
			document.LoadHtml( TTTHttp.PostHTTP( activityUrl ,postData ) );
		
			
			HtmlDocument rowDocument= new HtmlDocument();
									
			HtmlNodeCollection tables = document.DocumentNode.SelectNodes( "//table[@class='schedule']" ) ;
			foreach ( HtmlNode table in tables )
			{
				if ( table.GetAttributeValue("class","") == "schedule" )
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
											
						
						if ( row.GetAttributeValue( "class","" ).ToString().Trim() == "date" )
						{
							rowDocument.LoadHtml(  row.OuterHtml  );
							cells = document.DocumentNode.SelectNodes( "//td" );
							cell  = cells[0];
							date = cell.InnerText.Trim();
						}
						    
							
						if ( row.GetAttributeValue( "class","" ).ToString() == "row"  || 
						     row.GetAttributeValue( "class","" ).ToString() == "row alternateRow" ||
						     row.GetAttributeValue( "class","" ).ToString() == "row bookedRow") 
						{
							
							
							rowDocument.LoadHtml(  row.OuterHtml  );
							cells = rowDocument.DocumentNode.SelectNodes( "//td" );
							
							
							
							cell = cells[0];
							time = cell.InnerText.Trim();

							
							cell = cells[2];
							title = cell.InnerText.Trim();
							
							GymClass gymClass = new GymClass(title,date,time);
							
							cell = cells[1];
							gymClass.gym = cell.InnerText.Trim();
							
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
			
			return schedules;
		}	
		 
		
		
		
		
	}
}

