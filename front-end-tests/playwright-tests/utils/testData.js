export function getRandomUser() {
    const id = Date.now();

    return {
        username: `testUser${id}`,
        email: `testUser${id}@email.com`,
        password: 'Test1234!'
    };
}

const existingUser = {
    email: 'testUser_123@email.com',
    password: 'test1234'
}

const incorrectPassUser = {
    email: 'testUser_123@email.com',
    password: 'invalidPassword'
}

const unregisteredUser = {
    email: 'unregUser_123@email.com',
    password: 'test1234!'
}

export { existingUser, incorrectPassUser, unregisteredUser };