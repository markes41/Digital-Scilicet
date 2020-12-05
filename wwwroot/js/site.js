$(document).ready(function(){

    //Categoria 1: database, Categoría 2: web, Categoría 3: videogames, Categoría 4: mobile
    $('#ConsultarCursos').on('click', function(){
        $.ajax({
            url: '/home/ConsultarCurso',
            method: 'GET',
            success: function(response){
                console.log(response);
                for(var i = 0; i < response.length; i++){
                    if(response[i].categoria == 1)
                    {
                        $('#database').append('<div class="card" style="width: 20rem;">'+
                        '<img src="../img/img1.jpg" class="card-img-top" alt="...">'+
                        '<div class="contenido">'+
                        '<p class="cardTitulo">Programación Web FullStack Desde 0 a Experto</p>'+
                        '<p class="cardDescripcion">Lorem ipsum dolor sit amet consectetur adipisicing elit. Eligendi, perspiciatis? Pariatur vero ipsum</p>'+
                        '<div class="row">'+
                        '<p class="cardPrecio col-md-6">$20.99</p>'+
                        '<div class="cardEstrellas col-md-6">'+
                        '<i class="fas fa-star"></i>'+
                        '<i class="fas fa-star"></i>'+
                        '<i class="fas fa-star"></i>'+
                        '<i class="fas fa-star"></i>'+
                        '<i class="far fa-star"></i>'+
                        '</div>'+
                        '</div>'+
                        '</div>'+
                        '<a href="" class="cardComprar">COMPRAR</a>'+
                       '</div>');
                    }
                    else if(response[i].categoria == 2)
                    {
                        
                    }
                    else if(response[i].categoria == 3)
                    {
                        
                    }
                    else
                    {
                        
                    }
                }
            },
            failure: function(error){
                console.log(error);
            } 
        });
    })

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

