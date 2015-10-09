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

		private bool _isActive;

		public bool IsActive {
			get { return _isActive; }
			set { 
				if (value) {
					_isActive = true;
					_indexLabel.Text = String.Format ("{0}:{1}", "index", Index.ToString ());
				} else {
					_isActive = false;
					_indexLabel.Text = String.Empty;
				}
			}
		}

		#endregion

		#region UI

		private UILabel _indexLabel;

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

		private nfloat GetStatusBarHeight ()
		{
			nfloat statusBarInfoHeight = UIApplication.SharedApplication.StatusBarFrame.Height;			
			if (statusBarInfoHeight < 20) {
				statusBarInfoHeight = 20;
			}
			statusBarInfoHeight = 20;
			return (statusBarInfoHeight + this.NavigationController.NavigationBar.Frame.Height);
		}

		private void InitUI ()
		{
			nfloat padding = 100f;
			
			UIView mainView = new UIView (new CGRect (padding / 2f, 
				                  padding / 2f,
				                  View.Frame.Width - padding, 
				                  View.Frame.Height - padding * 2));

			var indexLabelHeight = 150f;
			_indexLabel = new UILabel (new CGRect (20f, 
				mainView.Frame.Height / 2 - indexLabelHeight / 2f,
				mainView.Frame.Width,
				indexLabelHeight));
			mainView.BackgroundColor = UIColor.Gray;
			mainView.Layer.BorderWidth = 5f;
			mainView.Layer.BorderColor = UIColor.DarkGray.CGColor;
			mainView.Layer.CornerRadius = 20f;
			_indexLabel.TextColor = UIColor.Red;
			_indexLabel.Font = UIFont.SystemFontOfSize (50);
			mainView.AddSubview (_indexLabel);

			View.AddSubview (mainView);
		}

		#endregion
	}
}

