export function getRandomUser() {
    const id = Date.now();

    return {
        username: `testUser${id}`,
        email: `testUser${id}@email.com`,
        password: 'Test1234!'
    };
}