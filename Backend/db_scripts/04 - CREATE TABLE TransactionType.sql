use creditcarddb
GO
CREATE TABLE TransactionType(
    TransactionTypeId INT PRIMARY KEY IDENTITY(1,1),
    TransactionTypeName VARCHAR(10) NOT NULL
)