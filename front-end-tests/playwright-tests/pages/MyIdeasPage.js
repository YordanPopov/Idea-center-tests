import { type } from "os";

export class MyIdeasPage {
    constructor(page) {
        this.page = page;
        this.ideaDescription = page.locator('//p[@class="card-text"]').textContent();
        this.viewIdeaBtn = page.locator('//a[@type="button" and contains(@href, "/Ideas/Read")]');
        this.editIdeaBtn = page.locator('//a[contains(@href, "/Ideas/Edit")]');
        this.deleteIdeaBtn = page.locator('//a[contains(@href, "/Ideas/Delete")]');
        this.searchInput = page.getByRole('input', { type: 'search' });
        this.searchBtn = page.getByRole('a', { id: 'search-button' });
    }

    async goto() {
        await this.page.goto('http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/Ideas/MyIdeas');
    }

    async searchIdea(ideaName) {
        await this.searchInput.fill(ideaName);
        await this.searchBtn.click();
    }

    async viewLastCreatedIdea() {
        await this.page.locator('//a[@type="button" and contains(@href, "/Ideas/Read")]')
            .last()
            .click();
    }

    async editLastCreatedIdea() {
        await this.page.locator('//a[contains(@href, "/Ideas/Edit")]')
            .last()
            .click();
    }

    async deleteLastCreatedIdea() {
        await this.page.locator('//a[contains(@href, "/Ideas/Delete")]')
            .last()
            .click();
    }
}