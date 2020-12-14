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
        slidesToScroll: 3,
        variableWidth: true
      });

      $('.responsive').slick({
        dots: true,
        infinite: false,
        speed: 300,
        slidesToShow: 4,
        slidesToScroll: 4,
        responsive: [
          {
            breakpoint: 1024,
            settings: {
              slidesToShow: 3,
              slidesToScroll: 3,
              infinite: true,
              dots: true
            }
          },
          {
            breakpoint: 600,
            settings: {
              slidesToShow: 2,
              slidesToScroll: 2
            }
          },
          {
            breakpoint: 480,
            settings: {
              slidesToShow: 1,
              slidesToScroll: 1
            }
          }
          // You can unslick at a given breakpoint now by adding:
          // settings: "unslick"
          // instead of a settings object
        ]
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

function comprobar()
{   
    if (document.getElementById("chec").checked)
      document.getElementById('boton').readOnly = false;
        
    else
      document.getElementById('boton').readOnly = true;
        
}

function validaNumericosPrecio(event) {
  if(event.charCode >= 48 && event.charCode <= 57 || event.charCode == 44){
    return true;
   }
   return false;        
}

function validaNumericosCantidad(event) {
  if(event.charCode >= 48 && event.charCode <= 57){
    return true;
   }
   return false;        
}
