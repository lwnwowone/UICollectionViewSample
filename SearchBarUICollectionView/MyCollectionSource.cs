using System;
using Foundation;
using System.Collections.Generic;
using UIKit;

namespace SearchBarUICollectionView
{
	public class MyCollectionSource : UICollectionViewSource
	{
		//List of source data
		private List<string> sourceList = new List<string>();
		public List<string> SourceList
		{
			get
			{
				return sourceList;
			}
			set
			{
				sourceList = value;
				GetDataList();
			}
		}

		//List of the data to display
		private List<ItemGroup> dataList = new List<ItemGroup>();

		private string cellID = "MyCollectionCell";
		private string headerID = "MyCollectionHeader";

		public MyCollectionSource(UICollectionView collectionView)
		{
			//Registering the cell and header view for reusing, it's very important, it will crash if you don't register it.
			collectionView.RegisterClassForCell(typeof(MyCollectionCell), cellID);
			collectionView.RegisterClassForSupplementaryView(typeof(MyCollectionHeader), UICollectionElementKindSection.Header, headerID);
		}

		//Get data from sourceList directly
		public void GetDataList()
		{
			dataList.Clear();
			dataList.Add(new ItemGroup("All items", sourceList));
		}

		//Get data from sourceList according to searchStr and separate results to 2 groups
		public void GetDataListBySearchStr(string searchStr)
		{
			dataList.Clear();
			dataList.Add(new ItemGroup("First 2 items", new List<string>()));
			dataList.Add(new ItemGroup("Else", new List<string>()));
			searchStr = searchStr.ToLower();
			foreach (string str in sourceList) {
				if (str.Contains(searchStr)) {
					if (dataList[0].ItemList.Count < 2)
						dataList[0].ItemList.Add(str);
					else
						dataList[1].ItemList.Add(str);
				}
			}
		}

		#region imeplement from UICollectionViewSource

		public override nint NumberOfSections(UICollectionView collectionView)
		{
			return dataList.Count;
		}

		public override nint GetItemsCount(UICollectionView collectionView, nint section)
		{
			return dataList[(int)section].ItemList.Count;
		}

		//For geting header view
		public override UICollectionReusableView GetViewForSupplementaryElement(UICollectionView collectionView, NSString elementKind, NSIndexPath indexPath)
		{
			var headerView = (MyCollectionHeader)collectionView.DequeueReusableSupplementaryView(elementKind, headerID, indexPath);
			headerView.Text = dataList[indexPath.Section].GroupName;
			return headerView;
		}

		//For geting cell view
		public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
		{
			MyCollectionCell cell = (MyCollectionCell)collectionView.DequeueReusableCell(cellID, indexPath);
			string str = dataList[indexPath.Section].ItemList[indexPath.Row];
			cell.ContentStr = str;
			return cell;
		}

		#endregion
	}

	//A class for showing how to make multiple groups
	public class ItemGroup
	{
		private string groupName;
		public string GroupName { 
			get {
				return groupName;
			}
		}

		private List<string> itemList;
		public List<string> ItemList
		{
			get
			{
				return itemList;
			}
		}

		public ItemGroup(string gn, List<string> iList)
		{
			this.groupName = gn;
			this.itemList = iList;
		}
	}
}
