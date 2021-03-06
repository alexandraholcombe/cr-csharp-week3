USE [hair_salon]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 2/24/2017 6:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[clients](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL,
	[stylist_id] [int] NULL
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[stylists]    Script Date: 2/24/2017 6:56:53 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[stylists](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](255) NULL
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[clients] ON 

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (2, N'Abigail', 2)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (3, N'Jenny', 3)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (4, N'Emily', 1)
SET IDENTITY_INSERT [dbo].[clients] OFF
SET IDENTITY_INSERT [dbo].[stylists] ON 

INSERT [dbo].[stylists] ([id], [name]) VALUES (1, N'Rebecca')
INSERT [dbo].[stylists] ([id], [name]) VALUES (2, N'Jean')
INSERT [dbo].[stylists] ([id], [name]) VALUES (3, N'Elizabeth')
SET IDENTITY_INSERT [dbo].[stylists] OFF
