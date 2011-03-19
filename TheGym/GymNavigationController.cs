using System;
using MonoTouch.UIKit;
using System.Drawing;
using System.Linq;

namespace TheGym
{
	public class GymNavigationController : UINavigationController
	{
		int _perViewType;
		
		public GymNavigationController( int perViewType ) 
		{
			_perViewType = perViewType;
		}
		
		public override void ViewDidLoad ()
		{
			GymState.PerViewType = _perViewType;
			
			var firstController = new ScheduleViewController();
							
			var viewControllers = ViewControllers.ToList();
			viewControllers.Add(firstController);
			ViewControllers = viewControllers.ToArray();
	
			base.ViewDidLoad ();
		}
	}
	

	
	
		
}
