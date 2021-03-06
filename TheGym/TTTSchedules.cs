using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace TheGym
{
	public static class TTTSchedules 
	{
		
		
		public static List<GymClass> getSchedules( DateTime scheduleDate )
		{
			string scheduleDateString = scheduleDate.Year.ToString() + "-" 
										+ scheduleDate.Month.ToString() + "-" 
										+ scheduleDate.Day.ToString();

			
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
				
				
			string activityUrl = "http://brp.netono.se/3t/mesh/showGroupActivities.action?businessUnit=1";

			HtmlDocument document = new HtmlDocument();
			HtmlNode.ElementsFlags.Remove( "option" );
			document.LoadHtml( TTTHttp.PostHTTP( activityUrl ,postData ) );
		
			
			HtmlDocument rowDocument= new HtmlDocument();
									
			HtmlNodeCollection tables = document.DocumentNode.SelectNodes( "//table[@class='schedule']" ) ;
			if ( tables != null ) 
			{
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
								cells = rowDocument.DocumentNode.SelectNodes( "//td" );
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
									gymClass.bookAction = link.GetAttributeValue("href","");
								} 
								
								else if ( cell.InnerText.Trim() == "Avbooke")
	
								{
									link = cell.SelectNodes( "//a" )[0];
									string href  = link.GetAttributeValue("href","");
									
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
								
							if ( gymClass.startTime > DateTime.Now ) 
								schedules.Add( gymClass );				
							}
						}
					}
				}
				 
			}		
			

			return schedules;
		}	
		 
		
		
		
		
	}
}

