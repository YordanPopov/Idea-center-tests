import { expect, test } from '@playwright/test';
import { HomePage } from '../pages/HomePage.js';
import { SignInPage } from '../pages/SignInPage.js';

test.describe('Verify Home Page Links and Elements', () => {

    test('Verify that guest user sees LOGIN and SIGN UP FOR FREE buttons.', async ({ page }) => {
        const homePage = new HomePage(page);

        await homePage.goto();

        await expect(homePage.signInBtn).toBeVisible();
        await expect(homePage.signUpBtn).toBeVisible();
    });

    test('Verify that guest user sees navigation to Home form Navbar', async ({ page }) => {
        const homePage = new HomePage(page);

        await homePage.goto();

        const homeLink = page.locator('//a[@class="nav-link"]');
        await expect(homeLink).toBeVisible();
    });

    test('Verify that guest user sees carousel with 3 slides.', async ({ page }) => {
        const homePage = new HomePage(page);

        await homePage.goto();

        const carouselSlides = page.locator('css=.carousel-item');
        await expect(carouselSlides).toHaveCount(3);
    });
});

test.describe('Logged-in user sees appropriate Home Page', async () => {

    const userData = {
        email: 'testUser_123@email.com',
        password: 'test1234'
    }
    test.beforeEach(async ({ page }) => {
        const homePage = new HomePage(page);
        const signInPage = new SignInPage(page);

        await homePage.goto();
        await homePage.clickSignIn();
        await signInPage.login(userData);
    });

    test('Verify that logged-in user do not see LOGIN and SIGN UP FOR FREE buttons.', async ({ page }) => {
        const loginBtn = page.locator('//a[@class="btn btn-outline-info px-3 me-2"]');
        const signUpBtn = page.locator('//a[@href="/Users/Register" and @type="button"]');

        await expect(loginBtn).toHaveCount(0);
        await expect(signUpBtn).toHaveCount(0);
    });
});