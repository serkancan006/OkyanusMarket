'use strict';
$(document).ready(function () {
    getBasketItems();
    orderSummaryComponenetRender();
});

function getBasketItems() {
    $.ajax({
        url: '/Basket/GetBasketItems/',
        type: 'GET',
        success: function (data) {
            let basketItems = data.items;
            let totalPrice = data.totalPrice;
            let totalItems = data.totalItems;
            $('#totalBasketItem').text(totalItems);
            let basketModalContentHtml = '';
            basketModalContentHtml += '<div class="modal-content">';
            basketModalContentHtml += '<div class="modal-header"><button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button><h4 class="modal-title" id="myModalLabel"><span class="glyphicon glyphicon-shopping-cart"></span> Sepetim</h4></div>';

            if (basketItems != null && basketItems.length > 0) {
                basketModalContentHtml += '<table class="table table-hover table-responsive" id="my-cart-table"><thead><tr><th>Resim</th><th>Ürün Adı</th><th>Fiyat</th><th>Miktar</th><th>Birim</th><th>Toplam</th><th>Ürünü Kaldır</th></tr></thead><tbody>';
                basketItems.forEach(function (item) {
                    basketModalContentHtml += `
                <tr>
                    <td class="text-center" style="width: 50px;"><img width="50px" height="50px" src="${item.imageUrl ? item.imageUrl : "/web/images/resimhazirlaniyor.png"}" /></td>
                    <td>${item.name}</td>
                    <td><label>₺${item.price}</label> ${item.realPrice != null ? '<p style="text-decoration: line-through;">₺' + item.realPrice + '</p>' : ""}</td>
                    <td><input type="number" max="${item.stock}" min="${item.increaseAmount}" step="${item.increaseAmount}" style="width: 70px;" class="my-product-quantity" value="${item.quantity}" onchange="updateBasketItemQuantity('${item.productId}', this.value, '${item.birim}', ${item.stock},${item.increaseAmount})" /></td>
                    <td>${item.birim}</td>
                    <td class="my-product-total">₺${item.totalPrice}</td>
                    <td class="text-center" style="width: 30px;"><a href="javascript:void(0);" class="btn btn-xs btn-danger my-product-remove" onclick="deleteBasketItem('${item.productId}')">X</a></td>
                </tr>`;
                });

                basketModalContentHtml += `<tr><td class="text-center" style="width: 50px;"></td><td><td></td></td><td></td><td>Toplam Fiyat:</td><td>₺${totalPrice}</td><td></td></tr>`;

                basketModalContentHtml += '</tbody></table>';
            } else {
                basketModalContentHtml += '<div class="alert alert-danger alert-dismissable"><button aria-hidden="true" data-dismiss="alert" class="close" type="button">×</button>Sepetinizde ürün bulunmamaktadır.</div>';
            }

            basketModalContentHtml += `<div class="modal-footer"><button type="button" class="btn btn-danger" data-dismiss="modal">Kapat</button>`;
            basketModalContentHtml += `<a href="/Order/Index/" class="btn btn-success" style="background-color:#029241;">Sipariş Ver</a>`;
            //basketModalContentHtml += `<button type="button" class="btn btn-success" style="background-color:#029241;" onclick="createOrder('@*@isAuthenticate*@')">Sipariş Ver</button></div>`;
            basketModalContentHtml += '</div>';

            // Append the generated HTML content to the modal
            $('#basketModalContentHtml').html(basketModalContentHtml);
        },
        error: function (err) {
        }
    });
}

function addBasket(id) {
    $.ajax({
        url: '/Basket/AddBasketItem/' + id,
        type: 'POST',
        success: function (data) {
            getBasketItems();
            toastNotifySuccess("sepete ürün eklendi!", 3000);
        },
        error: function (err) {
        }
    });
}

function updateBasketItemQuantity(id, quantity, birim, stock, increaseAmount) {
    quantity = parseFloat(quantity);
    stock = parseFloat(stock);
    increaseAmount = parseFloat(increaseAmount);
    $.ajax({
        url: '/Basket/UpdateBasketItemQuantity/',
        type: 'POST',
        data: { id: id, quantity: quantity, birim: birim, stock: stock, increaseAmount: increaseAmount },
        success: function (data) {
            getBasketItems();
            orderSummaryComponenetRender();
        },
        error: function (err) {
            getBasketItems();
            orderSummaryComponenetRender();
            toastNotifyError(err.responseText, 3000);
            //console.log(err.responseText);
        }
    });
}

function deleteBasketItem(id) {
    $.ajax({
        url: '/Basket/deleteBasketItem/' + id,
        type: 'DELETE',
        success: function (data) {
            getBasketItems();
            orderSummaryComponenetRender();
        },
        error: function (err) {
        }
    });
}

//function createOrder(isAuth) {
//    if (isAuth == "True") {
//        //window.location.href = '/Order';
//    }
//    else {
//        //window.location.href = '/Login';
//    }
//else {
//    Swal.fire({
//        title: 'Giriş yapmadan sipariş vermek istiyor musunuz?',
//        icon: 'question',
//        showDenyButton: true,
//        showCancelButton: false,
//        confirmButtonText: 'Giriş Yap',
//        denyButtonText: 'Devam Et'
//    }).then((result) => {
//        if (result.isConfirmed) {
//            window.location.href = '/Login';
//        } else if (result.isDenied) {
//            window.location.href = '/Order';
//        }
//    });
//}
//}

function openProductDetailModal(id) {
    console.log(id);
    $.ajax({
        url: '/Product/_OrderDetailModal/' + id,
        type: 'GET',
        success: function (data) {
            $('#productDetailModalContainer').html(data);
        },
        error: function (err) {
        }
    });
}

function orderSummaryComponenetRender() {
    $.ajax({
        url: '/Order/OrderSummaryComponent/',
        type: 'GET',
        success: function (data) {
            $('#orderSummaryComponentContainer').html(data);
        },
        error: function (err) {
        }
    });
}

function addFavoriteProduct(id) {
    $.ajax({
        url: '/User/FavoriUrunler/AddFavoriUrunler/' + id,
        type: 'GET',
        success: function (data) {
            toastNotifySuccess(data, 3000);
        },
        error: function (err) {
            toastNotifyError(err.responseText, 3000);
        }
    });
}

//document.addEventListener('contextmenu', function (e) {
//    e.preventDefault();
//});
