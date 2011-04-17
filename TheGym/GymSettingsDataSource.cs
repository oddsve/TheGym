using System;
using System.Collections.Generic;

using MonoTouch.Foundation;
//using MonoTouch.UIKit;

namespace TheGym
{
	public static class GymSettingsDataSource 
	{
		public static string UserName { get; set; }
		public static string Password { get ; set; }
		public static List<string> selectedGymKeys { get; set; }
		public static bool isLogedOn { get; set; }
		private static string gymKeys;
		
		public static void Read ()
		{
			UserName = NSUserDefaults.StandardUserDefaults.StringForKey("username");
			Password = NSUserDefaults.StandardUserDefaults.StringForKey("password");
			gymKeys = NSUserDefaults.StandardUserDefaults.StringForKey("gymKeys");
			
			selectedGymKeys = new List<string>();
			if ( gymKeys != null )
				{
				string[] keys = gymKeys.Split(',');
				
				
				foreach ( string key in keys )
				{
					selectedGymKeys.Add( key );
				}
			}
			
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
				
			if ( selectedGymKeys.Count  == 0 ) 
			{
				NSUserDefaults.StandardUserDefaults.RemoveObject("gymKeys");
			} 
			else
			{
				string keys = "";
				
				for (int i = 0; i< selectedGymKeys.Count; i++ )
				{
					keys += ","+selectedGymKeys[ i ];
				}
				keys = keys.Substring(1);
				NSUserDefaults.StandardUserDefaults.SetString( keys, "gymKeys" );
			}
			
			NSUserDefaults.StandardUserDefaults.Synchronize();
		}
	}
}

