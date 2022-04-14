async function FindListPurchase() {
    return await $.ajax({
        type: 'GET',
        accepts: "application/json",
        url: "purchase/getListPurchase",
        data: null
    });
}
