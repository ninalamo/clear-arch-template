using MediatR;
using static Core.Application.PositionsDTO;

namespace Core.Application
{
    public class GetPositionQuery : IRequest<GetPositionResult>
    {
    }
}