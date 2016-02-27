USE [ShellDb]
GO

/****** Object:  Table [dbo].[BusinessUsers]    Script Date: 28/02/2016 12:47:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[BusinessUsers](
	[BusinessId] [int] NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[Role] [int] NOT NULL
) ON [PRIMARY]

GO

