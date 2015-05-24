create table CachedHtmlElements (
       Id BIGINT IDENTITY NOT NULL,
       Url NVARCHAR(255) NOT NULL,
       HtmlElementName NVARCHAR(255) NOT NULL,
       HtmlElementAttributeName NVARCHAR(255) NOT NULL,
       HtmlElementAttributeValue NVARCHAR(255) NOT NULL,
       HtmlElementInnerHtml NVARCHAR(MAX) NULL,
       LastRefreshDate DATETIME NULL,
    )
    