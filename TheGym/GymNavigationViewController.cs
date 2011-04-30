using System;
using System.Drawing;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace TheGym
{
	public class GymNavigationViewController : UIViewController
	{
		List<UIButton> elements = new List<UIButton>();
		public GymNavigationViewController ()
		{
			
		}
		
		public override void ViewDidLoad ()
		{
			View.BackgroundColor = UIColor.Black;
			Title = "TheGym";
			
			for ( int i = 0 ;i< 7 ; i++)
			{
				ScheduleButton element = new ScheduleButton( DateTime.Now.AddDays( i ) );		
				element.TouchUpInside += delegate(object sender, EventArgs e) 
				{
					ScheduleButton btn = ( ScheduleButton ) sender;
					this.NavigationController.PushViewController( btn.scheduleViewController,true );
				};
				
				elements.Add(element);
			}
			
			ScheduleButton booking = new ScheduleButton( "mine bestillinger" );
			booking.TouchUpInside += delegate(object sender, EventArgs e) 
			{
				ScheduleButton btn = ( ScheduleButton ) sender;
				this.NavigationController.PushViewController( btn.scheduleViewController,true );
			};
			
			elements.Add( booking );
			
			
			
			
			UIButton settings = new UIButton();
			settings.SetBackgroundImage(  UIImage.FromFile ("images/grey.png"), UIControlState.Normal );
			settings.SetTitle( "innstillinger",UIControlState.Normal);
			settings.TouchUpInside += delegate(object sender, EventArgs e) {
				this.NavigationController.PushViewController( new GymSettingsViewController(),true );
			};
			
			elements.Add( settings );
			
		}
		
		public override void ViewDidAppear (bool animated)
		{
			float border = 0;
			float gridHight = ( View.Frame.Height-border) / 9;
			float gridWidh = View.Frame.Width ;
			float ypos = 0;
			float xpos = 0;
			

			for ( int i = 0; i < 9 ; i ++ )
			{
				elements[i].Frame = new RectangleF(xpos+border,ypos+border,gridWidh-2*border , gridHight-border  );
				View.AddSubview (elements[i]);
			
				ypos += gridHight;
			
			}
	
		
		}
	}
}

