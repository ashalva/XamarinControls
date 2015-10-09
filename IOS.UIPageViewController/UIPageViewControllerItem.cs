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
			this.ListIndex = index;
			this.RealIndex = index;
		}

		#endregion

		#region Properties

		public int ListIndex {
			get;
			set;
		}

		public int RealIndex {
			get;
			set;
		}

		private bool _isActive;

		public bool IsActive {
			get { return _isActive; }
			set { 
				if (value) {
					// you can use this property set for any logic on item activation
					_isActive = true;
					_listIndexLabel.Text = String.Format ("{0}:{1}", "list-index", ListIndex);
					_listIndexLabel.SizeToFit ();
					_listIndexLabel.Frame = new CGRect ((_mainView.Frame.Width - _listIndexLabel.Frame.Width) / 2f,
						(_mainView.Frame.Height - _listIndexLabel.Frame.Height) / 2f,
						_listIndexLabel.Frame.Width,
						_listIndexLabel.Frame.Height);

					// setting real index for
					_realIndexLabel.Text = String.Format ("{0}:{1}", "real-index", RealIndex);
					_realIndexLabel.SizeToFit ();
					_realIndexLabel.Frame = new CGRect ((_mainView.Frame.Width - _realIndexLabel.Frame.Width) / 2f,
						_listIndexLabel.Frame.Bottom + 10f,
						_realIndexLabel.Frame.Width,
						_realIndexLabel.Frame.Height);
				} else {
					_isActive = false;
					_listIndexLabel.Text = String.Empty;
				}
			}
		}

		#endregion

		#region UI

		private UILabel _listIndexLabel;
		private UILabel _realIndexLabel;
		private UIView _mainView;

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
			nfloat padding = 100f;
			
			_mainView = new UIView (new CGRect (padding / 2f, 
				padding / 2f,
				View.Frame.Width - padding, 
				View.Frame.Height - padding * 2));

			_mainView.BackgroundColor = UIColor.Gray;
			_mainView.Layer.BorderWidth = 5f;
			_mainView.Layer.BorderColor = UIColor.DarkGray.CGColor;
			_mainView.Layer.CornerRadius = 20f;

			_listIndexLabel = new UILabel ();
			_listIndexLabel.TextColor = UIColor.Red;
			_listIndexLabel.Font = UIFont.SystemFontOfSize (40);

			_realIndexLabel = new UILabel ();
			_realIndexLabel.TextColor = UIColor.Red;
			_realIndexLabel.Font = UIFont.SystemFontOfSize (35);

			UIButton skip = new UIButton (UIButtonType.System);
			skip.SetTitle ("Skip Item", UIControlState.Normal);
			skip.Frame = new CGRect (0, _mainView.Frame.Bottom - 100f, _mainView.Frame.Width, 40f);
			skip.TouchUpInside += SkipTheItem;
			skip.TintColor = UIColor.White;


			_mainView.AddSubview (_realIndexLabel);
			_mainView.AddSubview (_listIndexLabel);
			_mainView.AddSubview (skip);

			View.AddSubview (_mainView);
		}

		void SkipTheItem (object sender, EventArgs e)
		{
			if (ParentViewController != null) {
				(ParentViewController as PageViewController).SkipTheAd (this.ListIndex);
			}
		}

		#endregion
	}
}

