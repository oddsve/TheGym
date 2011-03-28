
using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace TheGym
{
	public class ScheduleViewController : UIViewController
	{
		protected ScheduleNavigationController _navigationController;
		
		public ScheduleViewController( ScheduleNavigationController navigationController )
		{
			this._navigationController = navigationController;
		}
			
		public override void ViewDidLoad ()
		{
			
			Title = "Gruppetimer";
			
			ScheduleTableViewController sheduleTableViewController = new ScheduleTableViewController( this._navigationController );
						
			sheduleTableViewController.View.Frame = new RectangleF( 0,0,View.Frame.Width,View.Frame.Height );
			View.AddSubview ( sheduleTableViewController.View );
			
			base.ViewDidLoad ();
		}
		
	}
}
