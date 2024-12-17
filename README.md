# myfinance-web-dotnet
Sistema de finan�as pessoais

Descri��o

O projeto myfinance-web-dotnet � um projeto de controle de finan�as criado em ASP.NET CORE 8.0 com um banco de dados Microsoft SQL Server.

Este projeto de controle de finan�as possui duas entidades: Plano Conta e Transa��o. Plano Conta representa a categoria do elemento a ser inclu�do nas finan�as possuindo um nome e se � uma despesa ou renda como, por exemplo, �Combust�vel,D� (D representa despesa e R, renda). A entidade Transa��o representa todas as transa��es feitas pelo usu�rio e possui as informa��es de: data da transa��o, valor em reais, hist�rico(descri��o),tipo (despesa ou renda). 

Entidade Plano Conta

Essa entidade representa as categorias para as transa��es financeiras. Cada categoria � descrita com:
Nome: Nome da categoria da despesa ou renda. Exemplo: "Combust�vel", "Aluguel", "Sal�rio", etc.
Tipo: Se � uma Despesa (D) ou Renda (R).
Exemplos:
"Combust�vel,D" (Categoria de despesa para combust�vel)
"Sal�rio,R" (Categoria de renda referente ao sal�rio)

Entidade Transa��o

Essa entidade representa as transa��es reais realizadas, que est�o associadas ao Plano Conta. A transa��o tem as seguintes informa��es:
Data da transa��o: Quando a transa��o ocorreu.
Valor: O valor da transa��o em reais.
Hist�rico (Descri��o): Uma descri��o ou justificativa da transa��o. Exemplo: "Pagamento da gasolina", "Recebido de cliente X".
Tipo: Pode ser Despesa (D) ou Renda (R), indicando o fluxo de dinheiro (sa�da ou entrada).
Categoria (Plano Conta): A categoria associada � transa��o (por exemplo, "Combust�vel,D" ou "Sal�rio,R").
Exemplo de Transa��o:
Data: 15/11/2024
Valor: R$ 150,00
Hist�rico: "Pagamento de combust�vel"
Tipo: Despesa
Plano Conta: "Combust�vel,D"

Relacionamento entre as entidades:

O Plano Conta atua como uma "categoria" para as transa��es financeiras.
Cada Transa��o tem um tipo (despesa ou renda) e � associada a uma categoria do Plano Conta.
Exemplo Pr�tico de como isso funcionaria:
O usu�rio define v�rias categorias no Plano Conta:
"Alimenta��o,D" (Despesa)
"Sal�rio,R" (Renda)
"Transporte,D" (Despesa)
O usu�rio registra transa��es associadas a essas categorias:
Transa��o 1: 10/11/2024, R$ 500,00, "Sal�rio recebido", Tipo Renda, Plano Conta "Sal�rio,R".
Transa��o 2: 12/11/2024, R$ 50,00, "Compra no supermercado", Tipo Despesa, Plano Conta "Alimenta��o,D".

Fluxo de uso:

O usu�rio cria as categorias no Plano Conta.
O usu�rio registra Transa��es associadas a essas categorias, com valores e hist�ricos.
O sistema pode calcular o saldo da conta, analisar o hist�rico de despesas e rendas, e gerar relat�rios baseados nas transa��es e categorias.

Script do Banco de Dados

create database myfinance;
use myfinance;
CREATE TABLE PlanoConta (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador �nico da categoria
    Nome VARCHAR(255) NOT NULL,    -- Descri��o da categoria (ex: Combust�vel)
    Tipo CHAR(1) NOT NULL               -- Tipo da categoria: 'D' para Despesa, 'R' para Renda
);

CREATE TABLE Transacao (
    Id INT IDENTITY(1,1) PRIMARY KEY,             -- Identificador �nico da transa��o
    Data DATE NOT NULL,                   -- Data da transa��o
    Valor DECIMAL(9, 2) NOT NULL,                 -- Valor da transa��o (em reais)
    Historico VARCHAR(100) NOT NULL,               -- Descri��o ou hist�rico da transa��o
    Tipo CHAR(1) NOT NULL CHECK (Tipo IN ('D', 'R')),  -- Tipo da transa��o: 'D' para Despesa, 'R' para Renda
    PlanoContaId INT NOT NULL,                     -- Chave estrangeira que referencia o Plano Conta
    CONSTRAINT FK_PlanoConta FOREIGN KEY (PlanoContaId) REFERENCES PlanoConta(Id)  -- Relacionamento com o PlanoConta
);


-- Inserir categorias de Despesas (D) para teste
INSERT INTO PlanoConta (Nome, Tipo) VALUES
('Combust�vel', 'D'),
('Alimenta��o', 'D'),
('Aluguel', 'D'),
('�gua', 'D'),
('Luz', 'D'),
('Internet', 'D'),
('Manuten��o Carro', 'D'),
('Manuten��o Casa', 'D'),
('Viagem', 'D'),
('Vestu�rio', 'D'),
('Beleza', 'D');

-- Inserir categorias de Renda (R) para teste
INSERT INTO PlanoConta (Descricao, Tipo) VALUES
('Sal�rio', 'R'),
('Dividendos', 'R');