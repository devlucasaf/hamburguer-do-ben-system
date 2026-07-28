const menuData = [
    {
        id: 1,
        name: "Clássico Burguer",
        category: "hamburguer",
        price: 22.90,
        description: "Pão, carne 150g, queijo, alface, tomate e maionese.",
        emoji: "🍔"
    },
    {
        id: 2,
        name: "Bacon Cheese",
        category: "hamburguer",
        price: 27.90,
        description: "Pão, carne 180g, queijo cheddar, bacon crocante e molho barbecue.",
        emoji: "🧀"
    },
    {
        id: 3,
        name: "Veggie Burguer",
        category: "hamburguer",
        price: 24.90,
        description: "Pão, hambúrguer de grão-de-bico, queijo, alface, tomate e maionese vegana."
    },
    {
        id: 4,
        name: "Duplo Cheddar",
        category: "hamburguer",
        price: 32.90,
        description: "Pão, duas carnes 150g, duplo cheddar, cebola caramelizada e molho especial."
    },
    // ACOMPANHAMENTOS
    {
        id: 5,
        name: "Batata Frita",
        category: "acompanhamento",
        price: 12.90,
        description: "Porção de batatas rústicas crocantes com sal e pimenta."
    },
    {
        id: 6,
        name: "Onion Rings",
        category: "acompanhamento",
        price: 14.90,
        description: "Anéis de cebola empanados e fritos, com molho agridoce."
    },
    {
        id: 7,
        name: "Chicken Nuggets",
        category: "acompanhamento",
        price: 16.90,
        description: "6 unidades de nuggets de frango com molho mostarda e mel."
    },
    // BEBIDAS
    {
        id: 8,
        name: "Refrigerante Lata",
        category: "bebida",
        price: 6.90,
        description: "Coca-Cola, Fanta ou Sprite (350ml)."
    },
    {
        id: 9,
        name: "Suco Natural",
        category: "bebida",
        price: 8.90,
        description: "Laranja, limão ou abacaxi (500ml)."
    },
    {
        id: 10,
        name: "Milkshake",
        category: "bebida",
        price: 14.90,
        description: "Morango, chocolate ou baunilha (400ml)."
    },
    // SOBREMESAS
    {
        id: 11,
        name: "Brownie com Sorvete",
        category: "sobremesa",
        price: 18.90,
        description: "Brownie quente com bola de sorvete de creme e calda de chocolate."
    },
    {
        id: 12,
        name: "Petit Gâteau",
        category: "sobremesa",
        price: 19.90,
        description: "Bolo de chocolate com recheio derretido, acompanha sorvete de baunilha."
        
    }
];

// --- DOM ELEMENTS ---
const menuGrid = document.getElementById("menuGrid");
const filtroBotoes = document.querySelectorAll(".botao-filtro");

function obterIconeCategoria(categoria) {
    if (categoria === "hamburguer") {
        return '<i class="fa-solid fa-burger" aria-hidden="true"></i>';
    }

    if (categoria === "bebida") {
        return '<i class="fa-solid fa-glass-water" aria-hidden="true"></i>';
    }

    return '<i class="fa-solid fa-utensils" aria-hidden="true"></i>';
}

// --- FUNÇÃO PARA RENDERIZAR ---
function renderizarMenu(category = "all") {
    const itensFiltrados = category === "all"
        ? menuData
        : menuData.filter(item => item.category === category);

    if (itensFiltrados.length === 0) {
        menuGrid.innerHTML = `
        <p style="grid-column:1/-1; text-align:center; color:var(--color-text-light); padding:2rem 0;">
            Nenhum item encontrado para esta categoria.
        </p>
        `;
        return;
    }

    menuGrid.innerHTML = itensFiltrados.map(item => `
        <div class="menu-item" data-id="${item.id}">
            <div class="menu-item__imagem">
                <i class="fa-solid fa-burger" aria-hidden="true"></i>
            </div>

            <div class="menu-item__body">
                <h3 class="menu-item__titulo">${item.name}</h3>

                <span class="menu-item__categoria">
                    ${item.category}
                </span>

                <p class="menu-item__descricao">
                    ${item.description}
                </p>

                <div class="menu-item__footer">
                    <span class="menu-item__preco">
                        R$ ${item.price.toFixed(2)}
                    </span>

                    <span
                        class="menu-item__badge"
                        aria-label="Categoria: ${item.category}"
                    >
                        ${obterIconeCategoria(item.category)}
                    </span>
                </div>
            </div>
        </div>
    `).join("");
}

filtroBotoes.forEach(botao => {
    botao.addEventListener("click", () => {
        filtroBotoes.forEach(b => b.classList.remove("ativo"));
        botao.classList.add("ativo");
        const categoria = botao.dataset.category;
        renderizarMenu(categoria);
    });
});

renderizarMenu("all");