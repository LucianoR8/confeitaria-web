import { get } from "./api.js";

let produtos = [];
let configuracao = null;

const listaProdutos =
    document.getElementById("listaProdutos");

const btnVoltar =
    document.getElementById("btnVoltar");

btnVoltar.addEventListener("click", () => {

    window.location.href = "index.html";

});

async function iniciar() {

    produtos = await get("/produtos");
    configuracao = await get("/configuracoes");

    renderizarProdutos();
    renderizarFooter();

}

async function carregarConfiguracao() {

    configuracao = await get("/configuracoes");

}

function renderizarProdutos() {

    listaProdutos.innerHTML = "";

    produtos.forEach(produto => {

        listaProdutos.innerHTML += `

        <article
            class="produto-card"
            data-slug="${produto.slug}">

            <img
                src="${produto.imagemUrl}"
                alt="${produto.nomeProduto}">

            <div class="produto-info">

                <h3>
                    ${produto.nomeProduto}
                </h3>

                <p>

                    ${produto.descricaoProduto}

                </p>

                <span>

                    R$ ${Number(produto.preco).toFixed(2).replace(".", ",")}

                </span>

            </div>

        </article>

        `;

    });

    document
        .querySelectorAll(".produto-card")
        .forEach(card => {

            card.addEventListener("click", () => {

                const slug = card.dataset.slug;

                window.location.href =
                    `produto.html?slug=${slug}`;

            });

        });

}

const footerNomeLoja = document.getElementById("footerNomeLoja");
const footerEndereco = document.getElementById("footerEndereco");
const footerHorario = document.getElementById("footerHorario");
const footerTelefone = document.getElementById("footerTelefone");
const footerWhatsApp = document.getElementById("footerWhatsApp");
const footerEmail = document.getElementById("footerEmail");

const footerFacebook = document.getElementById("footerFacebook");
const footerInstagram = document.getElementById("footerInstagram");

const footerCopyNome = document.getElementById("footerCopyNome");
const anoAtual = document.getElementById("anoAtual"); 

function renderizarFooter() {

    footerNomeLoja.textContent = configuracao.nomeLoja;

    footerEndereco.textContent = configuracao.endereco;

    footerHorario.textContent =
        `${configuracao.abreAs.substring(0,5)} às ${configuracao.fechaAs.substring(0,5)}`;

    footerTelefone.textContent = configuracao.telefone;

    footerWhatsApp.textContent = configuracao.whatsApp;

    footerEmail.textContent = configuracao.email;

    footerFacebook.href = configuracao.facebook;
    footerInstagram.href = configuracao.instagram;

    footerCopyNome.textContent = configuracao.nomeLoja;

    anoAtual.textContent = new Date().getFullYear();

}

iniciar();