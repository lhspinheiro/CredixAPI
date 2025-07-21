using CredixAPI.Communication.Event;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace CredixAPI.Infrastructure.Consumer.Bus;

public class LoansEventConsumer : IConsumer<LoansEvent>
{
    
    private readonly ILogger<LoansEventConsumer> _logger;

    public LoansEventConsumer(ILogger<LoansEventConsumer> logger)
    {
        _logger = logger;
    }


    public async Task Consume(ConsumeContext<LoansEvent> context)
    {
        var message =  context.Message;
        
        _logger.LogInformation("LoanEvent received: {@Event}", message);
    }
}