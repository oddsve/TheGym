using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;



namespace TheGym
{
	public static class TTTHttp
	{

		static CookieContainer cookies;

		
		
		public static void LogOn()
		{
			cookies = new CookieContainer();
			ServicePointManager.Expect100Continue = false;


			HttpWebRequest initailRequest = (HttpWebRequest)WebRequest.Create("http://brp.netono.se/3t/mesh/index.action?businessUnit=10");

			initailRequest.ContentType = "application/x-www-form-urlencoded";
			initailRequest.Method = "GET";

			initailRequest.CookieContainer = cookies;
			initailRequest.KeepAlive = true;



			HttpWebResponse initialResponse = (HttpWebResponse)initailRequest.GetResponse();
			CookieCollection initialCookieCollection = cookies.GetCookies(new Uri("http://brp.netono.se/3t/mesh/index.action"));

			foreach (Cookie cookie in initialCookieCollection)
			{
				cookie.Path = "/";
				cookies.Add(cookie);
			}


			HttpWebRequest loginRequest = (HttpWebRequest)WebRequest.Create("http://brp.netono.se/3t/mesh/login.action");

			string loginString = "username=rebekka%40sveas.org&password=200876&isSaving=G%E5+videre";
			byte[] data = Encoding.Default.GetBytes( loginString );
			loginRequest.ContentLength = data.Length;

			loginRequest.Method = "POST";


			loginRequest.CookieContainer = cookies;
			loginRequest.KeepAlive = true;
			loginRequest.ContentType = "application/x-www-form-urlencoded";
			//loginRequest.UserAgent = "Mozilla/4.0 (compatible; MSIE 7.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";

			
			Stream loginStream;
			loginStream = loginRequest.GetRequestStream();
			loginStream.Write(data, 0, data.Length);

			loginStream.Close();

			
			HttpWebResponse loginResponse = (HttpWebResponse)loginRequest.GetResponse();
			initialCookieCollection = cookies.GetCookies(new Uri("http://brp.netono.se/3t/mesh/login.action"));

			foreach (Cookie cookie in initialCookieCollection)
			{
				cookie.Path = "/";
				cookies.Add(cookie);
			}

			StreamReader reader = new StreamReader( loginResponse.GetResponseStream());
			reader.ReadToEnd();
			
			//System.Console.WriteLine( reader.ReadToEnd() );
			
			/*
			HttpWebRequest wr2 = (HttpWebRequest)WebRequest.Create("http://brp.netono.se/3t/mesh/showBookings.action");
			wr2.CookieContainer = cookies;
			wr2.KeepAlive = true;
			wr2.ContentType = "application/x-www-form-urlencoded";
			
			
			HttpWebResponse wresponse2 = (HttpWebResponse)wr2.GetResponse();
			StreamReader reader2 = new StreamReader(wresponse2.GetResponseStream());
			//reader2.ReadToEnd();
			System.Console.WriteLine( reader2.ReadToEnd() );
			*/

		}	
		
		
		public static string GroupActivities( string scheduleDateString ) 
		{
			string unitURL =  "http://brp.netono.se/3t/mesh/showGroupActivities.action?businessUnit=1";
			
			// now we can send out cookie along with a request for the protected page
			HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create( unitURL );
			webRequest.Method = "POST";
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.CookieContainer = cookies;
			

			
			
		
   			string postData = String.Format(  
			                         "selectableUnits%5B0%5D.chosen=true&selectableUnits%5B1%5D.chosen=true&"+
			                         "selectableUnits%5B2%5D.chosen=true&selectableUnits%5B3%5D.chosen=true&"+
			                         "selectableUnits%5B4%5D.chosen=true&selectableUnits%5B5%5D.chosen=true&"+
			                         "selectableUnits%5B6%5D.chosen=true&selectableUnits%5B7%5D.chosen=true&"+
			                         "selectableUnits%5B8%5D.chosen=true&selectableUnits%5B9%5D.chosen=true&"+
			                         "selectableUnits%5B10%5D.chosen=true&group=all&date="+ scheduleDateString +
			                         "&group=all&");
		

			StreamWriter requestWriter = new StreamWriter( webRequest.GetRequestStream() );
			requestWriter.Write( postData );
			requestWriter.Close();
			
			StreamReader responseReader = new StreamReader( webRequest.GetResponse().GetResponseStream() , Encoding.UTF7 );
   
			// and read the response
			string responseData = responseReader.ReadToEnd();
			responseReader.Close();
			
			
			return responseData;
				
		}
		
		public static string getHTTP ( string url )
		{
			
			// now we can send out cookie along with a request for the protected page
			HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create( url );
			webRequest.ContentType = "application/x-www-form-urlencoded";
			webRequest.CookieContainer = cookies;
		
   			StreamReader responseReader = new StreamReader( webRequest.GetResponse().GetResponseStream() , Encoding.UTF7 );
   
			// and read the response
			string responseData = responseReader.ReadToEnd();
			responseReader.Close();
			
			
			return responseData;
			
		}
		
/*		public static void sendAction ( string gymAction )
		{
			string actionURL =  "http://brp.netono.se/3t/mesh/" + gymAction ;
			
			
			// now we can send out cookie along with a request for the protected page
			HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create( actionURL );
			webRequest.Method = "GET";
			webRequest.CookieContainer = cookies;
			
			System.Console.WriteLine ( "====" );
			CookieCollection coco = cookies.GetCookies( new Uri( actionURL ) );
			foreach  ( Cookie c in coco ) 
			{					
				System.Console.WriteLine( c.Name );
				System.Console.WriteLine( c.Value );
			}			
			

            //Get Response
            HttpWebResponse webResponse = (HttpWebResponse) webRequest.GetResponse();

			StreamReader responseReader = new StreamReader( webRequest.GetResponse().GetResponseStream() , Encoding.UTF7);
   
			// and read the response
			string responseData = responseReader.ReadToEnd();
			responseReader.Close();
			
	//		System.Console.Write( responseData );
			
		}*/

		
	}
		
}

