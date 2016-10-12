using System;
using CoreGraphics;
using Foundation;
using UIKit;

namespace SearchBarUICollectionView
{
	public class MyCollectionCell : UICollectionViewCell
	{
		private UILabel lbTitle;

		private string contentStr;
		public string ContentStr
		{
			get
			{
				return contentStr;
			}
			set
			{
				contentStr = value;
				lbTitle.Text = contentStr;
			}
		}

		[Export("initWithFrame:")]
		public MyCollectionCell(CGRect frame) : base (frame)
		{
			ContentView.BackgroundColor = UIColor.White;

			lbTitle = new UILabel(this.Bounds);
			lbTitle.TextAlignment = UITextAlignment.Center;
			lbTitle.Text = "";
			this.AddSubview(lbTitle);
		}
	}
}
