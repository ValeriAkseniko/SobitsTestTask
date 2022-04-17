async function FindListUser() {
    return await $.ajax({
        type: 'GET',
        accepts: "application/json",
        url: "/user/getListUser",
        data: null
    });
}
async function CreateUser(data) {
    return await $.ajax({
        type: 'POST',
        accepts: "application/json",
        url: "/user/create",
        data: data
    });
}

async function DeleteUser(id) {
    return await $.ajax({
        type: 'POST',
        accepts: "application/json",
        url: `/user/remove?id=${id}`,
        data: null
    });
}
