
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/15/2018 14:12:40
-- Generated from EDMX file: c:\users\juan-\source\repos\ProyectoAllers\ProyectoAllers\Modelo.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [P09706_1_20];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_PedidoArticulo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_PedidoArticulo];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteVenta]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ventas] DROP CONSTRAINT [FK_ClienteVenta];
GO
IF OBJECT_ID(N'[dbo].[FK_VentaPedido]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Pedidos] DROP CONSTRAINT [FK_VentaPedido];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Articulos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Articulos];
GO
IF OBJECT_ID(N'[dbo].[Ventas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ventas];
GO
IF OBJECT_ID(N'[dbo].[Pedidos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Pedidos];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [CardCode] nvarchar(max)  NOT NULL,
    [GroupName] nvarchar(max)  NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [Region] nvarchar(max)  NOT NULL,
    [Pymnt] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Articulos'
CREATE TABLE [dbo].[Articulos] (
    [ItemCode] int  NOT NULL,
    [ItemName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ventas'
CREATE TABLE [dbo].[Ventas] (
    [DocNum] int  NOT NULL,
    [DocDate] nvarchar(max)  NOT NULL,
    [DocTotal] float  NOT NULL,
    [ClienteCardCode] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Pedidos'
CREATE TABLE [dbo].[Pedidos] (
    [Cantidad] int  NOT NULL,
    [Precio] float  NOT NULL,
    [ArticuloItemCode] int  NOT NULL,
    [LineaTotal] float  NOT NULL,
    [VentaDocNum1] int  NOT NULL,
    [VentaClienteCardCode] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [CardCode] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([CardCode] ASC);
GO

-- Creating primary key on [ItemCode] in table 'Articulos'
ALTER TABLE [dbo].[Articulos]
ADD CONSTRAINT [PK_Articulos]
    PRIMARY KEY CLUSTERED ([ItemCode] ASC);
GO

-- Creating primary key on [DocNum], [ClienteCardCode] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [PK_Ventas]
    PRIMARY KEY CLUSTERED ([DocNum], [ClienteCardCode] ASC);
GO

-- Creating primary key on [ArticuloItemCode], [VentaDocNum1] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [PK_Pedidos]
    PRIMARY KEY CLUSTERED ([ArticuloItemCode], [VentaDocNum1] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ArticuloItemCode] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_PedidoArticulo]
    FOREIGN KEY ([ArticuloItemCode])
    REFERENCES [dbo].[Articulos]
        ([ItemCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [ClienteCardCode] in table 'Ventas'
ALTER TABLE [dbo].[Ventas]
ADD CONSTRAINT [FK_ClienteVenta]
    FOREIGN KEY ([ClienteCardCode])
    REFERENCES [dbo].[Clientes]
        ([CardCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteVenta'
CREATE INDEX [IX_FK_ClienteVenta]
ON [dbo].[Ventas]
    ([ClienteCardCode]);
GO

-- Creating foreign key on [VentaDocNum1], [VentaClienteCardCode] in table 'Pedidos'
ALTER TABLE [dbo].[Pedidos]
ADD CONSTRAINT [FK_VentaPedido]
    FOREIGN KEY ([VentaDocNum1], [VentaClienteCardCode])
    REFERENCES [dbo].[Ventas]
        ([DocNum], [ClienteCardCode])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_VentaPedido'
CREATE INDEX [IX_FK_VentaPedido]
ON [dbo].[Pedidos]
    ([VentaDocNum1], [VentaClienteCardCode]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------