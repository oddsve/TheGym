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
		public bool isMyBookings{ get; set; }
		private DateTime reloadTimeStamp;
		private string gymKeys;
		
		public bool force {get; set; }
		
		
		public List<GymClass> Gyms
		{
			get { return this._gyms; }
			set { this._gyms = value; }
		}
		

		
		public ScheduleTableViewDataSource ( DateTime scheduleDate, bool myBookings  )
		{
			this.isMyBookings = myBookings;
			this.scheduleDate = scheduleDate;
					
		}
		
		public bool needToReload()
		{
			return ( force 
				     || gymKeys != GymSettingsDataSource.gymKeyString 
				     || reloadTimeStamp.AddMinutes(1) < DateTime.Now );
		}
		
		public void ReloadData ( )
		{
			if ( isMyBookings ) 
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
				if ( needToReload() )
				{
					gymKeys = GymSettingsDataSource.gymKeyString;
					this._gyms = TTTSchedules.getSchedules( scheduleDate );
					reloadTimeStamp = DateTime.Now;
					force= false;
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

