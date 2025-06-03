export class EditProfilePage {
    constructor(page) {
        this.page = page;
        this.profilePictureUrlInput = page.getByRole('input', { name: 'ProfilePicture' });
        this.firstNameInput = page.getByRole('input', { name: 'FirstName' });
        this.lastNameInput = page.getByRole('input', { name: 'LastName' });
        this.cityInput = page.getByRole('input', { name: 'City' });
        this.descriptionInput = page.getByRole('textarea', { name: 'About' });
        this.doneBtn = page.getByRole('button', { type: 'submit' });
    }

    async goto() {
        await this.page.goto('http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/Profile/Edit');
    }

    async fillProfileInfo({ profilePictureUrl, firstName, lastName, city, description }) {
        if (profilePictureUrl) {
            await this.profilePictureUrlInput.fill(profilePictureUrl);
        }
        if (firstName) {
            await this.firstNameInput.fill(firstName);
        }
        if (lastName) {
            await this.lastNameInput.fill(lastName);
        }
        if (city) {
            await this.cityInput.fill(city);
        }
        if (description) {
            await this.descriptionInput.fill(description);
        }
    }

    async clickDoneBtn() {
        await this.doneBtn.click();
    }
}