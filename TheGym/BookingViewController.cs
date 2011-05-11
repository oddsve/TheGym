using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class BookingViewController : UIViewController
	{
		UIButton bookButton;
		GymClass gymClass;		
		UITableView tableView;
		NSIndexPath indexPath;
		
		public BookingViewController ( GymClass gymClass, UITableView tableView, NSIndexPath indexPath ) 
		{
			Title = gymClass.title;
			this. gymClass = gymClass;	
			this.tableView = tableView;
			this.indexPath = indexPath;
			
		}
		
		private void setButton() 
		{
			
			if ( ! GymSettingsDataSource.isLogedOn ) 
			{
				bookButton.SetTitle("Ikke pålogget",UIControlState.Normal );
				bookButton.Enabled = false;
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/greybutton.png" ), UIControlState.Normal );
				
			}
			else if ( gymClass.bookAction == null && gymClass.unbookAction == null )
			{
				if ( gymClass.booked )
					bookButton.SetTitle("Kan ikke avbestilles",UIControlState.Normal );
				else
					bookButton.SetTitle("Kan ikke bestilles",UIControlState.Normal );
				bookButton.Enabled = false;	
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/greybutton.png" ), UIControlState.Normal );
			}
			else if ( gymClass.booked ) 
			{
				bookButton.SetTitle("Avbestill",UIControlState.Normal );
				bookButton.SetTitle("Sender avbestilling",UIControlState.Highlighted );
				bookButton.Enabled = true;
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/redbutton.png" ), UIControlState.Normal );
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/greybutton.png" ), UIControlState.Highlighted );
			}
			else if ( gymClass.fullt ) 
			{
				bookButton.SetTitle("Fullt",UIControlState.Normal );
				bookButton.Enabled = false;	
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/greybutton.png" ), UIControlState.Normal );
			} 
			else 
			{
				bookButton.SetTitle("Bestill",UIControlState.Normal );
				bookButton.SetTitle("Sender bestilling",UIControlState.Highlighted );
				bookButton.Enabled = true;	
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/greenbutton.png" ), UIControlState.Normal );				
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/greybutton.png" ), UIControlState.Highlighted );
			}
		}

		public override void ViewDidLoad ()
		{
			
			View.BackgroundColor = UIColor.Black;		
			bookButton = new UIButton( new RectangleF(10,100,this.View.Frame.Width-10 ,40) );
			
			
			bookButton.BackgroundColor = UIColor.Clear;
			setButton();
			
			bookButton.TouchUpInside += delegate {
				gymClass.book();
				System.Console.WriteLine( gymClass.unbookAction);
				ScheduleTableViewDataSource ds = ( ScheduleTableViewDataSource ) tableView.DataSource;
				if ( ! ds.isMyBookings ) 
				{
					ds.force = true;
					ds.ReloadData();
				}
				tableView.ReloadData();
				gymClass = ds.getGymClass( indexPath );
				setButton();
			
			};

			this.View.AddSubview( bookButton );
			                                   
		}
		
		
	}
}

