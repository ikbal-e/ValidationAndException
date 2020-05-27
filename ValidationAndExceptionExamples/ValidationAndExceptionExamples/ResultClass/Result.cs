using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ValidationAndExceptionExamples.ResultClass
{
    public class Result
    {
        public string Error { get; }

        public bool Success => Error == null;
        public bool Failure => !Success;

        protected Result() { }

        protected Result(string message)
        {
            if (String.IsNullOrEmpty(message)) throw new ArgumentException();

            Error = message;
        }

        public static Result Fail(string message) { return new Result(message); }
        public static Result Ok() { return new Result(); }
    }


    public class Result<T> : Result
    {
        public T Value { get; private set; }

        protected internal Result(T value)
        {
            Value = value;
        }

        protected internal Result(T value, string message) : base(message)
        {
            Value = value;
        }

        public static Result<T> Fail(T value,string message) { return new Result<T>(value, message); }

        public static Result<T> Ok(T value) { return new Result<T>(value); }
    }
}