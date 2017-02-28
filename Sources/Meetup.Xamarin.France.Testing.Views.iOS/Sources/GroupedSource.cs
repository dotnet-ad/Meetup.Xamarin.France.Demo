namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using System;
	using System.Collections.Generic;
	using Foundation;
	using ViewModels;
	using UIKit;
	using System.Linq;
	using System.Reflection;

	public class GroupedSource<TCell, TItem> : UITableViewSource
		where TCell : UITableViewCell, ICell<TItem>
	{
		public GroupedSource(UITableView table, ViewModelBase viewModel, string property, Action<TItem> onselect, Func<TItem,string> sections)
		{
			this.sections = sections;
			this.onselect = onselect;
			this.cellname = typeof(TCell).Name;
			table.RegisterNibForCellReuse(UINib.FromName(cellname, NSBundle.MainBundle), cellname);
			this.table = table;
			this.viewModel = viewModel;
			this.property = viewModel.GetType().GetProperty(property);
			viewModel.PropertyChanged += OnPropertyChanged; // TODO weak handler
			this.Update();
		}

		readonly Func<TItem, string> sections;

		private string cellname;

		readonly Action<TItem> onselect;

		readonly ViewModelBase viewModel;

		readonly PropertyInfo property;

		private UITableView table;

		private IEnumerable<TItem> Collection { get; set; }

		private IEnumerable<IGrouping<string,TItem>> GroupedCollection => Collection?.GroupBy(sections);

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
		{
			var view = tableView.DequeueReusableCell(cellname, indexPath) as TCell;
			view.Item = GroupedCollection.ElementAt(indexPath.Section).ElementAt(indexPath.Row);
			return view;
		}

		public override nint NumberOfSections(UITableView tableView) => GroupedCollection?.Count() ?? 0;

		public override nint RowsInSection(UITableView tableview, nint section) => this.GroupedCollection?.ElementAt((int)section).Count() ?? 0;

		public override void RowSelected(UITableView tableView, NSIndexPath indexPath)
		{
			var item = GroupedCollection.ElementAt(indexPath.Section).ElementAt(indexPath.Row);
			this.onselect?.Invoke(item);
		}

		private void OnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
		{
			if (e.PropertyName == property.Name)
			{
				this.Update();
			}
		}

		public override string[] SectionIndexTitles(UITableView tableView) => this.GroupedCollection?.Select(x => x.Key).ToArray();

		private void Update()
		{
			this.Collection = (property.GetValue(viewModel) as IEnumerable<TItem>);
			this.table.ReloadData();
		}
	}
}
