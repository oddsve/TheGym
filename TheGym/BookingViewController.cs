using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class BookingViewController : UIViewController
	{
		public BookingViewController ( String title ) 
		{
			Title = title;
		}
		public override void ViewDidLoad ()
		{
			
			
			
			View.BackgroundColor = UIColor.Black;
			
			UIButton bookButton = new UIButton( new RectangleF(10,100,this.View.Frame.Width-10 ,40) );
			bookButton.SetTitle("Bestill",UIControlState.Normal );
			bookButton.BackgroundColor = UIColor.Clear;
			bookButton.SetBackgroundImage( UIImage.FromFile ("images/greybutton.png" ), UIControlState.Normal );
			bookButton.TouchDown += delegate {
					
			};

			this.View.AddSubview( bookButton );
			                                   
		}
		
		
	}
}

