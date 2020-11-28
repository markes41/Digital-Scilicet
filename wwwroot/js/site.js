$(document).ready(function(){

    $('.owl-carousel').owlCarousel({
        loop:true,
        margin:10,
        nav:true,
        responsive:{
            0:{
                items:1
            },
            600:{
                items:3
            },
            1000:{
                items:5
            }
        }
    });

    $('.hide').hide();

    $('.acordion').on('click', function(){
        $(".hide").toggle(1000);
    });

    $(".item-header").click(function(){
        $(".accordion-item").removeClass("active");
        $(this).parent().addClass("active");
        $(".icon").text("+");
        $(this).children(".icon").text("-");
      });

      $('.testimonial-pics img').click(function(){
        $(".testimonial-pics img").removeClass("active");
        $(this).addClass("active");

        $(".testimonial").removeClass("active");
        $("#"+$(this).attr("alt")).addClass("active");
      });

});

