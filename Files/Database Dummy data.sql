USE IPCDatabase;
-- Dummy data section
INSERT INTO dbo.Roles
(
    RoleName
)
VALUES
( N'Admin' -- RoleName - nvarchar(50)
    ),
( N'User' -- RoleName - nvarchar(50)
);

DECLARE @AdminRoleId UNIQUEIDENTIFIER;
SELECT @AdminRoleId = ID
FROM dbo.Roles
WHERE RoleName = N'Admin';

DECLARE @UserRoleId UNIQUEIDENTIFIER;
SELECT @UserRoleId = ID
FROM dbo.Roles
WHERE RoleName = N'User';

DECLARE @UID UNIQUEIDENTIFIER;
SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Mahmoud Yasser',   -- nvarchar(50)
                          @Age = 24,                   -- smallint
                          @Email = N'mahmoudyasser@admin.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @AdminRoleId;           -- uniqueidentifier
SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Kareem Mohamed',   -- nvarchar(50)
                          @Age = 21,                   -- smallint
                          @Email = N'kareemmohamed@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier
SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Mohamed Osama',   -- nvarchar(50)
                          @Age = 22,                   -- smallint
                          @Email = N'mohamedosama@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier
SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Mostafa Ali',   -- nvarchar(50)
                          @Age = 23,                   -- smallint
                          @Email = N'mostafaali@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier
SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Wael Gomaa',   -- nvarchar(50)
                          @Age = 21,                   -- smallint
                          @Email = N'waelgomaa@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier

SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Ahmed Tarek',   -- nvarchar(50)
                          @Age = 18,                   -- smallint
                          @Email = N'ahmedtarek@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier

SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Moaz Tamer',   -- nvarchar(50)
                          @Age = 19,                   -- smallint
                          @Email = N'moaztamer@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier

SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Maged Abdo',   -- nvarchar(50)
                          @Age = 25,                   -- smallint
                          @Email = N'magedabdo@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier
SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Abdelrahman Ali',   -- nvarchar(50)
                          @Age = 25,                   -- smallint
                          @Email = N'abdelrahmanali@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier

SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'MahmoudMohamed',   -- nvarchar(50)
                          @Age = 25,                   -- smallint
                          @Email = N'mahmoudmohamed@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier

SET @UID = NEWID();

EXECUTE dbo.sp_InsertUser @UserID = @UID,              -- uniqueidentifier
                          @FullName = N'Zyad Ahmed',   -- nvarchar(50)
                          @Age = 25,                   -- smallint
                          @Email = N'zyadahmed@user.com', -- nvarchar(320)
                          @PW = N'12345',              -- nvarchar(max)
                          @Img = NULL,                 -- varbinary(max)
                          @RoleID = @UserRoleId;           -- uniqueidentifier
