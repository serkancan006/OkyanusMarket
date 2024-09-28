'use strict';

$(document).ready(() => {
    let siparisOnaylandiContainer = $("#siparisOnaylandiContainer");
    let siparsinizHazirlaniyorContainer = $("#siparsinizHazirlaniyorContainer");
    let siparisYoldaContainer = $("#yoldaContainer");
    let siparisTeslimEdildiContainer = $("#teslimEdildiContainer");

    let connection = new signalR.HubConnectionBuilder().withUrl("https://api.adlokyanus.com/SignalRHub").build();

    function start() {
        connection.start().then(() => {
            setInterval(() => {
                let url = window.location.pathname;
                let parts = url.split('/');
                let id = parseInt(parts[parts.length - 1]);
                connection.invoke("GetUserOrder", id);
            }, 3000)
        }).catch((err) => {
            setTimeout(() => start(), 5000); // 5 saniye sonra yeniden bağlanmayı dene
        });
    }

    connection.onclose(() => start());

    start();

    connection.on("ReceiveUserOrderStatus", (value) => {
        $("#orderStatusContainer").empty();
        $("#orderStatusContainer").append(value);
        if (value == "Sipariş Onaylandı") {
            siparisOnaylandiContainer.addClass("active")
            siparsinizHazirlaniyorContainer.removeClass("active")
            siparisYoldaContainer.removeClass("active")
            siparisTeslimEdildiContainer.removeClass("active")
        } else if (value == "Hazırlanıyor") {
            siparisOnaylandiContainer.addClass("active")
            siparsinizHazirlaniyorContainer.addClass("active")
            siparisYoldaContainer.removeClass("active")
            siparisTeslimEdildiContainer.removeClass("active")
        } else if (value == "Yolda") {
            siparisOnaylandiContainer.addClass("active")
            siparsinizHazirlaniyorContainer.addClass("active")
            siparisYoldaContainer.addClass("active")
            siparisTeslimEdildiContainer.removeClass("active")
        } else if (value == "Teslim Edildi") {
            siparisOnaylandiContainer.addClass("active")
            siparsinizHazirlaniyorContainer.addClass("active")
            siparisYoldaContainer.addClass("active")
            siparisTeslimEdildiContainer.addClass("active")
        } else {
            siparisOnaylandiContainer.removeClass("active")
            siparsinizHazirlaniyorContainer.removeClass("active")
            siparisYoldaContainer.removeClass("active")
            siparisTeslimEdildiContainer.removeClass("active")
        }
    });
});
