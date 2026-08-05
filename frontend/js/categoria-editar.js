import { verificarAutenticacao } from "./auth.js";
import { get, put, del } from "./api.js";

verificarAutenticacao();

const parametros = new URLSearchParams(window.location.search);

const id = parametros.get("id");

const nomeCategoria = document.getElementById("nomeCategoria");
const formCategoria = document.getElementById("formCategoria");
const btnExcluir = document.getElementById("btnExcluir");
const btnVoltar = document.getElementById("btnVoltar");

btnVoltar.addEventListener("click", () =>{
    window.location.href = "/frontend/admin/categorias.html";
});

async function carregarCategoria(){
    const categoria = await get(`/categorias/${id}`);

    nomeCategoria.value = categoria.nomeCategoria;
}

formCategoria.addEventListener("submit", async (event) =>{
    event.preventDefault();

    try{
    const dados = {
        nomeCategoria: nomeCategoria.value
    };

    await put(`/categorias/${id}`, dados);

    alert("Categoria atualizada com sucesso!");

    window.location.href = "/frontend/admin/categorias.html";
    }
    catch(erro){
        alert(erro.message);
    }
});

btnExcluir.addEventListener("click", async () =>{
    const confirmar = confirm("Deseja realmente excluir essa categoria?");

    if(!confirmar){
        return;
    }

    try{
        await del(`/categorias/${id}`);

        alert("Categoria excluida com sucesso.");

        window.location.href = "/frontend/admin/categorias.html";
    }
    catch(erro){
        alert(erro.message);
    }
});



carregarCategoria();