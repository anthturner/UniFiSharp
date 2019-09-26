using System;

public class UniFiApiException : Exception
{
    public UniFiApiException()
    {
    }

    public UniFiApiException(string message)
        : base(message)
    {
    }

    public UniFiApiException(string message, Exception inner)
        : base(message, inner)
    {
    }
}