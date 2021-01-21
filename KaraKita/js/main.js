/*! /*! www.cadamdigital.com - v1.0.0 - 2020
 * Copyright (c) 2020 - designerAgency: Diverseffect.com;
 */

$(function () {
    $.app = {

        PageLoad: function () {
            $.app.MobileMenu();
            $.app.fancybox();
        },
        //fancybox
        fancybox: function () {
            $("[data-fancybox]").fancybox({
                margin: [0, 0]
            });
            $.fancybox.defaults.hash = false;
        },
        //MobileMenu
		MobileMenu : function(){
			//Mobile SubMenu Olusturma
            var SubPageTopMenu = $('.header .topRow .info').html();
            var SubPageSocial = $('.header .social').html();
			var SubPageMenu = $('.header .Menu ul').html();
            
			//$(".MobilMenu").append('<ul class="navMenu">'+SubPageMenu+SubPageTopMenu+'</ul><div class="SearchBar">' + SearchBar + '</div><ul class="mobileSocial">'+SubSocialMenu+'</ul>');
			$(".MobilMenu").append('<div class="container-fluid WhiteRow"><div class="container-fluid container"><ul class="navMenu">'+SubPageMenu+'</ul></div></div><div class="container-fluid greyRow"><div class="container-fluid container"><div class="menuRow">'+SubPageTopMenu+'</div><div class="socialRow">'+SubPageSocial+'</div></div></div>');

            
			$(".MobileBt").on("click", function () {
				$(this).toggleClass("push");
                $(".MobilMenu").toggleClass("OpenMenu");
                $("body").toggleClass("release");
                $("html").toggleClass("htmlrelease");
				return false;
            });
            
             $(".SubPageMenu").on("click", function (event) {
                event.preventDefault();
				$(".SubPageMenu").toggleClass("push");
                var subSticky = $(this).closest(".leftMenu").find("ul:first");
				if((subSticky.is(':visible'))){
					subSticky.slideUp(300);
					subSticky.removeClass("subSticky");
				}else{
					subSticky.slideDown(300);
					subSticky.addClass("subSticky");
				}
				return false;
            });
		}
    }
});

$(document).ready(function ($) {
    $.app.PageLoad();

    $(window).on("scroll", function () {
        if ($(window).scrollTop() >= 2) {
            $('body').addClass("sticky");
        } else {
            $('body').removeClass("sticky");
        }

    });
});