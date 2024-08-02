using AutoMapper;
using CreditCardStatement.Application.Database.CreditCardInfo.Commands.CreateCreditCardInfo;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.CommonModel;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCustomerId;
using CreditCardStatement.Application.Database.CreditCardTransaction.CommonCreditCardTransactonModels;
using CreditCardStatement.Application.Database.CreditCardTransaction.Querys.GetCreditTransactionsByCardNumber;
using CreditCardStatement.Application.Database.Customer.CommonModel;
using CreditCardStatement.Application.Database.TransactionType.Querys.GetAllTransactionsType;
using CreditCardStatement.Application.Database.TransactionType.Querys.GetTransactionTypeById;
using CreditCardStatement.Domain.Entities.CreditCardInfo;
using CreditCardStatement.Domain.Entities.CreditCardTransaction;
using CreditCardStatement.Domain.Entities.Customer;
using CreditCardStatement.Domain.Entities.TransactionType;

namespace CreditCardStatement.Application.Configuration
{
    public class MapperProfile: Profile
    {
        public MapperProfile()
        {
            CreateMap<CreditCardInfoEntity, CreateCreditCardInfoModel>().ReverseMap();
            CreateMap<CreditCardInfoEntity, CommonModelCreditCardInfo>().ReverseMap();
            CreateMap<CustomerEntity, CommonCustomerModel>().ReverseMap();
            CreateMap<CreditCardInfoEntity, CreditCardInfoByCustomerIdModel>().ReverseMap();
            CreateMap<CreditCardTransactionEntity, GetCreditCardTransactionsByCardInfoIdModel>().ReverseMap();
            CreateMap<TransactionTypeEntity, GetAllTransactionsTypeModel>().ReverseMap();
            CreateMap<TransactionTypeEntity, GetTransactionTypeByIdModel>().ReverseMap();
            CreateMap<CreditCardTransactionEntity, CommonCreditCardTransactionModel>().ReverseMap();
        }
    }
}
