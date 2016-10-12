using System;
using System.Collections.Generic;
using CoreGraphics;
using UIKit;

namespace SearchBarUICollectionView
{
	public class MainViewController : UIViewController
	{
		private MainView mainView;

		public MainViewController()
		{
			mainView = new MainView();
			this.View = mainView;
		}
	}

	public class MainView : UIView
	{
		private UISearchBar searchBar;
		private UICollectionView collectionView;

		public MainView()
		{
			//Set basic properties
			this.BackgroundColor = UIColor.White;
			this.Frame = UIScreen.MainScreen.Bounds;

			//Init searchBar
			searchBar = new UISearchBar(new CGRect(0, 20, UIScreen.MainScreen.Bounds.Width, 30));
			searchBar.KeyboardType = UIKeyboardType.NumberPad;
			this.AddSubview(searchBar);

			//Init collectionView
			collectionView = new UICollectionView(new CGRect(0,50,UIScreen.MainScreen.Bounds.Width, UIScreen.MainScreen.Bounds.Height-50),new MyCollectionLayout());
			collectionView.BackgroundColor = UIColor.Red;
			this.AddSubview(collectionView);

			//Init testing data
			List<string> dataList = new List<string>();
			for (int i = 0; i < 50; i++) {
				dataList.Add(i.ToString());
			}

			//Init collection source
			MyCollectionSource source = new MyCollectionSource(collectionView);
			source.SourceList = dataList;
			collectionView.Source = source;
			collectionView.ReloadData();

			//Add a gesture for hiding keyboard
			collectionView.AddGestureRecognizer(new UITapGestureRecognizer(() => {
				this.EndEditing(true);
			}));

			//Binding search event
			searchBar.TextChanged += delegate
			{
				if (string.IsNullOrEmpty(searchBar.Text))
					source.GetDataList();
				else
					source.GetDataListBySearchStr(searchBar.Text);

				collectionView.ReloadData();
			};
		}
	}
}
