CREATE TABLE todos(
Id NVARCHAR(100) NOT NULL PRIMARY KEY,
Title NVARCHAR(100) NOT NULL,
Description NVARCHAR(200) NOT NULL,
DueBy DATETIME NOT NULL,
Completed BIT NOT NULL DEFAULT(0))