
using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Linq;
using System.Collections.Generic;

namespace TheGym
{
	public class ScheduleViewController : UIViewController
	{
		protected ScheduleNavigationController _navigationController;
		
		public ScheduleViewController( ScheduleNavigationController navigationController )
		{
			this._navigationController = navigationController;
		}
			
		public override void ViewDidLoad ()
		{
			/*
			UIBarButtonItem settingsButton = new UIBarButtonItem();
			settingsButton.Title = "Settings";
			settingsButton.Clicked += delegate(object sender, EventArgs e) {
				GymSettingsViewController settingsController = new GymSettingsViewController();
				NavigationController.PushViewController(settingsController,true);
			};
			
			NavigationItem.LeftBarButtonItem = settingsButton;					
			*/
			
			ScheduleTableViewController sheduleTableViewController = new ScheduleTableViewController( this._navigationController );
						
			sheduleTableViewController.View.Frame = new RectangleF( 0,0,View.Frame.Width,View.Frame.Height );
			View.Add ( sheduleTableViewController.View );
			
			base.ViewDidLoad ();
		}
		
		public override void ViewWillAppear (bool animated)
		{
			// Re-show the toolbar here for consistency
	//		NavigationController.SetToolbarHidden(false,true);
			base.ViewWillAppear (animated);
		}
		
		public RectangleF Center(float width,float height)
		{		
			var rect = new RectangleF((View.Frame.Width / 2) - (width /2),(View.Frame.Height / 2) - (height /2),width,height);
			
			// Prints:
			// Rect: {X=110,Y=180,Width=100,Height=100}
			// Frame: {X=0,Y=20,Width=320,Height=460}
			Console.WriteLine("Rect: {0}",rect);
			Console.WriteLine("Frame: {0}",View.Frame);
			
			return rect;
		}
	}
}
