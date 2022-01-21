CREATE TABLE [dbo].[Medico]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome] [varchar](255) NOT NULL,
	[DataCriacao] [datetime] NULL,
	[DataAtualizacao] [datetime] NULL
);

CREATE TABLE [dbo].[Paciente]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome] [varchar](255) NOT NULL,
	[DataCriacao] [datetime] NULL,
	[DataAtualizacao] [datetime] NULL
);

CREATE TABLE [dbo].[Consultorio]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome] [varchar](255) NOT NULL,
	[DataCriacao] [datetime] NULL,
	[DataAtualizacao] [datetime] NULL
);

CREATE TABLE [dbo].[HorarioAgenda]
(
	[Id] INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
	[Nome] [varchar](255) NOT NULL,
	[DataCriacao] [datetime] NULL,
	[DataAtualizacao] [datetime] NULL,
	[DataHoraMarcada] [datetime] NOT NULL,
	[IdMedico] [int]  NOT NULL,
	[IdPaciente] [int]  NOT NULL,
	[IdConsultorio] [int]  NOT NULL,
    CONSTRAINT FK_IdMedico FOREIGN KEY (IdMedico) REFERENCES Medico (Id),
    CONSTRAINT FK_IdPaciente FOREIGN KEY (IdPaciente) REFERENCES Paciente (Id),
    CONSTRAINT FK_IdConsultorio FOREIGN KEY (IdConsultorio) REFERENCES Consultorio (Id)
);