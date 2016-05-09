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

            $('.rpValor').prop('checked', false);
            $('.rtMoeda').prop('checked', false);
            $('.rtPorCento').prop('checked', false);

            $('.rpItens').prop('checked', true);
            $('.rtProduto').prop('checked', true);
        }
        else if ($('.tPrecoFixo').is(':checked')) {
            $('.btAcima').attr('disabled', 'disabled');
            $('.rpItens').attr('disabled', 'disabled');
            $('.rtPorCento').attr('disabled', 'disabled');
            $('.rtProduto').attr('disabled', 'disabled');

            $('.btAcima').prop('checked', false);
            $('.rpItens').prop('checked', false);
            $('.rtPorCento').prop('checked', false);
            $('.rtProduto').prop('checked', false);

            $('.rpValor').prop('checked', true);
            $('.rtMoeda').prop('checked', true);
            $('.btCada').prop('checked', true);
        }
        else if ($('.tDesconto').is(':checked')) {
            $('.rpItens').attr('disabled', 'disabled');
            $('.rtProduto').attr('disabled', 'disabled');

            $('.rpItens').prop('checked', false);
            $('.rtProduto').prop('checked', false);

            $('.rpValor').prop('checked', true);
        }
    });

});