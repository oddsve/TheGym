using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class GymClassTableViewCell : UITableViewCell
	{
		UILabel classTitle ;
		UILabel instructor;
		UILabel classTime;
		UILabel classDate;
		UILabel gym;
		
		public GymClass _gymClass {set; get; }
		
		public GymClassTableViewCell( GymClass gymClass ) 
		{
			_gymClass = gymClass;
			
			classTitle = new UILabel();
			instructor = new UILabel(  );
			classTime = new UILabel();
			classDate = new UILabel();
			gym = new UILabel();
			
			
			
		}
		
		public void setGymView()
		{
			classTitle.Text = _gymClass.title;
			classTitle.Frame = new RectangleF(5,5,100,25);
			AddSubview( classTitle );
			
			
		}
		
	}
}

