-- Creating Database Academy
IF NOT EXISTS ( SELECT * FROM sys.databases WHERE name = 'IPCDatabase' )
BEGIN
    CREATE DATABASE IPCDatabase;
END;
GO

-- Use Academy Database
USE IPCDatabase;
GO
IF OBJECT_ID(N'dbo.Roles', N'U') IS NULL
    CREATE TABLE Roles (
        ID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY
            DEFAULT NEWID(),
        RoleName NVARCHAR(50) NOT NULL,
    );
GO

IF OBJECT_ID(N'dbo.Users', N'U') IS NULL
    CREATE TABLE Users (
        ID UNIQUEIDENTIFIER NOT NULL PRIMARY KEY
            DEFAULT NEWID(),
        FullName NVARCHAR(50) NOT NULL,
        Age SMALLINT NOT NULL,
        Email NVARCHAR(320) NOT NULL
            UNIQUE,
        PW NVARCHAR(MAX) NOT NULL,
        Img VARBINARY(MAX) NULL,
        RoleID UNIQUEIDENTIFIER
            FOREIGN KEY REFERENCES dbo.Roles ( ID ) NOT NULL
    );
GO
CREATE OR ALTER PROCEDURE sp_InsertUser
    @UserID AS UNIQUEIDENTIFIER,
    @FullName AS NVARCHAR(50),
    @Age AS SMALLINT,
    @Email AS NVARCHAR(320),
    @PW AS NVARCHAR(MAX),
    @Img AS VARBINARY(MAX),
    @RoleID AS UNIQUEIDENTIFIER
AS
BEGIN
    INSERT INTO dbo.Users
    (
        ID,
        FullName,
        Age,
        Email,
        PW,
        Img,
        RoleID
    )
    VALUES
    (   @UserID,   -- ID - uniqueidentifier
        @FullName, -- FullName - nvarchar(50)
        @Age,      -- Age - smallint
        @Email,    -- Email - nvarchar(320)
        @PW,       -- PW - nvarchar(max)
        @Img,      -- Img - varbinary(max)
        @RoleID    -- RoleID - uniqueidentifier
        );
END;
GO
