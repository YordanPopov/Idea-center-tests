using Bogus;
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
	public class RegisterTests : BaseTest
	{
		Faker faker;
		public RegisterTests(string browserType) : base(browserType) { }

		[SetUp]
		public void Register_SetUp()
		{
			_registerPage.OpenPage();
			faker = new Faker();
		}

		[Test]
		public void Test_RegisterUserWithEmptyFields()
		{
			_registerPage.RegisterUser("", "", "", "", false);

			Assert.That(_registerPage.IsPageOpened(), Is.True);
			Assert.That(_registerPage.UserNameErrMsg, Is.EqualTo("User name is required!"));
			Assert.That(_registerPage.EmailErrMsg, Is.EqualTo("The e-mail is required!"));
			Assert.That(_registerPage.PasswordErrMsg, Is.EqualTo("The password is required!"));
			Assert.That(_registerPage.RePasswordErrMsg, Is.EqualTo("The repeat password is required!"));
			Assert.That(_registerPage.AcceptedAgreement.Selected, Is.False);
			Assert.That(_registerPage.AcceptedAgreementErrMsg, Is.EqualTo("You must accept the terms."));
		}

		[Test]
		public void Test_RegisterUserWithValidData()
		{
			string uName = faker.Internet.UserName();
			string email = faker.Internet.Email();
			string pass = faker.Internet.Password();
			string rePass = pass;
			_registerPage.RegisterUser(uName, email, pass, rePass, true);

			Assert.That(_homePage.IsPageOpened(), Is.True);
			Assert.That(_homePage.LogoutLink.Displayed, Is.True);
		}

		[Test]
		public void Test_RegisterUserWithoutAcceptAgreement()
		{
			string uName = faker.Internet.UserName();
			string email = faker.Internet.Email();
			string pass = faker.Internet.Password();
			string rePass = pass;
			_registerPage.RegisterUser(uName, email, pass, rePass, false);

			Assert.That(_registerPage.IsPageOpened(), Is.True);
			Assert.That(_registerPage.AcceptedAgreementErrMsg, Is.EqualTo("You must accept the terms."));
		}

		[Test]
		public void Test_RegisterUserWithDifferentRepeatPassword()
		{
			string uName = faker.Internet.UserName();
			string email = faker.Internet.Email();
			string pass = faker.Internet.Password();
			string rePass = faker.Internet.Password();
			_registerPage.RegisterUser(uName, email, pass, rePass, true);

			Assert.That(_registerPage.IsPageOpened(), Is.True);
			Assert.That(_registerPage.RePasswordErrMsg, Is.EqualTo("Passwords don't match."));
		}

		[Test]
		public void Test_RegisterUserWithExistingEmail()
		{
			string uName = faker.Internet.UserName();
			string email = "testUser_123@email.com";
			string pass = faker.Internet.Password();
			string rePass = pass;
			_registerPage.RegisterUser(uName, email, pass, rePass, true);

			Assert.That(_registerPage.IsPageOpened(), Is.True);
			Assert.That(_registerPage.MainErrMsg, Is.EqualTo("Email already taken!"));
		}

		[Test]
		public void Test_RegisterUserWithExistingUserName()
		{
			string uName = "testUser_123";
			string email = faker.Internet.Email();
			string pass = faker.Internet.Password();
			string rePass = pass;
			_registerPage.RegisterUser(uName, email, pass, rePass, true);

			Assert.That(_registerPage.IsPageOpened, Is.True);
			Assert.That(_registerPage.MainErrMsg, Is.EqualTo($"Username '{uName}' is already taken."));
		}
	}
}
