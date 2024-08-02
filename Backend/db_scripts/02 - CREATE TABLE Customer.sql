use creditcarddb
GO
CREATE TABLE Customer(
    CustomerId INT PRIMARY KEY IDENTITY(1,1),
    CustomerName VARCHAR(150) NOT NULL,
)