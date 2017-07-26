﻿using StoreManager.Model.Models;
using StoreManager.Service;
using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StoreManager.Web.Infrastructure.Core
{
    public class ApiControllerBase : ApiController
    {
        private IErrorService _errorService;

        public ApiControllerBase(IErrorService errorService)
        {
            _errorService = errorService;
        }

        protected HttpResponseMessage CreateHttpResponse(HttpRequestMessage requestMessage, Func<HttpResponseMessage> funtion)
        {
            HttpResponseMessage response = null;
            try
            {
                response = funtion.Invoke();
            }
            catch (DbEntityValidationException ex)
            {
                foreach (var eve in ex.EntityValidationErrors)
                {
                    Trace.WriteLine($"Entity of type\"{eve.Entry.Entity.GetType().Name}\"in state \"{eve.Entry.State}\" has the following validation errors.");
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Trace.WriteLine($"- Property: \"{ve.PropertyName}\",Error: \"{ve.ErrorMessage}\".");
                    }
                }

                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.InnerException.Message);
            }
            catch (DbUpdateException dbEx)
            {
                LogError(dbEx);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, dbEx.InnerException.Message);
            }
            catch (Exception ex)
            {
                LogError(ex);
                response = requestMessage.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return response;
        }

        public void LogError(Exception ex)
        {
            try
            {
                Error error = new Error();
                error.Message = ex.Message;
                error.Message = ex.StackTrace;
                error.CreatedDate = DateTime.Now;
                _errorService.Create(error);
                _errorService.Save();
            }
            catch 
            {
            }
        }
    }
}