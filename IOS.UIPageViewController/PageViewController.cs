using System;
using UIKit;
using System.Collections.Generic;
using CoreAnimation;

namespace IOS.UIPageViewController
{
	public class PageViewController : UIKit.UIPageViewController
	{
		#region Variables

		private List<UIPageViewControllerItem> pages;

		#endregion

		#region Constructor

		public PageViewController (UIPageViewControllerTransitionStyle style, 
		                           UIPageViewControllerNavigationOrientation orient, 
		                           UIPageViewControllerSpineLocation spine) : base (style, orient, spine)
		{
			
		}

		#endregion

		#region Overrides

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.NavigationController.NavigationBar.Translucent = false;
			View.BackgroundColor = UIColor.LightGray;
			pages = new List<UIPageViewControllerItem> ();
			for (int i = 0; i < 8; i++) {
				pages.Add (new UIPageViewControllerItem (i));
			}

			//setting datasource
			this.DataSource = new PageDataSource (pages);
			SetViewControllers (new UIViewController[] { pages [0] }, UIPageViewControllerNavigationDirection.Forward, false, s => {
			});
			pages [0].IsActive = true;
		}

		#endregion

		#region Methods

		public void SkipTheAd (int index)
		{	
			//choose which controller should be the next
			UIPageViewControllerItem controller = null;
			int nextIndex;
			if (pages.Count > 1) {
				if (index < pages.Count - 1) {
					controller = pages [index + 1];
				} else {
					controller = pages [index - 1];
				}
			}

			//removing current page
			pages.RemoveAt (index);

			//changing indexes for navigation
			for (int i = 0; i < pages.Count; i++)
				pages [i].ListIndex = i;

			//if the page was last set empy view controller
			if (pages.Count == 0) {
				SetViewControllers (new UIViewController[] { new UIViewController () }, UIPageViewControllerNavigationDirection.Forward, true, s => {
				});
				return;
			}

			//setting next view controller
			SetViewControllers (new UIViewController[] { controller }, UIPageViewControllerNavigationDirection.Forward, true, s => {
			});
			controller.IsActive = true;
		}

		#endregion
	}
}

