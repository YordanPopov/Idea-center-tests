export class CreateIdeaPage {
    constructor(page) {
        this.page = page;
        this.titleInput = page.getByRole('input', { name: 'Title' });
        this.pictureUrlInput = page.getByRole('input', { name: 'Url' });
        this.descriptionInput = page.getByRole('textarea', { name: 'Description' });
        this.createBtn = page.getByRole('button', { type: 'submit' });
    }

    async goto() {
        await this.page.goto('http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:83/Ideas/Create');
    }

    async fillIdeaInfo({ title, pictureUrl, description }) {
        if (title) {
            await this.titleInput.fill(title);
        }

        if (pictureUrl) {
            await this.pictureUrlInput.fill(pictureUrl);
        }

        if (description) {
            await this.descriptionInput.fill(description);
        }
    }

    async clickCreateBtn() {
        await this.createBtn.click();
    }
}