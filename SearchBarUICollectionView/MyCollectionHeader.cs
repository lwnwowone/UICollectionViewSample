using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SearchBarUICollectionView
{
	public class MyCollectionHeader : UICollectionReusableView
	{
		private UILabel label;
		public string Text
		{
			get
			{
				return label.Text;
			}
			set
			{
				label.Text = value;
				SetNeedsDisplay();
			}
		}

		[Export("initWithFrame:")]
		public MyCollectionHeader(CGRect frame) : base(frame)
			{
			label = new UILabel(this.Bounds);
			label.BackgroundColor = UIColor.Yellow;
			AddSubview(label);
		}
	}
}
