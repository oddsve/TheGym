using System;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class GymsTableViewDataSource : UITableViewDataSource
	{
		private List<string> gymNames;	
		private List<string> gymKeys;
		
		public GymsTableViewDataSource ()
		{
			gymNames = TTTGyms.getGymNames();
			gymKeys = TTTGyms.getGymKeys();
		}
		
		public override UITableViewCell GetCell ( UITableView tableView, NSIndexPath indexPath )
		{
			UITableViewCell cell =  new UITableViewCell();
			cell.TextLabel.Text = gymNames[ indexPath.Row ];
			cell.TextLabel.TextColor = UIColor.White;
			
			if ( GymSettingsDataSource.selectedGymKeys.Contains( gymKeys[ indexPath.Row ] ) )
			{
				cell.Accessory = UITableViewCellAccessory.Checkmark;
			} else
			{
				cell.Accessory = UITableViewCellAccessory.None;
			}
			return cell;		
		}
		
		public override int RowsInSection ( UITableView tableView, int section )
		{
			return gymNames.Count;
		}
		
		
		public void toggleCell( NSIndexPath indexPath )
		{
			string key = gymKeys[ indexPath.Row ];
			if ( GymSettingsDataSource.selectedGymKeys.Contains( key ) )
			{
				GymSettingsDataSource.selectedGymKeys.Remove( key );
			} else
			{
				GymSettingsDataSource.selectedGymKeys.Add( key );
			}
			
			
		}
	}
}

