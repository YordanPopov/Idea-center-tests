import { test, expect } from '@playwright/test';
import { SignUpPage } from '../pages/SignUpPage.js';
import { HomePage } from '../pages/HomePage.js';
import { getRandomUser } from '../utils/testData.js'


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

    test('Succesful user registration via carousel REGISTER NOW button', async ({page}) => {
        const homePage = new HomePage(page);
        const signUpPage = new SignUpPage(page);
        const user = getRandomUser();

        await homePage.goto();

        const registerButton = await page.locator('//div[@class="carousel-item active"]//a[@class="btn btn-secondary my-2"]');
        registerButton.waitFor({state: 'visible', timeout: 5000});
        registerButton.click();

        await signUpPage.register(user);

        const logoutBtn = await page.locator('//a[@type="button" and @href="/Users/Logout"]');
        await expect(logoutBtn).toBeVisible();
    });
});