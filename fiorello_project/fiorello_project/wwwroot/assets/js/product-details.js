﻿
jQuery(document).ready(function ($) {
    $(document).on('click', '#tab-title-description', function () {
        $('#tab-description').css("display", "block");
        $("#tab-additional_information").css("display", "none");
        $(this).addClass('active');
        $("#tab-title-additional_information").removeClass('active');
    })

    $(document).on('click', '#tab-title-additional_information', function () {
        $("#tab-additional_information").css("display", "block");
        $('#tab-description').css("display", "none");
        $(this).addClass('active');
        $("#tab-title-description").removeClass('active');
    })
});