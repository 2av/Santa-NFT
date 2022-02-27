$(document).ready(function () {
    $(".faq-heading").click(function(){
        $(".faq-description").hide("fast");
        $(this).siblings(".faq-description").show("fast");
    });

    $('.owl-carousel').owlCarousel({
        loop: true,
        item:4,
        margin: 10,
        nav: true,
        infinite: true,
        rtl: true,
        dots: false,
        items: 4,
        autoplayTimeout: 2000,
        autoplayHoverPause: true,
        
        navText: [
            "<i class='fa fa-caret-left'></i>",
            "<i class='fa fa-caret-right'></i>"
        ],
        autoPlay: true,
        autoplayHoverPause: true,
        responsive: {
            0: {
                items: 1
            },
            600: {
                items: 2
            }
        }
    })

    var sections = $('section')
        , nav = $('nav')
        , nav_height = nav.outerHeight();

    $(window).on('scroll', function () {
        var cur_pos = $(this).scrollTop();

        sections.each(function () {
            var top = $(this).offset().top - nav_height,
                bottom = top + $(this).outerHeight();

            if (cur_pos >= top && cur_pos <= bottom) {
                nav.find('a').removeClass('active');
                sections.removeClass('active');

                $(this).addClass('active');
                nav.find('a[href="#' + $(this).attr('id') + '"]').addClass('active');
            }
        });
    });

    nav.find('a').on('click', function () {
        var $el = $(this)
            , id = $el.attr('href');

        $('html, body').animate({
            scrollTop: $(id).offset().top - nav_height
        }, 10);

        return false;
    });
});