$(function () {
    toggleAcoes();

    $("#incluir").click(function () {
        var obj = new Object();
        obj.nome = $("#Nome").val();
        obj.cpf = $("#Cpf").val();
        obj.email = $("#Email").val();
        obj.telefone = $("#Telefone").val();
        $.ajax({
            url: "http://localhost:54307/Pessoas",
            type: "POST",
            contentType: "application/json",
            dataType: "html",
            crossDomain: true,
            data: JSON.stringify(obj),
            success: function (json) {
                incluirSuccess(json);
            },
            error: function (xhr, textStatus, errorThrown) {
                incluirError(xhr);
            }
        });
    });

    $("#atualizar").click(function () {
        var obj = new Object();
        obj.id = $("#Id").val();
        obj.nome = $("#Nome").val();
        obj.cpf = $("#Cpf").val();
        obj.email = $("#Email").val();
        obj.telefone = $("#Telefone").val();
        $.ajax({
            url: "http://localhost:54307/Pessoas/" + obj.id,
            type: "PUT",
            contentType: "application/json",
            dataType: "html",
            crossDomain: true,
            data: JSON.stringify(obj),
            success: function (msg) {
                alterarSuccess(msg);
            },
            error: function (xhr, textStatus, errorThrown) {
                alterarError(xhr);
            }
        });
    });

    $("#novo").click(function () {
        limparMsg();
        $("#Id").val("");
        $("#Nome").val("");
        $("#Cpf").val("");
        $("#Email").val("");
        $("#Telefone").val("");
        toggleAcoes();
    });

    $("#excluir").click(function () {
        var id = $("#Id").val();
        $.ajax({
            url: "http://localhost:54307/Pessoas/" + id,
            type: "DELETE",
            crossDomain: true,
            success: function (msg) {
                window.location.href = "http://localhost:54328/Pessoas";
            },
            error: function (xhr, textStatus, errorThrown) {
                excluirError(xhr);
            }
        });
    });

});