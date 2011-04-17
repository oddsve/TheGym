using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewController : UITableViewController
	{
		private UINavigationController navigationController;
		private DateTime _scheduleDate;
		private bool _myBookings;
		private List<string> currentSelectedGymKeys;
		
		public ScheduleTableViewController( UINavigationController navigationController, DateTime scheduleDate, bool myBookings )
		{
			this.navigationController = navigationController;
			this._scheduleDate = scheduleDate;
			this._myBookings = myBookings;
			currentSelectedGymKeys = new List<string>();
		}
		
		public override void ViewDidLoad()
		{
			
			TableView.DataSource = new ScheduleTableViewDataSource( _scheduleDate,_myBookings );
			TableView.Delegate = new ScheduleTableViewDelegate(  this.navigationController );
			
			
		}
		
		
	}
}