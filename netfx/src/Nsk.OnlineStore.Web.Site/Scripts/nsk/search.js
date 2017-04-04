$(function () {
    var txtQuery = $("#query")[0];
    $("#query").autocomplete({
        source:
            function (request, response) {
                $.ajax({
                    url: "/Home/GetProductsByPattern?query=" + txtQuery.value,
                    dataType: "json",
                    data: {
                        terminiRicerca: request.term
                    },
                    success: function (data) {
                        response($.map(data, function (item) {
                            return {
                                label: item.Name,
                                value: item.Name,
                                id: item.Id
                            }
                        }));
                    }
                });
            },
        minLength: 2,
        select: function (event, ui) {
            txtQuery.value = ui.item.value;
            document.forms[0].submit();
        },
        open: function () {
            $(this).removeClass("ui-corner-all").addClass("ui-corner-top");
        },
        close: function () {
            $(this).removeClass("ui-corner-top").addClass("ui-corner-all");
        }
    });
});