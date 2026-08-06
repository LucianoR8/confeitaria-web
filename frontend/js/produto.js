import { verificarAutenticacao } from "./auth.js";
import { get } from "./api.js";

verificarAutenticacao();

const listaProdutos = document.getElementById("listaProdutos");

async function carregarProdutos(){

    try{
    const produtos = await get("/produtos");

    listaProdutos.innerHTML = "";

    for (const produto of produtos) {

    const card = document.createElement("article");

    card.className = "produto-card";

    card.innerHTML = `

        <img
            src="${produto.imagemUrl}"
            alt="${produto.nomeProduto}"
            class="produto-imagem">

        <div class="produto-info">

            <h3 class="produto-nome">
                ${produto.nomeProduto}
            </h3>

            <p class="produto-preco">
                R$ ${Number(produto.preco).toFixed(2).replace(".", ",")}
            </p>

        </div>

    `;

    card.addEventListener("click", () => {
        window.location.href =
            `produto-editar.html?id=${produto.idProduto}`;
    });

    listaProdutos.appendChild(card);
}

}
catch(erro){
    console.error(erro);
    alert(erro.message);
}

    console.log(produtos);
}

const btnNovoProduto = document.getElementById("btnNovoProduto");

btnNovoProduto.addEventListener("click", () => {
    window.location.href = "produto-novo.html";
});


carregarProdutos();

