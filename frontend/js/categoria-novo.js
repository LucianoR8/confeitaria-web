import { verificarAutenticacao } from "./auth.js";
import { post } from "./api.js";

verificarAutenticacao();

const formCategoria = document.getElementById("formCategoria");
const nomeCategoria = document.getElementById("nomeCategoria");
const btnVoltar = document.getElementById("btnVoltar");
const btnSalvar = document.getElementById("btnSalvar");

btnVoltar.addEventListener("click", () => {
    window.location.href = "categorias.html";
});

formCategoria.addEventListener("submit", async (event) => {
    event.preventDefault();

    btnSalvar.disabled = true;
    btnSalvar.textContent = "Salvando...";

    

    try{

    const dados = {

    nomeCategoria: nomeCategoria.value
    
    };

    await post("/categorias", dados);

    alert("Categoria cadastrada com sucesso!");
    window.location.href = "categorias.html";
    }
    catch(erro){
        alert(erro.message);
    }
    finally{
        btnSalvar.disabled = false;
        btnSalvar.textContent = "Cadastrar Categoria";
    }

});

