$('div:not(".hide")').hide();

$('div.hide').click(
    function () {
        $('div:not(".hide")').slideUp();
        $(this).toggleClass('open');
    });

validateField = function (sender, args) {
    //do your validation logic        
    if (!args.IsValid) {
        var ctrl = $("#" + sender.controltovalidate);
        if (ctrl) {
            ctrl.css({ "background-color": "#990000", "border": "1px solid #993300" });
        }
    }
    return args.IsValid;
}