create table CachedElements (
       Id BIGINT IDENTITY NOT NULL,
       Url NVARCHAR(255) NOT NULL,
       TagName NVARCHAR(255) NOT NULL,
       TagAttributeName NVARCHAR(255) NOT NULL,
       TagAttributeValue NVARCHAR(255) NOT NULL,
       TagValue NVARCHAR(MAX) NOT NULL,
    )