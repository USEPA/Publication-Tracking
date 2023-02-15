USE [EPA_PubNumbers]
GO
-- First, fix the exsiting ones.
UPDATE [dbo].[ResponsibleCodes] SET [IsValid] = 1 WHERE [IsValid] = 0 GO

-- Now, create the new ones.
INSERT INTO [dbo].[ResponsibleCodes]([Code],[Organization],[IsValid])VALUES('000', 'Legacy/Invalid', 0)

GO