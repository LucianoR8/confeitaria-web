import { verificarAutenticacao } from "./auth.js";
import { get, put, del } from "./api.js";

verificarAutenticacao();


const parametros = new URLSearchParams(window.location.search);
const id = parametros.get("id");

const formProduto = document.getElementById("formProduto");
const nomeProduto = document.getElementById("nomeProduto");
const descricaoProduto = document.getElementById("descricaoProduto");
const preco = document.getElementById("preco");
const prazoEntrega = document.getElementById("prazoEntrega");
const categoriaId = document.getElementById("categoriaId");
const ativo = document.getElementById("ativo");
const destaque = document.getElementById("destaque");
const imagemAtual = document.getElementById("imagemAtual");

parametros.get(id);

console.log(id);

const btnVoltar = document.getElementById("btnVoltar");

btnVoltar.addEventListener("click", () => {
    window.location.href = "produto.html";
})

async function carregarProduto(){
    const produto = await get(`/produtos/${id}`);
    nomeProduto.value = produto.nomeProduto;
    descricaoProduto.value = produto.descricaoProduto;
    preco.value = produto.preco;
    prazoEntrega.value = produto.prazoEntrega;
    ativo.checked = produto.ativo;
    destaque.checked  = produto.destaque;
    categoriaId.value = produto.categoriaId;
    imagemAtual.src = produto.imagemUrl;
}

async function carregarCategorias(){

}

carregarProduto();