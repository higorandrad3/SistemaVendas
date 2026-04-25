let productsInCart = [];

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

// Funções de exemplo (serão integradas com o backend futuramente)
function limparCarrinho() {
    if (confirm("Deseja realmente limpar toda a lista?")) {
        location.reload();
    }
}

function finalizarVenda() {
    alert("Processando venda...");
}

async function addProductInCart() {
    let productInfo = JSON.parse(document.getElementById('productSearch').getAttribute('data-id-selecionado'));

    if (productInfo == null) {
        alert("Selecione um produto e sua quantidade!!");
        return;
    }
    productInfo.quantity = parseInt(document.getElementById('quantity').value);

    let productExist = productsInCart.find(p => p.id == productInfo.id)

    if (productExist) {
        productExist.quantity += parseInt(productInfo.quantity);
    }
    else {
        productsInCart.push(productInfo);
    }

    const response = await fetch(
        `/Sale/GetProductsInCart`, {
        method: "POST",
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(productsInCart)
    });
    if (response.ok) {

        const html = await response.text();
        document.getElementById('productList').innerHTML = html;
    }
    resetProductInfo();
}

function resetProductInfo() {
    document.getElementById('quantity').value = '1';
    document.getElementById('productSearch').value = '';
    document.getElementById('productSearch').removeAttribute('data-id-selecionado');
}

//autocomplete
$(document).ready(function () {
    const $inputBusca = $("#productSearch");
    const $listaResultado = $("#resultadoBusca");

    $inputBusca.on("keyup", function () {
        let termo = $(this).val();

        if (termo.length >= 3) {
            $.ajax({
                url: '/Sale/GetProductByName', // Sua rota no Controller
                type: 'GET',
                data: { termo: termo },
                success: function (data) {
                    $listaResultado.empty().show();

                    if (data.length > 0) {
                        $.each(data, function (i, item) {
                            $listaResultado.append(`
                                <a href="#" class="list-group-item list-group-item-action item-selecionado"
                                    data-id=${item.id}
                                   data-name="${item.name}"
                                   data-price=${item.salePrice}
                                   <span>ID: ${item.id} | ${item.name} | R$: ${item.salePrice}</span >
                                </a>
                            `);
                        });
                    } else {
                        $listaResultado.append('<li class="list-group-item text-muted">Nenhum produto encontrado</li>');
                    }
                }
            });
        } else {
            $listaResultado.hide();
        }
    });

    // Ao clicar em um produto da lista de sugestões
    $(document).on("click", ".item-selecionado", function (e) {
        e.preventDefault();

        const productInfo = {
            id: $(this).data("id"),
            name: $(this).data("name"),
            price: $(this).data("price"),
            qnatity: 0
        };

        //const id = $(this).data("id");
        //const nome = $(this).data("name");


        // Preenche o input com o nome selecionado
        $inputBusca.val(productInfo.name);

        // Armazena o ID em um atributo oculto para o botão "Adicionar" usar depois
        $inputBusca.attr("data-id-selecionado", JSON.stringify(productInfo));

        // Esconde a lista
        $listaResultado.hide();
    });

    // Fecha a lista se clicar fora dela
    $(document).click(function (e) {
        if (!$(e.target).closest('.position-relative').length) {
            $listaResultado.hide();
        }
    });
});

function saveImLocalStorage() {
    localStorage.setItem('Cart', JSON.stringify(productsInCart));
}

function loadLocalStorage() {
    const data = localStorage.getItem('Cart')

    if (data) {
        productsInCart = JSON.parse(data);
    }
}
function updateCart() {
}