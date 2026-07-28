// --- DOM ELEMENTS ---
const menuGrid = document.getElementById("menuGrid");
const filtroBotoes = document.querySelectorAll(".botao-filtro");

let menuData = [];

// --- CARREGA OS ITENS DO ARQUIVO JSON LOCAL ---
async function carregarMenuData() {
    const resposta = await fetch("data/menu.json");

    if (!resposta.ok) {
        throw new Error(`Falha ao carregar cardapio (HTTP ${resposta.status})`);
    }

    return resposta.json();
}

function obterIconeCategoria(categoria) {
    if (categoria === "hamburguer") {
        return '<i class="fa-solid fa-burger" aria-hidden="true"></i>';
    }

    if (categoria === "bebida") {
        return '<i class="fa-solid fa-glass-water" aria-hidden="true"></i>';
    }

    return '<i class="fa-solid fa-utensils" aria-hidden="true"></i>';
}

// --- QUEBRA O NOME EM LINHAS EMPILHADAS PARA O CARD TIPOGRAFICO ---
function quebrarNome(nome) {
    const palavras = nome.trim().split(/\s+/);
    const linhas = [];
    let acumulador = "";

    palavras.forEach((palavra, indice) => {
        if (palavra.length <= 3 && indice < palavras.length - 1) {
            acumulador = acumulador ? `${acumulador} ${palavra}` : palavra;
            return;
        }

        linhas.push(acumulador ? `${acumulador} ${palavra}` : palavra);
        acumulador = "";
    });

    if (acumulador) {
        linhas.push(acumulador);
    }

    return linhas
        .map((linha, indice) => `
            <span class="menu-item__linha menu-item__linha--${indice + 1}">${linha}</span>
        `).join("");
}

// --- OBTEM OS GRUPOS QUE DEVEM SER RENDERIZADOS PARA A CATEGORIA ESCOLHIDA ---
function obterGruposPorCategoria(categoria) {
    if (categoria === "all") {
        return menuData;
    }

    return menuData.filter(grupo => grupo.categoria === categoria);
}

// --- MONTA O HTML DE UM ÚNICO CARD ---
function montarCardItem(item, categoria) {
    return `
        <article class="menu-item" data-categoria="${categoria}">
            <div class="menu-item__nome-gigante" aria-hidden="true">
                ${quebrarNome(item.nome)}
            </div>

            <div class="menu-item__conteudo">
                <h3 class="menu-item__titulo sr-only">${item.nome}</h3>
                <p class="menu-item__descricao">${item.descricao}</p>
                <div class="menu-item__footer">
                    <span class="menu-item__preco">R$ ${item.preco.toFixed(2)}</span>
                    <span class="menu-item__badge" aria-label="${categoria}">
                        ${obterIconeCategoria(categoria)}
                    </span>
                </div>
            </div>
        </article>
    `;
}

// --- MONTA UMA SEÇÃO INTEIRA ---
function montarSecaoGrupo(grupo) {
    const cards = grupo.itens.map(item => montarCardItem(item, grupo.categoria)).join("");

    return `
        <section class="menu-grupo" data-categoria="${grupo.categoria}">
            <h3 class="menu-grupo__titulo">${grupo.nomeExibicao}</h3>
            <div class="menu-grupo__grid">
                ${cards}
            </div>
        </section>
    `;
}

// --- FUNÇÃO PARA RENDERIZAR O CARDAPIO INTEIRO A PARTIR DOS GRUPOS ---
function renderizarMenu(categoria = "all") {
    const grupos = obterGruposPorCategoria(categoria);
    const totalItens = grupos.reduce((soma, grupo) => soma + grupo.itens.length, 0);

    if (totalItens === 0) {
        menuGrid.innerHTML = `
            <p style="text-align:center; color:var(--cor-texto-suave); padding:2rem 0;">
                Nenhum item encontrado para esta categoria.
            </p>
        `;
        return;
    }

    menuGrid.innerHTML = grupos.map(montarSecaoGrupo).join("");
}

// --- LIGA OS BOTOES DE FILTRO ---
filtroBotoes.forEach(botao => {
    botao.addEventListener("click", () => {
        filtroBotoes.forEach(b => b.classList.remove("ativo"));
        botao.classList.add("ativo");
        const categoria = botao.dataset.category;
        renderizarMenu(categoria);
    });
});

// --- CARREGA O JSON E RENDERIZA O CARDAPIO INICIAL ---
(async function iniciar() {
    try {
        menuData = await carregarMenuData();
        renderizarMenu("all");
    } catch (erro) {
        console.error(erro);
        menuGrid.innerHTML = `
            <p style="text-align:center; color:var(--cor-erro); padding:2rem 0;">
                Nao foi possivel carregar o cardapio. Tente novamente mais tarde.
            </p>
        `;
    }
})();

