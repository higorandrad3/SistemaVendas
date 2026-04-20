// Função para garantir que não haja valores negativos ou zero
function validarQuantidade(input) {
    const erro = document.getElementById('msgErroQtd');
    if (input.value <= 0) {
        input.classList.add('is-invalid');
        erro.style.display = 'block';
    } else {
        input.classList.remove('is-invalid');
        erro.style.display = 'none';
    }
}

// Script para limpar apenas os inputs de pesquisa
document.getElementById('btnLimparInputs').addEventListener('click', function () {
    document.getElementById('produtoPesquisa').value = '';
    document.getElementById('quantidade').value = '1';
});

// Funções de exemplo (serão integradas com o backend futuramente)
function limparCarrinho() {
    if (confirm("Deseja realmente limpar toda a lista?")) {
        location.reload();
    }
}

function finalizarVenda() {
    alert("Processando venda...");
}