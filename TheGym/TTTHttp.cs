using System;
using System.Collections.Generic;
using HtmlAgilityPack;
using System.IO;
using System.Net;
using System.Text;



namespace TheGym
{
	public static class TTTHttp
	{

		
		
	/*	public static HttpWebResponse HttpPost(string url, string referer, string userAgent
		                                       , string postData, WebHeaderCollection headers)
	    {
            HttpWebRequest http = ( HttpWebRequest)WebRequest.Create(url) as HttpWebRequest;
            http.AllowAutoRedirect = true;
            http.Method = "POST";
            http.ContentType = "application/x-www-form-urlencoded";
            http.UserAgent = userAgent;
            http.CookieContainer = new CookieContainer();
            http.CookieContainer.Add(cookies);
            http.Referer = referer;
            byte[] dataBytes = UTF8Encoding.UTF8.GetBytes(postData);
            http.ContentLength = dataBytes.Length;
            using (Stream postStream = http.GetRequestStream())
            {
                postStream.Write(dataBytes, 0, dataBytes.Length);
            }
            HttpWebResponse httpResponse = ( HttpWebResponse ) http.GetResponse() as HttpWebResponse;
            headers = http.Headers;
            cookies.Add( httpResponse.Cookies );
	
	    }*/
	
		
	/*	public static void createSession ()
		{
			
			
			String logInURL = "http://brp.netono.se/3t/mesh/index.action";
			String actionURL = "http://brp.netono.se/3t/mesh/login.action";
			
			
   			// extract the viewstate value and build out POST data
   			//string viewState = ExtractViewState(responseData);       
   			string postData = String.Format( "username={0}&password={1}&isSaving=G%E5+videre"
			                                , "rebekka@sveas.org" ,"200876" );
  
  
			// now post to the login form
			HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create( actionURL ) ;
			webRequest.AllowAutoRedirect = true;
			webRequest.Method = "POST";
			webRequest.ContentType = "application/x-www-form-urlencoded";
			cookies = new CookieContainer();
			webRequest.CookieContainer = cookies;        
		   
			// write the form values into the request message
			StreamWriter requestWriter = new StreamWriter( webRequest.GetRequestStream() );
			requestWriter.Write( postData );
   			requestWriter.Close();
   
			HttpWebResponse webResponse = ( HttpWebResponse ) webRequest.GetResponse();
			
			cookies.Add( webResponse.Cookies );
			webResponse.Close();
			
	/*		responseReader = new StreamReader( webRequest.GetResponse().GetResponseStream() , Encoding.UTF7);
			
			// and read the response
			responseData = responseReader.ReadToEnd();
			cookies = webRequest.CookieContainer;
			responseReader.Close();
			
			webRequest.GetResponse().Close();
			
			System.Console.WriteLine ( "====" );
			CookieCollection coco = cookies.GetCookies( new Uri( logInURL ) );
			foreach  ( Cookie c in coco ) 
			{					
				System.Console.WriteLine( c.Name );
				System.Console.WriteLine( c.Value );
			}			
			
			
			
			//System.Console.WriteLine( responseData );
			
		}*/
		
		public static HtmlDocument GroupActivities() 
		{
			string unitURL =  "http://brp.netono.se/3t/mesh/showGroupActivities.action?businessUnit=1";
			
			// now we can send out cookie along with a request for the protected page
			HttpWebRequest webRequest = ( HttpWebRequest )WebRequest.Create( unitURL );
			webRequest.Method = "POST";
			webRequest.ContentType = "application/x-www-form-urlencoded";

			System.Console.WriteLine ( "====" );
			
			
		
   			string postData = String.Format(  
			                         "selectableUnits%5B0%5D.chosen=true&selectableUnits%5B1%5D.chosen=true&"+
			                         "selectableUnits%5B2%5D.chosen=true&selectableUnits%5B3%5D.chosen=true&"+
			                         "selectableUnits%5B4%5D.chosen=true&selectableUnits%5B5%5D.chosen=true&"+
			                         "selectableUnits%5B6%5D.chosen=true&selectableUnits%5B7%5D.chosen=true&"+
			                         "selectableUnits%5B8%5D.chosen=true&selectableUnits%5B9%5D.chosen=true&"+
			                         "selectableUnits%5B10%5D.chosen=true&group=all&date=2011-03-29&group=all" );

			StreamWriter requestWriter = new StreamWriter( webRequest.GetRequestStream() );
			requestWriter.Write( postData );
			requestWriter.Close();
			
			StreamReader responseReader = new StreamReader( webRequest.GetResponse().GetResponseStream() , Encoding.UTF7);
   
			// and read the response
			string responseData = responseReader.ReadToEnd();
			responseReader.Close();
			
			HtmlDocument document = new HtmlDocument();
			HtmlNode.ElementsFlags.Remove( "option" );
			document.LoadHtml( responseData );
			
			return document;
				
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

