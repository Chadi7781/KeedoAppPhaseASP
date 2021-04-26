

//DETAIL EVENT USING AJAX  AND JQUERY
$(function () {
    var PlaceHolderHere = $('#PlaceHolderHere');
    $('button[data-toggle="ajax-modal"]').click(function (event) {


        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            PlaceHolderHere.html(data);
            PlaceHolderHere.find('.modal').modal('show');

        })
    })


    var PlaceHolderHere1 = $('#PlaceHolderHere1');
    $('#btnEdit').click(function (event) {


        var url = $(this).data('url');
        var decodedUrl = decodeURIComponent(url);
        $.get(decodedUrl).done(function (data) {
            PlaceHolderHere1.html(data);
            PlaceHolderHere1.find('.modal').modal();

        })
    })
})


