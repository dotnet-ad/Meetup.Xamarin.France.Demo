namespace Meetup.Xamarin.France.Testing.ViewModels.Test
{
	using System;
	using Services;
	using NSubstitute;
	using NUnit.Framework;
	using System.Threading.Tasks;
	using System.Collections.Generic;
	using System.Linq;

	[TestFixture()]
	public class MembersViewModelTest
	{
		#region Fields

		private IMeetupService meetup;

		private MembersViewModel viewModel;

		#endregion

		#region Initialization

		[SetUp]
		public void Initialize()
		{
			meetup = Substitute.For<IMeetupService>();
			viewModel = new MembersViewModel(meetup);
		}

		#endregion


		#region Tests

		[Test()]
		public void UpdateCommand_Executed_MembersChangedAndOrdered()
		{
			// First, prepare the service api mock responses
			Member[] stubs =
			{
				new Member() { Name = "Satya Nadela" },
				new Member() { Name = "Miguel De Icaza" },
				new Member() { Name = "Nat Friedman" },
			};

			this.meetup.GetGroupMembers(Arg.Any<string>()).Returns(Task.FromResult<IEnumerable<Member>>(stubs));

			// Verify initial state
			Assert.IsEmpty(this.viewModel.Members);

			// Subscribe "PropertyChanged" event to know if
			// command triggers a "Members" property change after an update.
			var raised = this.viewModel.ObservePropertyChanged(nameof(this.viewModel.Members));

			// Start the update through command	
			this.viewModel.UpdateCommand.Execute(null);

			// Verify that the property "Members" changed ans that it is not empty now
			Assert.True(raised.WaitOne(TimeSpan.FromSeconds(1)));
			Assert.IsNotEmpty(this.viewModel.Members);

			// Verify expected member order
			Assert.AreEqual(stubs[1].Name, this.viewModel.Members.ElementAt(0).Name);
			Assert.AreEqual(stubs[2].Name, this.viewModel.Members.ElementAt(1).Name);
			Assert.AreEqual(stubs[0].Name, this.viewModel.Members.ElementAt(2).Name);
		}

		#endregion
	}
}
