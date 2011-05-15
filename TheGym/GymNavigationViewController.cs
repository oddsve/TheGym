using System;
using System.Drawing;
using MonoTouch.UIKit;
using System.Collections.Generic;

namespace TheGym
{
	public class GymNavigationViewController : UIViewController
	{
		List<UIButton> elements ;
		UIButton settingsButton ;

		public GymNavigationViewController ()
		{
			
		}
		
		public override void ViewDidLoad ()
		{
			View.BackgroundColor = UIColor.Black;
			Title = "Velg dag";
			
			
			arrangeMenu();
		}
		
		
		public void arrangeMenu()
		{
			elements = new List<UIButton>();
					
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
			
			ScheduleButton booking = new ScheduleButton( "Mine bestillinger" );
			booking.TouchUpInside += delegate(object sender, EventArgs e) 
			{
				ScheduleButton btn = ( ScheduleButton ) sender;
				this.NavigationController.PushViewController( btn.scheduleViewController,true );
			};
			
			elements.Add( booking );
			
			
			
			
			settingsButton = new UIButton();
			settingsButton.SetBackgroundImage(  UIImage.FromFile ("images/grey.png"), UIControlState.Normal );
			settingsButton.SetBackgroundImage(  UIImage.FromFile ("images/blue.png"), UIControlState.Highlighted );
			
			settingsButton.SetTitle( "Innstillinger",UIControlState.Normal);
			settingsButton.TouchUpInside += delegate(object sender, EventArgs e) {
				this.NavigationController.PushViewController( new GymSettingsViewController(),true );
			};
			
			elements.Add ( settingsButton );

			
		}
		
		public override void ViewDidAppear (bool animated)
		{
			
			NavigationController.NavigationBar.BackgroundColor = UIColor.FromPatternImage( UIImage.FromFile ("images/blue.png") );
			float border = 0;
			float gridHight = ( View.Frame.Height-border) / elements.Count;
			float gridWidh = View.Frame.Width ;
			float ypos = 0;
			float xpos = 0;
			
			for ( int i = 0; i < elements.Count ; i ++ )
			{
				
				elements[i].Frame = new RectangleF(xpos+border,ypos+border,gridWidh-2*border , gridHight-border  );
				View.AddSubview (elements[i]);
			
				ypos += gridHight;
			
			}
				
			
			if ( GymSettingsDataSource.UserName == null || GymSettingsDataSource.Password == null )
			{
				
				NavigationController.PushViewController( new GymSettingsViewController(), true );
			}
			else TTTHttp.LogOn() ;
			
			if ( TTTHttp.isError ) 
			{
				UIAlertView alert = new UIAlertView();
				alert.Title = "Påloggingsfeil";
				alert.Message = Text.getString( TTTHttp.ErrorMessage ) ;
				alert.AddButton("OK");
				alert.Show();	
				NavigationController.PushViewController( new GymSettingsViewController(), true );

			}

		}
	}
}

