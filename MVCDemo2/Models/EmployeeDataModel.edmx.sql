
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/11/2017 14:30:07
-- Generated from EDMX file: C:\Users\Jr\documents\visual studio 2015\Projects\MVCDemo2\MVCDemo2\Models\EmployeeDataModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Sample3];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK__tblEmploy__Depar__25869641]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK__tblEmploy__Depar__25869641];
GO
IF OBJECT_ID(N'[dbo].[FK_ClienteContrato]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Contratos] DROP CONSTRAINT [FK_ClienteContrato];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Clientes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Clientes];
GO
IF OBJECT_ID(N'[dbo].[Contratos]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Contratos];
GO
IF OBJECT_ID(N'[dbo].[Departments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Departments];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[Zonas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Zonas];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Departments'
CREATE TABLE [dbo].[Departments] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [IsSelected] bit  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmployeeId] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(50)  NULL,
    [Gender] nvarchar(10)  NULL,
    [City] nvarchar(50)  NULL,
    [DepartmentId] int  NULL
);
GO

-- Creating table 'Clientes'
CREATE TABLE [dbo].[Clientes] (
    [Id] int  NOT NULL,
    [Nome] varchar(100)  NULL,
    [Endereco] varchar(100)  NULL,
    [Cidade] varchar(100)  NULL,
    [Estado] char(2)  NULL
);
GO

-- Creating table 'Contratos'
CREATE TABLE [dbo].[Contratos] (
    [Id] int  NOT NULL,
    [Dados] varchar(100)  NULL,
    [Data] datetime  NULL,
    [ClienteId] int  NOT NULL
);
GO

-- Creating table 'Alarmes'
CREATE TABLE [dbo].[Alarmes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [EnderecoInstalacao] nvarchar(max)  NOT NULL,
    [DataInstalacao] datetime  NOT NULL,
    [ContratoId] int  NOT NULL
);
GO

-- Creating table 'Zonas'
CREATE TABLE [dbo].[Zonas] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] bigint  NOT NULL,
    [Nome] nvarchar(max)  NOT NULL,
    [AlarmeId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Departments'
ALTER TABLE [dbo].[Departments]
ADD CONSTRAINT [PK_Departments]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [EmployeeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmployeeId] ASC);
GO

-- Creating primary key on [Id] in table 'Clientes'
ALTER TABLE [dbo].[Clientes]
ADD CONSTRAINT [PK_Clientes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Contratos'
ALTER TABLE [dbo].[Contratos]
ADD CONSTRAINT [PK_Contratos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Alarmes'
ALTER TABLE [dbo].[Alarmes]
ADD CONSTRAINT [PK_Alarmes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Zonas'
ALTER TABLE [dbo].[Zonas]
ADD CONSTRAINT [PK_Zonas]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [DepartmentId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK__tblEmploy__Depar__25869641]
    FOREIGN KEY ([DepartmentId])
    REFERENCES [dbo].[Departments]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK__tblEmploy__Depar__25869641'
CREATE INDEX [IX_FK__tblEmploy__Depar__25869641]
ON [dbo].[Employees]
    ([DepartmentId]);
GO

-- Creating foreign key on [ClienteId] in table 'Contratos'
ALTER TABLE [dbo].[Contratos]
ADD CONSTRAINT [FK_ClienteContrato]
    FOREIGN KEY ([ClienteId])
    REFERENCES [dbo].[Clientes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClienteContrato'
CREATE INDEX [IX_FK_ClienteContrato]
ON [dbo].[Contratos]
    ([ClienteId]);
GO

-- Creating foreign key on [ContratoId] in table 'Alarmes'
ALTER TABLE [dbo].[Alarmes]
ADD CONSTRAINT [FK_ContratoAlarme]
    FOREIGN KEY ([ContratoId])
    REFERENCES [dbo].[Contratos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ContratoAlarme'
CREATE INDEX [IX_FK_ContratoAlarme]
ON [dbo].[Alarmes]
    ([ContratoId]);
GO

-- Creating foreign key on [AlarmeId] in table 'Zonas'
ALTER TABLE [dbo].[Zonas]
ADD CONSTRAINT [FK_AlarmeZona]
    FOREIGN KEY ([AlarmeId])
    REFERENCES [dbo].[Alarmes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_AlarmeZona'
CREATE INDEX [IX_FK_AlarmeZona]
ON [dbo].[Zonas]
    ([AlarmeId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------