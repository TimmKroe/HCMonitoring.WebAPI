--CREATE DATABASE [HCMonitoring.Main]

USE [HCMonitoring.Main]

CREATE TABLE [dbo].[Organization]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),
	[IsPublic] BIT DEFAULT 0 NOT NULL,
	
	-- Primary Key
	CONSTRAINT PK_OrganizatonId PRIMARY KEY (Id)
)

CREATE TABLE [dbo].[ApiKey]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),
	[OrganizationId] UNIQUEIDENTIFIER NOT NULL,
	
	-- Primary Key
	CONSTRAINT PK_ApiKeyId PRIMARY KEY (Id),
	
	-- Foreign Keys
	CONSTRAINT FK_ApiKey_OrganizationId FOREIGN KEY (OrganizationId) REFERENCES dbo.Organization (Id)
)

CREATE TABLE [dbo].[ServerStatus]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255)  NOT NULL,
	[Description] varchar(255)

    -- Primary Key
    CONSTRAINT PK_ServerStatusId PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[ServerType]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[HetznerId] int NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Cores] int NOT NULL,
	[Memory] int NOT NULL,
	[Disk] int NOT NULL,

    -- Primary Key
    CONSTRAINT PK_ServerTypeId PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[IPv4]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Ip] varchar(12) NOT NULL,
	[IsBlocked] BIT NOT NULL DEFAULT 1,
	[DnsPtr] varchar(255),

    -- Primary Key
    CONSTRAINT PK_IPv4Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[IPv6]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Ip] varchar(12) NOT NULL,
	[IsBlocked] BIT NOT NULL DEFAULT 1,
	[DnsPtr] varchar(255),

    -- Primary Key
    CONSTRAINT PK_IPv6Id PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[Datacenter]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[HetznerId] int NOT NULL,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,

    -- Primary Key
    CONSTRAINT PK_DatacenterId PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[ImageType]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),

    -- Primary Key
    CONSTRAINT PK_ImageTypeId PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[ImageStatus]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),

    -- Primary Key
    CONSTRAINT PK_ImageStatusId PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[Image]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
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
    CONSTRAINT PK_ImageId PRIMARY KEY (Id),

	-- Foreign Keys
	CONSTRAINT FK_Image_TypeId FOREIGN KEY (TypeId) REFERENCES dbo.ServerType (Id),
	CONSTRAINT FK_Image_StatusId FOREIGN KEY (StatusId) REFERENCES dbo.ServerStatus (Id),
)

CREATE TABLE [dbo].[Protection]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255),

    -- Primary Key
    CONSTRAINT PK_ProtectionId PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[Server]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
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
    CONSTRAINT PK_ServerId PRIMARY KEY (Id),

	-- Foreign Key
	CONSTRAINT FK_Server_StatusId FOREIGN KEY (StatusId) REFERENCES [dbo].ServerStatus (Id),
	CONSTRAINT FK_Server_IPv4Id FOREIGN KEY (IPv4Id) REFERENCES [dbo].[IPv4] (Id),
	CONSTRAINT FK_Server_IPv6Id FOREIGN KEY (IPv6Id) REFERENCES [dbo].[IPv6] (Id),
	CONSTRAINT FK_Server_ServerTypeId FOREIGN KEY (ServerTypeId) REFERENCES [dbo].[ServerType] (Id),
	CONSTRAINT FK_Server_DatacenterId FOREIGN KEY (DatacenterId) REFERENCES [dbo].[Datacenter] (Id),
	CONSTRAINT FK_Server_ImageId FOREIGN KEY (ImageId) REFERENCES dbo.Image (Id),
	CONSTRAINT FK_Server_ProtectionId FOREIGN KEY (ProtectionId) REFERENCES dbo.Protection (Id),
)


CREATE TABLE [dbo].[Backup]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
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
    CONSTRAINT PK_BackupId PRIMARY KEY (Id),

	-- Foreign Keys
	CONSTRAINT FK_Backup_TypeId FOREIGN KEY (TypeId) REFERENCES dbo.ImageType (Id),
	CONSTRAINT FK_Backup_StatusId FOREIGN KEY (StatusId) REFERENCES dbo.ImageStatus (Id),
	CONSTRAINT FK_Backup_FromServerId FOREIGN KEY (FromServerId) REFERENCES dbo.Server (Id),
	CONSTRAINT FK_Backup_BoundToServerId FOREIGN KEY (BoundToServerId) REFERENCES dbo.Server (Id),
)

CREATE TABLE [dbo].[Snapshot]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
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
    CONSTRAINT PK_SnapshotId PRIMARY KEY (Id),

	-- Foreign Keys
    CONSTRAINT FK_Snapshot_TypeId FOREIGN KEY (TypeId) REFERENCES dbo.ImageType (Id),
    CONSTRAINT FK_Snapshot_StatusId FOREIGN KEY (StatusId) REFERENCES dbo.ImageStatus (Id),
    CONSTRAINT FK_Snapshot_FromServerId FOREIGN KEY (FromServerId) REFERENCES dbo.Server (Id),
    CONSTRAINT FK_Snapshot_BoundToServerId FOREIGN KEY (BoundToServerId) REFERENCES dbo.Server (Id),
)


CREATE TABLE [dbo].[User]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255) NOT NULL,

    -- Primary Key
    CONSTRAINT PK_UserId PRIMARY KEY (Id),
)

CREATE TABLE [dbo].[IncidentComment]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255) NOT NULL, -- title
	[Comment] varchar(500) NOT NULL,
	[AuthorId] UNIQUEIDENTIFIER NOT NULL,

    -- Primary Key
    CONSTRAINT PK_IncidentCommentId PRIMARY KEY (Id),

    -- Foreign Key
	CONSTRAINT FK_IncidentComment_AuthorId FOREIGN KEY (AuthorId) REFERENCES dbo.[User] (Id)
)

CREATE TABLE [dbo].[Incident]
(
	[Id] UNIQUEIDENTIFIER UNIQUE,
	[Name] varchar(255) NOT NULL,
	[Description] varchar(255) NOT NULL,
	[AuthorId] UNIQUEIDENTIFIER NOT NULL,
	[Created_At] DATETIME NOT NULL DEFAULT GETDATE(),
    
    -- Primary Key
    CONSTRAINT PK_IncidentId PRIMARY KEY (Id),

	-- Foreign Key
    CONSTRAINT FK_Incident_AuthorId FOREIGN KEY (AuthorId) REFERENCES dbo.[User] (Id)
)