import { post } from "./api.js";

export async function login(email, senha){

    const dados = {
        email: email,
        senha: senha
    };

    const resposta = await post("/auth/login", dados);

    localStorage.setItem("token", resposta.token);
    localStorage.setItem("nome", resposta.nome);
    localStorage.setItem("expiracao", resposta.expiracao);
    localStorage.setItem("role", resposta.role);

    return resposta;
}

export function logout(){
    localStorage.removeItem("token");
    localStorage.removeItem("nome");
    localStorage.removeItem("expiracao");
    localStorage.removeItem("role");
}

export function usuarioLogado(){
    return localStorage.getItem("token") !== null;
}

export function verificarAutenticacao(){
    if(!usuarioLogado()){
        window.location.href = "login.html";
    }
}



