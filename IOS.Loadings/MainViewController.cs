using System;
using UIKit;
using CoreGraphics;

namespace IOS.Loadings
{
	public class MainViewController : UIPageViewController
	{

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;
			InitUI ();
		}

		private void InitUI ()
		{
			//Three dotted loading with moving effect
			View.AddSubview (Loading.ThreeDotLoading (View.Frame));
			//Two dotted loading
			View.AddSubview (Loading.TwoDotLoading (View.Frame));
			//Square Loading
			View.AddSubview (Loading.SquareLoading (View.Frame));
			//Three dotted loading with zoom effect
			View.AddSubview (Loading.ThreeDotLoadingZooming (View.Frame));
			// Multiple Lines loading
			View.AddSubview (Loading.MultipleLinesLoading (View.Frame));
		}
	}
}

