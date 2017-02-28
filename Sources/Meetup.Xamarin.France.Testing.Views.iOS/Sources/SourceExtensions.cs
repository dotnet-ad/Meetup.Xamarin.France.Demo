namespace Meetup.Xamarin.France.Testing.Views.iOS
{
	using System;
	using Meetup.Xamarin.France.Testing.ViewModels;
	using UIKit;

	public static class SourceExtensions
	{
		public static void AttachSource<TCell, TItem>(this UITableView table, ViewModelBase viewModel, string property, Action<TItem> onselect = null)
		where TCell : UITableViewCell, ICell<TItem>
		{
			table.Source = new Source<TCell, TItem>(table, viewModel, property, onselect);
		}

		public static void AttachGroupedSource<TCell, TItem>(this UITableView table, ViewModelBase viewModel, string property, Func<TItem, string> sections, Action<TItem> onselect = null)
		where TCell : UITableViewCell, ICell<TItem>
		{
			table.Source = new GroupedSource<TCell, TItem>(table, viewModel, property, onselect,sections);
		}
	}
}
