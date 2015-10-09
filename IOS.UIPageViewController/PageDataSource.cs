using System;
using System.Collections.Generic;
using UIKit;

namespace IOS.UIPageViewController
{
	public class PageDataSource : UIPageViewControllerDataSource
	{
		readonly List<UIPageViewControllerItem> _pages;

		public UIPageViewControllerItem OldPage { get; set; }

		public UIPageViewControllerItem CurrentPage { get; set; }

		public PageDataSource (List<UIPageViewControllerItem> pages)
		{
			_pages = pages;
		}

		override public UIViewController GetPreviousViewController (UIKit.UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			CurrentPage = referenceViewController as UIPageViewControllerItem;
			if (CurrentPage != null) {

				if (OldPage != null)
					OldPage.IsActive = false;
				CurrentPage.IsActive = true;

				OldPage = CurrentPage;

				if (CurrentPage.ListIndex == 0) {
					return null;
				} else {
					return _pages [CurrentPage.ListIndex - 1];
				}
			} else
				return null;
		}

		override public UIViewController GetNextViewController (UIKit.UIPageViewController pageViewController, UIViewController referenceViewController)
		{
			CurrentPage = referenceViewController as UIPageViewControllerItem;
			if (CurrentPage != null) {

				if (CurrentPage.ListIndex != 0) {
					if (OldPage != null)
						OldPage.IsActive = false;
					CurrentPage.IsActive = true;
					OldPage = CurrentPage;
				}

				if (CurrentPage.ListIndex == _pages.Count - 1) {
					return null;
				}

				return _pages [(CurrentPage.ListIndex + 1)];
			} else
				return null;
		}

	}
}

