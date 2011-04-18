using System;
using System.Drawing;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace TheGym
{
	public class GymSettingsViewController : UIViewController
	{
		UITextField userNameField;
		UITextField passwordField;
		GymsTableViewController gymsTableViewController;
		
		public GymSettingsViewController()
		{
			GymSettingsDataSource.Read();
		}
		
		public override void ViewDidLoad()
		{
			
			
			Title = "Settings";
			
			View.BackgroundColor = UIColor.Black ;
			
			int spacing = 10;
			
			int gridHight = 25;
			int labelWidth = 100;
			
			int fieldWidth = 320 - spacing * 3 - labelWidth;
			
			float xPos = spacing;
			float yPos = spacing;
			
			
			
			UILabel userNameLabel = new UILabel();
			userNameLabel.Text = "Brukernavn:";
			userNameLabel.BackgroundColor = UIColor.Black;
			userNameLabel.TextColor = UIColor.White;
			userNameLabel.Frame = new RectangleF(xPos,yPos,labelWidth,gridHight);
			View.AddSubview( userNameLabel );
			
			yPos += spacing + gridHight;
			
			UILabel PasswordLabel = new UILabel();
			PasswordLabel.Text = "Passord:";
			PasswordLabel.BackgroundColor = UIColor.Black;
			PasswordLabel.TextColor = UIColor.White;
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
			
			yPos += spacing + gridHight;
			
			
		
			gymsTableViewController = new GymsTableViewController();
			gymsTableViewController.View.Frame = new RectangleF(0,yPos, View.Frame.Width,View.Frame.Height-70);
			View.AddSubview( gymsTableViewController.View );
			
		}
		
		public override void ViewDidDisappear (bool animated)
		{
			userNameField.ResignFirstResponder();
			passwordField.ResignFirstResponder();
			GymSettingsDataSource.UserName = userNameField.Text;
			GymSettingsDataSource.Password = passwordField.Text;
			GymSettingsDataSource.Write();
			TTTHttp.LogOn();
			base.ViewDidDisappear (animated);
		}			
		

	}
}

