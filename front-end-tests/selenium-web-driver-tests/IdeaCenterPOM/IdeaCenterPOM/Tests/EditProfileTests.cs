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

		[Test]
		public void Test_EditProfileWithEmptyFields()
		{
			//To-Do
		}

		[Test]
		public void Test_EditProfileWithRandomData()
		{
			//To-Do
		}
	}
}
