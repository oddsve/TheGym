using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewDelegate : UITableViewDelegate
	{
		private ScheduleNavigationController _navigator;
		
		public ScheduleTableViewDelegate (  ScheduleNavigationController navigator) :base()
		{
			this._navigator = navigator;
		}
		
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			
			ScheduleTableViewDataSource dataSource = ( ScheduleTableViewDataSource ) tableView.DataSource;
				
			
			
			
			BookingViewController booking = new BookingViewController( dataSource.Gyms[ indexPath.Row ] );			
			_navigator.PushViewController( booking, true );
			
			
			
						
			
		}
		
		
		
		
	}
}

