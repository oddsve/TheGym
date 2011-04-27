using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using HtmlAgilityPack;



namespace TheGym
{
	public static class TTTHttp
	{

		static CookieContainer cookies;
		public static string ErrorMessage { set; get; }
		public static bool isError { set; get; }
		
		private static void findErrors( string output )
		{
			HtmlDocument document = new HtmlDocument();
			document.LoadHtml( output );
			
			HtmlNodeCollection spans = document.DocumentNode.SelectNodes( "//span[@class='errordescription']" ) ;
			ErrorMessage ="";
			
			if ( spans != null )
			{
				foreach ( HtmlNode span in spans )
				{
					ErrorMessage = span.InnerText;
					isError = true;
				}
			}
			
			
		}
		
		
		public static void  LogOn()
		{
			isError = false;
			ErrorMessage = "";
			cookies = new CookieContainer();
			ServicePointManager.Expect100Continue = false;


			HttpWebRequest initailRequest = (HttpWebRequest)WebRequest.Create("http://brp.netono.se/3t/mesh/index.action?businessUnit=10");

			initailRequest.ContentType = "application/x-www-form-urlencoded";
			initailRequest.Method = "GET";

			initailRequest.CookieContainer = cookies;
			initailRequest.KeepAlive = true;


			try
			{
				HttpWebResponse initialResponse = 	(HttpWebResponse)initailRequest.GetResponse();
				CookieCollection initialCookieCollection = cookies.GetCookies(new Uri("http://brp.netono.se/3t/mesh/index.action"));
	
				foreach (Cookie cookie in initialCookieCollection)
				{
					cookie.Path = "/";
					cookies.Add(cookie);
				}
				initialResponse.Close();
				
				HttpWebRequest loginRequest; 
				loginRequest = null;
				loginRequest = (HttpWebRequest)WebRequest.Create("http://brp.netono.se/3t/mesh/login.action");
	
				string loginString = "username=" + GymSettingsDataSource.UserName + "&password=" 
							+ GymSettingsDataSource.Password + "&isSaving=G%E5+videre";
				
				byte[] data = Encoding.Default.GetBytes( loginString );
				loginRequest.ContentLength = data.Length;
	
				loginRequest.Method = "POST";
	
	
				loginRequest.CookieContainer = cookies;
				loginRequest.KeepAlive = true;
				loginRequest.ContentType = "application/x-www-form-urlencoded";
				
				Stream loginStream = null;
				loginStream  = loginRequest.GetRequestStream();
				loginStream.Write(data, 0, data.Length);
	
				loginStream.Close();
	
				
				HttpWebResponse loginResponse = (HttpWebResponse)loginRequest.GetResponse();
				initialCookieCollection = cookies.GetCookies( new Uri("http://brp.netono.se/3t/mesh/login.action" ) );
	
				foreach (Cookie cookie in initialCookieCollection)
				{
					cookie.Path = "/";
					cookies.Add(cookie);
				}
	
				StreamReader reader = new StreamReader( loginResponse.GetResponseStream());
				string response = reader.ReadToEnd();
				
				loginResponse.Close();
				reader.Close();
				
				findErrors( response );
				
				if ( !isError ) 	GymSettingsDataSource.isLogedOn = true;
				else GymSettingsDataSource.isLogedOn = false;
			}
			catch ( Exception e ) 
			{
				isError = true;
				ErrorMessage = "Du er ikke koblet til Internett";
			}
			
		}	
		
		
		public static string PostHTTP( string url, string postData)
		{		
			isError = false;
			ErrorMessage = "";
			// now we can send out cookie along with a request for the protected page
			HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create( url );
			webRequest.Method = "POST";
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.CookieContainer = cookies;
			
  
			StreamWriter requestWriter = new StreamWriter( webRequest.GetRequestStream() );
			requestWriter.Write( postData );
			requestWriter.Close();
			
			StreamReader responseReader = new StreamReader( webRequest.GetResponse().GetResponseStream() , Encoding.UTF7 );
   
			// and read the response
			string responseData = responseReader.ReadToEnd();
			responseReader.Close();		
			
			return HtmlEntity.DeEntitize( responseData );
		}
		
		public static string getHTTP ( string url )
		{
			isError = false;
			ErrorMessage = "";
			// now we can send out cookie along with a request for the protected page
			HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create( url );
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.CookieContainer = cookies;
		
   			StreamReader responseReader = new StreamReader( webRequest.GetResponse().GetResponseStream() , Encoding.UTF7 );
   
			// and read the response
			string responseData = responseReader.ReadToEnd();
			responseReader.Close();
			
			findErrors( responseData );
			
			return HtmlEntity.DeEntitize( responseData );
		}
		
		
	}
		
}

