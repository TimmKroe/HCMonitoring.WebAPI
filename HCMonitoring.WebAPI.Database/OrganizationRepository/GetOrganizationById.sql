USE [HCMonitoring.Main]
GO

SELECT TOP(100) [Id]
      ,[Name]
      ,[Description]
      ,[IsPublic]
  FROM [dbo].[Organization]
  WHERE dbo.Organization.Id = '13AB153F-E1A3-42FB-9851-F22080AD0E90';

GO

