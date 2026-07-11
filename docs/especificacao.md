# Especificação de endpoints

## Produtos

GET /produtos - Lista todos os produtos existentes.
GET /produtos/{id} - Retorna um produto específico.
GET /produtos/categoria/{id} - Lista os produtos de uma categoria.
GET /produtos/destaques - Lista os produtos em destaque.
POST /produtos - Cadastra um novo produto.
PUT /produtos/{id} - Atualiza um produto.
DELETE /produtos/{id} - Exclui um produto.

## Categorias

GET /categorias - Lista as categorias existentes.
GET /categorias/{id} - Retorna uma categoria específica.
POST /categorias - Cadastra uma nova categoria.
PUT /categorias/{id} - Atualiza uma categoria.
DELETE /categorias/{id} - Exclui uma categoria.

## Configurações

GET /configuracoes - Lista todas as configurações existentes.
PUT /configuracoes/{id} - Atualiza uma configuração.

## Login

POST /login - Retorna um token após login.

### Público

Endpoints que serão utilizados pelo site

GET /produtos - Lista todos os produtos existentes.
GET /produtos/{id} - Retorna um produto específico.
GET /produtos/categoria/{id} - Lista os produtos de uma categoria.
GET /produtos/destaques - Lista os produtos em destaque.
GET /categorias - Lista as categorias existentes.
GET /categorias/{id} - Retorna uma categoria específica.
GET /configuracoes - Lista todas as configurações existentes.
POST /login - Retorna um token após login.

### Privado

Endpoints que serão utilizados no painel admnistrativo.

GET /produtos - Lista todos os produtos existentes.
GET /produtos/{id} - Retorna um produto específico.
GET /produtos/categoria/{id} - Lista os produtos de uma categoria.
GET /produtos/destaques - Lista os produtos em destaque.
POST /produtos - Cadastra um novo produto.
PUT /produtos/{id} - Atualiza um produto.
DELETE/produtos/{id} - Exclui um produto.
GET /categorias - Lista as categorias existentes.
GET /categorias/{id} - Retorna uma categoria específica.
POST /categorias - Cadastra uma nova categoria.
PUT /categorias/{id} - Atualiza uma categoria.
DELETE/categorias/{id} - Exclui uma categoria.
GET /configuracoes - Lista todas as configurações existentes
PUT /configuracoes/{id} - Atualiza uma configuração

#### Endpoints por telas

Os endpoints que cada tela consumirá.

##### Home

GET /produtos/destaques - Lista os produtos em destaque.
GET /categorias - Lista as categorias existentes.
GET /configuracoes - Lista todas as configurações existentes.

##### Produtos por categoria

GET /produtos/categoria/{id} - Lista os produtos de uma categoria.
GET /configuracoes - Lista todas as configurações existentes.

##### Produtos - Área Pública

GET /produtos/{id} - Retorna um produto específico.
GET /configuracoes - Lista todas as configurações existentes.

##### Login

POST /login - Retorna um token após login.

##### Dashboard

GET /produtos - Lista todos os produtos existentes.
GET /categorias - Lista as categorias existentes.
GET /configuracoes - Lista todas as configurações existentes.

##### Produtos - Área Admnistrativa

GET /produtos/{id} - Retorna um produto específico.
POST /produtos - Cadastra um novo produto.
PUT /produtos/{id} - Atualiza um produto.
DELETE/produtos/{id} - Exclui um produto.

##### Categorias - Área Admnistrativa

GET /categorias/{id} - Retorna uma categoria específica.
GET /produtos/categoria/{id} - Lista os produtos de uma categoria.
POST /categorias - Cadastra uma nova categoria.
PUT /categorias/{id} - Atualiza uma categoria.
DELETE/categorias/{id} - Exclui uma categoria.

##### Configurações da loja

PUT /configuracoes - Atualiza uma configuração.