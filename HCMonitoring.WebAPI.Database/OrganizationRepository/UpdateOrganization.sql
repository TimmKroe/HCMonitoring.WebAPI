USE [HCMonitoring.Main]
GO

UPDATE [dbo].[Organization]
   SET [Id] = @Id
      ,[Name] = @Name
      ,[Description] = @Description
      ,[IsPublic] = @Visibility
 WHERE dbo.Organization.Id = '';
GO

