using AARProject.Application.Common.Interfaces;

namespace AARProject.Infrastructure.Services;

public class DateTimeService : IDateTime
{
    public DateTime Now => DateTime.Now;
}
