USE [PruebTalycapGlobal]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 31/08/2023 03:57:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [int] IDENTITY(1,1) NOT NULL,
	[Nombres] [nvarchar](20) NOT NULL,
	[Apellidos] [nvarchar](20) NOT NULL,
	[Celular] [int] NOT NULL,
	[Correo] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[IdCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogisticaMaritima]    Script Date: 31/08/2023 03:57:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogisticaMaritima](
	[NumeroGuia] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[TipoProducto] [nvarchar](20) NOT NULL,
	[CantidadProducto] [int] NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[FechaEntrega] [datetime2](7) NOT NULL,
	[PrecioEnvio] [float] NOT NULL,
	[NumeroFlota] [nvarchar](max) NOT NULL,
	[Descuento] [float] NOT NULL,
	[PrecioEnvioNormal] [float] NOT NULL,
 CONSTRAINT [PK_LogisticaMaritima] PRIMARY KEY CLUSTERED 
(
	[NumeroGuia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[LogisticaTerrestre]    Script Date: 31/08/2023 03:57:26 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LogisticaTerrestre](
	[NumeroGuia] [int] NOT NULL,
	[IdCliente] [int] NOT NULL,
	[TipoProducto] [nvarchar](20) NOT NULL,
	[CantidadProducto] [int] NOT NULL,
	[FechaRegistro] [datetime2](7) NOT NULL,
	[FechaEntrega] [datetime2](7) NOT NULL,
	[PrecioEnvio] [float] NOT NULL,
	[PlacaVehiculo] [nvarchar](max) NOT NULL,
	[Descuento] [float] NOT NULL,
	[PrecioEnvioNormal] [float] NOT NULL,
 CONSTRAINT [PK_LogisticaTerrestre] PRIMARY KEY CLUSTERED 
(
	[NumeroGuia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[LogisticaMaritima] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Descuento]
GO
ALTER TABLE [dbo].[LogisticaMaritima] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [PrecioEnvioNormal]
GO
ALTER TABLE [dbo].[LogisticaTerrestre] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [Descuento]
GO
ALTER TABLE [dbo].[LogisticaTerrestre] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [PrecioEnvioNormal]
GO
