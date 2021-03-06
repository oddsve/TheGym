using System;
using System.Drawing;
using MonoTouch.UIKit;
using System.Globalization;

namespace TheGym
{
	public class ScheduleButton : UIButton
	{
		public DateTime scheduleDate {get; set; }
		public ScheduleViewController scheduleViewController { get; set; }
	
		public ScheduleButton( DateTime scheduleDate )
		{
			this.scheduleDate = scheduleDate;
			CultureInfo no = new CultureInfo("nn-NO");
			
			string dayName = scheduleDate.ToString("dddd",no);
			SetTitle(dayName.Substring(0,1).ToUpper() + dayName.Substring(1,dayName.Length-1),UIControlState.Normal);

			
			scheduleViewController = new ScheduleViewController( scheduleDate, false );
			SetBackgroundImage( UIImage.FromFile ("images/violet.png" ), UIControlState.Normal );
			SetBackgroundImage( UIImage.FromFile ("images/blue.png" ), UIControlState.Highlighted );
			initiate();
		}
		
		public ScheduleButton( string title )
		{
			this.scheduleDate = DateTime.Now;
			SetTitle( title, UIControlState.Normal );
			scheduleViewController = new ScheduleViewController( scheduleDate,true );
			SetBackgroundImage( UIImage.FromFile ("images/green.png" ), UIControlState.Normal );
			SetBackgroundImage( UIImage.FromFile ("images/blue.png" ), UIControlState.Highlighted );
			initiate();
		}
		
		private void initiate()
		{
			BackgroundColor = UIColor.Black;
			
			SetTitleColor( UIColor.White, UIControlState.Normal);	
		}
		
		
	}
}

