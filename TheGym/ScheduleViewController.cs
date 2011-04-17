
using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace TheGym
{
	public class ScheduleViewController : UIViewController
	{
		DateTime _scheduleDate;
		bool _myBookings;
		
	/*	public ScheduleViewController( UINavigationController navigationController , DateTime scheduleDate, bool myBookings )
		{
			//this._navigationController = navigationController;
			_scheduleDate = scheduleDate;
			_myBookings = myBookings;
			
		}*/
		
		public ScheduleViewController( DateTime scheduleDate, bool myBookings )
		{
			_scheduleDate = scheduleDate;
			_myBookings = myBookings;
			
		}
			
		public override void ViewDidLoad ()
		{
			
			Title = _scheduleDate.DayOfWeek.ToString();
			
			
	
			ScheduleTableViewController sheduleTableViewController = 
				new ScheduleTableViewController( this.NavigationController, _scheduleDate , _myBookings );
			
			sheduleTableViewController.View.Frame = new RectangleF( 0, 0, View.Frame.Width, View.Frame.Height );
			View.AddSubview ( sheduleTableViewController.View );
			
			base.ViewDidLoad ();
		}
		
	}
}
