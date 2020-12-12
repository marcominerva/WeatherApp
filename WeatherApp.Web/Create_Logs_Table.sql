CREATE TABLE [dbo].[Logs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Message] [nvarchar](max) NULL,
	[Level] [nvarchar](max) NULL,
	[Timestamp] [datetime] NULL,
	[Exception] [nvarchar](max) NULL,
	[LogEvent] [nvarchar](max) NULL,
 CONSTRAINT [PK_Logs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)) 
GO