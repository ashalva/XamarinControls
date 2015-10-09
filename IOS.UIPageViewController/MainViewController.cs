using System;
using UIKit;
using CoreGraphics;
using System.Runtime.InteropServices;

namespace IOS.UIPageViewController
{
	public class MainViewController: UIViewController
	{
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			NavigationController.NavigationBarHidden = false;
			NavigationController.NavigationBar.BackgroundColor = UIColor.Black;

			View.BackgroundColor = UIColor.White;
			UIButton startPageViewControler = new UIButton (UIButtonType.System);
			startPageViewControler.SetTitle ("Start UIPageViewController", UIControlState.Normal);
			startPageViewControler.Frame = new CGRect (0, View.Frame.Height / 2, View.Frame.Width, 30f);
			startPageViewControler.TouchUpInside += StartUIPageViewController;

			View.AddSubview (startPageViewControler);
		}

		void StartUIPageViewController (object sender, EventArgs e)
		{
			InvokeOnMainThread (() => {
				NavigationController.PushViewController (new PageViewController (), true);
			});
		}
	}
}

