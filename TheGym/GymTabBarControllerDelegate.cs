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
		
	}
}

