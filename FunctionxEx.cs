public class FunctionxEx : Exception
{
    // Дополнительное свойство для хранения информации о причине ошибки
    public string Reason { get; }

    public FunctionxEx(string message, string reason) : base(message)
    {
        Reason = reason;
    }
}
