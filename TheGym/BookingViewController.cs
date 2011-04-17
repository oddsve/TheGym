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
		
		public BookingViewController ( GymClass gymClass, UITableView tableView ) 
		{
			Title = gymClass.title;
			this. gymClass = gymClass;	
			this.tableView = tableView;
			
		}
		
		private void setButton() 
		{
			
			if ( gymClass.booked ) 
			{
				bookButton.SetTitle("Avbestill",UIControlState.Normal );
				bookButton.Enabled = true;
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/redbutton.png" ), UIControlState.Normal );
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
				bookButton.Enabled = true;	
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/greenbutton.png" ), UIControlState.Normal );				
			}
		}

		public override void ViewDidLoad ()
		{
			
			View.BackgroundColor = UIColor.Black;
			
			bookButton = new UIButton( new RectangleF(10,100,this.View.Frame.Width-10 ,40) );
			bookButton.BackgroundColor = UIColor.Clear;
			setButton();
			
			bookButton.TouchDown += delegate {
					
				gymClass.book();
				setButton();
				tableView.ReloadData();
					
			};

			this.View.AddSubview( bookButton );
			                                   
		}
		
		
	}
}

