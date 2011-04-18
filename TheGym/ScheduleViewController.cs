
using System;
using System.Globalization;
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
		ScheduleTableViewController scheduleTableViewController;
		
		
		public ScheduleViewController( DateTime scheduleDate, bool myBookings )
		{
			_scheduleDate = scheduleDate;
			_myBookings = myBookings;
			
		}
			
		public override void ViewDidLoad ()
		{
			if ( _myBookings ) 
			{
				Title = "mine bestillinger";
			}
			else 
			{
				CultureInfo no = new CultureInfo("nn-NO");
				Title = _scheduleDate.ToString("dddd",no);
			}
			
	
			scheduleTableViewController = 
				new ScheduleTableViewController( this.NavigationController, _scheduleDate , _myBookings );
			
			scheduleTableViewController.View.Frame = new RectangleF( 0, 0, View.Frame.Width, View.Frame.Height );
			View.AddSubview ( scheduleTableViewController.View );
			
			base.ViewDidLoad ();
		}
		
		public override void ViewWillAppear (bool animated)
		{
			ScheduleTableViewDataSource dataSource = (ScheduleTableViewDataSource) scheduleTableViewController.TableView.DataSource;
			dataSource.ReloadData();
			scheduleTableViewController.TableView.ReloadData();
			base.ViewWillAppear (animated);
		}
		
	}
}
