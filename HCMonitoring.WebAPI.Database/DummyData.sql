USE [HCMonitoring.Main]
GO

INSERT INTO [dbo].[Organization] ([Id], [Name], [Description], [IsPublic])
VALUES (NEWID(), 'Example Organization', 'Example Organization Description', 0)
GO

DECLARE @OrgId UNIQUEIDENTIFIER;
SELECT @OrgId = Id
FROM dbo.Organization;


INSERT INTO [dbo].[ApiKey] ([Id], [Name], [Description], [OrganizationId])
VALUES (NEWID(), 'Example ApiKey', 'APIKEY', @OrgId)
GO

INSERT INTO [dbo].[ServerStatus]([Id], [Name], [Description])
VALUES (NEWID(), 'running', 'everything is allright')
GO

INSERT INTO [dbo].[ServerType] ([Id], [HetznerId], [Name], [Cores], [Memory], [Disk])
VALUES (NEWID(), 7887, 'CPX11', 4, 16, 160)
GO

INSERT INTO [dbo].[IPv4]([Id], [Ip], [IsBlocked], [DnsPtr])
VALUES (NEWID(), '999.999.999.999', 0,'null')
GO

INSERT INTO [dbo].[IPv6]([Id], [Ip], [IsBlocked], [DnsPtr])
VALUES (NEWID(), 'akdf:ksd:dfk', 0,'null')
GO

INSERT INTO [dbo].[Datacenter]([Id], [HetznerId], [Name], [Description])
VALUES (NEWID(), 8743, 'fsn1-dc8', 'Falkenstein')
GO

INSERT INTO [dbo].[ImageStatus]([Id], [Name], [Description])
VALUES (NEWID(), 'available', 'this image is available')

INSERT INTO [dbo].[ImageStatus]([Id], [Name], [Description])
VALUES (NEWID(), 'creating', 'this image is creating')
GO

DECLARE @ImageStatusId UNIQUEIDENTIFIER;
SELECT TOP (1) @ImageStatusId = Id
FROM dbo.ImageStatus;

INSERT INTO [dbo].[Image]([Id], [HetznerId], [StatusId], [Name], [Description], [ImageSize], [DiskSize], [Created_At],
                          [OsFlavor], [OsVersion])
VALUES (NEWID(), 4635, @ImageStatusId, 'Example Image', 'Example Image Description', 1.6, 160, SYSDATETIME(), 'ubuntu',
        '20.04')
GO

DECLARE @OrgId UNIQUEIDENTIFIER;
DECLARE @StatusId UNIQUEIDENTIFIER;
DECLARE @Ipv4 UNIQUEIDENTIFIER;
DECLARE @Ipv6 UNIQUEIDENTIFIER;
DECLARE @ServerType UNIQUEIDENTIFIER;
DECLARE @Datacenter UNIQUEIDENTIFIER;
DECLARE @Image UNIQUEIDENTIFIER;

SELECT TOP (1) @OrgId = Id
FROM dbo.Organization;
SELECT TOP (1) @StatusId = Id
FROM dbo.ServerStatus;
SELECT TOP (1) @Ipv4 = Id
FROM dbo.IPv4;
SELECT TOP (1) @IPv6 = Id
FROM dbo.IPv6;
SELECT TOP (1) @ServerType = Id
FROM dbo.ServerType;
SELECT TOP (1) @Datacenter = Id
FROM dbo.Datacenter;
SELECT TOP (1) @Image = Id
FROM dbo.Image;


INSERT INTO [dbo].[Server]
( [Id]
, [HetznerId]
, [OrganizationId]
, [Name]
, [StatusId]
, [Created_At]
, [IPv4Id]
, [IPv6Id]
, [ServerTypeId]
, [DatacenterId]
, [ImageId]
, [IsProtected]
, [BackupWindow]
, [OutgoingTraffic]
, [IngoingTraffic]
, [IncludedTraffic]
, [IsVisible]
, [IsMonitored]
, [IsIpsVisible])
VALUES ( NEWID()
       , 769375
       , @OrgId
       , 'EX-SRV-01'
       , @StatusId
       , SYSDATETIME()
       , @Ipv4
       , @Ipv6
       , @ServerType
       , @Datacenter
       , @Image
       , 0
       , '22-05'
       , 8450234857203487
       , 8450234857203487
       , 8450234857203487
       , 1
       , 1
       , 1)
GO

DECLARE @Status UNIQUEIDENTIFIER;
DECLARE @Server UNIQUEIDENTIFIER;

SELECT TOP (1) @Status = Id
FROM dbo.ImageStatus;
SELECT TOP (1) @Server = Id
FROM dbo.Server;

INSERT INTO [dbo].[Backup]
( [Id]
, [HetznerId]
, [StatusId]
, [Name]
, [Description]
, [ImageSize]
, [DiskSize]
, [Created_At]
, [FromServerId]
, [BoundToServerId]
, [OsFlavor]
, [OsVersion])
VALUES ( NEWID()
       , 75357
       , @Status
       , 'backup 0249245203545'
       , 'a backup'
       , 1.8
       , 160
       , SYSDATETIME()
       , @Server
       , @Server
       , 'ubuntu'
       , '20.04')
GO


DECLARE @Status UNIQUEIDENTIFIER;
DECLARE @Server UNIQUEIDENTIFIER;

SELECT TOP (1) @Status = Id
FROM dbo.ImageStatus;
SELECT TOP (1) @Server = Id
FROM dbo.Server;

INSERT INTO [dbo].[Snapshot]
( [Id]
, [HetznerId]
, [StatusId]
, [Name]
, [Description]
, [ImageSize]
, [DiskSize]
, [Created_At]
, [FromServerId]
, [BoundToServerId]
, [OsFlavor]
, [OsVersion])
VALUES ( NEWID()
       , 75357
       , @Status
       , 'backup 0249245203545'
       , 'a backup'
       , 1.8
       , 160
       , SYSDATETIME()
       , @Server
       , @Server
       , 'ubuntu'
       , '20.04')
GO

DECLARE @OrgId UNIQUEIDENTIFIER;
SELECT @OrgId = Id
FROM dbo.Organization;

INSERT INTO [dbo].[User]
( [Id]
, [Name]
, [OrganizationId])
VALUES ( NEWID()
       , 'Timm'
       , @OrgId)
GO

DECLARE @OrgId UNIQUEIDENTIFIER;
SELECT @OrgId = Id
FROM dbo.Organization;

DECLARE @Server UNIQUEIDENTIFIER;
SELECT @Server = Id FROM dbo.Server;

DECLARE @Author UNIQUEIDENTIFIER;
SELECT @Author = Id FROM dbo.[User];

INSERT INTO [dbo].[Incident]
([Id]
,[OrganizationId]
,[ServerId]
,[Name]
,[Description]
,[AuthorId]
,[Created_At])
VALUES
(NEWID()
    ,@OrgId
    ,@Server
    ,'Example Incident'
    ,'Example Incident Description'
    ,@Author
    ,SYSDATETIME())
GO