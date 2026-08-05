import { verificarAutenticacao } from "./auth.js";
import { get, post } from "./api.js";

verificarAutenticacao();



const formProduto = document.getElementById("formProduto");
const nomeProduto = document.getElementById("nomeProduto");
const descricaoProduto = document.getElementById("descricaoProduto");
const preco = document.getElementById("preco");
const prazoEntrega = document.getElementById("prazoEntrega");
const categoriaId = document.getElementById("categoriaId");
const ativo = document.getElementById("ativo");
const destaque = document.getElementById("destaque");
const imagemAtual = document.getElementById("imagemAtual");
const imagem = document.getElementById("imagem");




let previewUrl = null;

imagem.addEventListener("change", () => {

    if(imagem.files.length === 0){
        return;
    }

    if(previewUrl){
        URL.revokeObjectURL(previewUrl);
    }

    const arquivo = imagem.files[0];

    previewUrl = URL.createObjectURL(arquivo);

    imagemAtual.src = previewUrl;
});




const btnVoltar = document.getElementById("btnVoltar");

btnVoltar.addEventListener("click", () => {
    window.location.href = "/frontend/admin/produtos.html";
});


async function iniciarPagina(){
    await carregarCategorias();
}

async function carregarCategorias(){
    const categorias = await get("/categorias");

    categoriaId.innerHTML = "";

    for(const categoria of categorias){
        const option = document.createElement("option");

        option.value = categoria.idCategoria;

        option.textContent = categoria.nomeCategoria;

        categoriaId.appendChild(option);

        
    }
    console.log(categoriaId);
    console.log(categoriaId.innerHTML);
    console.log(categorias);
}

iniciarPagina();

const btnSalvar = document.getElementById("btnSalvar");

formProduto.addEventListener("submit", async (event) => {
    event.preventDefault();

    btnSalvar.disabled = true;
    btnSalvar.textContent = "Salvando...";

    

    try{

    const formData = new FormData();

    formData.append("NomeProduto", nomeProduto.value);
    formData.append("DescricaoProduto", descricaoProduto.value);
    formData.append("Preco", preco.value);
    formData.append("PrazoEntrega", prazoEntrega.value);
    formData.append("CategoriaId", categoriaId.value);
    formData.append("Ativo", ativo.checked.toString());
    formData.append("Destaque", destaque.checked.toString());

    if(imagem.files.length > 0){
        formData.append("Imagem", imagem.files[0]);
    }

    await post(`/produtos`, formData, true);

    alert("Produto cadastrado com sucesso!");
    window.location.href = "/frontend/admin/produtos.html";
    }
    catch(erro){
        alert(erro.message);
    }
    finally{
        btnSalvar.disabled = false;
        btnSalvar.textContent = "Cadastrar  Produto";
    }

});