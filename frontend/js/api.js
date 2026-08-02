const API_URL = "https://localhost:7072/api";

export async function post(endpoint, body, isFormData = false){

        const url = API_URL + endpoint;

        const options = {

            method: "POST",
            headers: getHeaders(isFormData)
        }

        if(isFormData){
            options.body = body;
        }
        else{
            options.body = JSON.stringify(body);
        }

        const response = await fetch(url, options);

        if(!response.ok){

            const erro = await response.text();

            throw new Error(erro);
        }

        return await response.json();
}

export async function get(endpoint){

     const url = API_URL + endpoint;

     const options = {

            method: "GET",
            headers: getHeaders()
        }

        const response = await fetch(url, options);

        if(!response.ok){

            const erro = await response.text();

            throw new Error(erro);
        }

        return await response.json();
}

export async function put(endpoint, body, isFormData = false){

    const url = API_URL + endpoint;

    const options = {

            method: "PUT",
            headers: getHeaders(isFormData)
        }

        if(isFormData){
            options.body = body;
        }
        else{
            options.body = JSON.stringify(body);
        }

        const response = await fetch(url, options);

        if(!response.ok){

            const erro = await response.text();

            throw new Error(erro);
        }

        return await response.json();
}

export async function del(endpoint){

     const url = API_URL + endpoint;

     const options = {

            method: "DELETE",
            headers: getHeaders()
        }

        const response = await fetch(url, options);

        if(response.status == 401){
            localStorage.clear();

            alert("Sua sessão expirou. Faça login novamente.");

            window.location.href = "/frontend/pages/admin/login.html";

            return;
        }
        
        if(!response.ok){

            const erro = await response.text();

            throw new Error(erro);
        }

        
        return await response.json();

     
}

function getHeaders(isFormData = false){

    const token = localStorage.getItem("token");
    const headers = {};

    if(!isFormData){
        headers["Content-Type"] = "application/json";
    }

    if(token){
        headers["Authorization"] = `Bearer ${token}`;
    }

    return headers;
}