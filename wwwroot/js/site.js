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
                        $('#database').append('<a data-toggle="modal" data-target="#exampleModalCenter">'+
                        '<div class="card" style="width: 18rem; height: 20rem;">'+
                        '<img src="~/img/imgDatos.jpg" class="card-img-top" alt="...">'+
                        '<div class="card-body">'+
                        '<h5 class="card-title">'+response[i].titulo+'</h5>'+
                        '<p class="footer card-text">Curso</p>'+
                        '</div>'+
                        '</div>'+
                        '</a>');
                    }
                    else if(response[i].categoria == 2)
                    {
                        $('#web').append('<a data-toggle="modal" data-target="#exampleModalCenter">'+
                        '<div class="card" style="width: 18rem; height: 20rem;">'+
                        '<img src="~/img/imgWeb.jpg" class="card-img-top" alt="...">'+
                        '<div class="card-body">'+
                        '<h5 class="card-title">'+response[i].titulo+'</h5>'+
                        '<p class="footer card-text">Curso</p>'+
                        '</div>'+
                        '</div>'+
                        '</a>');
                    }
                    else if(response[i].categoria == 3)
                    {
                        $('#videogames').append('<a data-toggle="modal" data-target="#exampleModalCenter">'+
                        '<div class="card" style="width: 18rem; height: 20rem;">'+
                        '<img src="~/img/imgWeb.jpg" class="card-img-top" alt="...">'+
                        '<div class="card-body">'+
                        '<h5 class="card-title">'+response[i].titulo+'</h5>'+
                        '<p class="footer card-text">Curso</p>'+
                        '</div>'+
                        '</div>'+
                        '</a>');
                    }
                    else
                    {
                        $('#videogames').append('<a data-toggle="modal" data-target="#exampleModalCenter">'+
                        '<div class="card" style="width: 18rem; height: 20rem;">'+
                        '<img src="~/img/imgWeb.jpg" class="card-img-top" alt="...">'+
                        '<div class="card-body">'+
                        '<h5 class="card-title">'+response[i].titulo+'</h5>'+
                        '<p class="footer card-text">Curso</p>'+
                        '</div>'+
                        '</div>'+
                        '</a>');
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

      $('#agregar-carrito').click(function(){
        var titulo = $('#ID').text();
        alert(titulo);
      });
});

