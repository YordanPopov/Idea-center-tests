import { expect, test } from '@playwright/test';
import { HomePage } from '../pages/HomePage';
import { describe } from 'node:test';

describe('Verify Home Page Links and Elements', () => {

    test('Verify that guest user sees LOGIN and SIGN UP FOR FREE buttons.', async ({ page }) => {
        const homePage = new HomePage(page);

        await homePage.goto();

        await expect(homePage.signInBtn).toBeVisible();
        await expect(homePage.signUpBtn).toBeVisible();
    });

    test("Verify that guest user sees carousel with 3 slides.", async ({ page }) => {
        const homePage = new HomePage(page);

        await homePage.goto();

        const carouselSlides = page.locator('css=.carousel-item');
        await expect(carouselSlides).toHaveCount(3);
    });
});