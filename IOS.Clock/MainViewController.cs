using System;
using UIKit;
using CoreGraphics;
using CoreText;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Timers;

namespace IOS.Clock
{
	public class MainViewController : UIKit.UIViewController
	{
		#region UI

		private nfloat _clockDiameter = 150f;
		private UIView _clockView;
		private UIView _secondsArrow;
		private UIView _hourseView;
		private UIView _minutesArrow;

		#endregion

		#region Variables

		private int _seconds = 0;
		private int _minutes = 0;
		private int _hours = 0;

		#endregion

		#region overrides

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			this.View.BackgroundColor = UIColor.White;
			InitUI ();
		}

		#endregion

		#region Methods

		private void InitUI ()
		{
			_hours = DateTime.Now.Hour;
			_minutes = DateTime.Now.Minute;
			_seconds = DateTime.Now.Second;

			_clockView = new UIView (new CGRect ((this.View.Frame.Width - _clockDiameter) / 2,
				(this.View.Frame.Height - _clockDiameter) / 2,
				_clockDiameter,
				_clockDiameter));
			_clockView.BackgroundColor = UIColor.Black;
			_clockView.Layer.CornerRadius = _clockDiameter / 2;
			var centerX = _clockView.Frame.Width / 2f;
			var centerY = _clockView.Frame.Height / 2f;

			nfloat littleDotsDiameter = 2f;
			//center Dot
			var mainDot = new UIView (new CGRect (centerX - 2.5f,
				              centerY - 2.5f,
				              littleDotsDiameter + 5f,
				              littleDotsDiameter + 5f));
			mainDot.Layer.CornerRadius = (littleDotsDiameter + 5f) / 2f;
			mainDot.BackgroundColor = UIColor.Red;

			//adding hours dots
			for (int i = 0; i < 12; i++) {
				double x = centerX + (_clockDiameter / 2 - 7f) * Math.Cos (30 * i * Math.PI / 180);
				double y = centerY + (_clockDiameter / 2 - 7f) * Math.Sin (30 * i * Math.PI / 180);

				var dot = new UIView (new CGRect (x - littleDotsDiameter / 2,
					          y - littleDotsDiameter / 2,
					          littleDotsDiameter,
					          littleDotsDiameter));
				dot.Layer.CornerRadius = littleDotsDiameter / 2f;
				dot.BackgroundColor = UIColor.White;
				_clockView.AddSubview (dot);
			}

			//adding seconds arrow
			var arrowWidth = 1.3f;
			var arrowPadding = 12f;
			_secondsArrow = new UIView (new CGRect (centerX,
				12f,
				arrowWidth,
				_clockDiameter / 2 - 12f));

			_secondsArrow.BackgroundColor = UIColor.Clear.FromHexString ("#bcba2c");
			_secondsArrow.Layer.CornerRadius = arrowWidth / 2f;
			_secondsArrow.Layer.AnchorPoint = new CGPoint (0.5, 1);
			_secondsArrow.Layer.Position = new CGPoint (centerX, centerY);

			arrowWidth = 2f;
			arrowPadding -= 3f;
			_minutesArrow = new UIView (new CGRect (centerX,
				15f,
				arrowWidth,
				_clockDiameter / 2 - 15f));

			_minutesArrow.BackgroundColor = UIColor.Clear.FromHexString ("#f1ed12");
			_minutesArrow.Layer.CornerRadius = arrowWidth / 2f;
			_minutesArrow.Layer.AnchorPoint = new CGPoint (0.5, 1);
			_minutesArrow.Layer.Position = new CGPoint (centerX, centerY);

			var hoursWidth = 2.5f;
			arrowPadding -= 5f;
			_hourseView = new UIView (new CGRect (
				centerX - hoursWidth / 2,
				centerY - _clockDiameter / 3f,
				hoursWidth,
				_clockDiameter / 3f 
			));

			_hourseView.BackgroundColor = UIColor.White;
			_hourseView.Layer.CornerRadius = hoursWidth / 2f;
			_hourseView.Layer.AnchorPoint = new CGPoint (0.5, 1);
			_hourseView.Layer.Position = new CGPoint (centerX, centerY);

			_clockView.AddSubview (_hourseView);
			_clockView.AddSubview (_minutesArrow);
			_clockView.AddSubview (_secondsArrow);
			_clockView.AddSubview (mainDot);

			var timer = new Timer (100);
			timer.Elapsed += TimerElapsed;
			timer.Enabled = true;

			_minutesArrow.Transform = CGAffineTransform.MakeRotation ((float)Math.PI / 30 * _minutes);
			_hourseView.Transform = CGAffineTransform.MakeRotation ((_hours * (float)Math.PI / 6) +
			(_minutes / 60f) * ((float)Math.PI / 30f));

			View.AddSubview (_clockView);
		}


		void TimerElapsed (object sender, ElapsedEventArgs e)
		{

			_seconds++;
			InvokeOnMainThread (() => {
				_secondsArrow.Transform = CGAffineTransform.MakeRotation ((float)Math.PI / 300 * _seconds);

				if (_seconds == 60 * 10) { // if one minute passed
					_seconds = 0;
					_minutes++;																
					_hourseView.Transform = CGAffineTransform.MakeRotation ((_hours * (float)Math.PI / 6) +
					(_minutes / 60f) * ((float)Math.PI / 30f));	
				} 
				if (_seconds % (5 * 10) == 0) { //if 5 seconds passed
					_minutesArrow.Transform = CGAffineTransform.MakeRotation (((float)Math.PI / 30 * _minutes) + _seconds / 50 * (float)Math.PI / (30 * 12));
				}

				if (_minutes == 60) {
					_minutes = 0;
					_hours++;
				}
			});
		}

		#endregion
	}
}

