function allowDrop(ev) {
    ev.preventDefault();
}
function drag(ev) {
    ev.effectAllowed = 'copy';
    ev.dataTransfer.setData("text/html", ev.target.innerHTML);

    var btn = $('#' + ev.target.id);
    if (btn.hasClass('active')) {
        this._handleOffcanvasClose();
        return;
    }
    var id = btn.attr('href');
    this._useBackdrop = (btn.data('backdrop') === undefined) ? true : btn.data('backdrop');

    
    $(id).addClass('active');
    var leftOffcanvas = ($(id).closest('.offcanvas:first').length > 0);
    if (this._useBackdrop)
        $('body').addClass('offcanvas-expanded');
    var width = $(id).width();
    if (width > $(document).width()) {
        width = $(document).width() - 8;
        $(id + '.active').css({ 'width': width });
    }
    width = '-' + width;
    var translate = 'translate(' + width + 'px, 0)';
    $(id + '.active').css({ '-webkit-transform': translate, '-ms-transform': translate, '-o-transform': translate, 'transform': translate });
 
}

function drop(ev) {
    ev.preventDefault();

    if (ev.target.id === '') {
        console.log('a');
        return;

    }  
    var data = ev.dataTransfer.getData("text/html");
    if (ev.target.id === 'prod') {
        var div = ev.target;
        $('<div class="tile">' + data + '</div>').appendTo(div);
    }
    else {
        $(data).appendTo(ev.target);
    }
    $('#Cliente').hide();
    $('#Produto').show();
    $('#clienteLista').hide();
    $('#produtoLista').show();
    $('.trash').removeAttr("disabled");

    $('[data-toggle="offcanvas"]').removeClass('expanded');
    $('.offcanvas-pane').removeClass('active');
    $('.offcanvas-pane').css({ '-webkit-transform': '', '-ms-transform': '', '-o-transform': '', 'transform': '' });
}