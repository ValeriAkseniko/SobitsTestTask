$(document).ready(async function () {

    await Find();

});

async function Find() {

    const purchases = await FindListPurchase();
    console.log(purchases);
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
        const row = CreatePurchaseRow(purchase.users[i]);
        let id = `#${purchase.id}`;
        $(id).append(row);
    }
}
function CreatePurchaseRow(userByPurchase) {

    var button = `<a href=" " class="btn btn-outline-danger">Payment</a>`;

    const row = `<tr>
            <td width="25%">${userByPurchase.userName}</td>
            <td width="25%">${userByPurchase.status}</td>
            <td width="25%">${userByPurchase.debt}</td>
            <td width="25%">${button}</td>
        </tr>`;
    return row;
}