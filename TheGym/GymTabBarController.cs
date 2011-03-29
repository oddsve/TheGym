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
			
			var tabs = new UIViewController[8];
			
			tabs[7] = new GymSettingsViewController();
			tabs[7].TabBarItem = new UITabBarItem( "Settings", new UIImage() ,0);
			
			
			DateTime toDay = DateTime.Now;
			
			tabs[0] = new ScheduleNavigationController(toDay);
			tabs[0].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString() , new UIImage() ,1);
			
			toDay = toDay.AddDays(1);
			tabs[1] = new ScheduleNavigationController( toDay  );
			tabs[1].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,2);

			toDay = toDay.AddDays(1);
			tabs[2] = new ScheduleNavigationController( toDay );
			tabs[2].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,3);

			toDay = toDay.AddDays(1);
			tabs[3] = new ScheduleNavigationController( toDay );
			tabs[3].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,4);
			
			toDay = toDay.AddDays(1);
			tabs[4] = new ScheduleNavigationController( toDay );
			tabs[4].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,5);
			
			toDay = toDay.AddDays(1);
			tabs[5] = new ScheduleNavigationController( toDay );
			tabs[5].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,6);

			toDay = toDay.AddDays(1);
			tabs[6] = new ScheduleNavigationController( toDay  );
			tabs[6].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,7);

			
			
			ViewControllers = tabs;
			
		
			
		}
		
		
		
	}
}

