namespace Meetup.Xamarin.France.Testing.Services
{
	using System;

	public static class DatetimeExtensions
	{
		#region Timestamps

		/// <summary>
		/// Converts a timestamp to a DateTime
		/// </summary>
		/// <param name="timestamp">The timestamp (milliseconds unix epoch)</param>
		/// <returns>The date time</returns>
		public static DateTime ToDateTime(this long timestamp)
		{
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(timestamp).ToLocalTime();
		}

		#endregion
	}
}
