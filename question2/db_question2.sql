CREATE DATABASE question2
GO
USE [question2]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITEM](
	[Name] [nvarchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ITEM_TRANSLATION](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](20) NOT NULL,
	[Title] [nvarchar](50) NOT NULL,
	[Detail] [nvarchar](50) NOT NULL,
	[ImageUrls] [nvarchar](100) NOT NULL,
	[Category] [nvarchar](20) NOT NULL,
	[LanguageCode] [char](2) NOT NULL,
 CONSTRAINT [PK__ITEM_TRA__3214EC273962B8AF] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LANGUAGE](
	[Code] [char](2) NOT NULL,
	[Name] [varchar](20) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[ITEM] ([Name]) VALUES (N'Button1')
INSERT [dbo].[ITEM] ([Name]) VALUES (N'News1')
INSERT [dbo].[ITEM] ([Name]) VALUES (N'News2')
GO
SET IDENTITY_INSERT [dbo].[ITEM_TRANSLATION] ON 

INSERT [dbo].[ITEM_TRANSLATION] ([ID], [Name], [Title], [Detail], [ImageUrls], [Category], [LanguageCode]) VALUES (2, N'News1', N'Transfer', N'Dünya Kupasý Þampiyonu', N'example url tr', N'Spor', N'TR')
INSERT [dbo].[ITEM_TRANSLATION] ([ID], [Name], [Title], [Detail], [ImageUrls], [Category], [LanguageCode]) VALUES (5, N'News1', N'Transfer', N'World Cup Champion', N'example url en', N'Sport', N'EN')
INSERT [dbo].[ITEM_TRANSLATION] ([ID], [Name], [Title], [Detail], [ImageUrls], [Category], [LanguageCode]) VALUES (13, N'Button1', N'Giriþ Yap', N'Kullanýcý Giriþ Yap Butonu', N'button pic tr', N'Element', N'TR')
INSERT [dbo].[ITEM_TRANSLATION] ([ID], [Name], [Title], [Detail], [ImageUrls], [Category], [LanguageCode]) VALUES (15, N'Button1', N'Login', N'User Login Button', N'button pic en', N'Element', N'EN')
SET IDENTITY_INSERT [dbo].[ITEM_TRANSLATION] OFF
GO
INSERT [dbo].[LANGUAGE] ([Code], [Name]) VALUES (N'EN', N'English')
INSERT [dbo].[LANGUAGE] ([Code], [Name]) VALUES (N'TR', N'Türkçe')
GO
ALTER TABLE [dbo].[ITEM_TRANSLATION]  WITH CHECK ADD  CONSTRAINT [FK__ITEM_TRAN__Langu__300424B4] FOREIGN KEY([LanguageCode])
REFERENCES [dbo].[LANGUAGE] ([Code])
GO
ALTER TABLE [dbo].[ITEM_TRANSLATION] CHECK CONSTRAINT [FK__ITEM_TRAN__Langu__300424B4]
GO
ALTER TABLE [dbo].[ITEM_TRANSLATION]  WITH CHECK ADD FOREIGN KEY([Name])
REFERENCES [dbo].[ITEM] ([Name])
GO
ALTER TABLE [dbo].[ITEM_TRANSLATION]  WITH CHECK ADD FOREIGN KEY([Name])
REFERENCES [dbo].[ITEM] ([Name])
GO
SELECT ITEM.Name, Title, Detail, ImageUrls, Category FROM ITEM 
INNER JOIN ITEM_TRANSLATION AS TRNS ON ITEM.Name = TRNS.Name
WHERE ITEM.Name = 'Button1' AND LanguageCode = 'TR'
