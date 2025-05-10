using Microsoft.Extensions.Logging;
using ParkingPlatform.Application.Interfaces;

namespace ParkingPlatform.Application.Services;

public class DebugEmailSender: IEmailSender
{
    private readonly ILogger<DebugEmailSender> _logger;

    public DebugEmailSender(ILogger<DebugEmailSender> logger)
    {
        _logger = logger;
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        _logger.LogInformation($"Sending email to: {email}");
        _logger.LogInformation($"Subject: {subject}");
        _logger.LogInformation($"Message: {message}");
        
        return Task.CompletedTask;
    }
}