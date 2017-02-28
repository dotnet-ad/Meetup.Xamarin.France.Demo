namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using System;
	using System.Collections.Generic;
	using Foundation;
	using ViewModels;
	using UIKit;
	using System.Linq;
	using System.Reflection;

	public class Source<TCell, TItem> : UITableViewSource
		where TCell : UITableViewCell, ICell<TItem>
	{
		public Source(UITableView table, ViewModelBase viewModel, string property, Action<TItem> onselect)
		{
			this.onselect = onselect;
			this.cellname = typeof(TCell).Name;
			table.RegisterNibForCellReuse(UINib.FromName(cellname, NSBundle.MainBundle), cellname);
			this.table = table;
			this.viewModel = viewModel;
			this.property = viewModel.GetType().GetProperty(property);
			viewModel.PropertyChanged += OnPropertyChanged; // TODO weak handler
			this.Update();
		}

		private string cellname;

		readonly Action<TItem> onselect;

		readonly ViewModelBase viewModel;

		readonly PropertyInfo property;

		private UITableView table;

		private IEnumerable<TItem> Collection { get; set; }

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var view = tableView.DequeueReusableCell(cellname, indexPath) as TCell;
			view.Item = Collection.ElementAt(indexPath.Row);
			return view;
		}

		public override nint NumberOfSections(UITableView tableView) => 1;

		public override nint RowsInSection(UITableView tableview, nint section) => this.Collection?.Count() ?? 0;

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			this.onselect?.Invoke(Collection.ElementAt(indexPath.Row));
		}

		private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == property.Name)
			{
				this.Update();
			}
		}

		private void Update()
		{
			this.Collection = property.GetValue(viewModel) as IEnumerable<TItem>;
			this.table.ReloadData();
		}
	}
}
