use creditcarddb
GO
CREATE TABLE CreditCardInfo(
    CreditCardInfoId INT PRIMARY KEY IDENTITY(1,1),
    CustomerId INT NOT NULL,
    CardNumber VARCHAR(20) NOT NULL,
    CreditLimit DECIMAL(10, 2) NOT NULL,
    CurrentBalance DECIMAL(10, 2) NOT NULL,
    AvailableBalance DECIMAL(10, 2) NOT NULL,
    ConfigurableInterestRate DECIMAL(5, 2) NOT NULL DEFAULT 25.00,
    ConfigurableMinimumBalancePercentage DECIMAL(5, 2) NOT NULL DEFAULT 5.00,
    BonifiableInterest DECIMAL(10, 2) NOT NULL DEFAULT 0,
    MinimumFee DECIMAL(10, 2) NOT NULL DEFAULT 0,
    PaymentWithInterest DECIMAL(10, 2) NOT NULL DEFAULT 0,
    FOREIGN KEY (CustomerId) REFERENCES Customer(CustomerId) ON DELETE CASCADE
)