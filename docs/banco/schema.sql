create table categorias (
  id_categoria INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
  nome_categoria VARCHAR(100) UNIQUE NOT NULL
);

create table configuracoes (
  id_configuracao INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
  nome_loja varchar(100) NOT NULL,
  facebook TEXT,
  instagram TEXT,
  endereco TEXT NOT NULL,
  abre_as TIME NOT NULL,
  fecha_as TIME NOT NULL,
  telefone VARCHAR(20) NOT NULL,
  whatsapp VARCHAR(20),
  email VARCHAR(100),
  quantidade_maxima_destaques SMALLINT DEFAULT 9
);

CREATE TABLE produtos (
    id_produto INT GENERATED ALWAYS AS IDENTITY PRIMARY KEY,
    nome_produto VARCHAR(100) NOT NULL,
    descricao_produto TEXT,
    imagem_url TEXT,
    prazo_entrega VARCHAR(100) NOT NULL,
    slug VARCHAR(100) UNIQUE,
    criado_em TIMESTAMP WITH TIME ZONE DEFAULT CURRENT_TIMESTAMP,
    ativo BOOLEAN DEFAULT TRUE,
    destaque BOOLEAN DEFAULT FALSE,
    preco NUMERIC(10, 2) NOT NULL,
    categoria_id INT NOT NULL,

    CONSTRAINT fk_categoria
        FOREIGN KEY (categoria_id) 
        REFERENCES categorias(id_categoria)
);

CREATE OR REPLACE FUNCTION verificar_limite_destaques()
RETURNS TRIGGER AS $$
DECLARE
    limite SMALLINT;
    total_destaques INTEGER;
BEGIN

    -- Obtém o limite configurado
    SELECT quantidade_maxima_destaques
    INTO limite
    FROM configuracoes
    LIMIT 1;

    -- Caso ainda não exista registro na tabela configuracoes,
    -- utiliza o valor padrão.
    IF limite IS NULL THEN
        limite := 9;
    END IF;

    -- Apenas verifica quando o produto estiver sendo marcado como destaque
    IF NEW.destaque THEN

        SELECT COUNT(*)
        INTO total_destaques
        FROM produtos
        WHERE destaque = TRUE
          AND id_produto <> NEW.id_produto;

        IF total_destaques >= limite THEN
            RAISE EXCEPTION
                'Quantidade máxima de produtos em destaque atingida (%).',
                limite;
        END IF;

    END IF;

    RETURN NEW;

END;
$$ LANGUAGE plpgsql;

CREATE TRIGGER gatilho_limite_destaques
BEFORE INSERT OR UPDATE
ON produtos
FOR EACH ROW
EXECUTE FUNCTION verificar_limite_destaques();

