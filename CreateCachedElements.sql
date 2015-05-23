create table CachedElements (
       Id BIGINT IDENTITY NOT NULL,
       Url NVARCHAR(255) NOT NULL,
       TagName NVARCHAR(255) NOT NULL,
       TagValue NVARCHAR(255) NOT NULL,
       Value NVARCHAR(MAX) NOT NULL,
    )