using NUnit.Framework;
using System;
namespace Meetup.Xamarin.France.Testing.Services.Test
{
	[TestFixture()]
	public class Test
	{
		[Test()]
		public void ToDateTime_ValidTimestamp_ValidDate()
		{
			const long timestamp = 1488316259000;
			var expected = new DateTime(2017, 2, 28, 22, 10, 59);
			var value = timestamp.ToDateTime();
			Assert.AreEqual(expected, value);
		}
	}
}
