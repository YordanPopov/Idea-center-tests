export class SignInPage {
    constructor(page) {
        this.page = page;
        this.email = page.locator('//input[@name="Email"]');
        this.password = page.locator('//input[@name="Password"]');
        this.signInBtn = page.locator('//button[@type="submit" and text()="Sign in"]');
    }

    async goto() {
        await this.page.goto('http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/Users/Login');
    }

    async login({ email, password }) {
        await this.email.fill(email);
        await this.password.fill(password);
        await this.signInBtn.click();
    }
}