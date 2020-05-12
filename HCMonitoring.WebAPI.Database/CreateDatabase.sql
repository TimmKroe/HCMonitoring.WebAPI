CREATE DATABASE [HCMonitoring.Main]

USE [HCMonitoring.Main]

CREATE TABLE [dbo].[Organization]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),
	[IsPublic] BIT DEFAULT 0 NOT NULL,
	
	-- Primary Key
	CONSTRAINT PK_Id PRIMARY KEY (Id)
)

CREATE TABLE [dbo].[ApiKey]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),
	[OrganizationId] UNIQUEIDENTIFIER NOT NULL,
	
	-- Primary Key
	CONSTRAINT PK_Id PRIMARY KEY (Id),
	
	-- Foreign Keys
	CONSTRAINT FK_OrganizationId FOREIGN KEY (OrganizationId) REFERENCES dbo.Organization (Id)
)

CREATE TABLE [dbo].[ServerStatus]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255)  NOT NULL,
	[Description] varchar(255)

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[ServerType]
(
	[Id] UNIQUEIDENTIFIER,
	[HetznerId] int NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Cores] int NOT NULL,
	[Memory] int NOT NULL,
	[Disk] int NOT NULL,

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[IPv4]
(
	[Id] UNIQUEIDENTIFIER,
	[Ip] varchar(12) NOT NULL,
	[IsBlocked] BIT NOT NULL DEFAULT 1,
	[DnsPtr] varchar(255),

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[IPv6]
(
	[Id] UNIQUEIDENTIFIER,
	[Ip] varchar(12) NOT NULL,
	[IsBlocked] BIT NOT NULL DEFAULT 1,
	[DnsPtr] varchar(255),

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[Datacenter]
(
	[Id] UNIQUEIDENTIFIER,
	[HetznerId] int NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[ImageType]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[ImageStatus]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[Image]
(
	[Id] UNIQUEIDENTIFIER,
	[HetznerId] int NOT NULL,
	[TypeId] UNIQUEIDENTIFIER NOT NULL,
	[StatusId] UNIQUEIDENTIFIER NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[ImageSize] float NOT NULL,
	[DiskSize] float NOT NULL,
	[Created_At] DATETIME NOT NULL,
	[OsFlavor] varchar(255) NOT NULL,
	[OsVersion] varchar(255) NOT NULL,

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),

	-- Foreign Keys
	CONSTRAINT FK_TypeId FOREIGN KEY (TypeId) REFERENCES dbo.ServerType (Id),
	CONSTRAINT FK_StatusId FOREIGN KEY (StatusId) REFERENCES dbo.ServerStatus (Id),
)

CREATE TABLE [dbo].[Protection]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[Server]
(
	[Id] UNIQUEIDENTIFIER,
	[HetznerId] int NOT NULL UNIQUE,
	[Name] varchar(255) NOT NULL,
	[StatusId] UNIQUEIDENTIFIER NOT NULL,
	[Created_At] DATETIME NOT NULL,
	[IPv4Id] UNIQUEIDENTIFIER NOT NULL,
	[IPv6Id] UNIQUEIDENTIFIER NOT NULL,
	[ServerTypeId] UNIQUEIDENTIFIER NOT NULL,
	[DatacenterId] UNIQUEIDENTIFIER NOT NULL,
	[ImageId] UNIQUEIDENTIFIER NOT NULL,
	[ProtectionId] UNIQUEIDENTIFIER NOT NULL,
	[BackupWindow] varchar(5) NOT NULL,
	[OutgoingTraffic] bigint NOT NULL,
	[IngoingTraffic] bigint NOT NULL,
	[IncludedTraffic] bigint NOT NULL,

	-- Options
	[IsVisible] BIT NOT NULL DEFAULT 0, -- visible is false als default
	[IsMonitored] BIT NOT NULL DEFAULT 1, -- is true
	[IsIpsVisible] BIT NOT NULL DEFAULT 0, -- for privacy and security reasons false

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),

	-- Foreign Key
	CONSTRAINT FK_StatusId FOREIGN KEY (StatusId) REFERENCES [dbo].ServerStatus (Id),
	CONSTRAINT FK_IPv4Id FOREIGN KEY (IPv4Id) REFERENCES [dbo].[IPv4] (Id),
	CONSTRAINT FK_IPv6Id FOREIGN KEY (IPv6Id) REFERENCES [dbo].[IPv6] (Id),
	CONSTRAINT FK_ServerTypeId FOREIGN KEY (ServerTypeId) REFERENCES [dbo].[ServerType] (Id),
	CONSTRAINT FK_DatacenterId FOREIGN KEY (DatacenterId) REFERENCES [dbo].[Datacenter] (Id),
	CONSTRAINT FK_ImageId FOREIGN KEY (ImageId) REFERENCES dbo.Image (Id),
	CONSTRAINT FK_ProtectionId FOREIGN KEY (ProtectionId) REFERENCES dbo.Protection (Id),
)


CREATE TABLE [dbo].[Backup]
(
	[Id] UNIQUEIDENTIFIER,
	[HetznerId] int NOT NULL,
	[TypeId] UNIQUEIDENTIFIER NOT NULL,
	[StatusId] UNIQUEIDENTIFIER NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[ImageSize] float NOT NULL,
	[DiskSize] float NOT NULL,
	[Created_At] DATETIME NOT NULL,
	[FromServerId] UNIQUEIDENTIFIER NOT NULL,
	[BoundToServerId] UNIQUEIDENTIFIER NOT NULL,
	[OsFlavor] varchar(255) NOT NULL,
	[OsVersion] varchar(255) NOT NULL,

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),

	-- Foreign Keys
	CONSTRAINT FK_TypeId FOREIGN KEY (TypeId) REFERENCES dbo.ImageType (Id),
	CONSTRAINT FK_StatusId FOREIGN KEY (StatusId) REFERENCES dbo.ImageStatus (Id),
	CONSTRAINT FK_FromServerId FOREIGN KEY (FromServerId) REFERENCES dbo.Server (Id),
	CONSTRAINT FK_BoundToServerId FOREIGN KEY (BoundToServerId) REFERENCES dbo.Server (Id),
)

