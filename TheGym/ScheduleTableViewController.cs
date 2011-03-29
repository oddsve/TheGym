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
		
		public ScheduleTableViewController( ScheduleNavigationController navigationController, DateTime scheduleDate )
		{
			this._navigationController = navigationController;
			this._scheduleDate = scheduleDate;
		}
		
		public override void ViewDidLoad()
		{
			
			TableView.DataSource = new ScheduleTableViewDataSource( _scheduleDate );
			TableView.Delegate = new ScheduleTableViewDelegate( this , this._navigationController );
			
			//base.ViewDidLoad();
		}
		
	}
}