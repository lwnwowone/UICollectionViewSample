using System;
using CoreGraphics;
using UIKit;

namespace SearchBarUICollectionView
{
	public class MyCollectionLayout : UICollectionViewFlowLayout
	{
		public MyCollectionLayout()
		{
			int	padding = 5;
			int itemWidth = 80;
			int itemHeight = 80;
			int insidePadding = 5;

			ItemSize = new CGSize(itemWidth, itemHeight);
			ScrollDirection = UICollectionViewScrollDirection.Vertical;
			SectionInset = new UIEdgeInsets(padding, padding, padding, padding);
			MinimumLineSpacing = insidePadding;
			HeaderReferenceSize = new CGSize(UIScreen.MainScreen.Bounds.Width, 30);
		}
	}
}