CREATE TABLE [dbo].[Snapshot]
(
	[Id] UNIQUEIDENTIFIER,
	[HetznerId] int NOT NULL,
	[TypeId] UNIQUEIDENTIFIER NOT NULL,
	[StatusId] UNIQUEIDENTIFIER NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[ImageSize] float NOT NULL,
	[DiskSize] float NOT NULL,
	[Created_At] DATETIME NOT NULL,
	[FromServerId] UNIQUEIDENTIFIER NOT NULL,
	[BoundToServerId] UNIQUEIDENTIFIER NOT NULL,
	[OsFlavor] varchar(255) NOT NULL,
	[OsVersion] varchar(255) NOT NULL,

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),

	-- Foreign Keys
    CONSTRAINT FK_TypeId FOREIGN KEY (TypeId) REFERENCES dbo.ImageType (Id),
    CONSTRAINT FK_StatusId FOREIGN KEY (StatusId) REFERENCES dbo.ImageStatus (Id),
    CONSTRAINT FK_FromServerId FOREIGN KEY (FromServerId) REFERENCES dbo.Server (Id),
    CONSTRAINT FK_BoundToServerId FOREIGN KEY (BoundToServerId) REFERENCES dbo.Server (Id),
)


CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255) NOT NULL,

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[IncidentComment]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255) NOT NULL, -- title
	[Comment] varchar(500) NOT NULL,
	[AuthorId] UNIQUEIDENTIFIER NOT NULL,

    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),

    -- Foreign Key
	CONSTRAINT FK_AuthorId FOREIGN KEY (AuthorId) REFERENCES dbo.[User] (Id)
)

CREATE TABLE [dbo].[Incident]
(
	[Id] UNIQUEIDENTIFIER,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[AuthorId] UNIQUEIDENTIFIER NOT NULL,
	[Created_At] DATETIME NOT NULL DEFAULT GETDATE(),
    
    -- Primary Key
    CONSTRAINT PK_Id PRIMARY KEY (Id),

	-- Foreign Key
    CONSTRAINT FK_AuthorId FOREIGN KEY (AuthorId) REFERENCES dbo.[User] (Id)
)