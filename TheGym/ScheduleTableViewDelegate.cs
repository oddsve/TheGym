using System;
using System.Collections.Generic;

using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewDelegate : UITableViewDelegate
	{
		private ScheduleTableViewController _controller;
		private ScheduleNavigationController _navigator;
		
		public ScheduleTableViewDelegate ( ScheduleTableViewController controller
		                                  	, ScheduleNavigationController navigator) :base()
		{
			this._controller = controller;
			this._navigator = navigator;
		}
		
		
		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			
			ScheduleTableViewDataSource dataSource = ( ScheduleTableViewDataSource ) _controller.TableView.DataSource;
			
			
			
			BookingViewController booking = new BookingViewController( dataSource.Gyms[ indexPath.Row ].title,
			                                                          dataSource.Gyms[ indexPath.Row ].status );			
			_navigator.PushViewController( booking, true );
			
			
			
						
			
		}
		
		
		
		
	}
}

