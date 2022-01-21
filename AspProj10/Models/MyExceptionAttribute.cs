using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
/*
namespace AspProj10.Models
{
    public class MyException : Exception
    {
        public MyException(string? message) : base(message)
        {
        }
    }

    public class MyExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is MyException)
            {
                var body = new Dictionary<string, Object>();
                body["error"] = context.Exception.Message;
                context.Result = new BadRequestObjectResult(body);
            }
        }

    }
}
*/