
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

window.onscroll = function () {
    var popupBox = document.getElementById("popup-box");
    var scrollPosition = window.scrollY || window.pageYOffset;
    var windowHeight = window.innerHeight;
    var documentHeight = document.documentElement.scrollHeight;

    var distanceFromBottom = 400;

    if (scrollPosition + windowHeight >= documentHeight - distanceFromBottom) {
        popupBox.style.opacity = 1;
        popupBox.classList.remove("hidden");
    } else {
        popupBox.style.opacity = 0;
        popupBox.classList.add("hidden");
    }
};

function closePopup() {
    var popupBox = document.getElementById("popup-box");
    popupBox.style.opacity = 0;
    popupBox.classList.add("hidden");
}


function filterProducts(category) {
    var allBtn = document.getElementById('allBtn');
    var categoryBtns = document.getElementsByClassName('beer-categories')[0].getElementsByTagName('button');

    allBtn.classList.remove('active');
    for (var i = 0; i < categoryBtns.length; i++) {
        categoryBtns[i].classList.remove('active');
    }

    var productItems = document.getElementsByClassName('card');
    for (var i = 0; i < productItems.length; i++) {
        var productItem = productItems[i];
        var productCategories = productItem.getAttribute('data-categories').split(',');
        if (category === 'all' || productCategories.includes(category)) {
            productItem.style.display = 'block';
        } else {
            productItem.style.display = 'none';
        }
    }

    if (category !== 'all') {
        var activeCategoryBtn = document.querySelector('.beer-categories button[data-category="' + category + '"]');
        activeCategoryBtn.classList.add('active');
    }
}




