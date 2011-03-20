using System;
using MonoTouch.UIKit;
using MonoTouch.Foundation;

namespace TheGym
{
	public class GymTabBarController : UITabBarController
	{
		GymTabBarControllerDelegate gymDelegate;
		public GymTabBarController ()
		{
			
			
			gymDelegate = new GymTabBarControllerDelegate();
			
				
		}
		
		public override void ViewDidLoad ()
		{
			
			base.ViewDidLoad ();
			
			var tabs = new UIViewController[2];
			
			tabs[0] = new GymNavigationController( GymState.PER_CLASS );
			
			tabs[0].TabBarItem = new UITabBarItem( UITabBarSystemItem.Favorites, GymState.PER_CLASS );
			
			tabs[1] = new GymNavigationController( GymState.PER_GYM );
			
			tabs[1].TabBarItem = new UITabBarItem( "Senter", new UIImage(), GymState.PER_GYM );

			
			
			ViewControllers = tabs;
			
			
			
		}
		
		
	}
}

