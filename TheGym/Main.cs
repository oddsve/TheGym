
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
		private GymNavigationViewController gymNavigationController;
		private UINavigationController navigationController;
		
		
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			
			GymSettingsDataSource.Read();
			Text.initialize();
			
			gymNavigationController = new GymNavigationViewController();
			gymNavigationController.View.Frame = new System.Drawing.RectangleF (0, 20, window.Frame.Width, window.Frame.Height - 50);
			
			navigationController = new UINavigationController( gymNavigationController );
			navigationController.NavigationBar.BarStyle = UIBarStyle.Black;
			window.AddSubview ( navigationController.View );
			
			window.MakeKeyAndVisible();
			
			
			return true;
			
		}
		
		public override void WillEnterForeground (UIApplication application)
		{
			gymNavigationController.arrangeMenu();
		}

		public override void OnActivated (UIApplication application)
		{
		}
	}
}
