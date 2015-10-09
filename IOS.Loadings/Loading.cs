using System;
using UIKit;
using CoreGraphics;

namespace IOS.Loadings
{
	public class Loading
	{
		nfloat _padding = 50f;

		public static UIView ThreeDotLoading (CGRect frame)
		{
			
			var loadingView = new UIView (new CGRect ((frame.Width - _padding) / 2f, _padding, _padding, _padding));

			var dotDiameter = 10f;
			var padding = 4f;

			UIView middleDot = new UIView (new CGRect (
				                   (loadingView.Frame.Width - dotDiameter) / 2f,
				                   (loadingView.Frame.Height - dotDiameter) / 2f,
				                   dotDiameter,
				                   dotDiameter
			                   ));
			middleDot.Layer.CornerRadius = dotDiameter / 2f;
			middleDot.BackgroundColor = UIColor.Gray;

			UIView leftDot = new UIView (
				                 new CGRect (
					                 middleDot.Frame.Left - dotDiameter - padding,
					                 middleDot.Frame.Y,
					                 dotDiameter,
					                 dotDiameter
				                 ));
			leftDot.Layer.CornerRadius = dotDiameter / 2f;
			leftDot.BackgroundColor = UIColor.Gray;

			UIView rightDot = new UIView (
				                  new CGRect (
					                  middleDot.Frame.Right + padding,
					                  middleDot.Frame.Y,
					                  dotDiameter,
					                  dotDiameter
				                  ));
			rightDot.Layer.CornerRadius = dotDiameter / 2f;
			rightDot.BackgroundColor = UIColor.Gray;

			loadingView.AddSubviews (middleDot, leftDot, rightDot);


			UIView.Animate (0.6, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat,
				() => {
					leftDot.Center =
						new CGPoint (
						leftDot.Center.X,
						leftDot.Center.Y + 15f
					);
				},
				() => {
					leftDot.Center =
						new CGPoint (
						leftDot.Center.X,
						leftDot.Center.Y
					);
				}
			);

			UIView.Animate (0.6, 0.15, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat,
				() => {
					middleDot.Center =
						new CGPoint (
						middleDot.Center.X,
						middleDot.Center.Y + 15f
					);
				},
				() => {
					middleDot.Center =
						new CGPoint (
						middleDot.Center.X,
						middleDot.Center.Y
					);
				}
			);
			UIView.Animate (0.6, 0.3, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat,
				() => {
					rightDot.Center =
						new CGPoint (
						rightDot.Center.X,
						rightDot.Center.Y + 15f
					);
				},
				() => {
					rightDot.Center =
						new CGPoint (
						rightDot.Center.X,
						rightDot.Center.Y
					);
				}
			);
			return loadingView;
		}
		
	}
}

