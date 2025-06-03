export class MyProfilePage {
    constructor(page) {
        this.page = page;
        profileImage = page.getByAltText('Generic placeholder image');
        this.username = page.locator('//div[@class="ms-3"]//h5').textContent();
        this.userInfo = page.locator('//div[@class="ms-3"]//p').textContent();
        this.aboutSection = page.locator('//div[@class="p-4"]/p').textContent();
        this.recentIdeas = page.$$('//div[@class="card-body"]');
        this.showAllBtn = page.locator('//a[@class="text-muted"]');
        this.editProfileBtn = page.getByRole('span', { type: 'button' });
    }

    async goto() {
        await this.page.goto('http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/Profile');
    }

    async clickEditProfileBtn() {
        await this.editProfileBtn.click();
    }
}