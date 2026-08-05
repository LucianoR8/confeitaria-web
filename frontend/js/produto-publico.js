import { get } from "./api.js";

const parametros = new URLSearchParams(window.location.search);

const slug = parametros.get("slug");

let produto = null;
let configuracao = null;



async function iniciarPagina(){

    produto = await get(`/produtos/slug/${slug}`);

    configuracao = await get("/configuracoes");

    console.log(produto);

    renderizarProduto();
    renderizarFooter();

}

async function carregarConfiguracao() {

    configuracao = await get("/configuracoes");

}

iniciarPagina();

const imagemProduto = document.getElementById("imagemProduto");
const nomeProduto = document.getElementById("nomeProduto");
const precoProduto = document.getElementById("precoProduto");
const categoriaProduto = document.getElementById("categoriaProduto");
const prazoEntrega = document.getElementById("prazoEntrega");
const descricaoProduto = document.getElementById("descricaoProduto");
const btnWhatsapp = document.getElementById("btnWhatsapp");
const btnVoltar = document.getElementById("btnVoltar");

btnVoltar.addEventListener("click", () => {

    history.back();

});

function renderizarProduto(){

    imagemProduto.src = produto.imagemUrl;

    imagemProduto.alt = produto.nomeProduto;

    nomeProduto.textContent = produto.nomeProduto;

    precoProduto.textContent =
        produto.preco.toLocaleString(
            "pt-BR",
            {
                style:"currency",
                currency:"BRL"
            }
        );

    categoriaProduto.textContent =
        produto.nomeCategoria;

    prazoEntrega.textContent =
        produto.prazoEntrega;

    descricaoProduto.textContent =
        produto.descricaoProduto;

        const mensagem = encodeURIComponent(

`Olá!

Tenho interesse no produto:

${produto.nomeProduto}

Valor: ${precoProduto.textContent}`

);

btnWhatsapp.href =

`https://wa.me/55${configuracao.whatsApp}?text=${mensagem}`;

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
