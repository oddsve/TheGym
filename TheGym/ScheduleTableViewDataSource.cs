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
		
		
/*		public ScheduleTableViewDataSource (   )
		{
			TTTSchedule schedule = new TTTSchedule( );
			this._gyms = schedule.GymSchedules;
			//this._gyms = session.getGymSchedule();
		}

*/
		
		public ScheduleTableViewDataSource (   )
		{
			
			_gyms = new List<GymClass>();
			
			GymClass gc = new GymClass();
			gc.title = "Spinning";
			gc.time = "09.40";
			gc.instructor = "Klara Ku";
			gc.gym = "Rosten";
			gc.date = "12.12.2011";
			_gyms.Add ( gc );
			
			gc = new GymClass();
			gc.title = "Spinning";
			gc.time = "09.40";
			gc.instructor = "Klara Ku";
			gc.gym = "Rosten";
			gc.date = "12.12.2011";
			_gyms.Add ( gc );

			gc = new GymClass();
			gc.title = "Spinning";
			gc.time = "09.40";
			gc.instructor = "Klara Ku";
			gc.gym = "Rosten";
			gc.date = "12.12.2011";
			_gyms.Add ( gc );

			gc = new GymClass();
			gc.title = "Spinning";
			gc.time = "09.40";
			gc.instructor = "Klara Ku";
			gc.gym = "Rosten";
			gc.date = "12.12.2011";
			_gyms.Add ( gc );
			
			//this._gyms = session.getGymSchedule();
		}
		
		
		//Overrided methods
		public override int RowsInSection (UITableView tableView, int section )
		{
			return this._gyms.Count;
			//return 1;
		}
		
		public override UITableViewCell GetCell ( UITableView tableView, NSIndexPath indexPath )
		{
			UITableViewCell cell =  new UITableViewCell ();
			GymClassTableViewCell tableViewCell = new GymClassTableViewCell( _gyms[ indexPath.Row ] );
			
			cell = tableViewCell;
			
			
			return cell;
		}
	}
}

