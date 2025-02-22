﻿using Business.Wrappers;
using Core.Exceptions;

namespace Presentation.Middlewares
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate next;

        public CustomExceptionMiddleware(RequestDelegate  requestDelegate)
        {
            next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                var response = new Response();
                switch (e)
                {
                    case ValidationException ex:
                        context.Response.StatusCode = StatusCodes.Status400BadRequest;
                       response.Errors= ex.Errors;
                        break;

                    case NotFoundException exp:
                        context.Response.StatusCode= StatusCodes.Status404NotFound;
                        response.Errors= exp.Errors;
                        break;

                    case UnauthorizedException exc:
                        context.Response.StatusCode=StatusCodes.Status401Unauthorized;
                        response.Errors = exc.Errors;
                        break;

                    default:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        response.Message = "Error ocured!!!";
                        break;
                }
                await context.Response.WriteAsJsonAsync(response);

            }
        }
    }
}
