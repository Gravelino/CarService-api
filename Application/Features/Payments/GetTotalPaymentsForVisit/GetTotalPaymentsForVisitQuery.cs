using MediatR;

namespace Application.Features.Payments.GetTotalPaymentsForVisit;

public class GetTotalPaymentsForVisitQuery : IRequest<decimal>
{
    public int VisitId { get; set; }
}