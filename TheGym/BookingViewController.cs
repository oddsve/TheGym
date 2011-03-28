using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class BookingViewController : UIViewController
	{
		UIButton bookButton;
		Boolean _booked;
		
		
		public BookingViewController ( String title , Boolean booked) 
		{
			Title = title;
			_booked = booked;

			
			
		}
		
		private void setButton() 
		{
			if ( _booked ) 
			{
				bookButton.SetTitle("Avbestill",UIControlState.Normal );
				bookButton.SetBackgroundImage( UIImage.FromFile ("images/redbutton.png" ), UIControlState.Normal );
			} else 
			{
				bookButton.SetTitle("Bestill",UIControlState.Normal );
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
				_booked = !_booked;
				setButton();
					
			};

			this.View.AddSubview( bookButton );
			                                   
		}
		
		
	}
}

