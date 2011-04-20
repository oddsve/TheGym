using System;
using System.Collections.Generic;

namespace TheGym
{
	public static class Text
	{
		private static Dictionary<string,string> texts; 
		public static void initialize ()
		{
			texts = new Dictionary<string, string>();
			texts.Add( "Felaktigt anv&#xE4;ndarnamn", "Brukernavnet finnes ikke" );
			texts.Add( "Felaktigt l&#xF6;senord", "Passordet stemmer ikke" );
			
		}
		
		public static string getString  ( string key )
		{
			if ( texts.ContainsKey( key ) ) return texts[ key ];
			else 
			{	
				System.Console.WriteLine( key ) ;
				return key;
			}
		}
	}
}

