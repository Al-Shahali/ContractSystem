USE [ContractSystem]
GO
/****** Object:  Table [dbo].[CONTACT]    Script Date: 2/27/2024 9:17:57 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CONTACT](
	[CONCOD] [int] IDENTITY(1,1) NOT NULL,
	[NAME] [nvarchar](255) NOT NULL,
	[PHONE] [nvarchar](15) NOT NULL,
	[ADDRESS] [nvarchar](255) NOT NULL,
	[NOTE] [nvarchar](max) NULL,
 CONSTRAINT [PK_CONTACT] PRIMARY KEY CLUSTERED 
(
	[CONCOD] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[CONTACT] ON 
GO
INSERT [dbo].[CONTACT] ([CONCOD], [NAME], [PHONE], [ADDRESS], [NOTE]) VALUES (1, N'Name', N'1234567', N'Address', N'Note')
GO
INSERT [dbo].[CONTACT] ([CONCOD], [NAME], [PHONE], [ADDRESS], [NOTE]) VALUES (2, N'ahmde', N'1232143', N'Address', N'noteeeeeeeeeeee')
GO
SET IDENTITY_INSERT [dbo].[CONTACT] OFF
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Code' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CONTACT', @level2type=N'COLUMN',@level2name=N'CONCOD'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Name' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CONTACT', @level2type=N'COLUMN',@level2name=N'NAME'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Phone' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CONTACT', @level2type=N'COLUMN',@level2name=N'PHONE'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Address' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CONTACT', @level2type=N'COLUMN',@level2name=N'ADDRESS'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Contact Note' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'CONTACT', @level2type=N'COLUMN',@level2name=N'NOTE'
GO
