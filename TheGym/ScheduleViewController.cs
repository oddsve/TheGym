
using System;
using System.Globalization;
using MonoTouch.UIKit;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;
using System.Threading;

namespace TheGym
{
	public class ScheduleViewController : UIViewController
	{
		DateTime _scheduleDate;
		bool _myBookings;
		ScheduleTableViewController scheduleTableViewController;
		UIActivityIndicatorView activityIndicator;
		
		
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
			
			View.BackgroundColor = UIColor.Black;
			scheduleTableViewController = 
				new ScheduleTableViewController( this.NavigationController, _scheduleDate , _myBookings );
			
			scheduleTableViewController.View.Frame = new RectangleF( 0, 0, View.Frame.Width, View.Frame.Height - 90 );
			
			
			activityIndicator = new UIActivityIndicatorView();
			activityIndicator.ActivityIndicatorViewStyle = UIActivityIndicatorViewStyle.WhiteLarge;
			
			float sides = View.Frame.Width - 200;
			float ypos = (View.Frame.Height-View.Frame.Width)/2;
			activityIndicator.Frame = new RectangleF( 100, ypos, sides, sides );
			activityIndicator.BackgroundColor = UIColor.Black;
			
			
			
			
		}
		
		public override void ViewDidAppear (bool animated)
		{
			scheduleTableViewController.View.RemoveFromSuperview();
			View.AddSubview( activityIndicator );
			activityIndicator.StartAnimating();
			ThreadStart workerTread = new ThreadStart(populateView);
			new Thread ( workerTread ).Start();			
		}
		
		public void populateView ()
		{
			ScheduleTableViewDataSource dataSource = (ScheduleTableViewDataSource) scheduleTableViewController.TableView.DataSource;
			dataSource.ReloadData(false);
			scheduleTableViewController.TableView.ReloadData();
			activityIndicator.RemoveFromSuperview();
			View.AddSubview ( scheduleTableViewController.View );
		}
		
	}
}
