using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewDelegate : UITableViewDelegate
	{
		protected ScheduleTableViewController _controller;
		public ScheduleTableViewDelegate ( ScheduleTableViewController controller) :base()
		{
			this._controller = controller;
		}
		
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			//tableView.DataSource.GetCell( tableView, indexPath ).Accessory = UITableViewCellAccessory.Checkmark ;
			
			BookingViewController booking = new BookingViewController();
			
			this._controller._navigationController.PushViewController( booking, true );
			
			
						
			
		}
		
/*		public override float GetHeightForRow (UITableView tableView, NSIndexPath indexPath)
		{
			return 60;
		}*/
		
		
		
	}
}

