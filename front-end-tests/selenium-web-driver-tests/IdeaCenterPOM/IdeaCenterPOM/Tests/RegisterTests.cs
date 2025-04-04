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
		public RegisterTests(string browserType) : base(browserType) { }

		[Test]
		public void Test_RegisterUserWithEmptyFields()
		{
			_registerPage.OpenPage();
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
			_registerPage.OpenPage();

			var faker = new Faker();
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
			_registerPage.OpenPage();

			var faker = new Faker();
			string uName = faker.Internet.UserName();
			string email = faker.Internet.Email();
			string pass = faker.Internet.Password();
			string rePass = pass;
			_registerPage.RegisterUser(uName, email, pass, rePass, false);

			Assert.That(_registerPage.IsPageOpened(), Is.True);
			Assert.That(_registerPage.AcceptedAgreementErrMsg, Is.EqualTo("You must accept the terms."));
		}
	}
}
