CREATE TABLE [dbo].verse
(
	[id] INT NOT NULL PRIMARY KEY, 
    [testemant] VARCHAR(50) NOT NULL, 
    [book] VARCHAR(50) NOT NULL, 
    [chapter] BIGINT NOT NULL, 
    [verse] BIGINT NOT NULL, 
    [text] TEXT NOT NULL
)
