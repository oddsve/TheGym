using System;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class GymsTableViewController : UITableViewController
	{
		
		public GymsTableViewController ()
		{
		}
		
		public override void ViewDidLoad ()
		{
			View.BackgroundColor = UIColor.Black;
			TableView.Delegate = new GymsTableViewDelegate();
			TableView.DataSource = new GymsTableViewDataSource();
			
			base.ViewDidLoad ();
		}
	}
}

