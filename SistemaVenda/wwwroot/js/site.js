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

async function finalizeSale() {
    if (productsInCart === 0) {
        alert("O carrinho está vazio. Adicione itens ao carrinho!");
        return;
    }

    const response = await fetch(
        `/Sale/FinalizeSale`, {
            method: "POST",
            headers: {
                'Content-Type':'application/json'
            },
            body: JSON.stringify(productsInCart)
        }
    );
    if (response.redirected) {
        window.location.href = response.url;
    }
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

    resetProductInfo();
    renderTableRows();
    updateSummary();
}

function updateSummary() {
    var orderValueElement = document.getElementById('orderValue');
    var totalItemsElement = document.getElementById('totalItems');
    var orderValue = 0;
    var totalItems = 0;

    productsInCart.forEach((p) => {
        orderValue += p.quantity * p.price;
        totalItems += p.quantity;
    })

    totalItemsElement.innerText = totalItems;
    orderValueElement.innerText = orderValue;
}

function renderTableRows() {
    const tableBody = document.getElementById('listaCarrinho');

    // Limpa o conteúdo atual da tabela
    tableBody.innerHTML = '';

    // Cria as linhas baseadas nos dados
    productsInCart.forEach(product => {
        const row = document.createElement('tr');

        row.innerHTML = `
            <td class="ps-4">${product.name}</td>
            <td class="text-center">${product.quantity}</td>
            <td class="text-end">R$ ${product.price}</td>
            <td class="text-end pe-4">R$ ${product.price * product.quantity}</td>
            <td class="text-center"><a>Remover</a></td>
        `;

        tableBody.appendChild(row);
    });
}

function resetProductInfo() {
    document.getElementById('quantity').value = '1';
    document.getElementById('productSearch').value = '';
    document.getElementById('productSearch').removeAttribute('data-id-selecionado');
}

//autocomplete
$(document).ready(function () {
    const $inputSearch = $("#productSearch");
    const $resultList = $("#resultadoBusca");

    $inputSearch.on("keyup", function () {
        let term = $(this).val();

        if (term.length >= 3) {
            $.ajax({
                url: '/Sale/GetProductByName', // Sua rota no Controller
                type: 'GET',
                data: { term: term },
                success: function (data) {
                    $resultList.empty().show();

                    if (data.length > 0) {
                        $.each(data, function (i, item) {
                            $resultList.append(`
                                <a href="#" class="list-group-item list-group-item-action item-selecionado"
                                    data-id=${item.id}
                                   data-name="${item.name}"
                                   data-price=${item.salePrice}
                                   <span>ID: ${item.id} | Nome: ${item.name}</span >
                                </a>
                            `);
                        });
                    } else {
                        $resultList.append('<li class="list-group-item text-muted">Nenhum produto encontrado</li>');
                    }
                }
            });
        } else {
            $resultList.hide();
        }
    });

    // Ao clicar em um produto da lista de sugestões
    $(document).on("click", ".item-selecionado", function (e) {
        e.preventDefault();

        const productInfo = {
            id: $(this).data("id"),
            name: $(this).data("name"),
            price: $(this).data("price")
        };

        // Preenche o input com o nome selecionado
        $inputSearch.val(productInfo.name);

        // Armazena o ID em um atributo oculto para o botão "Adicionar" usar depois
        $inputSearch.attr("data-id-selecionado", JSON.stringify(productInfo));

        // Esconde a lista
        $resultList.hide();
    });

    // Fecha a lista se clicar fora dela
    $(document).click(function (e) {
        if (!$(e.target).closest('.position-relative').length) {
            $resultList.hide();
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