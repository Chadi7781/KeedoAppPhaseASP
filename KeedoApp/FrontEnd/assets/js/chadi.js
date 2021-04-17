
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
    })
