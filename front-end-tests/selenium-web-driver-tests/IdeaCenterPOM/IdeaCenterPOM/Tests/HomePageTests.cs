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
	public class HomePageTests : BaseTest
	{
		public HomePageTests(string browserType) : base(browserType)
		{

		}

		[Test, Order(1)]
		public void Test_VerifyHomePageLinksForLoggedUser()
		{
			_homePage.OpenPage();
			Assert.That(_homePage.LinkHomePage.Displayed, Is.True);
			Assert.That(_homePage.LinkLoginPage.Displayed, Is.True);
			Assert.That(_homePage.LinkRegisterPage.Displayed, Is.True);
		}

		[Test, Order(3)]
		public void Test_VerifyHomePageLinksForLoggedInUser()
		{
			_loginPage.OpenPage();
			_loginPage.LoginUser("testUser_123@email.com", "test1234");

			Assert.That(_homePage.MyProfileLink.Displayed, Is.True);
			Assert.That(_homePage.MyIdeasLink.Displayed, Is.True);
			Assert.That(_homePage.CreateIdeaLink.Displayed, Is.True);
			Assert.That(_homePage.LogoutLink.Displayed, Is.True);
		}

		[Test, Order(4)]
		public void Test_CarouselActiveSlidesTextForLoggedInUser()
		{
			_homePage.OpenPage();
			Assert.That(_homePage.CaroulselActiveSlide.Text.Contains("Wellcome to Idea Center, testUser_123!"));

			_homePage.NextButton.Click();
			Assert.That(_homePage.CaroulselActiveSlide.Text.Contains("Enjoy your space for ideas"));

			_homePage.NextButton.Click();
			Assert.That(_homePage.CaroulselActiveSlide.Text.Contains("Controll your own idea space!"));
		}

		[Test, Order(2)]
		public void Test_CarouselActiveSlidesTextForNonLoggedUser()
		{
			_homePage.OpenPage();
			Assert.That(_homePage.CaroulselActiveSlide.Text.Contains("Be a part of our community!!!"));

			_homePage.NextButton.Click();
			Assert.That(_homePage.CaroulselActiveSlide.Text.Contains("Already have an account?"));

			_homePage.NextButton.Click();
			Assert.That(_homePage.CaroulselActiveSlide.Text.Contains("Enjoy out site!"));
		}
	}
}
