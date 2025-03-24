using IdeaCenterPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	[TestFixture]
	public class LoginPageTests : BaseTest
	{
		[Test]
		public void Test_LoginUserWithValidData()
		{
			_loginPage.OpenPage();
			_loginPage.LoginUser("testUser_123@email.com", "test1234");

			Assert.That(_homePage.IsPageOpened(), Is.True);
			Assert.That(_homePage.LogoutLink.Displayed, Is.True);
		}
	}
}
