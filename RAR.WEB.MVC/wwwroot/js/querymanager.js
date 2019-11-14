$(document).ready(function () {

    //$("#fieldsetQuery").hide();


    function SetQueryParameters(query) {
        const regex = /\$#(.+?)\#\$/gm;

        $("#divParameters").html("");
        match = regex.exec(query);

        if (match == null)
            $("#divFullParameters").hide();
        else {
            var result = new Array();
            while (match != null) {
                $("#divFullParameters").show();
                console.log(match[1]);

                if (result.indexOf(match[1]) === -1) {
                    result.push(match[1]);

                    var newTextBoxDiv = $(document.createElement('div'));

                    newTextBoxDiv.after().html('<li><label>' + match[1] + ' : </label><input required type="text" name="' + match[1] + '" id="' + match[1] + '" value=""></li>');
                    newTextBoxDiv.appendTo("#divParameters");

                }
                match = regex.exec(query);
            }
        }
    }

    $(document).ready(function () {

        //$("#fieldsetQuery").hide();
        $(function () {
            $(document).delegate('input[name=ConfermaQuery]', 'click',
                function (e) {
                    var current = $(this);
                    var idQuery = current.attr('IdQuery');
                    var descrizione = $("#" + idQuery + "").text();//.find("td[name=queryDescription]").html();
                    //alert(descrizione);
                    var data = {
                        ID_QUERY: idQuery
                    };
                    $.ajax({
                        url: '/QueryManager/GetQuery',
                        type: 'GET',
                        data: data,
                        success: function (data) {
                            $("#QuerySQL").text(data);
                            $("#fieldsetQuery").show();
                            $("#QuerySQL").focus();
                            $("#idQuery").val(idQuery);
                            $("#QueryDescription").html("<strong>" + descrizione + "</strong>");
                            SetQueryParameters(data);
                        },
                        error: function (request, message, error) {
                            handleException(request, message, error);
                        }
                    });
                });
        });
    });
});