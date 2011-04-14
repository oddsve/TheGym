using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Web;

namespace TheGym
{
	public static class TTTGyms
	{
			
				
		private static List<string> gymNames;
		private static List<string> gymKeys;
		
		
	
		
		public static List<string> getGymNames()
		{
			if ( gymNames == null ) 
			{
				populateGyms();
			}
			return gymNames;
			
		}
		
		public static List<string> getGymKeys()
		{
			if ( gymNames == null ) 
			{
				populateGyms();
			}
			return gymKeys;
			
		}

		
		private static void populateGyms()
		{
			gymNames = new List<string>();
			gymKeys = new List<string>();
			
			gymNames.Add("3T-Byåsen");
			gymNames.Add("3T-Leangen");
			gymNames.Add("3T-Levanger");
			gymNames.Add("3T-Midtbyen");
			gymNames.Add("3T-Orkanger");
			gymNames.Add("3T-Pirbadet");
			gymNames.Add("3T-Rosten");
			gymNames.Add("3T-Saupstad");
			gymNames.Add("3T-Sluppen");
			gymNames.Add("3T-Solsiden");
			gymNames.Add("3T-Steinkjer");
			
			gymKeys.Add("0");
			gymKeys.Add("1");
			gymKeys.Add("2");
			gymKeys.Add("3");
			gymKeys.Add("4");
			gymKeys.Add("5");
			gymKeys.Add("6");
			gymKeys.Add("7");
			gymKeys.Add("8");
			gymKeys.Add("9");
			gymKeys.Add("10");
			
			
			
			/*
			string document =  TTTHttp.getHTTP( "http://brp.netono.se/3t/mesh/selectUnit.action" );
			string replace = "&#xE5;";
			Regex repl = new Regex(replace, RegexOptions.IgnoreCase );
			
			//System.Console.WriteLine("å" + char.ConvertFromUtf32(70));
			
			document = repl.Replace(document, "å" );
			
			string pattern = "<option value=\"(.*?)\">(.*?)<";
			// Instantiate the regular expression object.
			Regex r = new Regex(pattern, RegexOptions.IgnoreCase);
			
			// Match the regular expression pattern against a text string.
			Match m = r.Match(document);
			while (m.Success) 
			{
				
				gymKeys.Add( m.Groups[1].ToString() );
				gymNames.Add (  m.Groups[2].ToString() );
			
				//Console.WriteLine(g1 + "---" + g2);//HttpUtility.HtmlEncode (g2.ToString()) );			 
			 	m = m.NextMatch();
				
			}
			*/

	
		}
			
			
	}
}

