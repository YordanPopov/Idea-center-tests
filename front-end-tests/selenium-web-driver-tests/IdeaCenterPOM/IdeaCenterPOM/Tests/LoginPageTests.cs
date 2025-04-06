using IdeaCenterPOM.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	[TestFixture("chrome")]
	[TestFixture("firefox")]
	[TestFixture("edge")]
	public class LoginPageTests : BaseTest
	{
		public LoginPageTests(string browserType) : base(browserType) { }

		[SetUp]
		public void LoginTest_SetUp()
		{
			_loginPage.OpenPage();
		}

		[Test, Order(6)]
		public void Test_LoginUserWithValidData()
		{	
			_loginPage.LoginUser("testUser_123@email.com", "test1234");

			Assert.That(_homePage.IsPageOpened(), Is.True);
			Assert.That(_homePage.LogoutLink.Displayed, Is.True);
			Assert.That(_homePage.MyProfileLink.Displayed, Is.True);
		}

		[Test, Order(2)]
		public void Test_LoginUserWithEmptyFields()
		{
			_loginPage.LoginUser("", "");

			Assert.That(_loginPage.IsPageOpened(), Is.True);
			Assert.That(_loginPage.MainErrorMsg, Is.EqualTo("Unable to sign in!"));
			Assert.That(_loginPage.EmailErrorMsg, Is.EqualTo("The e-mail is required!"));
			Assert.That(_loginPage.PasswordErrorMsg, Is.EqualTo("The password is required!"));
		}

		[Test, Order(3)]
		public void Test_LoginUserWithWrongPassword()
		{
			_loginPage.LoginUser("testUser_123@email.com", "wrong-pass");

			Assert.That(_loginPage.IsPageOpened(), Is.True);
			Assert.That(_loginPage.MainErrorMsg, Is.EqualTo("Unable to sign in!"));
		}

		[Test, Order(4)]
		public void Test_LoginUserWithNonExistentEmail()
		{
			_loginPage.LoginUser("nonExistentUser@email.com", "somePassword1234");

			Assert.That(_loginPage.IsPageOpened(), Is.True);
			Assert.That(_loginPage.MainErrorMsg, Is.EqualTo("Unable to sign in!"));
		}

		[Test, Order(5)]
		public void Test_VerifyThatGoogleSingInButtonRedirectToTheGoogleLoginPage()
		{
			//To-Do
		}

		[Test, Order(1)]
		public void Test_VerifyThatFbSignInButtonRedirectToTheFaceBookLoginPage()
		{
			//To-Do
		}
	}
}
