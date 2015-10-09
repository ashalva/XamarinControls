using System;
using UIKit;

namespace IOS.UIPageViewController
{
	public class PageViewController : UIKit.UIPageViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.LightGray;
		}
	}
}

