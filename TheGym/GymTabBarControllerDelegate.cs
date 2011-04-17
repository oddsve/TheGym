using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class GymTabBarControllerDelegate : UITabBarControllerDelegate
	{
		public GymTabBarControllerDelegate ()
		{
			
		}
		
		public override void DidChangeValue ( string forKey )			                                  
		{
			base.DidChangeValue (forKey);
			System.Console.WriteLine( "HHHH" + forKey );
			
			
			
		}
		
		public override void ViewControllerSelected (UITabBarController tabBarController, UIViewController viewController)
		{
			// TODO: Implement - see: http://go-mono.com/docs/index.aspx?link=T%3aMonoTouch.Foundation.ModelAttribute
		}
		
	
		
	}
}

