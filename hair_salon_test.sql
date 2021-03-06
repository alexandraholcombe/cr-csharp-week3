USE [hair_salon_test]
GO
/****** Object:  Table [dbo].[clients]    Script Date: 2/24/2017 6:57:35 PM ******/
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
/****** Object:  Table [dbo].[stylists]    Script Date: 2/24/2017 6:57:35 PM ******/
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

INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (3008, N'Rebecca', 7006)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (3009, N'Julia', 7006)
INSERT [dbo].[clients] ([id], [name], [stylist_id]) VALUES (3010, N'Claire', 7006)
SET IDENTITY_INSERT [dbo].[clients] OFF
