public class InpArrayEx : Exception
{
    // Дополнительное свойство для хранения информации о причине ошибки
    public string Reason { get; }

    public InpArrayEx(string message, string reason) : base(message)
    {
        Reason = reason;
    }
}