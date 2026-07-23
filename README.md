# Confeitaria Web

![Status](https://img.shields.io/badge/Status-Em%20Desenvolvimento-yellow?style=for-the-badge)
![Last Commit](https://img.shields.io/github/last-commit/LucianoR8/site-docearia?style=for-the-badge)

## Descrição

Plataforma web para gerenciamento de produtos de uma docearia, permitindo que clientes consultem o catálogo, visualizem informações dos produtos e realizem pedidos por meio do WhatsApp.

O projeto está sendo desenvolvido com foco em boas práticas de desenvolvimento, documentação e arquitetura de software, servindo tanto como solução para pequenos negócios quanto como projeto de portfólio.

---

## Objetivo

Desenvolver uma plataforma simples e intuitiva que permita ao administrador gerenciar o catálogo de produtos da loja, enquanto os clientes podem navegar pelas categorias, visualizar detalhes dos produtos e iniciar uma encomenda diretamente pelo WhatsApp.

---

## Funcionalidades

### Área Administrativa

- Autenticação de administrador;
- Gerenciamento de produtos (CRUD);
- Gerenciamento de categorias (CRUD);
- Gerenciamento das configurações da loja;
- Alteração das informações de contato;
- Configuração do horário de funcionamento;
- Definição dos produtos em destaque;
- Gerenciamento da identidade visual (logo, ícone e, futuramente, banner).

### Área do Cliente

- Página inicial com produtos em destaque;
- Navegação por categorias;
- Página de detalhes do produto;
- Redirecionamento para o WhatsApp com mensagem pré-definida;
- Exibição das informações de contato da loja.

---

## Tecnologias

![HTML5](https://img.shields.io/badge/HTML5-E34F26?style=for-the-badge&logo=html5&logoColor=white)
![CSS3](https://img.shields.io/badge/CSS3-1572B6?style=for-the-badge&logo=css3&logoColor=white)
![JavaScript](https://img.shields.io/badge/JavaScript-F7DF1E?style=for-the-badge&logo=javascript&logoColor=black)
![Bootstrap](https://img.shields.io/badge/Bootstrap-7952B3?style=for-the-badge&logo=bootstrap&logoColor=white)
![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=csharp&logoColor=white)
![ASP.NET Core](https://img.shields.io/badge/ASP.NET_Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Entity Framework Core](https://img.shields.io/badge/Entity_Framework_Core-512BD4?style=for-the-badge)
![PostgreSQL](https://img.shields.io/badge/PostgreSQL-336791?style=for-the-badge&logo=postgresql&logoColor=white)
![Supabase](https://img.shields.io/badge/Supabase-3FCF8E?style=for-the-badge&logo=supabase&logoColor=white)
![Git](https://img.shields.io/badge/Git-F05032?style=for-the-badge&logo=git&logoColor=white)
![GitHub](https://img.shields.io/badge/GitHub-181717?style=for-the-badge&logo=github&logoColor=white)
![Figma](https://img.shields.io/badge/Figma-F24E1E?style=for-the-badge&logo=figma&logoColor=white)
![brModelo](https://img.shields.io/badge/brModelo-0066CC?style=for-the-badge)
![Render](https://img.shields.io/badge/Render-46E3B7?style=for-the-badge&logo=render&logoColor=white)
![VS Code](https://img.shields.io/badge/VS_Code-007ACC?style=for-the-badge&logo=visualstudiocode&logoColor=white)

---

## Arquitetura

O sistema foi dividido em dois módulos principais:

### Área Pública

- Home
- Categorias
- Produto

### Área Administrativa

- Login
- Dashboard
- Produtos
- Categorias
- Configurações

### Visão Comunicacional do Sistema

```
Frontend (HTML/CSS/JavaScript)
            │
            ▼
 ASP.NET Core Web API
            │
            ▼
 PostgreSQL (Supabase)
```

---

## Estrutura do Projeto

```text
ConfeitariaWeb/

backend/
│
└── ConfeitariaWeb/
    │
    ├── Controllers/
    ├── Data/
    ├── DTOs/
    ├── Interfaces/
    ├── Models/
    ├── Repositories/
    ├── Services/
    ├── Helpers/
    └── Program.cs

docs/
│
├── banco/
├── imagens/
└── wireframes/

frontend/
│
├── assets/
├── components/
├── css/
├── js/
├── pages/
└── index.html
```

---

## Banco de Dados

- [Modelo Conceitual](docs/banco/modelo-conceitual.png)
- [Schema SQL](docs/banco/schema.sql)

---

## Deploy

Frontend

- Cloudflare Pages

Backend

- Render

Banco de Dados

- Supabase

Domínio

- Registro.br (.com.br)

---

## Roadmap

### Planejamento

- [x] Levantamento de requisitos
- [x] Modelagem do banco de dados
- [x] Diagrama Entidade-Relacionamento
- [x] Criação do banco no Supabase
- [x] Documentação inicial

### Desenvolvimento

- [ ] Estrutura do Front-end
- [ ] Página Inicial
- [ ] Página de Categoria
- [ ] Página de Produto
- [x] Integração com Supabase
- [ ] Login Administrativo
- [ ] Dashboard
- [x] CRUD de Produtos
- [x] CRUD de Categorias
- [ ] Configurações da Loja

### Publicação

- [ ] Deploy
- [ ] Domínio
- [ ] Testes finais

---

## Melhorias Futuras

- Banner principal configurável;
- Upload de múltiplas imagens por produto;
- Pesquisa de produtos;
- Sistema de promoções;
- Área de pedidos;
- Carrinho de compras;
- Pagamento online;
- Controle de estoque;
- Área do cliente;
- Dashboard com estatísticas.

---

## Aprendizados

Durante o desenvolvimento deste projeto foram estudados e aplicados conceitos como:

- Modelagem de banco de dados relacional;
- Planejamento utilizando wireframes;
- Desenvolvimento de API REST com ASP.NET Core;
- Entity Framework Core;
- Integração entre API e PostgreSQL (Supabase);
- Organização de projetos em camadas;
- Documentação técnica;
- Estruturação de projetos para clientes reais.

---

## Autor

**Luciano Ribeiro**

GitHub: https://github.com/LucianoR8