async function CreateItem() {
    const data = {
        Name: $('#user-name').val(),
        Balance: $('#user-balance').val()
    };
    await CreateUser(data);
}