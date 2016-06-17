﻿using System;

namespace DotNetFuncToolBelt
{
    public class Result
    {
        public bool IsSuccess { get; }
        public ErrorTypebase ErrorType { get; }
        public bool IsFailure => !IsSuccess;

        protected Result(bool isSuccess, ErrorTypebase errorType)
        {
            if (isSuccess && errorType != null)
                throw new InvalidOperationException();
            if (!isSuccess && errorType == null)
                throw new InvalidOperationException();

            IsSuccess = isSuccess;
            ErrorType = errorType;
        }

        public static Result Fail(object someError)
        {
            throw new NotImplementedException();
        }

        public static Result Fail(ErrorTypebase errorType)
        {
            return new Result(false, errorType);
        }

        public static Result<T> Fail<T>(ErrorTypebase errorType)
        {
            return new Result<T>(default(T), false, errorType);
        }

        public static Result Ok()
        {
            return new Result(true, null);
        }

        public static Result<T> Ok<T>(T value)
        {
            return new Result<T>(value, true, null);
        }
    }


    public class Result<T> : Result
    {
        private readonly T _value;
        public T Value
        {
            get
            {
                if (!IsSuccess)
                    throw new InvalidOperationException();

                return _value;
            }
        }

        protected internal Result(T value, bool isSuccess, ErrorTypebase errorType)
            : base(isSuccess, errorType)
        {
            _value = value;
        }
    }


   
}
