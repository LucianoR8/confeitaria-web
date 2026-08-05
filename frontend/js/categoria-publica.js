import { get } from "./api.js";

const parametros = new URLSearchParams(window.location.search);

const id = parametros.get("id");

let categoria = null;

let produtos = [];

async function iniciarPagina(){

    await carregarCategoria();

    await carregarProdutos();

    console.log(categoria);

    console.log(produtos);

    renderizarCategoria();
    renderizarProdutos();

}

async function carregarCategoria(){

    categoria = await get(`/categorias/${id}`);

}

async function carregarProdutos(){

    produtos = await get(`/produtos/categoria/${id}`);

}

const tituloCategoria = document.getElementById("tituloCategoria");


function renderizarCategoria(){

    document.title = categoria.nomeCategoria;

    tituloCategoria.textContent = categoria.nomeCategoria;

}

const listaProdutos = document.getElementById("listaProdutos");

function renderizarProdutos(){

    listaProdutos.innerHTML = "";

    for(const produto of produtos){

        const card = document.createElement("article");

        card.className = "produto-card";

        card.innerHTML = `
        
            <img
                src="${produto.imagemUrl}"
                alt="${produto.nomeProduto}">

            <div class="produto-info">

                <h3>${produto.nomeProduto}</h3>

                <span class="preco">

                    R$ ${Number(produto.preco).toFixed(2).replace(".", ",")}

                </span>

            </div>

        `;

        card.addEventListener("click", () =>{

            window.location.href =
                `produto.html?id=${produto.idProduto}`;

        });

        listaProdutos.appendChild(card);

    }

}

const btnVoltar = document.getElementById("btnVoltar");

btnVoltar.addEventListener("click", () =>{

    history.back();

});

iniciarPagina();

