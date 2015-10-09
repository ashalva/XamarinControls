using System;
using UIKit;
using System.Collections.Generic;
using CoreAnimation;

namespace IOS.UIPageViewController
{
	public class PageViewController : UIKit.UIPageViewController
	{
		public PageViewController (UIPageViewControllerTransitionStyle style, 
		                           UIPageViewControllerNavigationOrientation orient, 
		                           UIPageViewControllerSpineLocation spine) : base (style, orient, spine)
		{
			
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.NavigationController.NavigationBar.Translucent = false;
			View.BackgroundColor = UIColor.LightGray;
			List<UIPageViewControllerItem> pages = new List<UIPageViewControllerItem> ();
			for (int i = 0; i < 8; i++) {
				pages.Add (new UIPageViewControllerItem (i));
			}

			this.DataSource = new PageDataSource (pages);
			SetViewControllers (new UIViewController[] { pages [0] }, UIPageViewControllerNavigationDirection.Forward, false, s => {
			});
			pages [0].IsActive = true;
		}
	}
}

