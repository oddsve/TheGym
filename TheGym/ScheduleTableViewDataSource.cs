using System;

using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewDataSource : UITableViewDataSource
	{
		protected List<GymClass> _gyms;
		
		
		public List<GymClass> Gyms
		{
			get { return this._gyms; }
			set { this._gyms = value; }
		}
		
		
		
		public ScheduleTableViewDataSource ( DateTime scheduleDate, bool myBookings  )
		{
			if ( myBookings ) this._gyms = TTTBookings.getMyBookings();
			else this._gyms = TTTSchedules.getSchedules( scheduleDate );
			
		}

		
		//Overrided methods
		public override int RowsInSection (UITableView tableView, int section )
		{
			return this._gyms.Count;
		}
		
		public override UITableViewCell GetCell ( UITableView tableView, NSIndexPath indexPath )
		{

			GymClassTableViewCell tableViewCell = new GymClassTableViewCell( _gyms[ indexPath.Row ] );
			
			return tableViewCell;
			
			
		}
	}
}

