import { logout, verificarAutenticacao } from "./auth.js";

verificarAutenticacao();

const nome = localStorage.getItem("nome");

const nomeUsuario = document.getElementById("nomeUsuario");

nomeUsuario.textContent = `Olá, ${nome}!`;

const btnLogout = document.getElementById("btnLogout");

btnLogout.addEventListener("click", () => {
    logout();

    window.location.href = "login.html";
});