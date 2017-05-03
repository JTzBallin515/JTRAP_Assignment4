using System;
using System.Collections.Generic;
using System.IO;
using Foundation;
using SQLite;
using UIKit;

namespace JTRAP_Assignment4
{

	public partial class ViewController : UIViewController
	{
		string filePath;
		UIBarButtonItem myItem;
		UIBarButtonItem myItem2;

		partial void BtnAdd_TouchUpInside(UIButton sender)
		{

            
			// Input Validation: only insert a book if the title is not empty
			if (!string.IsNullOrEmpty(txtTitle.Text))
			{
				// Insert a new book into the database
				var newBook = new Book { BookTitle = txtTitle.Text, ISBN = txtISBN.Text };

				var db = new SQLiteConnection(filePath);
				db.Insert(newBook);



				var alert = UIAlertController.Create("Success", string.Format("Book ID: {0} with Title: {1} has been successfully added!", newBook.BookId, newBook.BookTitle), UIAlertControllerStyle.Alert);

				alert.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));

				if (alert.PopoverPresentationController != null)
					alert.PopoverPresentationController.BarButtonItem = myItem;
				PresentViewController(alert, animated: true, completionHandler: null);

			}

			else

			{ 
				var alert2 = UIAlertController.Create("Failed", "Enter a valid Book Title", UIAlertControllerStyle.Alert);
				alert2.AddAction(UIAlertAction.Create("Ok", UIAlertActionStyle.Cancel, null));

				if (alert2.PopoverPresentationController != null)
					alert2.PopoverPresentationController.BarButtonItem = myItem;
				PresentViewController(alert2, animated: true, completionHandler: null);
			}

            PopulateTableView();

			tblBooks.ReloadData ();
		}




			private void PopulateTableView() 			 { 				var db = new SQLiteConnection (filePath); 				// retrieve all the data in the DB table 				var bookList = db.Table<Book>();  				List<string> bookTitles = new List<string> ();  				// loop through the data and retrieve the BookTitle column data only 				foreach (var book in bookList) { 					bookTitles.Add (book.BookTitle); 				} 
			       // set the data source for the tableView control 				tblBooks.Source = new BookListTableSource (bookTitles.ToArray ()); 			 }


		protected ViewController(IntPtr handle) : base(handle)
		{ }
		// Note: this .ctor should not contain any initialization logic.

		public override void ViewDidLoad()
		{
			// define the file path on the device where the DB will be stored
			filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "BookList.db3");

			base.ViewDidLoad();

			// Create our connection, if the database file and/or table doesn't exist create it
			var db = new SQLiteConnection(filePath);
			db.CreateTable<Book>();

			// TODO: Add code to populate the Table View if it contains data
            
			PopulateTableView();

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}
