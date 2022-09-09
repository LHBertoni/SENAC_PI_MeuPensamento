// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(() => {
    if ($('.input-reacao').length) {
        let inputReacao = $('.input-reacao');
        let inputHidden = $('#Reacoes');
        let inputReacaoSelecionada = $('.input-reacao-selecionada');
        let ul = inputReacaoSelecionada.find('ul');
        let select = inputReacao.find('select');
        let btn = inputReacao.find('button');
        var contador = 0;
        let valorRecaoes = [];

        
        $.each(ul.find('li'), (i, e) => {
            $(e).find('button').on('click', () => {
                let liUpper = $(event.target).parents('li');
                let valor = $(liUpper).find('span').text();
                liUpper.remove();
                contador--;

                valorRecaoes = valorRecaoes.filter(v => v != valor);

                inputHidden.val(valorRecaoes.join(';'));
            });

            contador++;

            valorRecaoes.push($(e).find('span').text());
        });

        btn.on('click',() => {
            let valor = select.val();

            if (valor == '')
                return;

            if (valorRecaoes.some(v => v == valor))
                return;

            contador++;

            ul.append(`<li data-count='${contador}'>
                    <span>${valor}</span>
                    <button type="button">
                        <i class="fa-solid fa-minus"></i>
                    </button>
                </li>`)

            ul.find('li[data-count=\'' + contador + '\']>button').on('click', () => {
                let liUpper = $(event.target).parents('li');
                let liValor = $(liUpper).find('span').text();
                liUpper.remove();
                contador--;

                valorRecaoes = valorRecaoes.filter(v => v != liValor);

                inputHidden.val(valorRecaoes.join(';'));
            });

            valorRecaoes.push(valor);

            inputHidden.val(valorRecaoes.join(';'));
        });
    }

});