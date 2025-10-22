function Advogado_AoCarregarComponente() {
    
    $('#cep').mask('00000-000');

    $('#cep').blur(function () {
        Advogado_CarregarEnderecoPorCep();
    });
}

function Advogado_CarregarEnderecoPorCep() {
    var cep = $('#cep').val().replace(/\D/g, '');
    if (cep !== "") {
        var validacep = /^[0-9]{8}$/;
        if (validacep.test(cep)) {
            $("#logradouro").val("...");
            $("#bairro").val("...");
            $("#estado").val("...");

            $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {
                if (!("erro" in dados)) {
                    $("#logradouro").val(dados.logradouro);
                    $("#bairro").val(dados.bairro);
                    $("#estado").val(dados.uf);
                } else {
                    Advogado_LimparCamposEndereco();
                    alert("CEP não encontrado.");
                }
            });
        } else {
            Advogado_LimparCamposEndereco();
            alert("Formato de CEP inválido.");
        }
    } else {
        Advogado_LimparCamposEndereco();
    }
}

function Advogado_LimparCamposEndereco() {
    $("#logradouro").val("");
    $("#bairro").val("");
    $("#estado").val("");
}
