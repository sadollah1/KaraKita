/*! /*! www.cadamdigital.com - v1.0.0 - 2020
 * Copyright (c) 2020 - designerAgency: Diverseffect.com;
 */

$(function () {
    $.app = {

        PageLoad: function () {
            if ($(".homeSlider").length) {
                $.app.promoSlider();
            };
            if ($(".projectSlide").length) {
                $.app.projectSlider();
            };

        },
        //Ana Sayfa Slider
        promoSlider: function () {
            $('.homeSlider').slick({
                dots: true,
                arrows:false,
                autoplay: true,
                autoplaySpeed: 4000,
                mobileFirst: true,
                easing: "linear",
                edgeFriction: .35,
                lazyLoad: "ondemand",
                infinite: false,
                speed: 500,
                slidesToShow: 1,
                adaptiveHeight: true,
                touchThreshold: 5,
                appendDots: $(".slickDots")
            })
        },
        projectSlider: function () {
            $('.projectSlide').slick({
                dots: false,
                centerMode: false,
                centerPadding: '0px',
                slidesToShow: 3,
                prevArrow: $(".Prev"),
                nextArrow: $(".Next"),
                responsive: [
                    {
                        breakpoint: 992,
                        settings: {
                            arrows: false,
                            centerMode: true,
                            slidesToShow: 2
                        }
                    },
                    {
                        breakpoint: 500,
                        settings: {
                            arrows: false,
                            centerMode: true,
                            slidesToShow: 1
                        }
                    }]
            });
        },
        boxStretch: function () {
            var pageInnerHeight = $(window).height();
            var pageInnerWidth = $(window).width();

            var device = $(window).innerWidth() > 992 ? "desktop" : "mobile";
            $(".homeSlider .Slide").each(function () {
                if (device == "mobile"){
                    $(this).find(".cropcontainer").attr("style", "background-image: url(" + $(this).data(device) + ")");
                } else {
                    $(this).find(".cropcontainer").attr("style", "background-image: url(" + $(this).data(device) + ")");
                }
            });
        }
    }
});

$(document).ready(function ($) {
    $.app.PageLoad();
    $.app.boxStretch();

    $(window).resize(function () {
        $.app.boxStretch();
    });
});


document.onreadystatechange = function () {
    if (document.readyState === 'complete') {
        $.app.boxStretch();
    }
}