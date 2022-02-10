/*
  Theme Name: Cekko - Creative Portfolio and Personal HTML5 Template
  Author: ThemexHunter
  Description: One Page Personal template.
  Version: 1.0
*/

/* JS Index
-----------------------------------
1. Theme default css
2. Header-section
3. Banner-section
4. About-section
5. Services-section
6. protfolio-section
7. Pricing-section
8. Client-section
9. blog-section
10. contact-section
*/

(function ($) {
    "use strict";

let navButton = document.querySelector(".nav-button");

navButton.addEventListener("click", e => {
  e.preventDefault();

  // toggle nav state
  document.body.classList.toggle("nav-visible");
});

$(function() {
    $('.left-sidebar').StickySidebar({
       // Settings
       additionalMarginTop: 90
     });
});	


$('.loading-container').delay(1000).fadeOut(500, function() {});
  
  
  $(window).on('scroll',function() { 
      var scroll = $(window).scrollTop();
   if (scroll < 245) {
    $("#header_sticky_2").removeClass("scroll_header_2");
   }else{
    $("#header_sticky_2").addClass("scroll_header_2");
   }
    });
/* testimonial-active */
$('.about-slider').owlCarousel({
    loop:true,
    nav:false,
	dots:true,
	autoplay:false,
    responsive:{
        0:{
            items:1
        },
        767:{
            items:1
        },
        1000:{
            items:1
        }
    }
})

function mousecursor() {
    if ($("body")) {
        const e = document.querySelector(".cursor-inner"),
            t = document.querySelector(".cursor-outer");
        let n, i = 0,
            o = !1;
        window.onmousemove = function (s) {
            o || (t.style.transform = "translate(" + s.clientX + "px, " + s.clientY + "px)"), e.style.transform = "translate(" + s.clientX + "px, " + s.clientY + "px)", n = s.clientY, i = s.clientX
        }, $("body").on("mouseenter", "a, .cursor-pointer", function () {
            e.classList.add("cursor-hover"), t.classList.add("cursor-hover")
        }), $("body").on("mouseleave", "a, .cursor-pointer", function () {
            $(this).is("a") && $(this).closest(".cursor-pointer").length || (e.classList.remove("cursor-hover"), t.classList.remove("cursor-hover"))
        }), e.style.visibility = "visible", t.style.visibility = "visible"
    }
};

$(function () {
    mousecursor();
});



/* ACTIVE POPUP IMAGE */  
    if ($(".fancybox").length) {
        $(".fancybox").fancybox({
            openEffect  : "elastic",
            closeEffect : "elastic",
            wrapCSS     : "project-fancybox-title-style"
        });
    }
  
/* POPUP VIDEO */  
    if ($(".video-btn").length) {
        $(".video-btn").on("click", function(){
            $.fancybox({
                href: this.href,
                type: $(this).data("type"),
                'title'         : this.title,
                helpers     : {  
                    title : { type : 'inside' },
                    media : {}
                },

                beforeShow : function(){
                    $(".fancybox-wrap").addClass("gallery-fancybox");
                }
            });
            return false
        });    
    }

/* Scroll Up */
$.scrollUp({
	easingType: 'linear',
	scrollSpeed: 900,
	animation: 'fade',
	scrollText: '<i class="fa fa-angle-up"></i>',
});


/* SWIPER SLIDER 4 */	
	var swiper = new Swiper('.swiper-coverflow', {
      effect: 'coverflow',
      grabCursor: true,
      centeredSlides: true,
      slidesPerView: 'auto',
      coverflowEffect: {
        rotate: 50,
        stretch: 2,
        depth: 100,
        modifier: 1,
        slideShadows : true,
      },
      pagination: {
        el: '.swiper-pagination',
      },
    });


/* ===============================  Mouse effect  =============================== */


/* Scrolling Effect js */
	// Select all links with hashes
	$('a[href*="#"]')
	  // Remove links that don't actually link to anything
	  .not('[href="#"]')
	  .not('[href="#0"]')
	  .click(function(event) {
		// On-page links
		if (
		  location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') 
		  && 
		  location.hostname == this.hostname
		) {
		  // Figure out element to scroll to
		  var target = $(this.hash);
		  target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
		  // Does a scroll target exist?
		  if (target.length) {
			// Only prevent default if animation is actually gonna happen
			event.preventDefault();
			$('html, body').animate({
			  scrollTop: target.offset().top
			}, 500, function() {
			  // Callback after animation
			  // Must change focus!
			  var $target = $(target);
			  $target.focus();
			  if ($target.is(":focus")) { // Checking if the target was focused
				return false;
			  } else {
				$target.attr('tabindex','-1'); // Adding tabindex for elements not focusable
				$target.focus(); // Set focus again
			  };
			});
		  }
		}
	});	
	

	
	

})(jQuery);