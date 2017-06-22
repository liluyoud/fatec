function toggleAcoes() {
    var id = $("#Id").val()
    if (id == "") {
        $("#incluir").show();
        $("#atualizar").hide();
        $("#excluir").hide();
    } else {
        $("#incluir").hide();
        $("#atualizar").show();
        $("#excluir").show();
    }
}

function limparMsg() {
    $("#msg").removeClass("alert-danger");
    $("#msg").removeClass("alert-success");
    $("#msg").removeClass("alert-warning");
    $("#msg").removeClass("alert-info");
}

function incluirSuccess(json) {
    limparMsg();
    $("#msg").addClass("alert-success");
    $("#msg").show();
    var obj = JSON.parse(json);
    $("#Id").val(obj.id);
    $("#msg").html(obj.mensagem);
    toggleAcoes();
}

function incluirError(xhr) {
    limparMsg();
    $("#msg").addClass("alert-danger");
    $("#msg").show();
    $("#msg").html("ERRO: " + xhr.responseText);
    toggleAcoes();
}

function alterarSuccess(msg) {
    limparMsg();
    $("#msg").addClass("alert-success");
    $("#msg").show();
    $("#msg").html(msg);
    toggleAcoes();
}

function alterarError(xhr) {
    limparMsg();
    $("#msg").addClass("alert-danger");
    $("#msg").show();
    $("#msg").html("ERRO: " + xhr.responseText);
    toggleAcoes();
}

function excluirSuccess(msg) {
    
}

function excluirError(xhr) {
    limparMsg();
    $("#msg").addClass("alert-danger");
    $("#msg").show();
    $("#msg").html("ERRO: " + xhr.responseText);
    toggleAcoes();
}