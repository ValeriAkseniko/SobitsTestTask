async function FindListUser() {
    return await $.ajax({
        type: 'GET',
        accepts: "application/json",
        url: "user/getListUser",
        data: null
    });
}
