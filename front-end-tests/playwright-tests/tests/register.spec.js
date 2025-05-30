import { test, expect } from '@playwright/test';
import { SignUpPage } from '../pages/SignUpPage.js';
import { HomePage } from '../pages/HomePage.js';
import { existingUser, getRandomUser, unregisteredUser } from '../utils/testData.js'


test.describe('Successful user registration', () => {

    test('Succesful user registration via SIGN UP FOR FREE button.', async ({ page }) => {
        const homePage = new HomePage(page);
        const signUpPage = new SignUpPage(page);
        const user = getRandomUser();

        await homePage.goto();
        await homePage.clickSignUp();


        await signUpPage.register(user);

        const logoutBtn = await page.locator('//a[@type="button" and @href="/Users/Logout"]');
        await expect(logoutBtn).toBeVisible();
    });

    test('Succesful user registration via carousel REGISTER NOW button', async ({ page }) => {
        const homePage = new HomePage(page);
        const signUpPage = new SignUpPage(page);
        const user = getRandomUser();

        await homePage.goto();

        const registerButton = await page.locator('//div[@class="carousel-item active"]//a[@class="btn btn-secondary my-2"]');
        registerButton.waitFor({ state: 'visible', timeout: 5000 });
        registerButton.click();

        await signUpPage.register(user);

        const logoutBtn = await page.locator('//a[@type="button" and @href="/Users/Logout"]');
        await expect(logoutBtn).toBeVisible();
    });
});

test.describe('Failed user registration', async () => {

    test('A user cannot register with empty fields.', async ({ page }) => {
        const signUpPage = new SignUpPage(page);

        await signUpPage.goto();

        await signUpPage.registerBtn.click();

        await expect(page).toHaveURL(/.*\/Users\/Register/);

        const usernameErrMsg = await page.locator('//span[@data-valmsg-for="UserName"]').textContent();
        const emailErrMsg = await page.locator('//span[@data-valmsg-for="Email"]').textContent();
        const passErrMsg = await page.locator('//span[@data-valmsg-for="Password"]').textContent();
        const rePassErrMsg = await page.locator('//span[@data-valmsg-for="RePassword"]').textContent();
        const agreementErrMsg = await page.locator('//span[@data-valmsg-for="AcceptedAgreement"]').textContent();

        expect(usernameErrMsg).toBe('User name is required!');
        expect(emailErrMsg).toBe('The e-mail is required!');
        expect(passErrMsg).toBe('The password is required!');
        expect(rePassErrMsg).toBe('The repeat password is required!');
        expect(agreementErrMsg).toBe('You must accept the terms.');
    });

    test('A user cannot register with empty username field.', async ({ page }) => {
        const signUpPage = new SignUpPage(page);

        await signUpPage.goto();
        await signUpPage.email.fill(unregisteredUser.email);
        await signUpPage.password.fill(unregisteredUser.password);
        await signUpPage.rePassword.fill(unregisteredUser.password);
        await signUpPage.agreement.click();
        await signUpPage.registerBtn.click();

        await expect(page).toHaveURL(/.*\Users\/Register/);
        const usernameErrMsg = await page.locator('//span[@data-valmsg-for="UserName"]').textContent();
        expect(usernameErrMsg).toBe('User name is required!');
    });

    test('A user cannot register with empty email field.', async ({ page }) => {
        const signUpPage = new SignUpPage(page);

        await signUpPage.goto();
        await signUpPage.username.fill('someUser');
        await signUpPage.password.fill(unregisteredUser.password);
        await signUpPage.rePassword.fill(unregisteredUser.password);
        await signUpPage.agreement.click();
        await signUpPage.registerBtn.click();

        await expect(page).toHaveURL(/.*\/Users\/Register/);
        const emailErrMsg = await page.locator('//span[@data-valmsg-for="Email"]').textContent();
        expect(emailErrMsg).toBe('The e-mail is required!');
    });

    test('A user cannot register with empty password field.', async ({ page }) => {
        const signUpPage = new SignUpPage(page);

        await signUpPage.goto();
        await signUpPage.username.fill('someUser');
        await signUpPage.email.fill(unregisteredUser.email);
        await signUpPage.rePassword.fill(unregisteredUser.password);
        await signUpPage.agreement.click();
        await signUpPage.registerBtn.click();

        await expect(page).toHaveURL(/.*\/Users\/Register/);
        const passErrMsg = await page.locator('//span[@data-valmsg-for="Password"]').textContent();
        expect(passErrMsg).toBe('The password is required!');
    });

    test('A user cannot register with empty repeat password field.', async ({ page }) => {
        const signUpPage = new SignUpPage(page);

        await signUpPage.goto();
        await signUpPage.username.fill('someUser');
        await signUpPage.email.fill(unregisteredUser.email);
        await signUpPage.password.fill(unregisteredUser.password);
        await signUpPage.agreement.click();
        await signUpPage.registerBtn.click();

        await expect(page).toHaveURL(/.*\/Users\/Register/);
        const rePassErrMsg = await page.locator('//span[@data-valmsg-for="RePassword"]').textContent();
        expect(rePassErrMsg).toBe('The repeat password is required!');
    });

    test('A user cannot register with mismatched password fields.', async ({ page }) => {
        const signUpPage = new SignUpPage(page);

        await signUpPage.goto();
        await signUpPage.username.fill('someUser');
        await signUpPage.email.fill(unregisteredUser.email);
        await signUpPage.password.fill(unregisteredUser.password);
        await signUpPage.rePassword.fill('test4321');
        await signUpPage.agreement.click();
        await signUpPage.registerBtn.click();

        await expect(page).toHaveURL(/.*\/Users\/Register/);
        const rePassErrMsg = await page.locator('//span[@data-valmsg-for="RePassword"]').textContent();
        expect(rePassErrMsg).toBe('Passwords don\'t match.');
    });

    test('A user cannot register with already taken username.', async ({ page }) => {
        const signUpPage = new SignUpPage(page);
        const existingUsername = 'testUser_123';

        await signUpPage.goto();
        await signUpPage.username.fill(existingUsername);
        await signUpPage.email.fill(unregisteredUser.email);
        await signUpPage.password.fill(unregisteredUser.password);
        await signUpPage.rePassword.fill(unregisteredUser.password);
        await signUpPage.agreement.click();
        await signUpPage.registerBtn.click();

        await expect(page).toHaveURL(/.*\/Users\/Register/);

        const usernameErrMsg = await page.locator('//div[@class="text-danger validation-summary-errors"]/ul/li').textContent();
        expect(usernameErrMsg).toBe(`Username '${existingUsername}' is already taken.`);
    });

    test('A user cannot register with already taken email.', async ({ page }) => {
        const signUpPage = new SignUpPage(page);

        await signUpPage.goto();
        await signUpPage.username.fill('newTestUser123');
        await signUpPage.email.fill(existingUser.email);
        await signUpPage.password.fill(unregisteredUser.password);
        await signUpPage.rePassword.fill(unregisteredUser.password);
        await signUpPage.agreement.click();
        await signUpPage.registerBtn.click();

        await expect(page).toHaveURL(/.*\/Users\/Register/);
        const emailErrMsg = await page.locator('//div[@class="text-danger validation-summary-errors"]/ul/li').textContent();
        expect(emailErrMsg).toBe('Email already taken!');
    });
});