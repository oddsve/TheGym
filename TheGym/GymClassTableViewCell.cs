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
		UILabel gym;
		UILabel vacant;
		
		public GymClass _gymClass {set; get; }
		
		public GymClassTableViewCell( GymClass gymClass ) 
		{
			_gymClass = gymClass;
			
			
			classTitle = new UILabel();
			instructor = new UILabel(  );
			classTime = new UILabel();
			gym = new UILabel();
			vacant = new UILabel();
			
			classTitle.BackgroundColor = UIColor.Clear;
			instructor.BackgroundColor = UIColor.Clear;
			classTime.BackgroundColor = UIColor.Clear;
			gym.BackgroundColor = UIColor.Clear;
			vacant.BackgroundColor = UIColor.Clear;
			
			
			classTitle.Text = _gymClass.title;
			instructor.Text = _gymClass.instructor ;
			classTime.Text= _gymClass.time;
			gym.Text = _gymClass.gym;
			
			if ( _gymClass.status == "Fullt" ) 
				vacant.Text = "Fullt";
			else if ( vacant == null )
				vacant.Text ="";
			else 
				vacant.Text = _gymClass.vacant + " ledig" ;
			
			
			UIView backGround = new UIView( new RectangleF( 0,0,Frame.Width ,Frame.Height ) );	
			UIColor textColor = UIColor.White;
			backGround.BackgroundColor = UIColor.Black;
			
			if ( _gymClass.status == "Fullt" )
			{
				backGround.BackgroundColor = UIColor.Gray;
			} else if ( _gymClass.status == "Booket" )
			{
				backGround.BackgroundColor = UIColor.Green;
				textColor = UIColor.Black;
			} 		

			BackgroundView = backGround;                               
			
			float leftColumn = 5;
			float upperMargin = 1;
			float verticalSpace= 1;
			float horisontalSpace = 5;
			float leftLength = 200;
			float heigth = 22;
			float smallHeight = 14;
			
				
			classTitle.Frame = new RectangleF( 	leftColumn, 
		                             		    upperMargin, 
		                                  		leftLength,
		                                  		heigth );
			classTitle.TextColor = textColor;
			AddSubview( classTitle );
			
			gym.Frame = new RectangleF( 	leftColumn + horisontalSpace + leftLength, 
		                            		upperMargin , 
		                            		leftLength , 
		                            		smallHeight );
			gym.TextColor = textColor;
			gym.Font = UIFont.FromName("Arial",10);
			AddSubview( gym  );

			instructor.Frame = new RectangleF(	leftColumn, 
		                                  		upperMargin+heigth+verticalSpace, 
		                                  		leftLength,
		                                  		smallHeight );
			instructor.Font = UIFont.FromName("Arial",10);
			instructor.TextColor = textColor;
			AddSubview( instructor );
			
			
			classTime.Frame = new RectangleF( 	leftColumn + horisontalSpace+ leftLength, 
		                                 		upperMargin + smallHeight , 
		                                 		leftLength , 
		                                 		smallHeight );
			classTime.TextColor = textColor;
			classTime.Font = UIFont.FromName("Arial",10);
			AddSubview( classTime );
			
			vacant.Frame = new RectangleF( 	leftColumn + horisontalSpace+ leftLength, 
		                                 		upperMargin + smallHeight * 2 , 
		                                 		leftLength , 
		                                 		smallHeight );
			vacant.TextColor = textColor;
			vacant.Font = UIFont.FromName("Arial",10);
			AddSubview( vacant );
			
				
		}
		
	}
}

