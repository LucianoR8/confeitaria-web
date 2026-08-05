import { get } from "./api.js";

const parametros = new URLSearchParams(window.location.search);

const id = parametros.get("id");

let produto = null;
let configuracao = null;

async function iniciarPagina(){

    produto = await get(`/produtos/${id}`);

    configuracao = await get("/configuracoes");

    console.log(produto);

    renderizarProduto();

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

}

const mensagem = encodeURIComponent(

`Olá!

Tenho interesse no produto:

${produto.nomeProduto}

Valor: ${precoProduto.textContent}`

);

btnWhatsapp.href =

`https://wa.me/55${configuracao.whatsApp}?text=${mensagem}`;
