CREATE TABLE [dbo].verse
(
    [testament] VARCHAR(50) NOT NULL, 
    [book] VARCHAR(50) NOT NULL, 
    [chapter] BIGINT NOT NULL, 
    [verse] BIGINT NOT NULL, 
    [text] TEXT NOT NULL
)
