import { test, expect } from '@playwright/test';
import { SignInPage } from '../pages/SignInPage';

test.describe('Login Page tests', () => {
    const existingUser = {
        email: 'testUser_123@email.com',
        password: 'test1234'
    }

    const incorrectPassUser = {
        email: 'testUser_123@email.com',
        password: 'invalidPassword'
    }

    test('Verify that user can successfully login with correct emai and password.', async ({ page }) => {
        const signInPage = new SignInPage(page);

        await signInPage.goto();
        await signInPage.login(existingUser);

        await expect(page.locator('//a[@type="button"]')).toBeVisible();
    });

    test('Verify that user cannot login with empty fields.', async ({ page }) => {
        const signInPage = new SignInPage(page);

        await signInPage.goto();

        await signInPage.signInBtn.click();

        await expect(page.locator('//div[@class="text-danger validation-summary-errors"]//li')).toContainText('Unable to sign in!');
        await expect(page.locator('//span[@data-valmsg-for="Email"]')).toContainText('The e-mail is required!');
        await expect(page.locator('//span[@data-valmsg-for="Password"]')).toContainText('The password is required!');
    });

    test('Verify than user cannot login with incorrect password.', async ({ page }) => {
        const signInPage = new SignInPage(page);

        await signInPage.goto();
        await signInPage.login(incorrectPassUser);

        await expect(page.locator('//div[@class="text-danger validation-summary-errors"]//li')).toContainText('Unable to sign in!');
    });
});