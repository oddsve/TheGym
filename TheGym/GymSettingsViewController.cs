using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class GymSettingsViewController : UIViewController
	{
		UINavigationController _navigationController;
		UITextField userNameField;
		UITextField passwordField;
		
		
		public override void ViewDidLoad()
		{
			
			
			Title = "Settings";
			
			View.BackgroundColor = UIColor.White;
			
			int spacing = 10;
			
			int gridHight = 25;
			int labelWidth = 100;
			
			int fieldWidth = 320 - spacing*3 - labelWidth;
			
			int xPos = spacing;
			int yPos = spacing;
			
			
			
			UILabel userNameLabel = new UILabel();
			userNameLabel.Text = "Brukernavn:";
			userNameLabel.Frame = new RectangleF(xPos,yPos,labelWidth,gridHight);
			View.AddSubview( userNameLabel );
			
			yPos += spacing + gridHight;
			
			UILabel PasswordLabel = new UILabel();
			PasswordLabel.Text = "Passord:";
			PasswordLabel.Frame = new RectangleF(xPos,yPos,labelWidth,gridHight);
			View.AddSubview( PasswordLabel );
			
			xPos += spacing + labelWidth;
			yPos = spacing;
			
			userNameField = new UITextField( new RectangleF(xPos,yPos,fieldWidth,gridHight) );
			userNameField.BorderStyle = UITextBorderStyle.RoundedRect;
			userNameField.AutocorrectionType = UITextAutocorrectionType.No;
			userNameField.Placeholder = "Brukernavn";		
			userNameField.Text = GymSettingsDataSource.UserName;
			View.Add( userNameField );
			
			yPos += spacing + gridHight;
			
			passwordField = new UITextField( new RectangleF(xPos,yPos,fieldWidth,gridHight) );
			passwordField.BorderStyle = UITextBorderStyle.RoundedRect;
			passwordField.AutocorrectionType = UITextAutocorrectionType.No;
			passwordField.SecureTextEntry = true;
			passwordField.Placeholder = "Passord";
			passwordField.Text = GymSettingsDataSource.Password;
			View.Add( passwordField );
			
		}
		
			
		public override void ViewWillDisappear (bool animated)
		{
			GymSettingsDataSource.UserName = userNameField.Text;
			GymSettingsDataSource.Password = passwordField.Text;
			GymSettingsDataSource.Write();
		}
		

	}
}

