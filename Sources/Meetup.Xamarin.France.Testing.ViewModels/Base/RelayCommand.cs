namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System;
	using System.Windows.Input;

	public class RelayCommand : ICommand
	{
		public RelayCommand(Action execute, Func<bool> canExecute = null)
		{
			this.execute = execute;
			this.canExecute = canExecute ?? (() => true);
		}

		private Action execute;

		private Func<bool> canExecute;

		public void RaiseCanExecuteChanged() => this.CanExecuteChanged?.Invoke(this, EventArgs.Empty);

		public event EventHandler CanExecuteChanged;

		public bool CanExecute(object parameter) => this.canExecute();

		public void Execute(object parameter) => this.execute();

		public void TryExecute(object parameter = null)
		{
			if (this.CanExecute(parameter))
				this.Execute(parameter);
		}
	}
}
