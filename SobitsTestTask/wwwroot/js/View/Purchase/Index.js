$(document).ready(async function () {

    await Find();

});

async function Find() {

    const purchases = await FindListPurchase();
    console.log(purchases);
    for (let i = 0; i < purchases.length; i++) {
        FillPurchase(purchases[i]);
    }    
}

function FillPurchase(purchase) {

    $("#title").text(purchase.title);
    $("#buyer").text(purchase.buyer);

    for (let i = 0; i < purchase.users.length; i++) {
        const row = CreatePurchaseRow(purchase.users[i]);
        $("#purchase-list").append(row);
    }
}
function CreatePurchaseRow(userByPurchase) {
    const row = `<tr>
            <td width="40%">${userByPurchase.userName}</td>
            <td width="30%">${userByPurchase.status}</td>
            <td width="30%">${userByPurchase.debt}</td>
        </tr>`;
    return row;
}