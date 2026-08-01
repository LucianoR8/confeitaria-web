import { verificarAutenticacao } from "./auth.js";
import { get } from "./api.js";

verificarAutenticacao();

const listaProdutos = document.getElementById("listaProdutos");

async function carregarProdutos(){

    const produtos = await get("/produtos");

    listaProdutos.innerHTML = "";

    for(const produto of produtos){
        const coluna = document.createElement("div");
        
        coluna.className = "produto-coluna";

        coluna.innerHTML = `
            <article class = "produto-card">
            <img
                src = "${produto.imagemUrl}"
                alt = "${produto.nomeProduto}"
                class = "produto-imagem">

                <h3 class = "produto-nome"> ${produto.nomeProduto}</h3>
                <p class = "produto-preco">R$ ${produto.preco}</p>
            </article>
            `;

        listaProdutos.appendChild(coluna);

        coluna.addEventListener("click", () => {
            window.location.href = `produto-editar.html?id=${produto.idProduto}`;
        });

    }

    

    console.log(produtos);
}



carregarProdutos();

