using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class GymTabBarController : UITabBarController
	{
		GymTabBarControllerDelegate gymDelegate;
		private DateTime dateToDay; 
		public GymTabBarController ()
		{
			
			
			gymDelegate = new GymTabBarControllerDelegate();
			
				
		}
		
		
		public void arrangeTabBars()
		{
			var tabs = new UIViewController[9];		
			
			DateTime toDay = DateTime.Now;
			
			tabs[0] = new UINavigationController( new ScheduleViewController( toDay , false ) );
			tabs[0].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString() , new UIImage() ,1);
			
			toDay = toDay.AddDays(1);
			tabs[1] = new UINavigationController( new ScheduleViewController( toDay , false ) );
			tabs[1].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,2);

			toDay = toDay.AddDays(1);
			tabs[2] = new UINavigationController( new ScheduleViewController( toDay , false ) );
			tabs[2].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,3);

			toDay = toDay.AddDays(1);
			tabs[3] = new UINavigationController( new ScheduleViewController( toDay , false ) );
			tabs[3].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,4);
			
			toDay = toDay.AddDays(1);
			tabs[4] = new UINavigationController( new ScheduleViewController( toDay , false ) );
			tabs[4].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,5);
			
			toDay = toDay.AddDays(1);
			tabs[5] = new UINavigationController( new ScheduleViewController( toDay , false ) );
			tabs[5].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,6);

			toDay = toDay.AddDays(1);
			tabs[6] = new UINavigationController( new ScheduleViewController( toDay , false ) );
			tabs[6].TabBarItem = new UITabBarItem( toDay.DayOfWeek.ToString(), new UIImage() ,7);
									
			tabs[7] = new UINavigationController( new ScheduleViewController( toDay , true  ) );
			tabs[7].TabBarItem = new UITabBarItem( "Mine bookinger", new UIImage() ,8);

			tabs[8] = new GymSettingsViewController();
			tabs[8].TabBarItem = new UITabBarItem( "Settings", new UIImage() ,0);
			
			
			ViewControllers = tabs;
			
		}
		
		public override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();
			arrangeTabBars();
		
			
		}
		
		

		
	}
}

