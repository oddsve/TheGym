using System;
using System.Drawing;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class BookingViewController : UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			
			
			UIButton bookButton = new UIButton( new RectangleF(10,100,this.View.Frame.Width-10 ,20) );
			bookButton.SetTitle("Bestill",UIControlState.Normal );
			
			this.View.AddSubview( bookButton );
			                                   
		}
		
	}
}

