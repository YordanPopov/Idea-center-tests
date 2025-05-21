import { test, expect } from '@playwright/test';
import { SignInPage } from '../pages/SignInPage.js';
import { existingUser, incorrectPassUser, unregisteredUser } from '../utils/testData.js';

test.describe('Login Page tests', () => {

    test('Verify that user can successfully login with correct email and password.', async ({ page }) => {
        const signInPage = new SignInPage(page);

        await signInPage.goto();
        await signInPage.login(existingUser);

        const logoutBtn = await page.locator('//a[@type="button" and @href="/Users/Logout"]');
        await expect(logoutBtn).toBeVisible();
    });

    test('Verify that user cannot login with empty fields.', async ({ page }) => {
        const signInPage = new SignInPage(page);

        await signInPage.goto();

        await signInPage.signInBtn.click();

        const mainErrorMsg = await page.locator('//div[@class="text-danger validation-summary-errors"]//li').textContent();
        const emailErrorMsg = await page.locator('//span[@data-valmsg-for="Email"]').textContent();
        const passErrorMsg = await page.locator('//span[@data-valmsg-for="Password"]').textContent();

        expect(mainErrorMsg).toBe('Unable to sign in!');
        expect(emailErrorMsg).toBe('The e-mail is required!');
        expect(passErrorMsg).toBe('The password is required!');
    });

    test('Verify than user cannot login with incorrect password.', async ({ page }) => {
        const signInPage = new SignInPage(page);

        await signInPage.goto();
        await signInPage.login(incorrectPassUser);

        const errorMsg = await page.locator('//div[@class="text-danger validation-summary-errors"]/ul/li').textContent();
        expect(errorMsg).toBe('Unable to sign in!');
    });

    test('Unregistered user cannot log in.', async ({ page }) => {
        const signInPage = new SignInPage(page);

        await signInPage.goto();
        await signInPage.login(unregisteredUser);

        const errorMsg = await page.locator('//div[@class="text-danger validation-summary-errors"]/ul/li').textContent();

        expect(errorMsg).toBe('Unable to sign in!');
    });
});