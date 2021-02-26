USE master

GO

CREATE DATABASE FavoDeMel;

GO
USE [FavoDeMel]
GO 

PRINT N'Creating [dbo].[Cliente]...';

GO
CREATE TABLE [dbo].[Cliente] (
    [IDCliente]            UNIQUEIDENTIFIER NOT NULL,
    [Nome]         NVARCHAR (255)  NOT NULL,
    [DataCriacao]   DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([IDCliente] ASC)
);

GO
PRINT N'Creating [dbo].[Produto]...';

GO
CREATE TABLE [dbo].[Produto] (
    [IDProduto]            UNIQUEIDENTIFIER NOT NULL,
    [Nome]         NVARCHAR (255)  NOT NULL,
    [Valor]   DECIMAL(10,2)         NOT NULL,
    PRIMARY KEY CLUSTERED ([IDProduto] ASC)
);

GO
PRINT N'Creating [dbo].[Garcom]...';

GO
CREATE TABLE [dbo].[Garcom] (
    [IDGarcom]            UNIQUEIDENTIFIER NOT NULL,
    [Nome]         NVARCHAR (255)  NOT NULL,
    [Telefone]         NVARCHAR (15)  NOT NULL,
    PRIMARY KEY CLUSTERED ([IDGarcom] ASC)
);

GO
PRINT N'Creating [dbo].[Comanda]...';

GO
CREATE TABLE [dbo].[Comanda] (
    [IDComanda]            UNIQUEIDENTIFIER NOT NULL,
    [Numero]         int NOT NULL,
    PRIMARY KEY CLUSTERED ([IDComanda] ASC)
);

GO
PRINT N'Creating [dbo].[Pedido]...';

GO
CREATE TABLE [dbo].[Pedido] (
    [IDPedido]            UNIQUEIDENTIFIER NOT NULL,
    [IDGarcom]         UNIQUEIDENTIFIER NOT NULL,
    [IDComanda]         UNIQUEIDENTIFIER NOT NULL,
    [IDCliente]         UNIQUEIDENTIFIER NOT NULL,
    [DataPedido]   DATETIME         NOT NULL,
    PRIMARY KEY CLUSTERED ([IDPedido] ASC)
);

ALTER TABLE Pedido ADD FOREIGN KEY (IDGarcom) REFERENCES Garcom(IDGarcom);
ALTER TABLE Pedido ADD FOREIGN KEY (IDComanda) REFERENCES Comanda(IDComanda);
ALTER TABLE Pedido ADD FOREIGN KEY (IDCliente) REFERENCES Cliente(IDCliente);

GO
PRINT N'Creating [dbo].[ProdutoPedido]...';

GO
CREATE TABLE [dbo].[ProdutoPedido] (
    [IDProdutoPedido]            UNIQUEIDENTIFIER NOT NULL,
    [IDProduto]    UNIQUEIDENTIFIER NOT NULL,
    [IDPedido]    UNIQUEIDENTIFIER NOT NULL,
    [Quantidade]   int         NOT NULL,
    PRIMARY KEY CLUSTERED ([IDProdutoPedido] ASC)
);

ALTER TABLE ProdutoPedido ADD FOREIGN KEY (IDProduto) REFERENCES Produto(IDProduto);
ALTER TABLE ProdutoPedido ADD FOREIGN KEY (IDPedido) REFERENCES Pedido(IDPedido);

GO
PRINT N'Creating [dbo].[HistoricoPedido]...';

GO
CREATE TABLE [dbo].[HistoricoPedido] (
    [IDHistoricoPedido] UNIQUEIDENTIFIER NOT NULL,
    [IDPedido]          UNIQUEIDENTIFIER NOT NULL,
    [Data]              DATETIME NOT NULL,
    [Situacao]          INT NOT NULL,
    PRIMARY KEY CLUSTERED ([IDHistoricoPedido] ASC)
);

ALTER TABLE HistoricoPedido ADD FOREIGN KEY (IDPedido) REFERENCES Pedido(IDPedido);

PRINT N'Update complete.';


GO