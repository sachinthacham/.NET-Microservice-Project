namespace Mango.Services.EmailConsumer.Messaging
{
    public interface IAzureServiceBusConsumer
    {
        Task Start();
        Task Stop();
      
    }
}
