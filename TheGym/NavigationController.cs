using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Linq;

namespace TheGym
{
	public class NavigationController : UINavigationController
	{
		HomeViewController _firstController;
		
//		public override void ViewDidLoad ()
//		{
//			_firstController = new HomeViewController();
//			PushViewController(_firstController,true);
//			
//			base.ViewDidLoad ();
//		}
		
		public override void ViewDidLoad ()
		{
			var firstController = new HomeViewController();
							
			var viewControllers = ViewControllers.ToList();
			viewControllers.Add(firstController);
			ViewControllers = viewControllers.ToArray();
	
			base.ViewDidLoad ();
		}
	}
	

	
	
		
}
