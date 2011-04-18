using System;

namespace TheGym
{
	public static class TTTBook
	{
		public static void book ( string gymAction ) 
		{
			string actionURL =  "http://brp.netono.se/3t/mesh/" + gymAction ;
			TTTHttp.getHTTP( actionURL );
		}
		
		
		public static void unBook ( string gymAction )
		{
			string actionURL =  "http://brp.netono.se/3t/mesh/" + gymAction ;
			TTTHttp.getHTTP( actionURL );
			
		}
	}
}

