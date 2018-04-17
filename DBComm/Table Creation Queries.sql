-- create scenario table
/*

CREATE TABLE [dbo].[Scenario] (
    [ID]          int           NOT NULL IDENTITY(1,1),
    [Name]        VARCHAR (50)  NOT NULL,
    [Description] VARCHAR (200) NULL,
    CONSTRAINT [PK_Scenario] PRIMARY KEY CLUSTERED ([ID] ASC));

*/


-- create stage table
/*

CREATE TABLE [dbo].[Stage] (
    [ID]          int           NOT NULL IDENTITY(1,1),
    [Name]   	VARCHAR (50)  NOT NULL,
	[Description]	VARCHAR (200) NULL,
	[ScenarioID]       int           NULL,    
    [AudioFilePath]    VARCHAR (50)  NULL,
    [ImageFilePath]    VARCHAR (50)  NULL,
	[Answer1ID]			int				NULL,
	[Ans1NextStagID]		int				NULL,	
	[Answer2ID]			int				NULL,
	[Ans2NextStagID]		int				NULL,
	[Start]			bit			NULL,
    CONSTRAINT [PK_Stage] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Stage_Scenario] FOREIGN KEY ([ScenarioID]) REFERENCES [dbo].[Scenario] ([ID]),
	CONSTRAINT [FK_Stage_Answer1ID] FOREIGN KEY ([Answer1ID]) REFERENCES [dbo].[Answer] ([ID]),
	CONSTRAINT [FK_Stage_Ans1NextStagID] FOREIGN KEY ([Ans1NextStagID]) REFERENCES [dbo].[Stage] ([ID]),
	CONSTRAINT [FK_Stage_Answer2ID] FOREIGN KEY ([Answer2ID]) REFERENCES [dbo].[Answer] ([ID]),
	CONSTRAINT [FK_Stage_Ans2NextStagID] FOREIGN KEY ([Ans2NextStagID]) REFERENCES [dbo].[Stage] ([ID]));

*/


-- create answer table
/*

CREATE TABLE [dbo].[Answer] (
    [ID]          int           NOT NULL IDENTITY(1,1),
    [Name]        VARCHAR (50)  NOT NULL,
	[Description] VARCHAR (200) NULL,
    CONSTRAINT [PK_Answer] PRIMARY KEY CLUSTERED ([ID] ASC));
	
	
	
CREATE TABLE [dbo].[PieceRelations] (
    [ScenRelID]          int			NOT NULL,
    [StagRelID]			 int			NULL,
	[AnsRelID]			 int			NULL,
	[NextStagRelID]		 int			NULL,	
    CONSTRAINT [FK_PieceRelations_Scenario] FOREIGN KEY ([ScenRelID]) REFERENCES [dbo].[Scenario] ([ID]),
	CONSTRAINT [FK_PieceRelations_Stage] FOREIGN KEY ([StagRelID]) REFERENCES [dbo].[Stage] ([ID]),
	CONSTRAINT [FK_PieceRelations_Answer] FOREIGN KEY ([AnsRelID]) REFERENCES [dbo].[Answer] ([ID]);