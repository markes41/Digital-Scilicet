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

      $(".center").slick({
        dots: true,
        infinite: true,
        centerMode: true,
        variableWidth: true,
        adaptiveHeight: true
      });

      $(".regular").slick({
        dots: true,
        infinite: true,
        centerMode: true,
        slidesToShow: 3,
        slidesToScroll: 3
      });
});

function cursoExist() {
  Swal.fire({
    title: '¡ERROR!',
    text: 'Ya existe un curso con el nombre o url que usted ha ingresado.',
    icon: 'error',
    confirmButtonText: 'Volver a intentar'
  })
}

function tieneCurso() {
  Swal.fire({
    title: '¡ERROR!',
    text: 'Ya compraste este curso, revisá tu sección "Mis Cursos"',
    icon: 'error',
    confirmButtonText: 'Seguir comprando'
  })
}

function comproCurso() {
  Swal.fire({
    title: 'BIEN!',
    text: 'Tu compra finalizó con éxito. Podés ver tu nuevo curso yendo a la sección "Mis Cursos".',
    icon: 'success',
    confirmButtonText: 'Seguir comprando'
  })
}

