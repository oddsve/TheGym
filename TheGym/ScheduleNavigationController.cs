using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class ScheduleNavigationController : UINavigationController
	{
		DateTime _scheduleDate;
		bool _myBookings;
		public ScheduleNavigationController ( DateTime scheduleDate, bool myBookings )
		{
			 _scheduleDate = scheduleDate;
			 _myBookings = myBookings;
		}
		
		public override void ViewDidLoad ()
		{
				
			ScheduleViewController viewController = new ScheduleViewController( this , _scheduleDate , _myBookings );
			this.PushViewController( viewController , true );
		//	this.View.AddSubview( viewController.View );
			
			NavigationBarHidden = false;
			
		}
		
/*		public override void PushViewController ( UIViewController viewController, bool animated )
		{
			System.Console.WriteLine( "Antall:" + this.ViewControllers.Length );
			base.PushViewController ( viewController, animated );
			
		}*/
	}
}

