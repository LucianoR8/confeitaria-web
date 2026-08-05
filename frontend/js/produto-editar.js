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
const imagem = document.getElementById("imagem");
const btnExcluir = document.getElementById("btnExcluir");

btnExcluir.addEventListener("click", async () =>{


const confirmar = confirm("Deseja realmente excluir esse produto?");

if(!confirmar){
    return;
}

await del(`/produtos/${id}`);
alert("Produto excluído com sucesso.");
window.location.href = "/frontend/admmin/produtos.html";

});

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



console.log(id);

const btnVoltar = document.getElementById("btnVoltar");

btnVoltar.addEventListener("click", () => {
    window.location.href = "/frontend/admin/produtos.html";
})


async function iniciarPagina(){
    await carregarCategorias();
    await carregarProduto();
}
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
    const categorias = await get("/categorias");

    categoriaId.innerHTML = "";

    for(const categoria of categorias){
        const option = document.createElement("option");

        option.value = categoria.idCategoria;

        option.textContent = categoria.nomeCategoria;

        categoriaId.appendChild(option);

        
    }

    console.log(categorias);
}

formProduto.addEventListener("submit", async (event) => {
    event.preventDefault();

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

    await put(`/produtos/${id}`, formData, true);

    alert("Produto atualizado com sucesso!");
    window.location.href = "/frontend/admin/produtos.html";


});

iniciarPagina();

