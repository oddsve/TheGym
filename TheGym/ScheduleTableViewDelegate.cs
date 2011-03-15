using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewDelegate : UITableViewDelegate
	{
		protected UITableViewController _controller;
		public ScheduleTableViewDelegate ( UITableViewController controller) :base()
		{
			this._controller = controller;
		}
		
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
		//	tableView.DataSource.GetCell( tableView, indexPath ).Accessory = UITableViewCellAccessory.Checkmark ;
						
			
		}
		
		
		
	}
}

