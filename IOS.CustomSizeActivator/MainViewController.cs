using System;
using UIKit;
using CoreText;
using CoreGraphics;

namespace IOS.CustomSizeActivator
{
	public class MainViewController : UIViewController
	{
		UIView _customView;

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			View.BackgroundColor = UIColor.White;
			InitUI ();
		}

		private void InitUI ()
		{
			nfloat padding = 100f;
			nfloat viewWidth = View.Frame.Width - padding;
			nfloat viewHeight = View.Frame.Height - padding * 2;

			_customView = new UIView (new CGRect (
				padding / 2,
				padding,
				viewWidth,
				viewHeight));
			_customView.Layer.CornerRadius = 25f;
			_customView.BackgroundColor = UIColor.Black;	
			View.AddSubview (_customView);

			UIButton startActivator = new UIButton (UIButtonType.System);
			startActivator.SetTitle ("Start Activator", UIControlState.Normal);
			startActivator.Frame = new CGRect (0f, 
				_customView.Frame.Height / 2, 
				_customView.Frame.Width,
				30f);
			_customView.AddSubview (startActivator);
			startActivator.TouchUpInside += StartActivator;


		}

		void StartActivator (object sender, EventArgs e)
		{
			DialogPlugin.CornerRadius = _customView.Layer.CornerRadius;
			DialogPlugin.ShowCustomDialog (_customView.Frame);
		}
	}
}

