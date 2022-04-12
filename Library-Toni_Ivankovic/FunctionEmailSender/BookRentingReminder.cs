using System;
using Library.ToniIvankovic.Contracts.Services;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace FunctionEmailSender
{
    public class BookRentingReminder
    {
        private readonly ILogger _logger;
        private readonly ILibraryNotificationService _service;
        public BookRentingReminder(
            ILibraryNotificationService service,
            ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<BookRentingReminder>();
            _service = service;
        }

        [FunctionName("BookRentingReminder")]
        public async Task Run([TimerTrigger("*/5 * * * * *")] TimerInfo myTimer)
        {
            Console.WriteLine("Hej");
            try
            {
                await _service.SendReturnBookNotification();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Timer trigger function executed with error: {ex.Message}");
                throw;
            }
        }

        [FunctionName("LoggerFunction")]
        public void RunLogging([TimerTrigger("* * * * * *")] TimerInfo myTimer)
        {
            _logger.LogInformation($"{DateTime.UtcNow}");
        }
    }
}
