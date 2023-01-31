CREATE TABLE [dbo].[ProductTable] (
    [Product ID]    INT          NOT NULL,
    [Product Name]  VARCHAR (50) NOT NULL,
    [Amount(kg)]   FLOAT (53)   NULL,
    [Price(CAD)/kg] VARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Product ID] ASC)
);

