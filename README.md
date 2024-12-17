# myfinance-web-dotnet
Sistema de finanças pessoais

Descrição

O projeto myfinance-web-dotnet é um projeto de controle de finanças criado em ASP.NET CORE 8.0 com um banco de dados Microsoft SQL Server.

Este projeto de controle de finanças possui duas entidades: Plano Conta e Transação. Plano Conta representa a categoria do elemento a ser incluído nas finanças possuindo um nome e se é uma despesa ou renda como, por exemplo, “Combustível,D” (D representa despesa e R, renda). A entidade Transação representa todas as transações feitas pelo usuário e possui as informações de: data da transação, valor em reais, histórico(descrição),tipo (despesa ou renda). 

Entidade Plano Conta

Essa entidade representa as categorias para as transações financeiras. Cada categoria é descrita com:
Nome: Nome da categoria da despesa ou renda. Exemplo: "Combustível", "Aluguel", "Salário", etc.
Tipo: Se é uma Despesa (D) ou Renda (R).
Exemplos:
"Combustível,D" (Categoria de despesa para combustível)
"Salário,R" (Categoria de renda referente ao salário)

Entidade Transação

Essa entidade representa as transações reais realizadas, que estão associadas ao Plano Conta. A transação tem as seguintes informações:
Data da transação: Quando a transação ocorreu.
Valor: O valor da transação em reais.
Histórico (Descrição): Uma descrição ou justificativa da transação. Exemplo: "Pagamento da gasolina", "Recebido de cliente X".
Tipo: Pode ser Despesa (D) ou Renda (R), indicando o fluxo de dinheiro (saída ou entrada).
Categoria (Plano Conta): A categoria associada à transação (por exemplo, "Combustível,D" ou "Salário,R").
Exemplo de Transação:
Data: 15/11/2024
Valor: R$ 150,00
Histórico: "Pagamento de combustível"
Tipo: Despesa
Plano Conta: "Combustível,D"

Relacionamento entre as entidades:

O Plano Conta atua como uma "categoria" para as transações financeiras.
Cada Transação tem um tipo (despesa ou renda) e é associada a uma categoria do Plano Conta.
Exemplo Prático de como isso funcionaria:
O usuário define várias categorias no Plano Conta:
"Alimentação,D" (Despesa)
"Salário,R" (Renda)
"Transporte,D" (Despesa)
O usuário registra transações associadas a essas categorias:
Transação 1: 10/11/2024, R$ 500,00, "Salário recebido", Tipo Renda, Plano Conta "Salário,R".
Transação 2: 12/11/2024, R$ 50,00, "Compra no supermercado", Tipo Despesa, Plano Conta "Alimentação,D".

Fluxo de uso:

O usuário cria as categorias no Plano Conta.
O usuário registra Transações associadas a essas categorias, com valores e históricos.
O sistema pode calcular o saldo da conta, analisar o histórico de despesas e rendas, e gerar relatórios baseados nas transações e categorias.

Script do Banco de Dados

create database myfinance;
use myfinance;
CREATE TABLE PlanoConta (
    Id INT IDENTITY(1,1) PRIMARY KEY,  -- Identificador único da categoria
    Nome VARCHAR(255) NOT NULL,    -- Descrição da categoria (ex: Combustível)
    Tipo CHAR(1) NOT NULL               -- Tipo da categoria: 'D' para Despesa, 'R' para Renda
);

CREATE TABLE Transacao (
    Id INT IDENTITY(1,1) PRIMARY KEY,             -- Identificador único da transação
    Data DATE NOT NULL,                   -- Data da transação
    Valor DECIMAL(9, 2) NOT NULL,                 -- Valor da transação (em reais)
    Historico VARCHAR(100) NOT NULL,               -- Descrição ou histórico da transação
    Tipo CHAR(1) NOT NULL CHECK (Tipo IN ('D', 'R')),  -- Tipo da transação: 'D' para Despesa, 'R' para Renda
    PlanoContaId INT NOT NULL,                     -- Chave estrangeira que referencia o Plano Conta
    CONSTRAINT FK_PlanoConta FOREIGN KEY (PlanoContaId) REFERENCES PlanoConta(Id)  -- Relacionamento com o PlanoConta
);


-- Inserir categorias de Despesas (D) para teste
INSERT INTO PlanoConta (Nome, Tipo) VALUES
('Combustível', 'D'),
('Alimentação', 'D'),
('Aluguel', 'D'),
('Água', 'D'),
('Luz', 'D'),
('Internet', 'D'),
('Manutenção Carro', 'D'),
('Manutenção Casa', 'D'),
('Viagem', 'D'),
('Vestuário', 'D'),
('Beleza', 'D');

-- Inserir categorias de Renda (R) para teste
INSERT INTO PlanoConta (Descricao, Tipo) VALUES
('Salário', 'R'),
('Dividendos', 'R');