async function FindListPurchase() {
    return await $.ajax({
        type: 'GET',
        accepts: "application/json",
        url: "purchase/getListPurchase",
        data: null
    });
}

async function PaymentByUser(data) {
    return await $.ajax({
        type: 'POST',
        accepts: "application/json",
        url: "purchase/payment",
        data: data
    });
}

async function CreatePurchase(data) {
    return await $.ajax({
        type: 'POST',
        accepts: "application/json",
        url: "/purchase/create",
        data: data
    });
}
