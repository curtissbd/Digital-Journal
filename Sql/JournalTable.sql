USE [DigitalDiaryCenter]
GO

/****** Object:  Table [dbo].[Journal]    Script Date: 1/30/2019 10:34:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Journal](
	[UserID] [int] NOT NULL,
	[JournalID] [int] IDENTITY(1,1) NOT NULL,
	[JournalName] [nchar](25) NOT NULL,
 CONSTRAINT [PK_Journal] PRIMARY KEY CLUSTERED 
(
	[JournalID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Journal]  WITH CHECK ADD  CONSTRAINT [FK_Journal_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[User] ([UserID])
GO

ALTER TABLE [dbo].[Journal] CHECK CONSTRAINT [FK_Journal_User]
GO

