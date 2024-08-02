use creditcarddb
GO
CREATE TABLE CreditCardTransaction(
    CreditCardTransactionId INT PRIMARY KEY IDENTITY(1,1),
    CreditCardInfoId INT NOT NULL,
    TransactionTypeId INT NOT NULL,
    TransactionDate DATETIME NOT NULL,
    Amount DECIMAL(10, 2) NOT NULL,
    [Description] VARCHAR(150) NOT NULL,
    FOREIGN KEY (CreditCardInfoId) REFERENCES CreditCardInfo(CreditCardInfoId) ON DELETE CASCADE,
    FOREIGN KEY (TransactionTypeId) REFERENCES TransactionType(TransactionTypeId) ON DELETE CASCADE
)