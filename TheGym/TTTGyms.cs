using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TheGym
{
	public static class TTTGyms
	{
			
				
		private static Dictionary<int,string> gyms;
		
	
		public static Dictionary<int, string> getGyms()
		{
			if ( gyms == null ) 
			{
				gyms = new Dictionary<int, string>();
				populateGyms();
			}
			return gyms;
			
		}
		
		private static void populateGyms()
		{
			
			string document =  TTTHttp.getHTTP( "http://brp.netono.se/3t/mesh/selectUnit.action" );
			
	
			//string pattern = "<option value=\"(\d)\">(.)*?</option>";
			string pattern = "<option value=\"(.*?)\">(.*?)<";
			// Instantiate the regular expression object.
			Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
			
			// Match the regular expression pattern against a text string.
			Match m = r.Match(document);
			while (m.Success) 
			{
				Group g1 = m.Groups[1];
				Group g2 = m.Groups[2];
				Console.WriteLine(g1 + "---" + g2 );			 
			 	m = m.NextMatch();
			}

	
		}
			
			
	}
}

