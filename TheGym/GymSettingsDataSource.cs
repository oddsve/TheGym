using System;
using System.Collections.Generic;

using MonoTouch.Foundation;
//using MonoTouch.UIKit;

namespace TheGym
{
	public class GymSettingsDataSource 
	{
		public static string UserName { get; set; }
		public static string Password { get ; set; }
		public static Dictionary<int,string> gyms { get; set; }
		
		public GymSettingsDataSource()
		{
			gyms = TTTGyms.getGyms();
		}
		
		public static void Read ()
		{
			UserName = NSUserDefaults.StandardUserDefaults.StringForKey("username");
			Password = NSUserDefaults.StandardUserDefaults.StringForKey("password");
			
		}
		
		public static void Write ()
		{
			if ( UserName != null ) 
			{
				NSUserDefaults.StandardUserDefaults.SetString( UserName, "username" );
			}	
			else
			{
				NSUserDefaults.StandardUserDefaults.RemoveObject( "username" );
			}
						
			
			if ( Password != null ) 
			{
				NSUserDefaults.StandardUserDefaults.SetString( Password, "password" );
			} 
			else
			{
				NSUserDefaults.StandardUserDefaults.RemoveObject("password");
			}
				
			
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}
	}
}

