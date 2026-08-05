import { verificarAutenticacao } from "./auth.js";
import { get } from "./api.js";

verificarAutenticacao();

const listaCategorias = document.getElementById("listaCategorias");

async function carregarCategorias(){

    const categorias = await get("/categorias");

    listaCategorias.innerHTML = "";

     for (const categoria of categorias) {

        const item = document.createElement("div");

        item.className = "categoria-item";

        item.innerHTML = `
            <div class="categoria-info">

                <h3>${categoria.nomeCategoria}</h3>

                <span>
                    ${categoria.quantidadeProdutos} produto(s)
                </span>

            </div>

            <button class="btnEditar">
                Editar
            </button>
        `;

        const btnEditar = item.querySelector(".btnEditar");

        btnEditar.addEventListener("click", () =>{
            window.location.href = `categoria-editar.html?id=${categoria.idCategoria}`
            });

        listaCategorias.appendChild(item);

    }

    console.log(categorias);

}



carregarCategorias();

const btnNovaCategoria = document.getElementById("btnNovaCategoria");

btnNovaCategoria.addEventListener("click", () => {
    window.location.href = "/frontend/admin/categoria-novo.html";
});