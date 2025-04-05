using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeaCenterPOM.Tests
{
	[TestFixture("chrome")]
	//[TestFixture("firefox")]
	//[TestFixture("edge")]
	public class EditProfileTests : BaseTest
	{
		public EditProfileTests(string browserType) : base(browserType)
		{
		}

		[OneTimeSetUp]
		public void EditProfile_OneTimeSetUp()
		{
			_loginPage.OpenPage();
			_loginPage.LoginUser("testUser_123@email.com", "test1234");
		}

		[SetUp]
		public void EditProfile_SetUp()
		{
			_editProfilePage.OpenPage();
		}

		[Test]
		public void Test_EditProfileWithEmptyFields()
		{		
			Assert.That(_editProfilePage.IsPageOpened(), Is.True);

			_editProfilePage.EditProfile("", "", "", "", "");
			Assert.That(_myProfilePage.IsPageOpened(), Is.True);

			Assert.That(_myProfilePage.UserName, Is.EqualTo("testUser_123"));
			Assert.That(_myProfilePage.UserInfo, Is.Empty);
			Assert.That(_myProfilePage.AboutSection, Is.Empty);
		}

		[Test]
		public void Test_EditProfileWithRandomData()
		{
			Assert.That(_editProfilePage.IsPageOpened(), Is.True);

			var faker = new Faker();
			string firstName = faker.Name.FirstName();
			string lastName = faker.Name.LastName();
			string location = faker.Address.City();
			string description = faker.Lorem.Sentence();

			_editProfilePage.EditProfile("", firstName, lastName, location, description);
			Assert.That(_myProfilePage.IsPageOpened(), Is.True);

			Assert.That(_myProfilePage.UserName, Is.EqualTo("testUser_123"));
			Assert.That(_myProfilePage.UserInfo, Does.Contain($"{firstName} {lastName} , {location}"));
			Assert.That(_myProfilePage.AboutSection, Does.Contain(description));		
		}
	}
}
