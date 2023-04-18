public class FillWithRndEx : Exception
{
    // Дополнительное свойство для хранения информации о причине ошибки
    public string Reason { get; }

    public FillWithRndEx(string message, string reason) : base(message)
    {
        Reason = reason;
    }

}