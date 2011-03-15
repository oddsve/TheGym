using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewController : UITableViewController
	{
		
		
		public ScheduleTableViewController( ) : base()
		{
			
		}
		
		public override void ViewDidLoad()
		{
			
			TableView.DataSource = new ScheduleTableViewDataSource();
			TableView.Delegate = new ScheduleTableViewDelegate( this );
			
			//base.ViewDidLoad();
		}
		
	}
}