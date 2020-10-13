﻿using System;
using System.Collections.Generic;
using System.Text;

namespace IdraakApp.ViewModels
{
    public class Response
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }
        public object ResultData { get; set; }
    }

    public enum ResponseStatus
    {
        OK = 200,
        Error = 400,
        Restrected = 403
    }
}
