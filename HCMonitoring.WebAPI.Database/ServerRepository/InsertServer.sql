USE [HCMonitoring.Main]
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

SELECT * FROM dbo.Server;
Go