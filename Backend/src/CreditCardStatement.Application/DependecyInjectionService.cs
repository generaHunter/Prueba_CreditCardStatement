using AutoMapper;
using CreditCardStatement.Application.Configuration;
using CreditCardStatement.Application.Database.CreditCardInfo.Commands.CreateCreditCardInfo;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCreditInfoId;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCustomerId;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.ValidateCreditCardNumber;
using CreditCardStatement.Application.Database.CreditCardTransaction.Commands.CreateCreditCardTransaction;
using CreditCardStatement.Application.Database.CreditCardTransaction.CommonCreditCardTransactonModels;
using CreditCardStatement.Application.Database.CreditCardTransaction.Querys.GetCreditTransactionsByCardInfoId;
using CreditCardStatement.Application.Database.CreditCardTransaction.Querys.GetCreditTransactionsByCardNumber;
using CreditCardStatement.Application.Database.Customer.Commands.CreateCustomer;
using CreditCardStatement.Application.Database.Customer.CommonModel;
using CreditCardStatement.Application.Database.Customer.Querys.GetAllCustomers;
using CreditCardStatement.Application.Database.Customer.Querys.GetCustomerById;
using CreditCardStatement.Application.Database.TransactionType.Querys.GetAllTransactionsType;
using CreditCardStatement.Application.Database.TransactionType.Querys.GetTransactionTypeById;
using CreditCardStatement.Application.Validators.CreditCardInfo;
using CreditCardStatement.Application.Validators.CreditCardTransaction;
using CreditCardStatement.Application.Validators.Customer;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace CreditCardStatement.Application
{
    public static class DependecyInjectionService
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var mapper = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperProfile());
            });

            services.AddSingleton(mapper.CreateMapper());

            #region Customer
            services.AddTransient<ICreateCustomerCommand, CreateCustomerCommand>();
            services.AddTransient<IGetAllCustomerQuery, GetAllCustomerQuery>();
            services.AddTransient<IGetCustomerByIdQuery, GetCustomerByIdQuery>();
            #endregion

            #region CreditCardTransactions
            services.AddTransient<ICreateCreditCardTransaction, CreateCreditCardTransaction>();
            services.AddTransient<IGetCreditCardTransactionsByCardInfoId, GetCreditCardTransactionsByCardInfoId>();
            #endregion

            #region TransactionType
            services.AddTransient<IGetAllTransactionsType, GetAllTransactionsType>();
            services.AddTransient<IGetTransactionTypeById, GetTransactionTypeById>();
            #endregion

            #region CreditCardInfo
            services.AddTransient<ICreateCreditCardInfoCommand, CreateCreditCardInfoCommand>();
            services.AddTransient<ICreditCardInfoByCustomerId, CreditCardInfoByCustomerId>();
            services.AddTransient<IGetCreditCardInfoByCreditInfoId, GetCreditCardInfoByCreditInfoId>();
            services.AddTransient<IValidateCreditCardNumber, ValidateCreditCardNumber>();
            #endregion

            #region Customer Validations
            services.AddScoped<IValidator<CommonCustomerModel>, CreateCustomerValidator>();
            #endregion

            #region Credit Card Info Validations
            services.AddScoped<IValidator<CreateCreditCardInfoModel>, CreateCreditCardInfoValidator>();
            #endregion

            #region Credit Card Transactions
            services.AddScoped<IValidator<CommonCreditCardTransactionModel>, CreateCreditCardTransactionValidator>();
            #endregion


            return services;
        }
    }
}
