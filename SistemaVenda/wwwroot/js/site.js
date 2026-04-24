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

// Script para limpar apenas os inputs de pesquisa
document.getElementById('btnClean').addEventListener('click', function () {
    document.getElementById('productSearch').value = '';
    document.getElementById('quantity').value = '1';
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

function addProductInCart() {
    const productInfo = JSON.parse(document.getElementById('productSearch').getAttribute('data-id-selecionado'));
    productInfo.quantity = document.getElementById('quantity').value;

    productsInCart.push(productInfo);
    console.log(productInfo.id);
    console.log(productInfo.nome);
    console.log(productInfo.price)
    console.log(productInfo.quantity);

    const response = fetch(
        `/Sale/GetProductsInCart`, {
            method: "POST",
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify(productsInCart)
    });
    if (response.ok) {
        console.log("sucess")
    }

    //fetch("/Sale/UpdateCart", {
    //    method: "POST",
    //    headers: {
    //        'Content-Type': 'application/json'
    //    },
    //    body: JSON.stringify(id)
    //}).then(res => res.ok ? console.log("sucess") : console.log("fail"));

    //$.ajax({
    //    url: '/Sale/GetProductsInCart', // Tag Helper para gerar a URL correta
    //    type: 'GET',
    //    success: function (response) {
    //        // 'response' deve ser o HTML da sua PartialView
    //        $("#productList").html(response);

    //        // Limpa os campos de entrada
    //        $("#productSearch").val('');
    //        $("#quantity").val('1');
    //    },
    //    error: function (xhr, status, error) {
    //        console.error("Erro na requisição:", error);
    //        alert("Não foi possível adicionar o produto.");
    //    }
    //});

    $("#btnClean").on("click", function () {
        $("#productSearch").val('');
        $("#quantity").val('1');
        $("#msgErroQtd").hide();
        $("#quantity").removeClass('is-invalid');
    });
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
                                   <span>${item.name}</span>
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
            nome: $(this).data("name"),
            price: $(this).data("price"),
            qnatity: 0
        };

        //const id = $(this).data("id");
        //const nome = $(this).data("name");


        // Preenche o input com o nome selecionado
        $inputBusca.val(productInfo.nome);

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