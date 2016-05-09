$(document).ready(function () {
    $(this).click(function () {
        $('.rpValor').removeAttr('disabled');
        $('.bpItens').removeAttr('disabled');
        $('.bpValor').removeAttr('disabled');
        $('.btAcima').removeAttr('disabled');
        $('.btCada').removeAttr('disabled');
        $('.rpItens').removeAttr('disabled');
        $('.rpValor').removeAttr('disabled');
        $('.rtProduto').removeAttr('disabled');
        $('.rtMoeda').removeAttr('disabled');
        $('.rtPorCento').removeAttr('disabled');

        if ($('.tBrinde').is(':checked')) {
            $('.rpValor').attr('disabled', 'disabled');
            $('.rtMoeda').attr('disabled', 'disabled');
            $('.rtPorCento').attr('disabled', 'disabled');
        }
        else if ($('.tPrecoFixo').is(':checked')) {
            $('.btAcima').attr('disabled', 'disabled');
            $('.rpItens').attr('disabled', 'disabled');
            $('.rtPorCento').attr('disabled', 'disabled');
            $('.rtProduto').attr('disabled', 'disabled');
        }
        else if ($('.tDesconto').is(':checked')) {
            $('.rpItens').attr('disabled', 'disabled');
            $('.rtProduto').attr('disabled', 'disabled');
        }
    });

});