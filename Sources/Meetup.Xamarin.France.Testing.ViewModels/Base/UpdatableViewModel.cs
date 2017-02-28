namespace Meetup.Xamarin.France.Testing.ViewModels
{
	using System;
	using System.Diagnostics;
	using System.Threading.Tasks;

	public abstract class UpdatableViewModel : ViewModelBase
	{
		public UpdatableViewModel()
		{
			this.UpdateCommand = new RelayCommand(this.ExecuteUpdateCommand);
		}

		#region Fields

		private bool isUpdating, isUpdated;

		#endregion

		#region Properties

		public bool IsUpdating
		{
			get { return this.isUpdating; }
			set 
			{
				if (this.Set(ref isUpdating, value))
				{
					this.UpdateCommand.RaiseCanExecuteChanged();
				}
			}
		}

		public bool IsUpdated
		{
			get { return this.isUpdating; }
			set { if (this.Set(ref isUpdating, value)) ; }
		}

		#endregion

		#region Commands

		public RelayCommand UpdateCommand { get; }

		private bool CanExecuteUpdateCommand() => !this.IsUpdating;

		private async void ExecuteUpdateCommand()
		{
			try
			{
				this.IsUpdating = true;
				await this.UpdateAsync();
				this.IsUpdated = true;
			}
			catch (Exception ex)
			{
				Debug.WriteLine($"[{this.GetType().Name}] Something got wrong during update : {ex}");
			}
			finally
			{
				this.IsUpdating = false;
			}
		}

		protected abstract Task UpdateAsync();

		#endregion
	}
}
