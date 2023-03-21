using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace MinimalAPI.Shared.Communication.Response;

public class ErrorResponse
{
    public List<string> Messages { get; set; }
    public HttpStatusCode StatusCode { get; set; }
    public string Title { get; set; }

    public ErrorResponse(string message)
    {
        Messages = new List<string> {
            message
        };
    }

    public ErrorResponse(List<string> messages, string title, HttpStatusCode statusCode)
    {
        Messages = messages;
        StatusCode = statusCode;
        Title = title;
    }

    public ErrorResponse(string message, HttpStatusCode statusCode)
    {

        Messages = new List<string> {
            message
        };
        StatusCode = statusCode;
    }
}
