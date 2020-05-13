USE [HCMonitoring.Main]
GO

UPDATE [dbo].[Server]
   SET [Id] = @Id
      ,[HetznerId] = @HetznerId
      ,[OrganizationId] = @OrganizationId
      ,[Name] = @Name
      ,[StatusId] = @StatusId
      ,[Created_At] = @CreatedAt
      ,[IPv4Id] = @IPv4Id
      ,[IPv6Id] = @Ipv6Id
      ,[ServerTypeId] = @ServerTypeId
      ,[DatacenterId] = @DatacenterId
      ,[ImageId] = @ImageId
      ,[IsProtected] = @Protection
      ,[BackupWindow] = @BackupWindow
      ,[OutgoingTraffic] = @OutgoingTraffic
      ,[IngoingTraffic] = @IngoingTraffic
      ,[IncludedTraffic] = @IncludedTraffic
      ,[IsVisible] = @Visibilty
      ,[IsMonitored] = @Monitored
      ,[IsIpsVisible] = @IpVisibility
 WHERE [Id] = ''
GO

