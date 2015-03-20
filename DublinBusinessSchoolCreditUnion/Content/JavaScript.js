$('div:not(".hide")').hide();

$('div.hide').click(
    function () {
        $('div:not(".hide")').slideUp();
        $(this).toggleClass('open');
    });