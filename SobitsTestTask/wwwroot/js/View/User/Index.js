$(document).ready(async function () {

    await Find();

});

async function Find() {

    const users = await FindListUser();
    console.log(users);
    FillUsers(users);
}

function FillUsers(users) {
    for (let i = 0; i < users.length; i++) {
        const row = CreateUsersRow(users[i]);
        $("#users-list").append(row);
    }
}
function CreateUsersRow(user) {

    var buttonDelete = `<a href=" " class="btn btn-outline-danger">Delete</a>`;
    

    const row = `<tr>
            <td width="30%">${user.name}</td>
            <td width="30%">${user.balance}</td>
            <td width="20%">${buttonDelete}</td>
        </tr>`;
    return row;
}