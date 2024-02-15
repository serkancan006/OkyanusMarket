/*
* jQuery myCart - v1.0 - 2016-04-21
* http://asraf-uddin-ahmed.github.io/
* Copyright (c) 2016 Asraf Uddin Ahmed; Licensed None
*/

(function ($) {

    "use strict";

    // OptionManager: Se�enekleri y�neten mod�l
    var OptionManager = (function () {
        var objToReturn = {};

        // Varsay�lan se�enekler
        var defaultOptions = {
            classCartIcon: 'my-cart-icon', // Sepet simgesinin CSS s�n�f�
            classCartBadge: 'my-cart-badge', // Sepet simgesi i�in say� rozeti CSS s�n�f�
            classProductQuantity: 'my-product-quantity', // �r�n miktar� giri� alan� CSS s�n�f�
            classProductRemove: 'my-product-remove', // �r�n� sepetten kald�rma d��mesi CSS s�n�f�
            classCheckoutCart: 'my-cart-checkout', // Sepeti �deme d��mesi CSS s�n�f�
            affixCartIcon: true, // Sepet simgesini ekran�n �st�nde sabitleme se�ene�i
            showCheckoutModal: true, // �deme i�lemi i�in modal penceresini g�sterme se�ene�i
            clickOnAddToCart: function ($addTocart) { }, // �r�n ekleme i�lemine t�klama olay�
            clickOnCartIcon: function ($cartIcon, products, totalPrice, totalQuantity) { }, // Sepet simgesine t�klama olay�
            checkoutCart: function (products, totalPrice, totalQuantity) { }, // Sepeti �deme i�lemine t�klama olay�
            getDiscountPrice: function (products, totalPrice, totalQuantity) { return null; } // �ndirim fiyat�n� hesaplama i�levi
        };

        // Kullan�c� tan�ml� se�enekleri al ve varsay�lan se�eneklerle birle�tir
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


    // ProductManager: �r�nleri y�neten mod�l
    var ProductManager = (function () {
        var objToReturn = {};

        // T�m �r�nleri yerel depodan al
        localStorage.products = localStorage.products ? localStorage.products : "";

        // Belirli bir �r�n�n dizindeki konumunu al
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

        // T�m �r�nleri yerel depoya ayarla
        var setAllProducts = function (products) {
            localStorage.products = JSON.stringify(products);
        }

        // Yeni bir �r�n ekle
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

        // T�m �r�nleri al
        var getAllProducts = function () {
            try {
                var products = JSON.parse(localStorage.products);
                return products;
            } catch (e) {
                return [];
            }
        }

        // �r�n miktar�n� g�ncelle
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

        // �r�n ekle veya g�ncelle
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

        // T�m �r�nleri temizle
        var clearProduct = function () {
            setAllProducts([]);
        }

        // �r�n� sil
        var removeProduct = function (id) {
            var products = getAllProducts();
            products = $.grep(products, function (value, index) {
                return value.id != id;
            });
            setAllProducts(products);
        }

        // Toplam �r�n miktar�n� al
        var getTotalQuantity = function () {
            var total = 0;
            var products = getAllProducts();
            $.each(products, function (index, value) {
                total += value.quantity * 1;
            });
            return total;
        }

        // Toplam fiyat� hesapla
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


    // loadMyCartEvent: Sepet etkinliklerini y�kleyen fonksiyon
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

        // Sepet modal�n� olu�tur
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

        // Sepet tablosunu olu�tur ve modal� g�ster
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
                    '<td title="Birim Fiyat�">$' + this.price + '</td>' +
                    '<td title="Miktar"><input type="number" min="1" style="width: 70px;" class="' + classProductQuantity + '" value="' + this.quantity + '"/></td>' +
                    '<td title="Total" class="' + classProductTotal + '">$' + total + '</td>' +
                    '<td title="Sepetten Kald�r" class="text-center" style="width: 30px;"><a href="javascript:void(0);" class="btn btn-xs btn-danger ' + classProductRemove + '">X</a></td>' +
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
                : '<div class="alert alert-danger" role="alert" id="' + idEmptyCartMessage + '">Sepetinizde �r�n bulunmamaktad�r.</div>'
            );

            // �ndirim fiyat�n� g�ster (varsa)
            var discountPrice = options.getDiscountPrice(products, ProductManager.getTotalPrice(), ProductManager.getTotalQuantity());
            if (products.length && discountPrice !== null) {
                $cartTable.append(
                    '<tr style="color: red">' +
                    '<td></td>' +
                    '<td><strong>Toplam(�ndirimli)</strong></td>' +
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

        // Sepet modal�n� g�ster
        var showModal = function () {
            drawTable();
            $("#" + idCartModal).modal('show');
        }

        // Sepeti g�ncelle
        var updateCart = function () {
            $.each($("." + classProductQuantity), function () {
                var id = $(this).closest("tr").data("id");
                ProductManager.updatePoduct(id, $(this).val());
            });
        }

        // Toplam fiyat� g�ster
        var showGrandTotal = function () {
            $("#" + idGrandTotal).text("$" + ProductManager.getTotalPrice());
        }

        // �ndirim fiyat�n� g�ster
        var showDiscountPrice = function () {
            $("#" + idDiscountPrice).text("$" + options.getDiscountPrice(ProductManager.getAllProducts(), ProductManager.getTotalPrice(), ProductManager.getTotalQuantity()));
        }

        // Sepet simgesini ekran�n �st�nde sabitle
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

        // Sepet simgesine t�klama olay�
        $cartIcon.click(function () {
            options.showCheckoutModal ? showModal() : options.clickOnCartIcon($cartIcon, ProductManager.getAllProducts(), ProductManager.getTotalPrice(), ProductManager.getTotalQuantity());
        });

        // �r�n miktar� de�i�ikli�i olay�
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

        // Klavye olaylar�n� engelle
        $(document).on('keypress', "." + classProductQuantity, function (evt) {
            if (evt.keyCode == 38 || evt.keyCode == 40) {
                return;
            }
            evt.preventDefault();
        });

        // �r�n� sepetten kald�rma olay�
        $(document).on('click', "." + classProductRemove, function () {
            var $tr = $(this).closest("tr");
            var id = $tr.data("id");
            $tr.hide(500, function () {
                ProductManager.removeProduct(id);
                drawTable();
                $cartBadge.text(ProductManager.getTotalQuantity());
            });
        });

        // �deme i�lemi olay�
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

    // MyCart: Sepet i�levini uygulayan s�n�f
    var MyCart = function (target, userOptions) {
        var $target = $(target);
        var options = OptionManager.getOptions(userOptions);
        var $cartIcon = $("." + options.classCartIcon);
        var $cartBadge = $("." + options.classCartBadge);

        // T�klama olay�
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

    // jQuery eklentisi olarak MyCart'� tan�mla
    $.fn.myCart = function (userOptions) {
        loadMyCartEvent(userOptions);
        return $.each(this, function () {
            new MyCart(this, userOptions);
        });
    }

})(jQuery);
