using System;
using CoreGraphics;
using UIKit;

namespace IOS.CustomSizeActivator
{
	public class DialogPlugin
	{
		public static nfloat CornerRadius {
			get;
			set;
		}

		public static void ShowCustomDialog (CGRect frame)
		{
			AppDelegate app = UIApplication.SharedApplication.Delegate as AppDelegate;
			app.ActivityIndicator = new UIActivityIndicatorView (UIActivityIndicatorViewStyle.WhiteLarge);//[[UIActivityIndicatorView alloc]initWithActivityIndicatorStyle:UIActivityIndicatorViewStyleGray];
			app.ActivityIndicator.BackgroundColor = UIColor.Gray;
			app.ActivityIndicator.Alpha = 0.5f;
			app.ActivityIndicator.Frame = frame;
			app.ActivityIndicator.Layer.CornerRadius = CornerRadius;
			app.ActivityIndicator.Center = app.Window.Center;   
			app.Window.AddSubview (app.ActivityIndicator);
			app.ActivityIndicator.StartAnimating ();
			UIApplication.SharedApplication.NetworkActivityIndicatorVisible = true;
		}
	}
}

