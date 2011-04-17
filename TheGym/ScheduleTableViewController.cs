using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewController : UITableViewController
	{
		private ScheduleNavigationController _navigationController;
		private DateTime _scheduleDate;
		private bool _myBookings;
		private List<string> currentSelectedGymKeys;
		
		public ScheduleTableViewController( ScheduleNavigationController navigationController, DateTime scheduleDate, bool myBookings )
		{
			this._navigationController = navigationController;
			this._scheduleDate = scheduleDate;
			this._myBookings = myBookings;
			currentSelectedGymKeys = new List<string>();
		}
		
		public override void ViewDidLoad()
		{
			
			TableView.DataSource = new ScheduleTableViewDataSource( _scheduleDate,_myBookings );
			TableView.Delegate = new ScheduleTableViewDelegate(  this._navigationController );
			
			
			//base.ViewDidLoad();
		}
		
		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);
		}
		
		public override void ViewDidAppear (bool animated)
		{
			if ( currentSelectedGymKeys != GymSettingsDataSource.selectedGymKeys ) TableView.ReloadData();
			base.ViewDidAppear (animated);
		}
		
		public override void ViewWillDisappear (bool animated)
		{
			base.ViewWillDisappear (animated);
		}
		
	}
}