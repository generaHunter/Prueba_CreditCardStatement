using AutoMapper;
using CreditCardStatement.Application.Database.CreditCardInfo.Querys.CommonModel;

namespace CreditCardStatement.Application.Database.CreditCardInfo.Querys.GetCreditCardInfoByCreditInfoId
{
    public class GetCreditCardInfoByCreditInfoId: IGetCreditCardInfoByCreditInfoId
    {
        private readonly IDatabaseService _databaseService;
        private readonly IMapper _mapper;

        public GetCreditCardInfoByCreditInfoId(IDatabaseService databaseService, IMapper mapper)
        {
            _databaseService = databaseService;
            _mapper = mapper;
        }

        public async Task<CommonModelCreditCardInfo> Execute(int CreditCardInfoId)
        {
            var result = await _databaseService.CreditCardInfo.FindAsync(CreditCardInfoId);
            return _mapper.Map<CommonModelCreditCardInfo>(result);
        }
    }
}
