
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
		private GymNavigationViewController gymNavigationController;
		private UINavigationController navigationController;
		
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			
			GymSettingsDataSource.Read();
			Text.initialize();
			
			gymNavigationController = new GymNavigationViewController();
			gymNavigationController.View.Frame = new System.Drawing.RectangleF (0, 20, window.Frame.Width, window.Frame.Height - 50);
			
			navigationController = new UINavigationController( gymNavigationController );
			window.AddSubview ( navigationController.View );
			
			window.MakeKeyAndVisible();
			
			if ( GymSettingsDataSource.UserName == null || GymSettingsDataSource.Password == null )
			{
		//		tabBarController.arrangeTabBars();
		//		tabBarController.SelectedIndex = 8;
			}
			else TTTHttp.LogOn() ;
			
			if ( TTTHttp.isError ) 
			{
				UIAlertView alert = new UIAlertView();
				alert.Title = "Påloggingsfeil";
				alert.Message = Text.getString( TTTHttp.ErrorMessage ) ;
				alert.AddButton("OK");
				alert.Show();	
	//			tabBarController.arrangeTabBars();
	//			tabBarController.SelectedIndex = 8;

			}
	//		else tabBarController.arrangeTabBars();
			
			return true;
			
		/*	tabBarController = new GymTabBarController();
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
				tabBarController.arrangeTabBars();
				tabBarController.SelectedIndex = 8;

			}
			else tabBarController.arrangeTabBars();
			
			return true;*/
		}
		
		public override void WillEnterForeground (UIApplication application)
		{
	/*		if ( !GymSettingsDataSource.isLogedOn ) 
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
				
			if ( GymSettingsDataSource.isLogedOn )	tabBarController.arrangeTabBars(); */
		}

		public override void OnActivated (UIApplication application)
		{
		}
	}
}
