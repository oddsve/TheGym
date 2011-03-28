using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewController : UITableViewController
	{
		private ScheduleNavigationController _navigationController;
		
		public ScheduleTableViewController( ScheduleNavigationController navigationController )
		{
			this._navigationController = navigationController;
		}
		
		public override void ViewDidLoad()
		{
			
			TableView.DataSource = new ScheduleTableViewDataSource();
			TableView.Delegate = new ScheduleTableViewDelegate( this , this._navigationController );
			
			//base.ViewDidLoad();
		}
		
	}
}