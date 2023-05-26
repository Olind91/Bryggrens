
//Dubbla $(document).ready-funktioner i din site.js-fil, vilket kan orsaka problem. 

$(document).ready(function () {
    

    $('.carousel-items').slick({
        dots: false,
        arrows: true,
        prevArrow: $('.carousel-prev'),
        nextArrow: $('.carousel-next'),
        slidesToShow: 1,
        slidesToScroll: 1
        // Add more options and customizations as needed
    });

    // Trigger carousel navigation on button click
    $('.carousel-prev').click(function () {
        $('.carousel-items').slick('slickPrev');
    });

    $('.carousel-next').click(function () {
        $('.carousel-items').slick('slickNext');
    });

    $(window).scroll(function () {
        var scroll = $(window).scrollTop();
        if (scroll > 0) {
            $("#welcome-screen").hide();
            $("#content").show();
        } else {
            $("#welcome-screen").show();
            $("#content").hide();
        }
    });
});

function toggleContent(section) {
    // Toggle button active state
    var missionBtn = document.getElementById('missionBtn');
    var brewingBtn = document.getElementById('brewingBtn');

    if (section === 'mission') {
        missionBtn.classList.add('active');
        brewingBtn.classList.remove('active');

        // Show Mission and Values content
        document.getElementById('missionContent').style.display = 'block';
        document.getElementById('brewingContent').style.display = 'none';
    } else if (section === 'brewing') {
        brewingBtn.classList.add('active');
        missionBtn.classList.remove('active');

        // Show Brewing Process content
        document.getElementById('brewingContent').style.display = 'block';
        document.getElementById('missionContent').style.display = 'none';
    }
}


