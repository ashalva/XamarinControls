using System;
using UIKit;
using CoreGraphics;

namespace IOS.UIPageViewController
{
	public class UIPageViewControllerItem : UIViewController
	{
		#region Constructor

		public UIPageViewControllerItem (int index)
		{
			this.Index = index;
		}

		#endregion

		#region Properties

		public int Index {
			get;
			set;
		}

		#endregion

		#region Overrides

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.LightGray;
			InitUI ();
		}

		#endregion

		#region Methods

		private void InitUI ()
		{
			var padding = 100f;
			UIView mainView = new UIView (new CGRect (padding / 2f, padding, View.Frame.Width - padding, View.Frame.Height - padding * 2));

			var indexLabelHeight = 30f;
			UILabel indexLabel = new UILabel (new CGRect (0, 
				                     mainView.Frame.Height / 2 - indexLabelHeight / 2f,
				                     mainView.Frame.Width,
				                     indexLabelHeight));
			indexLabel.Text = Index.ToString ();
			indexLabel.TextColor = UIColor.Red;
			indexLabel.Font = UIFont.SystemFontOfSize (22);
			mainView.AddSubview (indexLabel);

			View.AddSubview (mainView);
		}

		#endregion
	}
}

