using System;
using System.Diagnostics.Contracts;
using Foundation;
using UIKit;

namespace JTRAP_Assignment4
{
	public class BookListTableSource : UITableViewSource
	{ 

		UIBarButtonItem myItem2;
		protected string[] tableItems; 		protected string cellIdentifier = "TableCell";  		public BookListTableSource (string[] items) 		{ 			tableItems = items; 		}
 		public override nint RowsInSection (UITableView tableview, nint section) 		{ 			return tableItems.Length; 		}
 		public override UITableViewCell GetCell (UITableView tableView, 
			NSIndexPath indexPath) 		{ 			// request a recycled cell to save memory 			UITableViewCell cell = tableView.DequeueReusableCell (cellIdentifier); 			// if there are no cells to reuse, create a new one 			if (cell == null) 				cell = new UITableViewCell (UITableViewCellStyle.Default, 
						cellIdentifier); 			cell.TextLabel.Text = tableItems[indexPath.Row]; 			return cell; 		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath) 
		{
			
				
			var alert3 = UIAlertController.Create("Success", "Row Selected", UIAlertControllerStyle.Alert);
			alert3.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));

			if (alert3.PopoverPresentationController != null)
				alert3.PopoverPresentationController.BarButtonItem = myItem2;
			UIApplication.SharedApplication.KeyWindow.RootViewController.PresentViewController(alert3, true, null); 		}
  	 } 

}
