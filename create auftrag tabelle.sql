CREATE TABLE [dbo].[Auftrag] (
    [auftragsNummer]     INT           IDENTITY (1, 1) NOT NULL,
    [erstelldatum]       DATETIME      NULL,
    [titel]              NVARCHAR (50) NOT NULL,
    [beschreibung]       NVARCHAR (50) NULL,
    [ort]                NVARCHAR (50) NULL,
    [ausschreibungsende] DATETIME      NULL,
    [userid]             INT           NOT NULL,
    [ausgeschrieben]     BIT           DEFAULT ((0)) NOT NULL,
    CONSTRAINT [PK_Auftrag] PRIMARY KEY CLUSTERED ([auftragsNummer] ASC),
    CONSTRAINT [FK_Auftrag_ToAuftraggeber] FOREIGN KEY ([userid]) REFERENCES [dbo].[Auftraggeber] ([userid])
);

