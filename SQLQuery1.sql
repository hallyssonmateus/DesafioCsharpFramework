-- Criar tabela Peça
CREATE TABLE Peça (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chave primária
    Nome NVARCHAR(100) NOT NULL,
    Fabricante NVARCHAR(100) NOT NULL,
    Categoria NVARCHAR(100) NOT NULL,
    TipoVeiculo NVARCHAR(100) NOT NULL,
    Quantidade INT NOT NULL DEFAULT 0,
    PrecoCompra DECIMAL(18, 2) NOT NULL,
    PrecoVenda DECIMAL(18, 2) NOT NULL,
    Status NVARCHAR(20) NOT NULL CHECK (Status IN ('Ativo', 'Inativo')) -- Aceita apenas 'Ativo' ou 'Inativo'
);

-- Criar tabela Vendas
CREATE TABLE Vendas (
    Id INT IDENTITY(1,1) PRIMARY KEY, -- Chave primária
    PecaId INT NOT NULL, -- Relacionamento com a tabela Peça
    QuantidadeVendida INT NOT NULL,
    ValorVenda DECIMAL(18, 2) NOT NULL,
    DataVenda DATETIME NOT NULL DEFAULT GETDATE(),
    CONSTRAINT FK_Vendas_Peca FOREIGN KEY (PecaId) REFERENCES Peça(Id) ON DELETE CASCADE
);
