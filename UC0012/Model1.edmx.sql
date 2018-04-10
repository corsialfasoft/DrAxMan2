create database Ordini
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 04/10/2018 10:25:35
-- Generated from EDMX file: C:\Users\ALFA-PC\source\Workspaces\MVCOrdiniUC001\MVCOrdiniUC001\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [ORDINI];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_OrdiniProdotti_Ordini]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdiniProdotti] DROP CONSTRAINT [FK_OrdiniProdotti_Ordini];
GO
IF OBJECT_ID(N'[dbo].[FK_OrdiniProdotti_Prodotti]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OrdiniProdotti] DROP CONSTRAINT [FK_OrdiniProdotti_Prodotti];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[OrdiniProdotti]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdiniProdotti];
GO
IF OBJECT_ID(N'[dbo].[OrdiniSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrdiniSet];
GO
IF OBJECT_ID(N'[dbo].[ProdottiSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdottiSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'OrdiniProdotti'
CREATE TABLE [dbo].[OrdiniProdotti] (
    [Ordini_Id] int  NOT NULL,
    [Prodotti_Id] int  NOT NULL,
    [quantita] int  NOT NULL
);
GO

-- Creating table 'OrdiniSet'
CREATE TABLE [dbo].[OrdiniSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [data] datetime  NOT NULL
);
GO

-- Creating table 'ProdottiSet'
CREATE TABLE [dbo].[ProdottiSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [descrizione] nvarchar(max)  NOT NULL,
    [quantita] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Ordini_Id], [Prodotti_Id] in table 'OrdiniProdotti'
ALTER TABLE [dbo].[OrdiniProdotti]
ADD CONSTRAINT [PK_OrdiniProdotti]
    PRIMARY KEY CLUSTERED ([Ordini_Id], [Prodotti_Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrdiniSet'
ALTER TABLE [dbo].[OrdiniSet]
ADD CONSTRAINT [PK_OrdiniSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdottiSet'
ALTER TABLE [dbo].[ProdottiSet]
ADD CONSTRAINT [PK_ProdottiSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Ordini_Id] in table 'OrdiniProdotti'
ALTER TABLE [dbo].[OrdiniProdotti]
ADD CONSTRAINT [FK_OrdiniProdotti_Ordini]
    FOREIGN KEY ([Ordini_Id])
    REFERENCES [dbo].[OrdiniSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Prodotti_Id] in table 'OrdiniProdotti'
ALTER TABLE [dbo].[OrdiniProdotti]
ADD CONSTRAINT [FK_OrdiniProdotti_Prodotti]
    FOREIGN KEY ([Prodotti_Id])
    REFERENCES [dbo].[ProdottiSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OrdiniProdotti_Prodotti'
CREATE INDEX [IX_FK_OrdiniProdotti_Prodotti]
ON [dbo].[OrdiniProdotti]
    ([Prodotti_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

insert into ProdottiSet(descrizione,quantita) values('televisore',1000),('telefono',2000)