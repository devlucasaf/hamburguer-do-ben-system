<img
    width=100%
    src="https://capsule-render.vercel.app/api?type=waving&color=A020F0&height=120&section=header"
/>

<h1 align="center">🍔 Hambúrguer do Ben</h1>
<h3 align="center">Cardápio Digital</h3>

<p align="center">
    <img 
        src="https://img.shields.io/badge/status-concluído-DC2626?style=for-the-badge" 
    />
    <img 
        src="https://img.shields.io/badge/licença-MIT-DC2626?style=for-the-badge" 
    />
    <img 
        src="https://img.shields.io/badge/HTML%20%7C%20CSS%20%7C%20JS-vanilla-DC2626?style=for-the-badge" 
    />
</p>

---

## 📋 Índice

- [Sobre o projeto](#-sobre-o-projeto)
- [Funcionalidades](#-funcionalidades)
- [Estrutura do projeto](#-estrutura-do-projeto)
- [Tecnologias utilizadas](#-tecnologias-utilizadas)
- [Como executar](#-como-executar)
- [Licença](#-licença)

---

## 💡 Sobre o projeto

Um cardápio digital moderno e responsivo para a **Hambúrguer do Ben** — uma hamburgueria com o sabor que fica na memória.

O projeto oferece uma experiência fluida e organizada para os clientes visualizarem hambúrgueres, acompanhamentos, bebidas e sobremesas de forma atraente e intuitiva, com design **tipográfico dramático** em tema escuro para um clima acolhedor de casa noturna gastronômica.

Este cardápio faz parte de um sistema maior — o **Hambúrguer do Ben System** — que inclui aplicações para clientes, garçons e cozinha.

---

## ✨ Funcionalidades

- 🍔 Visualização completa do cardápio agrupado por categorias
- 🎨 Cards com design tipográfico único (nomes gigantes empilhados)
- 🥤 Seções dedicadas para hambúrgueres, acompanhamentos, bebidas e sobremesas
- 🔎 Filtros por categoria com um clique
- 📱 Layout responsivo para desktop, tablet e mobile
- 🌙 Tema escuro elegante com paleta marrom-café
- 📦 Dados desacoplados em `menu.json` (pronto para virar API)
- ♿ Estrutura semântica com atributos ARIA

---

## 🗃️ Estrutura do projeto

```
/cardapio
 ├── index.html
 ├── data/
 │   └── menu.json
 ├── img/
 │   └── hamburguer-do-ben.png
 ├── scripts/
 │   └── main.js
 ├── styles/
 │   ├── global.css
 │   ├── layout.css
 │   └── components.css
 └── README.md
```

---

## 🛠️ Tecnologias utilizadas

<div align="left">
    <img 
        align="center"
        alt="JavaScript"
        title="JavaScript"
        height="40" 
        style="padding-right: 10px;"
        src="https://skillicons.dev/icons?i=javascript" 
    />
    <img
        align="center" 
        alt="HTML" 
        title="HTML"
        height="40" 
        style="padding-right: 10px;" 
        src="https://skillicons.dev/icons?i=html"
    />
    <img
        align="center" 
        alt="CSS" 
        title="CSS"
        height="40" 
        style="padding-right: 10px;" 
        src="https://skillicons.dev/icons?i=css"
    />
    <img
        align="center"
        alt="VS Code"
        title="VS Code"
        height="40" 
        style="padding-right: 10px;" 
        src="https://skillicons.dev/icons?i=vscode"
    />
    <img
        align="center"
        alt="GitHub"
        title="GitHub"
        height="40" 
        style="padding-right: 10px;" 
        src="https://skillicons.dev/icons?i=github"
    />
    <img
        align="center"
        alt="Git"
        title="Git"
        height="40" 
        style="padding-right: 10px;" 
        src="https://skillicons.dev/icons?i=git"
    />
</div>

<br/>

Também utiliza **Google Fonts** (Bebas Neue, Oswald e Righteous) e **Font Awesome** para os ícones.

---

## 🚀 Como executar

> ⚠️ O cardápio carrega os produtos via `fetch("data/menu.json")`. Por questão de segurança dos navegadores, isso **não funciona** ao abrir o `index.html` direto pelo explorador de arquivos (`file://`). É necessário servir a pasta via HTTP.

1. Clone o repositório:
```bash
git clone https://github.com/devlucasaf/hamburguer-do-ben-system.git
```

2. Acesse a pasta do cardápio:
```bash
cd hamburguer-do-ben-system/frontend/cardapio
```

3. Abra com **Live Server** no VS Code (recomendado):
   - Instale a extensão **Live Server** (Ritwick Dey).
   - Clique com o botão direito em `index.html` → **Open with Live Server**.

Ou use um servidor HTTP simples:
```bash
# Python
python -m http.server 8080

# Node
npx serve
```

Acesse então `http://localhost:8080` (ou a porta indicada pelo Live Server).

---

## 🏆 Licença

Distribuído sob a licença [MIT](../../LICENSE).

<img 
    width=100% 
    src="https://capsule-render.vercel.app/api?type=waving&color=A020F0&height=120&section=footer"
/>
