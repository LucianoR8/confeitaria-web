import { login } from "./auth.js";

const form = document.getElementById("formLogin");

form.addEventListener("submit", async (event) => {

    event.preventDefault();

    const email = document.getElementById("email").value;

    const senha = document.getElementById("senha").value;

    const mensagemErro = document.getElementById("mensagemErro");
    mensagemErro.textContent = "";

    try{
        await login(email, senha);
        window.location.href = "/frontend/admin/dashboard.html";
    }
    catch(erro){
        console.error(erro);

        mensagemErro.textContent = erro.message;

    }
});