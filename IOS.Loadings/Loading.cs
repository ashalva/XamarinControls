using System;
using UIKit;
using CoreGraphics;
using CoreAnimation;
using Foundation;
using System.Collections.Generic;
using CoreImage;

namespace IOS.Loadings
{
	public class Loading
	{
		static nfloat _padding = 60f;

		public static UIView ThreeDotLoading (CGRect frame)
		{
			var loadingView = new UIView (new CGRect ((frame.Width - _padding) / 2f, _padding, _padding, _padding));

			var dotDiameter = 8f;
			var padding = 3f;

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

		public static UIView TwoDotLoading (CGRect frame)
		{
			var dotDiameter = 2f;

			var loadingView = new UIView (new CGRect ((frame.Width - _padding) / 2f, _padding * 2, _padding, _padding));

			UIView firstDot = new UIView (new CGRect (
				                  (loadingView.Frame.Width - dotDiameter) / 2f + 7.5f,
				                  (loadingView.Frame.Height - dotDiameter) / 2f,
				                  dotDiameter,
				                  dotDiameter
			                  ));
			firstDot.Layer.CornerRadius = dotDiameter / 2f;
			firstDot.BackgroundColor = UIColor.Gray;


			UIView secondDot = new UIView (new CGRect (
				                   (loadingView.Frame.Width - dotDiameter) / 2f - 7.5f,
				                   (loadingView.Frame.Height - dotDiameter) / 2f,
				                   dotDiameter,
				                   dotDiameter
			                   ));
			secondDot.Layer.CornerRadius = dotDiameter / 2f;
			secondDot.BackgroundColor = UIColor.Gray; 

			loadingView.AddSubviews (firstDot, secondDot);


			var firstDotCenter = firstDot.Center;
			var secondDotCenter = secondDot.Center;
			UIView.Animate (0.8, 0.4, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat,
				() => {
					firstDot.Center =
						new CGPoint (
						secondDotCenter.X,
						secondDotCenter.Y + 20f
					);
					firstDot.Transform = CGAffineTransform.MakeScale (5f, 5f);
				},
				() => {
					firstDot.Center =
						new CGPoint (
						firstDotCenter.X,
						firstDotCenter.Y
					);
				}
			);
			UIView.Animate (0.8, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat,
				() => {
					secondDot.Center =
						new CGPoint (
						firstDotCenter.X,
						firstDotCenter.Y + 20f
					);
					secondDot.Transform = CGAffineTransform.MakeScale (5f, 5f);
				},
				() => {
					secondDot.Center =
						new CGPoint (
						secondDotCenter.X,
						secondDotCenter.Y
					);
				}
			);

			return loadingView;
		}

		public static UIView SquareLoading (CGRect frame)
		{
			var loadingView = new UIView (new CGRect ((frame.Width - _padding) / 2f, _padding * 3.5, _padding, _padding));

			var squareWidth = 10f;

			var square = new UIView (new CGRect (0, (loadingView.Frame.Height - squareWidth) / 2f, squareWidth, squareWidth));
			square.BackgroundColor = UIColor.Gray;
			square.Layer.CornerRadius = 3f;

			loadingView.AddSubview (square);

			UIView.Animate (0.8, 0, UIViewAnimationOptions.CurveEaseInOut | UIViewAnimationOptions.Autoreverse | UIViewAnimationOptions.Repeat,
				() => {
					CABasicAnimation rotationAnimation;
					rotationAnimation = CABasicAnimation.FromKeyPath ("transform.rotation.z");
					rotationAnimation.To = new NSNumber (Math.PI * 2);
					rotationAnimation.Duration = 1.5;
					rotationAnimation.Cumulative = true;
					rotationAnimation.RepeatCount = int.MaxValue;
					square.Layer.AddAnimation (rotationAnimation, "rotationAnimation");

					square.Center = new CGPoint (
						50f,
						square.Frame.Y
					);
				},
				() => {
					square.Center = new CGPoint (
						square.Frame.X,
						square.Frame.Y
					);
				});
			return loadingView;
		}

		public static UIView ThreeDotLoadingZooming (CGRect frame)
		{
			var loadingView = new UIView (new CGRect ((frame.Width - _padding) / 2f, _padding * 4.5, _padding, _padding));
			var dotDiameter = 6f;
			var padding = 5.5f;

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
			leftDot.Alpha = 0.5f;
			middleDot.Alpha = 0.5f;
			rightDot.Alpha = 0.5f;

			UIView.Animate (0.6, 0, UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Autoreverse, () => {
				leftDot.Transform = CGAffineTransform.MakeScale (1.8f, 1.8f);
				leftDot.Alpha = 1f;
			}, null);
			UIView.Animate (0.6, 0.2, UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Autoreverse, () => {
				middleDot.Transform = CGAffineTransform.MakeScale (1.8f, 1.8f);
				middleDot.Alpha = 1f;
			}, null);
			UIView.Animate (0.6, 0.4, UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Autoreverse, () => {
				rightDot.Transform = CGAffineTransform.MakeScale (1.8f, 1.8f);
				rightDot.Alpha = 1f;
			}, null);
			return loadingView;	
		}

		public static UIView MultipleLinesLoading (CGRect frame)
		{
			//creating mainView
			var loadingView = new UIView (new CGRect ((frame.Width - _padding) / 2f, _padding * 5.5, _padding + 20f, _padding + 20f));
			var lineWidth = 5f;
			var lineHeight = _padding + 16f;

			List<UIView> viewsList = new List<UIView> ();

			//creating middle line
			var middleLine = new UIView (new CGRect (
				                 (loadingView.Frame.Width - lineWidth) / 2f,
				                 8f,
				                 lineWidth,
				                 lineHeight));
			middleLine.Layer.CornerRadius = lineWidth / 2f;
			middleLine.BackgroundColor = UIColor.Gray;
			viewsList.Add (middleLine);
			loadingView.AddSubview (middleLine);

			// line properties
			var linePadding = 3f;
			int lineCount = 15;
			var random = new Random ();

			//creating left and right lines
			for (int i = 0; i < lineCount; i++) {
				//generating random color
				var color = String.Format ("#{0:X6}", random.Next (0x1000000));

				var view = new UIView ();
				view.Layer.CornerRadius = lineWidth / 2f;
				if (i < lineCount - 1) {
					if (i % 2 == 0) {
						// choose right X position of next Line
						int k = i;
						if (i > 0)
							k--;
						view.Frame = new CGRect (viewsList [k].Frame.X - linePadding - lineWidth,
							8f,
							lineWidth,
							lineHeight);
					} else {
						view.Frame = new CGRect (viewsList [i - 1].Frame.X + linePadding + lineWidth,
							8f,
							lineWidth,
							lineHeight);
					}
				}

				// add random color for each line
				//view.BackgroundColor = UIColor.Clear.FromHexString (color);
				view.BackgroundColor = UIColor.Gray;
				viewsList.Add (view);
				loadingView.AddSubview (view);

				if (i % 2 == 0)
					UIView.Animate (1.2, i * 0.12, UIViewAnimationOptions.Repeat | UIViewAnimationOptions.Autoreverse, () => {
						if (i == 0) {
							// animate middleElement
							viewsList [i].Transform = CGAffineTransform.MakeScale (1f, 0.1f);
							viewsList [i].Alpha = 0.3f;
							viewsList [i].Layer.CornerRadius = 2f;
						} else {
							//animate next elements
							viewsList [i].Transform = CGAffineTransform.MakeScale (1f, 0.1f);
							viewsList [i].Alpha = 0.3f;
							viewsList [i].Layer.CornerRadius = 2f;
							viewsList [i - 1].Transform = CGAffineTransform.MakeScale (1f, 0.1f);
							viewsList [i - 1].Layer.CornerRadius = 2f;
							viewsList [i - 1].Alpha = 0.3f;
						}
					}, null);
			}

			return loadingView;
		}

		public static UIView CircleLoading (CGRect frame)
		{
			var loadingView = new UIView (new CGRect ((frame.Width - _padding) / 2f, _padding * 6.5, _padding + 20f, _padding + 20f));

			var circleDiameter = 20f;
			var mainCircle = new UIView (new CGRect ((loadingView.Frame.Width - circleDiameter) / 2f,
				                 (loadingView.Frame.Height - circleDiameter) / 2f,
				                 circleDiameter, 
				                 circleDiameter));
			mainCircle.BackgroundColor = UIColor.Gray;

			loadingView.AddSubview (mainCircle);

			return loadingView;
		}
	}
}

