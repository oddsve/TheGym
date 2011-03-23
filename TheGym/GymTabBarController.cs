using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class GymTabBarController : UITabBarController
	{
		GymTabBarControllerDelegate gymDelegate;
		public GymTabBarController ()
		{
			
			
			gymDelegate = new GymTabBarControllerDelegate();
			
				
		}
		
		public override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();
			
			var tabs = new UIViewController[2];
			
			tabs[0] = new GymSettingsViewController();
			tabs[0].TabBarItem = new UITabBarItem( "Konto", new UIImage() ,0);
			
			tabs[1] = new ScheduleNavigationController();
			tabs[1].TabBarItem = new UITabBarItem( "Timer", new UIImage() ,1);
			
			
			
	
			
			
			ViewControllers = tabs;
			
		
			
		}
		
		
		
	}
}

