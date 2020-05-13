/****** Skript für SelectTopNRows-Befehl aus SSMS ******/
SELECT TOP (100) dbo.Server.[Id] AS [ServerId]
      ,dbo.Server.[Name] AS [ServerName] 
      ,dbo.ServerStatus.Name AS [Status]
      ,dbo.Server.[Created_At]
      ,dbo.IPv4.Ip AS [IPv4]
      ,dbo.IPv6.Ip AS [IPv6]
      ,dbo.ServerType.Name AS [ServerTypeName]
      ,dbo.Datacenter.Name AS [DatacenterName]
	  ,dbo.Datacenter.Description AS [DatacenterNameNormalized]
      ,dbo.Image.Name AS [ImageName]
	  ,dbo.Image.OsFlavor + '-' + dbo.Image.OsVersion AS [OsFlavour]
      ,[IsProtected]
      ,[BackupWindow]
      ,[OutgoingTraffic]
      ,[IngoingTraffic]
      ,[IncludedTraffic]
      ,[IsVisible]
      ,[IsMonitored]
      ,[IsIpsVisible]
  FROM [HCMonitoring.Main].[dbo].[Server]
  INNER JOIN dbo.ServerStatus ON dbo.Server.StatusId = dbo.ServerStatus.Id
  INNER JOIN dbo.IPv4 ON dbo.Server.IPv4Id = dbo.IPv4.Id
  INNER JOIN dbo.IPv6 On dbo.Server.IPv6Id = dbo.IPv6.Id
  INNER JOIN dbo.ServerType ON dbo.Server.ServerTypeId = dbo.ServerType.Id
  INNER JOIN dbo.Datacenter ON dbo.Server.DatacenterId = dbo.Datacenter.Id
  INNER JOIN dbo.Image ON dbo.Server.ImageId = dbo.Image.Id WHERE dbo.Server.Id = '7E9A34EE-D2E8-4A04-950A-BD020A269538';