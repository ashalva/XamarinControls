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
			//three dotted loading
			View.AddSubview (Loading.ThreeDotLoading (View.Frame));
			//two dotted loading
			View.AddSubview (Loading.TwoDotLoading (View.Frame));
		}
	}
}

