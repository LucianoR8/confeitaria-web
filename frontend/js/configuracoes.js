import { verificarAutenticacao } from "./auth.js";
import { get, put } from "./api.js";

verificarAutenticacao();

const formConfiguracao = document.getElementById("formConfiguracao");

const nomeLoja = document.getElementById("nomeLoja");
const telefone = document.getElementById("telefone");
const whatsApp = document.getElementById("whatsApp");
const email = document.getElementById("email");
const facebook = document.getElementById("facebook");
const instagram = document.getElementById("instagram");
const endereco = document.getElementById("endereco");

const abreAs = document.getElementById("abreAs");
const fechaAs = document.getElementById("fechaAs");
const quantidadeMaximaDestaques = document.getElementById("quantidadeMaximaDestaques");

const logoAtual = document.getElementById("logoAtual");
const iconeAtual = document.getElementById("iconeAtual");
const bannerAtual = document.getElementById("bannerAtual");

const logo = document.getElementById("logo");
const icone = document.getElementById("icone");
const banner = document.getElementById("banner");

const btnVoltar = document.getElementById("btnVoltar");

btnVoltar.addEventListener("click", () => {
    window.location.href = "dashboard.html";
});

async function carregarConfiguracao(){

    const configuracao = await get("/configuracoes/");

    console.log(configuracao);

     nomeLoja.value = configuracao.nomeLoja;
    facebook.value = configuracao.facebook ?? "";
    instagram.value = configuracao.instagram ?? "";

    endereco.value = configuracao.endereco;
    telefone.value = configuracao.telefone;
    whatsApp.value = configuracao.whatsApp ?? "";
    email.value = configuracao.email ?? "";

    abreAs.value = configuracao.abreAs;
    fechaAs.value = configuracao.fechaAs;

    quantidadeMaximaDestaques.value = configuracao.quantidadeMaximaDestaques;

    logoAtual.src = configuracao.logoUrl;
    iconeAtual.src = configuracao.iconeUrl;
    bannerAtual.src = configuracao.bannerUrl;

}

carregarConfiguracao();

formConfiguracao.addEventListener("submit", async (event) => {

    event.preventDefault();

    const formData = new FormData();

    formData.append("NomeLoja", nomeLoja.value);
    formData.append("Facebook", facebook.value);
    formData.append("Instagram", instagram.value);
    formData.append("Endereco", endereco.value);
    formData.append("Telefone", telefone.value);
    formData.append("WhatsApp", whatsApp.value);
    formData.append("Email", email.value);
    formData.append("AbreAs", abreAs.value);
    formData.append("FechaAs", fechaAs.value);
    formData.append(
        "QuantidadeMaximaDestaques",
        quantidadeMaximaDestaques.value
    );

    if(logo.files.length > 0){
    formData.append("Logo", logo.files[0]);
    }

    if(icone.files.length > 0){
        formData.append("Icone", icone.files[0]);
    }

    if(banner.files.length > 0){
        formData.append("Banner", banner.files[0]);
    }

    await put("/configuracoes", formData, true);

alert("Configurações atualizadas com sucesso!");

location.reload();

});


let previewLogo = null;
let previewIcone = null;
let previewBanner = null;


logo.addEventListener("change", () => {

    if (logo.files.length === 0)
        return;

    if (previewLogo)
        URL.revokeObjectURL(previewLogo);

    previewLogo = URL.createObjectURL(logo.files[0]);

    logoAtual.src = previewLogo;
});


icone.addEventListener("change", () => {

    if (icone.files.length === 0)
        return;

    if (previewIcone)
        URL.revokeObjectURL(previewIcone);

    previewIcone = URL.createObjectURL(icone.files[0]);

    iconeAtual.src = previewIcone;
});


banner.addEventListener("change", () => {

    if (banner.files.length === 0)
        return;

    if (previewBanner)
        URL.revokeObjectURL(previewBanner);

    previewBanner = URL.createObjectURL(banner.files[0]);

    bannerAtual.src = previewBanner;
});

configurarPreview();