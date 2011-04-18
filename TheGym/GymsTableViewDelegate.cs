using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class GymsTableViewDelegate : UITableViewDelegate
	{
		public GymsTableViewDelegate (  )
		{
		}
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
					
			GymsTableViewDataSource dataSoruce = (GymsTableViewDataSource) tableView.DataSource;
			dataSoruce.toggleCell (indexPath );
			tableView.ReloadData();
		}
	}
}

