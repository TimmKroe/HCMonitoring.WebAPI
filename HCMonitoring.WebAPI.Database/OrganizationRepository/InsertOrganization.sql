USE [HCMonitoring.Main]
GO

INSERT INTO [dbo].[Organization]
           ([Id]
           ,[Name]
           ,[Description]
           ,[IsPublic])
     VALUES
           (NEWID()
           ,@Name
           ,@Description
           ,@Visiblity)
GO

