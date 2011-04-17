using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class oldScheduleNavigationController : UINavigationController
	{
		DateTime _scheduleDate;
		bool _myBookings;
		public oldScheduleNavigationController ( DateTime scheduleDate, bool myBookings )
		{
			 _scheduleDate = scheduleDate;
			 _myBookings = myBookings;
		}
		
	/*	public override void ViewDidLoad ()
		{
				
			ScheduleViewController viewController = new ScheduleViewController( this , _scheduleDate , _myBookings );
			this.PushViewController( viewController , true );
			NavigationBarHidden = false;
			
		}*/
		
	}
}

