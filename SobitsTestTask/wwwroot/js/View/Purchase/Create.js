$(document).ready(async function () {

    const users = await FindListUser();
    FiilBuyers(users);

});

async function FiilBuyers(users) {
    for (let i = 0; i < users.length; i++) {
        const user = `<option value="${users[i].id}">${users[i].name}</option>`;
        $('#buyer-list').append(user);
    }
}

async function CreateItem() {
    const data = {
        Title: $('#title-purchase').val(),
        Sum: $('#sum-purchase').val(),
        BuyerId: $('#buyer-list').val()
    };
    console.log(data);
    await CreatePurchase(data);
}