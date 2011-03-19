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
			
			classTitle.Text = _gymClass.title;
			instructor.Text = _gymClass.instructor;
			classTime.Text= _gymClass.time;
			gym.Text = _gymClass.gym;
			
			
			float leftColumn = 5;
			float upperMargin = 1;
			float verticalSpace= 1;
			float horisontalSpace = 5;
			float leftLength = 200;
			float heigth = 20;
			
			
			
			if ( GymState.PerViewType == GymState.PER_GYM ) {
				
				classTitle.Frame = new RectangleF( leftColumn, upperMargin, leftLength,heigth );
				AddSubview( classTitle );
				
				instructor.Frame = new RectangleF(leftColumn, upperMargin+heigth+verticalSpace, leftLength,heigth );
				AddSubview( instructor );
				
				
				classTime.Frame = new RectangleF( leftColumn + horisontalSpace+ leftLength, upperMargin + heigth , leftLength , heigth );
				AddSubview( classTime );
			} else if ( GymState.PerViewType == GymState.PER_CLASS ) 
			{
				
				gym.Frame = new RectangleF( leftColumn, upperMargin, leftLength,heigth );
				AddSubview( gym  );
				
				instructor.Frame = new RectangleF(leftColumn, upperMargin+heigth+verticalSpace, leftLength,heigth );
				AddSubview( instructor );
				
				
				classTime.Frame = new RectangleF( leftColumn + horisontalSpace+ leftLength, upperMargin + heigth , leftLength , heigth );
				AddSubview( classTime );

			}
			
		}
		
	}
}

