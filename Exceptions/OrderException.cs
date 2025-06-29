﻿using System;

namespace PharmacyProject.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string message) : base(message)
        {
        }

        public OrderException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}