namespace FormulaAirLine.Services
{
    public interface IMassageProducer
    {
        void SendingMessage<T>(T message);
    }
}