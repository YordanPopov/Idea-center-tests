
export class SignUpPage {
    constructor(page) {
        this.page = page;
        this.username = page.locator('//input[@name="UserName"]');
        this.email = page.locator('//input[@name="Email"]');
        this.password = page.locator('//input[@name="Password"]');
        this.rePassword = page.locator('//input[@name="RePassword"]');
        this.agreement = page.locator('//input[@type="checkbox"]');
        this.registerBtn = page.locator('//button[@type="submit"]');
    }

    async goto() {
        await this.page.goto('http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/Users/Register');
    }

    async register({ username, email, password }) {
        await this.username.fill(username);
        await this.email.fill(email);
        await this.password.fill(password);
        await this.rePassword.fill(password);
        await this.agreement.click();
        await this.registerBtn.click();
    }
}