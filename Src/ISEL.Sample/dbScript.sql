USE [iselsample]
GO
/****** Object:  User [iselsample]    Script Date: 09/14/2010 02:22:32 ******/
CREATE USER [iselsample] FOR LOGIN [iselsample] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[Pessoa]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Pessoa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Antiguidade] [varchar](100) NULL,
	[LimiteCartaoCredito] [numeric](18, 3) NULL,
	[Numero] [int] NULL,
	[DtAdmissao] [datetime] NULL,
	[Nome] [varchar](100) NULL,
	[DtNascimento] [datetime] NULL,
	[NIF] [varchar](9) NULL,
	[LitrosCombustivel] [int] NULL,
	[CreditoMaximo] [numeric](18, 3) NULL,
        [LimiteAprovacao] [numeric](18, 3) NULL,
 CONSTRAINT [PK_Pessoa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LP]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LP](
	[ID] [int] NOT NULL,
	[DtEdicao] [datetime] NOT NULL,
 CONSTRAINT [PK_LP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[EP]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EP](
	[ID] [int] NOT NULL,
	[DtLancamento] [datetime] NOT NULL,
 CONSTRAINT [PK_EP] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Editor]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Editor](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](50) NOT NULL,
	[Pais] [varchar](3) NOT NULL,
 CONSTRAINT [PK_Editor] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Loja]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Loja](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
 CONSTRAINT [PK_Loja] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Interprete]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Interprete](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NULL,
	[Nacionalidade] [char](3) NULL,
 CONSTRAINT [PK_Interprete] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Faixa]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Faixa](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Nome] [varchar](100) NOT NULL,
	[Duracao] [varchar](5) NOT NULL,
	[Genero] [varchar](75) NOT NULL,
	[EPID] [int] NULL,
	[LPID] [int] NULL,
 CONSTRAINT [PK_Faixa] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Album]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Album](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Titulo] [varchar](100) NOT NULL,
	[EditorID] [int] NOT NULL,
	[InterpreteID] [int] NOT NULL,
 CONSTRAINT [PK_Album] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LojaAlbum]    Script Date: 09/14/2010 02:22:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LojaAlbum](
	[LojaID] [int] NOT NULL,
	[AlbumID] [int] NOT NULL,
 CONSTRAINT [PK_LojaAlbum] PRIMARY KEY CLUSTERED 
(
	[LojaID] ASC,
	[AlbumID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  ForeignKey [FK_Album_Editor]    Script Date: 09/14/2010 02:22:32 ******/
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Editor] FOREIGN KEY([EditorID])
REFERENCES [dbo].[Editor] ([ID])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Editor]
GO
/****** Object:  ForeignKey [FK_Album_Interprete]    Script Date: 09/14/2010 02:22:32 ******/
ALTER TABLE [dbo].[Album]  WITH CHECK ADD  CONSTRAINT [FK_Album_Interprete] FOREIGN KEY([InterpreteID])
REFERENCES [dbo].[Interprete] ([ID])
GO
ALTER TABLE [dbo].[Album] CHECK CONSTRAINT [FK_Album_Interprete]
GO
/****** Object:  ForeignKey [FK_Faixa_EP]    Script Date: 09/14/2010 02:22:32 ******/
ALTER TABLE [dbo].[Faixa]  WITH CHECK ADD  CONSTRAINT [FK_Faixa_EP] FOREIGN KEY([EPID])
REFERENCES [dbo].[EP] ([ID])
GO
ALTER TABLE [dbo].[Faixa] CHECK CONSTRAINT [FK_Faixa_EP]
GO
/****** Object:  ForeignKey [FK_Faixa_LP]    Script Date: 09/14/2010 02:22:32 ******/
ALTER TABLE [dbo].[Faixa]  WITH CHECK ADD  CONSTRAINT [FK_Faixa_LP] FOREIGN KEY([LPID])
REFERENCES [dbo].[LP] ([ID])
GO
ALTER TABLE [dbo].[Faixa] CHECK CONSTRAINT [FK_Faixa_LP]
GO
/****** Object:  ForeignKey [FK_LojaAlbum_Album]    Script Date: 09/14/2010 02:22:32 ******/
ALTER TABLE [dbo].[LojaAlbum]  WITH CHECK ADD  CONSTRAINT [FK_LojaAlbum_Album] FOREIGN KEY([AlbumID])
REFERENCES [dbo].[Album] ([ID])
GO
ALTER TABLE [dbo].[LojaAlbum] CHECK CONSTRAINT [FK_LojaAlbum_Album]
GO
/****** Object:  ForeignKey [FK_LojaAlbum_Loja]    Script Date: 09/14/2010 02:22:32 ******/
ALTER TABLE [dbo].[LojaAlbum]  WITH CHECK ADD  CONSTRAINT [FK_LojaAlbum_Loja] FOREIGN KEY([LojaID])
REFERENCES [dbo].[Loja] ([ID])
GO
ALTER TABLE [dbo].[LojaAlbum] CHECK CONSTRAINT [FK_LojaAlbum_Loja]
GO
