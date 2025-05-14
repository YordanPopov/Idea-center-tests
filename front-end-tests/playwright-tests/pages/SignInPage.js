export class SignInPage {
    constructor(page) {
        this.email = page.locator('//input[@name="Email"]');
        this.password = page.locator('//input[@name="Password"]');
        this.signInBtn = page.locator('//button[@type="submit" and text()="Sign in"]');
    }

    async login({ email, password }) {
        await this.email.fill(email);
        await this.password.fill(password);
        await this.signInBtn.click();
    }
}