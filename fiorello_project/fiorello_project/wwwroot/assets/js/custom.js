﻿jQuery(function ($) {
    $(document).on('click', '#addToCart', function () {
        var id = $(this).data('id');

        $.ajax({
            method: "POST",
            url: "/basket/add",
            data: {
                id: id

            },
            success: function (result) {

                console.log(result);

            }
        })
    })

    $(document).on('click', '#deleteButton', function () {
        var id = $(this).data('id');


        $.ajax({
            method: "POST",
            url: "/basket/delete",
            data: {
                id: id
            },
            success: function (result) {
                $(`.basketProduct[id=${id}]`).remove();
            }

        })
    })


    $(document).on('click', '#addcount', function () {
        var id = $(this).data('id');

        $.ajax({
            method: "POST",
            url: "/basket/upcount",
            data: {
                id: id
            },
            success: function (result) {
                console.log(result);
            }

        })
    })


    $(document).on('click', '#downcount', function () {
        var id = $(this).data('id');

        $.ajax({
            method: "POST",
            url: "/basket/downcount",
            data: {
                id: id
            },
            success: function (result) {
                console.log(result);
            }

        })
    })

})