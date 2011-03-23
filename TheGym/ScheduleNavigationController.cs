using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class ScheduleNavigationController : UINavigationController
	{
		
		
		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			ScheduleViewController viewController = new ScheduleViewController( this );
			this.View.AddSubview( viewController.View );
			
		}
	}
}

