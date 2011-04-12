
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
		DateTime _scheduleDate;
		bool _myBookings;
		
		public ScheduleViewController( ScheduleNavigationController navigationController , DateTime scheduleDate, bool myBookings )
		{
			this._navigationController = navigationController;
			_scheduleDate = scheduleDate;
			_myBookings = myBookings;
		}
		
		public ScheduleViewController( DateTime scheduleDate, bool myBookings )
		{
			_scheduleDate = scheduleDate;
			_myBookings = myBookings;
			
		}
			
		public override void ViewDidLoad ()
		{
			
			Title = _scheduleDate.DayOfWeek.ToString();
			
			
			/*ScheduleSearchBar searchBar = new ScheduleSearchBar();
			searchBar.Frame = new RectangleF ( 0, 0, View.Frame.Width, 40 ) ;			
			View.AddSubview( searchBar );*/
	
			ScheduleTableViewController sheduleTableViewController = 
				new ScheduleTableViewController( this._navigationController, _scheduleDate , _myBookings );
			
			sheduleTableViewController.View.Frame = new RectangleF( 0, 0, View.Frame.Width, View.Frame.Height );
			View.AddSubview ( sheduleTableViewController.View );
			
			base.ViewDidLoad ();
		}
		
	}
}
