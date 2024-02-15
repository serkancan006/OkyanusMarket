/*
* jQuery myCart - v1.0 - 2016-04-21
* http://asraf-uddin-ahmed.github.io/
* Copyright (c) 2016 Asraf Uddin Ahmed; Licensed None
*/

(function ($) {

    "use strict";

    // OptionManager: Seçenekleri yöneten modül
    var OptionManager = (function () {
        var objToReturn = {};

        // Varsayýlan seçenekler
        var defaultOptions = {
            classCartIcon: 'my-cart-icon', // Sepet simgesinin CSS sýnýfý
            classCartBadge: 'my-cart-badge', // Sepet simgesi için sayý rozeti CSS sýnýfý
            classProductQuantity: 'my-product-quantity', // Ürün miktarý giriþ alaný CSS sýnýfý
            classProductRemove: 'my-product-remove', // Ürünü sepetten kaldýrma düðmesi CSS sýnýfý
            classCheckoutCart: 'my-cart-checkout', // Sepeti ödeme düðmesi CSS sýnýfý
            affixCartIcon: true, // Sepet simgesini ekranýn üstünde sabitleme seçeneði
            showCheckoutModal: true, // Ödeme iþlemi için modal penceresini gösterme seçeneði
            clickOnAddToCart: function ($addTocart) { }, // Ürün ekleme iþlemine týklama olayý
            clickOnCartIcon: function ($cartIcon, products, totalPrice, totalQuantity) { }, // Sepet simgesine týklama olayý
            checkoutCart: function (products, totalPrice, totalQuantity) { }, // Sepeti ödeme iþlemine týklama olayý
            getDiscountPrice: function (products, totalPrice, totalQuantity) { return null; } // Ýndirim fiyatýný hesaplama iþlevi
        };

        // Kullanýcý tanýmlý seçenekleri al ve varsayýlan seçeneklerle birleþtir
        var getOptions = function (customOptions) {
            var options = $.extend({}, defaultOptions);
            if (typeof customOptions === 'object') {
                $.extend(options, customOptions);
            }
            return options;
        }

        objToReturn.getOptions = getOptions;
        return objToReturn;
    }());


    // ProductManager: Ürünleri yöneten modül
    var ProductManager = (function () {
        var objToReturn = {};

        // Tüm ürünleri yerel depodan al
        localStorage.products = localStorage.products ? localStorage.products : "";

        // Belirli bir ürünün dizindeki konumunu al
        var getIndexOfProduct = function (id) {
            var productIndex = -1;
            var products = getAllProducts();
            $.each(products, function (index, value) {
                if (value.id == id) {
                    productIndex = index;
                    return;
                }
            });
            return productIndex;
        }

        // Tüm ürünleri yerel depoya ayarla
        var setAllProducts = function (products) {
            localStorage.products = JSON.stringify(products);
        }

        // Yeni bir ürün ekle
        var addProduct = function (id, name, summary, price, quantity, image) {
            var products = getAllProducts();
            products.push({
                id: id,
                name: name,
                summary: summary,
                price: price,
                quantity: quantity,
                image: image
            });
            setAllProducts(products);
        }

        // Tüm ürünleri al
        var getAllProducts = function () {
            try {
                var products = JSON.parse(localStorage.products);
                return products;
            } catch (e) {
                return [];
            }
        }

        // Ürün miktarýný güncelle
        var updatePoduct = function (id, quantity) {
            var productIndex = getIndexOfProduct(id);
            if (productIndex < 0) {
                return false;
            }
            var products = getAllProducts();
            products[productIndex].quantity = typeof quantity === "undefined" ? products[productIndex].quantity * 1 + 1 : quantity;
            setAllProducts(products);
            return true;
        }

        // Ürün ekle veya güncelle
        var setProduct = function (id, name, summary, price, quantity, image) {
            if (typeof id === "undefined") {
                console.error("id required")
                return false;
            }
            if (typeof name === "undefined") {
                console.error("name required")
                return false;
            }
            if (typeof image === "undefined") {
                console.error("image required")
                return false;
            }
            if (!$.isNumeric(price)) {
                console.error("price is not a number")
                return false;
            }
            if (!$.isNumeric(quantity)) {
                console.error("quantity is not a number");
                return false;
            }
            summary = typeof summary === "undefined" ? "" : summary;

            if (!updatePoduct(id)) {
                addProduct(id, name, summary, price, quantity, image);
            }
        }

        // Tüm ürünleri temizle
        var clearProduct = function () {
            setAllProducts([]);
        }

        // Ürünü sil
        var removeProduct = function (id) {
            var products = getAllProducts();
            products = $.grep(products, function (value, index) {
                return value.id != id;
            });
            setAllProducts(products);
        }

        // Toplam ürün miktarýný al
        var getTotalQuantity = function () {
            var total = 0;
            var products = getAllProducts();
            $.each(products, function (index, value) {
                total += value.quantity * 1;
            });
            return total;
        }

        // Toplam fiyatý hesapla
        var getTotalPrice = function () {
            var products = getAllProducts();
            var total = 0;
            $.each(products, function (index, value) {
                total += value.quantity * value.price;
            });
            return total;
        }

        objToReturn.getAllProducts = getAllProducts;
        objToReturn.updatePoduct = updatePoduct;
        objToReturn.setProduct = setProduct;
        objToReturn.clearProduct = clearProduct;
        objToReturn.removeProduct = removeProduct;
        objToReturn.getTotalQuantity = getTotalQuantity;
        objToReturn.getTotalPrice = getTotalPrice;
        return objToReturn;
    }());


    // loadMyCartEvent: Sepet etkinliklerini yükleyen fonksiyon
    var loadMyCartEvent = function (userOptions) {

        var options = OptionManager.getOptions(userOptions);
        var $cartIcon = $("." + options.classCartIcon);
        var $cartBadge = $("." + options.classCartBadge);
        var classProductQuantity = options.classProductQuantity;
        var classProductRemove = options.classProductRemove;
        var classCheckoutCart = options.classCheckoutCart;

        var idCartModal = 'my-cart-modal';
        var idCartTable = 'my-cart-table';
        var idGrandTotal = 'my-cart-grand-total';
        var idEmptyCartMessage = 'my-cart-empty-message';
        var idDiscountPrice = 'my-cart-discount-price';
        var classProductTotal = 'my-product-total';
        var classAffixMyCartIcon = 'my-cart-icon-affix';

        $cartBadge.text(ProductManager.getTotalQuantity());

        // Sepet modalýný oluþtur
        if (!$("#" + idCartModal).length) {
            $('body').append(
                '<div class="modal fade" id="' + idCartModal + '" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">' +
                '<div class="modal-dialog" role="document">' +
                '<div class="modal-content">' +
                '<div class="modal-header">' +
                '<button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>' +
                '<h4 class="modal-title" id="myModalLabel"><span class="glyphicon glyphicon-shopping-cart"></span> My Cart</h4>' +
                '</div>' +
                '<div class="modal-body">' +
                '<table class="table table-hover table-responsive" id="' + idCartTable + '"></table>' +
                '</div>' +
                '<div class="modal-footer">' +
                '<button type="button" class="btn btn-default" data-dismiss="modal">Kapat</button>' +
                '</div>' +
                '</div>' +
                '</div>' +
                '</div>'
            );
        }

        // Sepet tablosunu oluþtur ve modalý göster
        var drawTable = function () {
            var $cartTable = $("#" + idCartTable);
            $cartTable.empty();

            var products = ProductManager.getAllProducts();
            $.each(products, function () {
                var total = this.quantity * this.price;
                $cartTable.append(
                    '<tr title="' + this.summary + '" data-id="' + this.id + '" data-price="' + this.price + '">' +
                    '<td class="text-center" style="width: 30px;"><img width="30px" height="30px" src="' + this.image + '"/></td>' +
                    '<td>' + this.name + '</td>' +
                    '<td title="Birim Fiyatý">$' + this.price + '</td>' +
                    '<td title="Miktar"><input type="number" min="1" style="width: 70px;" class="' + classProductQuantity + '" value="' + this.quantity + '"/></td>' +
                    '<td title="Total" class="' + classProductTotal + '">$' + total + '</td>' +
                    '<td title="Sepetten Kaldýr" class="text-center" style="width: 30px;"><a href="javascript:void(0);" class="btn btn-xs btn-danger ' + classProductRemove + '">X</a></td>' +
                    '</tr>'
                );
            });

            $cartTable.append(products.length ?
                '<tr>' +
                '<td></td>' +
                '<td><strong>Toplam</strong></td>' +
                '<td></td>' +
                '<td></td>' +
                '<td><strong id="' + idGrandTotal + '">$</strong></td>' +
                '<td></td>' +
                '</tr>'
                : '<div class="alert alert-danger" role="alert" id="' + idEmptyCartMessage + '">Sepetinizde ürün bulunmamaktadýr.</div>'
            );

            // Ýndirim fiyatýný göster (varsa)
            var discountPrice = options.getDiscountPrice(products, ProductManager.getTotalPrice(), ProductManager.getTotalQuantity());
            if (products.length && discountPrice !== null) {
                $cartTable.append(
                    '<tr style="color: red">' +
                    '<td></td>' +
                    '<td><strong>Toplam(Ýndirimli)</strong></td>' +
                    '<td></td>' +
                    '<td></td>' +
                    '<td><strong id="' + idDiscountPrice + '">$</strong></td>' +
                    '<td></td>' +
                    '</tr>'
                );
            }

            showGrandTotal();
            showDiscountPrice();
        }

        // Sepet modalýný göster
        var showModal = function () {
            drawTable();
            $("#" + idCartModal).modal('show');
        }

        // Sepeti güncelle
        var updateCart = function () {
            $.each($("." + classProductQuantity), function () {
                var id = $(this).closest("tr").data("id");
                ProductManager.updatePoduct(id, $(this).val());
            });
        }

        // Toplam fiyatý göster
        var showGrandTotal = function () {
            $("#" + idGrandTotal).text("$" + ProductManager.getTotalPrice());
        }

        // Ýndirim fiyatýný göster
        var showDiscountPrice = function () {
            $("#" + idDiscountPrice).text("$" + options.getDiscountPrice(ProductManager.getAllProducts(), ProductManager.getTotalPrice(), ProductManager.getTotalQuantity()));
        }

        // Sepet simgesini ekranýn üstünde sabitle
        if (options.affixCartIcon) {
            var cartIconBottom = $cartIcon.offset().top * 1 + $cartIcon.css("height").match(/\d+/) * 1;
            var cartIconPosition = $cartIcon.css('position');
            $(window).scroll(function () {
                if ($(window).scrollTop() >= cartIconBottom) {
                    $cartIcon.css('position', 'fixed').css('z-index', '999').addClass(classAffixMyCartIcon);
                } else {
                    $cartIcon.css('position', cartIconPosition).css('background-color', 'inherit').removeClass(classAffixMyCartIcon);
                }
            });
        }

        // Sepet simgesine týklama olayý
        $cartIcon.click(function () {
            options.showCheckoutModal ? showModal() : options.clickOnCartIcon($cartIcon, ProductManager.getAllProducts(), ProductManager.getTotalPrice(), ProductManager.getTotalQuantity());
        });

        // Ürün miktarý deðiþikliði olayý
        $(document).on("input", "." + classProductQuantity, function () {
            var price = $(this).closest("tr").data("price");
            var id = $(this).closest("tr").data("id");
            var quantity = $(this).val();

            $(this).parent("td").next("." + classProductTotal).text("$" + price * quantity);
            ProductManager.updatePoduct(id, quantity);

            $cartBadge.text(ProductManager.getTotalQuantity());
            showGrandTotal();
            showDiscountPrice();
        });

        // Klavye olaylarýný engelle
        $(document).on('keypress', "." + classProductQuantity, function (evt) {
            if (evt.keyCode == 38 || evt.keyCode == 40) {
                return;
            }
            evt.preventDefault();
        });

        // Ürünü sepetten kaldýrma olayý
        $(document).on('click', "." + classProductRemove, function () {
            var $tr = $(this).closest("tr");
            var id = $tr.data("id");
            $tr.hide(500, function () {
                ProductManager.removeProduct(id);
                drawTable();
                $cartBadge.text(ProductManager.getTotalQuantity());
            });
        });

        // Ödeme iþlemi olayý
        $("." + classCheckoutCart).click(function () {
            var products = ProductManager.getAllProducts();
            if (!products.length) {
                $("#" + idEmptyCartMessage).fadeTo('fast', 0.5).fadeTo('fast', 1.0);
                return;
            }
            updateCart();
            options.checkoutCart(ProductManager.getAllProducts(), ProductManager.getTotalPrice(), ProductManager.getTotalQuantity());
            ProductManager.clearProduct();
            $cartBadge.text(ProductManager.getTotalQuantity());
            $("#" + idCartModal).modal("hide");
        });

    }

    // MyCart: Sepet iþlevini uygulayan sýnýf
    var MyCart = function (target, userOptions) {
        var $target = $(target);
        var options = OptionManager.getOptions(userOptions);
        var $cartIcon = $("." + options.classCartIcon);
        var $cartBadge = $("." + options.classCartBadge);

        // Týklama olayý
        $target.click(function () {
            options.clickOnAddToCart($target);

            var id = $target.data('id');
            var name = $target.data('name');
            var summary = $target.data('summary');
            var price = $target.data('price');
            var quantity = $target.data('quantity');
            var image = $target.data('image');

            ProductManager.setProduct(id, name, summary, price, quantity, image);
            $cartBadge.text(ProductManager.getTotalQuantity());
        });

    }

    // jQuery eklentisi olarak MyCart'ý tanýmla
    $.fn.myCart = function (userOptions) {
        loadMyCartEvent(userOptions);
        return $.each(this, function () {
            new MyCart(this, userOptions);
        });
    }

})(jQuery);
