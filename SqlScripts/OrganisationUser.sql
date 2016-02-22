USE [ShellDb]
GO

/****** Object:  Table [dbo].[OrganisationUser]    Script Date: 22/02/2016 6:26:04 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[OrganisationUser](
	[OrganisationId] [int] NOT NULL,
	[UserId] [nvarchar](50) NOT NULL,
	[Role] [int] NOT NULL
) ON [PRIMARY]

GO

