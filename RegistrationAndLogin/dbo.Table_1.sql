CREATE TABLE [dbo].[LoginTable]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Email] NCHAR(10) NOT NULL, 
    [Password] NCHAR(10) NOT NULL, 
    [Role] BIT NULL DEFAULT 0, 
    [Username] NCHAR(10) NULL
)
