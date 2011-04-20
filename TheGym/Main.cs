
using System;
using System.Collections.Generic;
using System.Linq;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class Application
	{
		static void Main (string[] args)
		{
			UIApplication.Main (args);
		}
	}

	public partial class AppDelegate : UIApplicationDelegate
	{
		private GymTabBarController tabBarController;
		
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			
			GymSettingsDataSource.Read();
			Text.initialize();
			tabBarController = new GymTabBarController();
			window.AddSubview ( tabBarController.View );		
			
			window.MakeKeyAndVisible ();

			if ( GymSettingsDataSource.UserName == "" || GymSettingsDataSource.Password == "" )
			{
				tabBarController.SelectedIndex = 8;
			}
			else TTTHttp.LogOn() ;
			
			return true;
		}
		
		public override void WillEnterForeground (UIApplication application)
		{
			tabBarController.arrangeTabBars();
		}

		public override void OnActivated (UIApplication application)
		{
		}
	}
}
