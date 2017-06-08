$(function () {
    $("#incluir").click(function () {
        var obj = new Object();
        obj.descricao = $("#nome").val();
        $.ajax({
            url: "http://localhost:54307/Pessoas",
            type: "POST",
            contentType: "application/json",
            dataType: "html",
            crossDomain: true,
            data: JSON.stringify(obj),
            success: function (data, textStatus, xhr) {
                $("#msg").html("Inserido com sucesso!");
            },
            error: function (xhr, textStatus, errorThrown) {
                $("#msg").html("Erro ao chamar a API!");
            }
        });
    });
});