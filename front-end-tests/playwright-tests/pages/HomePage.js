export class HomePage {
    constructor(page) {
        this.page = page;
        this.signUpBtn = page.locator('//a[@class="btn btn-primary me-3"]');
        this.signInBtn = page.locator('//a[@class="btn btn-outline-info px-3 me-2"]');
    }

    async goto() {
        await this.page.goto('http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83');
    }

    async clickSignUp() {
        await this.signUpBtn.click();
    }

    async clickSignIn() {
        await this.signInBtn.click();
    }
}