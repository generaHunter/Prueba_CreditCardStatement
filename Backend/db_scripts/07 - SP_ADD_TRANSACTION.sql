use creditcarddb
GO

IF OBJECT_ID('dbo.SP_ADD_TRANSACTION', 'P') IS NOT NULL
    DROP PROCEDURE dbo.SP_ADD_TRANSACTION;
GO


CREATE PROCEDURE SP_ADD_TRANSACTION
    @transactionType INT,
    @amount DECIMAL(10, 2),
    @creditCardNumber VARCHAR(20) = '',
    @transactionDate DATETIME = NULL,
    @creditCardInfoId INT = 0,
    @description VARCHAR(150) = ''
/*
    EXEC SP_ADD_TRANSACTION @transactionType = 1,
    @amount = 25.30,
    @creditCardNumber = '',
    @transactionDate = NULL,
    @creditCardInfoId = 1,
    @description = 'Compra de articulo'
*/
AS
BEGIN



    --Inicio: Declaracion de variables
        DECLARE @creditCardTransactionId INT
        DECLARE @currentBalance DECIMAL(10, 2)
        DECLARE @availableBalance DECIMAL(10, 2)
        DECLARE @configurableInterestRate DECIMAL(5, 2)
        DECLARE @configurableMinimumBalancePercentage DECIMAL(5, 2)
        DECLARE @bonifiableInterest DECIMAL(10, 2)
        DECLARE @minimumFee DECIMAL(10, 2)
        DECLARE @paymentWithInterest DECIMAL(10, 2)
        DECLARE @creditLimit DECIMAL(10, 2)


        DECLARE @newCurrentBalance DECIMAL(10, 2)
        DECLARE @newAvailableBalance DECIMAL(10, 2)
        DECLARE @newBonifiableInterest DECIMAL(10, 2)
        DECLARE @newMinimumFee DECIMAL(10, 2)
        DECLARE @newPaymentWithInterest DECIMAL(10, 2)

        DECLARE @SUCCESS INT
        DECLARE @MESSAGE VARCHAR(100)

    --Fin: Declaracion de variables

    --Inicio: Seteo inicial de variables
        IF @transactionDate IS NULL
        BEGIN
            SET @transactionDate = GETDATE();
        END

        SELECT @creditCardTransactionId = 0
        SET @SUCCESS = -1
        SET @MESSAGE = ''
    --Fin: Seteo inicial de variables


        IF EXISTS (SELECT 1 FROM CreditCardInfo WHERE CreditCardInfoId = @creditCardInfoId)
        BEGIN
            -- El registro existe
            SELECT
                @currentBalance = CurrentBalance,
                @availableBalance = AvailableBalance,
                @configurableInterestRate = ConfigurableInterestRate,
                @configurableMinimumBalancePercentage = ConfigurableMinimumBalancePercentage,
                @bonifiableInterest = BonifiableInterest,
                @minimumFee = MinimumFee,
                @paymentWithInterest = PaymentWithInterest,
                @creditLimit = CreditLimit
            FROM
                CreditCardInfo
            WHERE
                CreditCardInfoId = @creditCardInfoId

            IF @transactionType = 1 --Compra
            BEGIN
                IF @availableBalance < @amount
                BEGIN
                    SET @MESSAGE = 'No se registro la transaccion, saldo disponible insuficiente'
                    SET @SUCCESS = -1
                    SELECT @SUCCESS as SUCCESS, @creditCardTransactionId as creditCardTransactionId, @MESSAGE as [MESSAGE]
                    RETURN
                END
            END
            ELSE IF @transactionType = 2 --Pago
            BEGIN
                IF @currentBalance < @amount
                BEGIN
                    SET @MESSAGE = 'No se registro la transaccion, pago mayor al saldo actual'
                    SET @SUCCESS = -1
                    SELECT @SUCCESS as SUCCESS, @creditCardTransactionId as creditCardTransactionId, @MESSAGE as [MESSAGE]
                    RETURN
                END
            END
                
        END
        ELSE
        BEGIN
            -- El registro no existe
            SET @MESSAGE = 'No se encontro el registro de la tarjeta de credito'
            SELECT @SUCCESS as SUCCESS, @creditCardTransactionId as creditCardTransactionId, @MESSAGE as [MESSAGE]
            RETURN
        END


   
    --Inicio: Se registra la transaction
    INSERT INTO CreditCardTransaction
    (CreditCardInfoId,TransactionTypeId,TransactionDate,Amount, Description)
    VALUES
    (@creditCardInfoId, @transactionType, @transactionDate, @amount, @description)

    SELECT @creditCardTransactionId = SCOPE_IDENTITY()
    --Fin: Se registra la transaction

    IF @creditCardTransactionId > 0
    BEGIN
        IF @transactionType = 1 --Compra
        BEGIN
            --Se calcula el saldo disponible
            SET @newAvailableBalance = @availableBalance - @amount
            --SELECT '@newAvailableBalance', @newAvailableBalance

            --Se calcula el saldo actual
            SET @newCurrentBalance = @currentBalance + @amount
            --SELECT '@newCurrentBalance', @newCurrentBalance

            --Se calcula Cuota Mínima a Pagar
            SET @newMinimumFee = ROUND((@newCurrentBalance * @configurableMinimumBalancePercentage) / 100, 2)
            --SELECT '@newMinimumFee', @newMinimumFee

            --Se calcula Interés Bonificable
            SET @newBonifiableInterest = ROUND((@newCurrentBalance * @configurableInterestRate) / 100, 2)
            --SELECT '@newBonifiableInterest', @newBonifiableInterest

            --Se calcula Monto total de Contado con Intereses:
            SET @newPaymentWithInterest = @newCurrentBalance + @newBonifiableInterest
            --SELECT '@newPaymentWithInterest', @newPaymentWithInterest

            UPDATE
                CreditCardInfo
            SET
                CurrentBalance = @newCurrentBalance,
                AvailableBalance = @newAvailableBalance,
                MinimumFee = @newMinimumFee,
                BonifiableInterest = @newBonifiableInterest,
                PaymentWithInterest = @newPaymentWithInterest
            WHERE
                CreditCardInfoId = @creditCardInfoId
        END
        ELSE IF @transactionType = 2 --Pago
        BEGIN
            --Se calcula el saldo disponible
            SET @newAvailableBalance = @availableBalance + @amount

            --Se calcula el saldo actual
            SET @newCurrentBalance = @currentBalance - @amount

            --Se calcula Cuota Mínima a Pagar
            SET @newMinimumFee = ROUND((@newCurrentBalance * @configurableMinimumBalancePercentage) / 100, 2)

            --Se calcula Interés Bonificable
            SET @newBonifiableInterest = ROUND((@newCurrentBalance * @configurableInterestRate) / 100, 2)

            --Se calcula Monto total de Contado con Intereses:
            SET @newPaymentWithInterest = @newCurrentBalance + @newBonifiableInterest

            UPDATE
                CreditCardInfo
            SET
                CurrentBalance = @newCurrentBalance,
                AvailableBalance = @newAvailableBalance,
                MinimumFee = @newMinimumFee,
                BonifiableInterest = @newBonifiableInterest,
                PaymentWithInterest = @newPaymentWithInterest
            WHERE
                CreditCardInfoId = @creditCardInfoId
        
        END
        SET @MESSAGE = 'Se registro correctamente la transaccion'
        SET @SUCCESS = 1
        SELECT @SUCCESS as SUCCESS, @creditCardTransactionId as creditCardTransactionId, @MESSAGE as [MESSAGE]
    END
    ELSE
    BEGIN
      SET @MESSAGE = 'No se registro la transaccion'
      SELECT @SUCCESS as SUCCESS, @creditCardTransactionId as creditCardTransactionId, @MESSAGE as [MESSAGE]
      RETURN
    END


END