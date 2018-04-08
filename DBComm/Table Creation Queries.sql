-- create scenario table
/*

CREATE TABLE [dbo].[Scenario] (
    [ID]          int           NOT NULL IDENTITY(1,1),
    [Name]        VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (MAX) NULL,
    CONSTRAINT [PK_Scenario] PRIMARY KEY CLUSTERED ([ID] ASC));

*/


-- create stage table
/*

CREATE TABLE [dbo].[Stage] (
    [ID]          int           NOT NULL IDENTITY(1,1),
    [Name]   	VARCHAR (50)  NOT NULL,
	[Description]	VARCHAR (MAX) NULL,
	[ScenarioID]       int           NULL,    
    [AudioFilePath]    VARCHAR (50)  NULL,
    [ImageFilePath]    VARCHAR (50)  NULL,
    CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Stage_Scenario] FOREIGN KEY ([ScenarioID]) REFERENCES [dbo].[Scenario] ([ID]) ON DELETE CASCADE);

*/


-- create answer table
/*

CREATE TABLE [dbo].[Answer] (
    [ID]          int           NOT NULL IDENTITY(1,1),
    [Name]        VARCHAR (50)  NOT NULL,
	[Description] VARCHAR (MAX) NULL,
	[StageID]           int           NULL,
    [NextStageID]       int           NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Answer_Stage] FOREIGN KEY ([StageID]) REFERENCES [dbo].[Stage] ([ID]) ON DELETE CASCADE);

*/