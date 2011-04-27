using System;

using System.Collections.Generic;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class ScheduleTableViewDataSource : UITableViewDataSource
	{
		protected List<GymClass> _gyms;
		
		private DateTime scheduleDate;
		private bool myBookings;
		private DateTime reloadTimeStamp;
		private string gymKeys;
		
		
		public List<GymClass> Gyms
		{
			get { return this._gyms; }
			set { this._gyms = value; }
		}
		

		
		public ScheduleTableViewDataSource ( DateTime scheduleDate, bool myBookings  )
		{
			this.myBookings = myBookings;
			this.scheduleDate = scheduleDate;
					
		}
		 
		
		public void ReloadData ( bool forse )
		{
			if ( myBookings ) 
			{
				if ( !GymSettingsDataSource.isLogedOn ) 
				{
					GymClass notLoggedIn = new GymClass("Ikke logget inn", "Gå til settings" , "");
					_gyms = new List<GymClass>();
					_gyms.Add( notLoggedIn );
				}
				else
				{
					this._gyms = TTTBookings.getMyBookings();
				}
			}
			else 
				if ( forse 
				    || gymKeys != GymSettingsDataSource.gymKeyString 
				    || reloadTimeStamp.AddMinutes(1) < DateTime.Now )
				{
					gymKeys = GymSettingsDataSource.gymKeyString;
					this._gyms = TTTSchedules.getSchedules( scheduleDate );
					reloadTimeStamp = DateTime.Now;
				}
			
		}
		
		public GymClass getGymClass( NSIndexPath indexPath)
		{
			return _gyms[ indexPath.Row ];
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

