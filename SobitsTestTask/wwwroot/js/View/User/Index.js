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

    var button = `<a href=" " class="btn btn-outline-danger">Delete</a>`;
    

    const row = `<tr>
            <td width="40%">${user.name}</td>
            <td width="40%">${user.balance}</td>
            <td width="20%">${button}</td>
        </tr>`;
    return row;
}