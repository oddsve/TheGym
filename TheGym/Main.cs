
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

			if ( GymSettingsDataSource.UserName == null || GymSettingsDataSource.Password == null )
			{
				tabBarController.arrangeTabBars();
				tabBarController.SelectedIndex = 8;
			}
			else TTTHttp.LogOn() ;
			
			if ( TTTHttp.isError ) 
			{
				UIAlertView alert = new UIAlertView();
				alert.Title = "Påloggingsfeil";
				alert.Message = Text.getString( TTTHttp.ErrorMessage ) ;
				alert.AddButton("OK");
				alert.Show();	
			}
			else tabBarController.arrangeTabBars();
			
			return true;
		}
		
		public override void WillEnterForeground (UIApplication application)
		{
			if ( !GymSettingsDataSource.isLogedOn ) 
			{
				TTTHttp.LogOn();
			
				if ( TTTHttp.isError ) 
				{
					UIAlertView alert = new UIAlertView();
					alert.Title = "Påloggingsfeil";
					alert.Message = Text.getString( TTTHttp.ErrorMessage ) ;
					alert.AddButton("OK");
					alert.Show();	
				}
			}
				
			if ( GymSettingsDataSource.isLogedOn )	tabBarController.arrangeTabBars();
		}

		public override void OnActivated (UIApplication application)
		{
		}
	}
}
