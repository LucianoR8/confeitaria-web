import { get } from "./api.js";

let configuracao = null;
let categorias = [];
let produtos = [];

async function iniciarPagina() {

    await carregarConfiguracao();
    await carregarCategorias();
    await carregarProdutos();

    console.log(configuracao);
    console.log(categorias);
    console.log(produtos);

    renderizarHeader();
    renderizarHero();
    renderizarCategorias();
    renderizarProdutos();
    renderizarFooter();
}

async function carregarConfiguracao() {

    configuracao = await get("/configuracoes");

}

const iconeLoja = document.getElementById("iconeLoja");
const nomeLoja = document.getElementById("nomeLoja");


function renderizarHeader(){
    iconeLoja.src = configuracao.iconeUrl;
    iconeLoja.alt = configuracao.nomeLoja;

    nomeLoja.textContent = configuracao.nomeLoja;

    document.title = configuracao.nomeLoja;

    const favicon = document.getElementById("favicon");
    const name = document.getElementById("name");

    favicon.href = configuracao.iconeUrl;
    name.textContent = configuracao.nomeLoja;
}

const heroTitulo = document.getElementById("heroTitulo");
const heroLogo = document.getElementById("heroLogo");

function renderizarHero(){
    heroTitulo.textContent = configuracao.nomeLoja;

    heroLogo.src = configuracao.logoUrl;
    heroLogo.alt = configuracao.nomeLoja;
}


async function carregarCategorias() {

    categorias = await get("/categorias");

}

const listaCategorias = document.getElementById("listaCategorias");

function renderizarCategorias(){
    listaCategorias.innerHTML = "";

    const categoriaTodos = document.createElement("button");

    categoriaTodos.className = "itemCategoria";
    categoriaTodos.textContent = "Todos os Produtos";

    categoriaTodos.addEventListener("click", () => {
        fecharDrawer();

        console.log("Mostrar todos");


    });

    listaCategorias.appendChild(categoriaTodos);

    for(const categoria of categorias){
        const botao = document.createElement("button");

        botao.className = "itemCategoria";

        botao.textContent = 
            `${categoria.nomeCategoria} (${categoria.quantidadeProdutos})`;
            botao.addEventListener("click", () => {
                fecharDrawer();
                console.log(categoria.idCategoria);

            });

            listaCategorias.appendChild(botao);
        }
}




const drawer = document.getElementById("drawerCategorias");
const overlay = document.getElementById("overlay");
const btnCategorias = document.getElementById("btnCategorias");
const btnFecharDrawer = document.getElementById("btnFecharDrawer");

btnCategorias.addEventListener("click", () => {
    drawer.classList.add("ativo");
    overlay.classList.add("ativo");
});

btnFecharDrawer.addEventListener("click", fecharDrawer);

overlay.addEventListener("click", fecharDrawer);

function fecharDrawer(){
    drawer.classList.remove("ativo");
    overlay.classList.remove("ativo");
}

async function carregarProdutos() {

    produtos = await get("/produtos/destaques");

}

const listaProdutos = document.getElementById("listaProdutos");

function renderizarProdutos(){
    listaProdutos.innerHTML = "";

    for (const produto of produtos){
        const card = document.createElement("div");

        card.className = "produto-card";

        card.innerHTML = `<img src ="${produto.imagemUrl}"
        alt="${produto.nomeProduto}">
        
        <div class="produto-info">
        
        <h3>${produto.nomeProduto}</h3>
        
        <span>R$ ${Number(produto.preco).toFixed(2).replace(".",",")}</span>
        
        </div>`;

        card.addEventListener("click", () =>{
            window.location.href = `produto.html?id=${produto.idProduto}`;

        });

        listaProdutos.appendChild(card);
    }
}

const footerNomeLoja = document.getElementById("footerNomeLoja");
const footerEndereco = document.getElementById("footerEndereco");
const footerHorario = document.getElementById("footerHorario");
const footerTelefone = document.getElementById("footerTelefone");
const footerWhatsApp = document.getElementById("footerWhatsApp");
const footerEmail = document.getElementById("footerEmail");

const footerFacebook = document.getElementById("footerFacebook");
const footerInstagram = document.getElementById("footerInstagram");

const footerCopyNome = document.getElementById("footerCopyNome");
const anoAtual = document.getElementById("anoAtual"); 

function renderizarFooter() {

    footerNomeLoja.textContent = configuracao.nomeLoja;

    footerEndereco.textContent = configuracao.endereco;

    footerHorario.textContent =
        `${configuracao.abreAs.substring(0,5)} às ${configuracao.fechaAs.substring(0,5)}`;

    footerTelefone.textContent = configuracao.telefone;

    footerWhatsApp.textContent = configuracao.whatsApp;

    footerEmail.textContent = configuracao.email;

    footerFacebook.href = configuracao.facebook;
    footerInstagram.href = configuracao.instagram;

    footerCopyNome.textContent = configuracao.nomeLoja;

    anoAtual.textContent = new Date().getFullYear();

}

iniciarPagina();

