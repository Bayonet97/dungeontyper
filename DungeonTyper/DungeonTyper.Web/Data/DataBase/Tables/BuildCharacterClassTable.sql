IF EXISTS(SELECT 1 FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = 'GebruikersKampen' AND TABLE_SCHEMA = 'S2Buitendoor') DROP TABLE S2Buitendoor.GebruikersKampen
GO

CREATE TABLE [S2Buitendoor].[Gebruikers] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [Naam]            VARCHAR (50)  NOT NULL,
    [Wachtwoord]      VARCHAR (100) NOT NULL,
    [Email]           VARCHAR (50)  NOT NULL,
    [Administrator]   BIT           CONSTRAINT [DF_Gebruikers_Administrator] DEFAULT ((0)) NOT NULL,
    [UpdateTimeValue] INT           CONSTRAINT [DF_Gebruikers_UpdateTimeValue] DEFAULT ((5)) NOT NULL,
    [SeeAllItems]     BIT           CONSTRAINT [DF_Gebruikers_SeeAllItems] DEFAULT ((0)) NOT NULL,
    [FirstLogin]      BIT           CONSTRAINT [DF_Gebruikers_FirstLogin] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_Gebruikers] PRIMARY KEY CLUSTERED ([Id] ASC)
);