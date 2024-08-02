using AutoMapper;
using CreditCardStatement.Domain.Entities.CreditCardInfo;

namespace CreditCardStatement.Application.Database.CreditCardInfo.Commands.CreateCreditCardInfo
{
    public class CreateCreditCardInfoCommand: ICreateCreditCardInfoCommand
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public CreateCreditCardInfoCommand(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CreateCreditCardInfoModel> Execute(CreateCreditCardInfoModel model)
        {
            var entity = _mapper.Map<CreditCardInfoEntity>(model);
            var result = _databaseService.CreditCardInfo.AddAsync(entity);
            var resultSave = await _databaseService.SaveAsync();
            if (resultSave)
            {
                model.CreditCardInfoId = result.Result.Entity.CreditCardInfoId;
            }
            return model;
        }
    }
}
