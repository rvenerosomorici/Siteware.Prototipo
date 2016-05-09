$(document).ready(function () {
    $('#IdProduto').val("");
    $('#NomeProduto').val("");
    $('#ValorUnitario').val("");
    $('#QuantidadeCompra').val("");

    $('.desabilitado').keypress(function () {
        event.preventDefault();
    });

    $('#btnSelecionarProduto').click(function () {
        if ($('#ddProdutos').val() == "0") {
            $('.mensagemErro').removeClass('invisivel');
            $('.mensagemErro').addClass('visible');
            $('#ddProdutos').focus();
        }
        else {
            var id = $('#ddProdutos').val();
            $.ajax({
                method: "GET",
                url: "/Carrinho/SelecionarProduto?strId=" + id,
                success: function (data) {
                    $('#IdProduto').val(data.IdProduto);
                    $('#NomeProduto').val(data.NomeProduto);
                    $('#ValorUnitario').val(data.ValorUnitario.toString().replace(".", ","));
                    $('.formulario').removeClass('invisivel');
                    $('.formulario').addClass('visivel');
                },
                error: function (data) {
                    alert("Não foi possível encontrar o produto");
                }
            });
        }
    });

    $('#naoSubmit').click(function () {
        $('#IdProduto').val(null);
        $('#NomeProduto').val(null);
        $('#ValorUnitario').val(null);
        $('#QuantidadeCompra').val(null);
        $('.formulario').removeClass('visivel');
        $('.formulario').addClass('invisivel');
    });
});