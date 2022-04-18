$(document).ready(async function () {

    await Find();

});

async function Find() {

    const purchases = await FindListPurchase();
    for (let i = 0; i < purchases.length; i++) {
        let table = `${purchases[i].title}
                    <br />${purchases[i].buyer}
                    <br />
                        <table class="table table-hover" width="100%">
                            <tbody id="${purchases[i].id}">
                            </tbody>
                        </table>
                    <br />`;        
        $("#table-list").append(table);
        FillPurchase(purchases[i]);
    }
}

function FillPurchase(purchase) {
    
    for (let i = 0; i < purchase.users.length; i++) {
        const row = CreatePurchaseRow(purchase.users[i], purchase.id);
        let id = `#${purchase.id}`;
        $(id).append(row);
    }
}
async function Payment(userByPurchaseId, purchaseId) {
     let data = {
         PurchaseId: purchaseId,
         UserId: userByPurchaseId
    };    
     PaymentByUser(data);
}

function CreatePurchaseRow(userByPurchase, purchaseId) {

    var blank;
    if (userByPurchase.status) {
        blank = "Оплачено"
    }
    else {
        blank = "Не оплачено"
    }
    var button = `<button type="button" class="btn btn-danger" onclick="Payment('${userByPurchase.id}', '${purchaseId}')">Payment</button>`;

    const row = `<tr>
            <td width="25%">${userByPurchase.userName}</td>
            <td width="25%">${blank}</td>
            <td width="25%">${userByPurchase.debt}</td>
            <td width="25%">${button}</td>
        </tr>`;
    return row;
}