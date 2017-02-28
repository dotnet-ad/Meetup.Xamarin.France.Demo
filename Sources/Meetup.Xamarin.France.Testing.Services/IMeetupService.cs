namespace Meetup.Xamarin.France.Testing.Services
{
	using System.Collections.Generic;
	using System.Threading.Tasks;

	/// <summary>
	/// A service for getting data from Meetup.
	/// </summary>
	public interface IMeetupService
	{
		/// <summary>
		/// Gets the group detail.
		/// </summary>
		/// <returns>The group detail.</returns>
		/// <param name="groupid">Group id.</param>
		Task<Group> GetGroupDetail(string groupid);

		/// <summary>
		/// Gets the group events.
		/// </summary>
		/// <returns>The group events.</returns>
		/// <param name="groupid">Group id.</param>
		Task<IEnumerable<Event>> GetGroupEvents(string groupid);

		/// <summary>
		/// Gets the group members.
		/// </summary>
		/// <returns>The group members.</returns>
		/// <param name="groupid">Group id.</param>
		Task<IEnumerable<Member>> GetGroupMembers(string groupid);
	}
}
