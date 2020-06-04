using System;
using System.Runtime.Serialization;

namespace Student2.Utils
{
    public readonly struct Result<TResult>
        where TResult : class
    {
        public readonly TResult Value;
        public readonly Error Error;
        public readonly ResultType Match;
        public readonly bool HasError;
        public readonly bool HasValue;

        Result(TResult value)
        {
            Value = value;
            Error = null!;
            Match = ResultType.Ok;
            HasError = false;
            HasValue = true;
        }

        Result(Error error)
        {
            Value = default!;
            Error = error;
            Match = ResultType.Error;
            HasError = true;
            HasValue = false;
        }

        public static implicit operator Result<TResult>(TResult result)
        {
            return new Result<TResult>(result);
        }

        public static implicit operator Result<TResult>(Error error)
        {
            return new Result<TResult>(error);
        }


        public TResult Unwrap()
        {
            return Value ?? throw Error!;
        }

        public TResult UnwrapOr(TResult alternate)
        {
            return Value ?? alternate;
        }

        public TResult UnwrapOr(Func<Exception, TResult> action)
        {
            return Value ?? action(Error!);
        }

        public TResult Expect(string msg)
        {
            return Value ?? throw new Exception(msg, Error);
        }

        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}, {nameof(Error)}: {Error?.Message}";
        }
    }

    public enum ResultType
    {
        Ok,
        Error
    }

    public class Error : Exception
    {
        protected Error(SerializationInfo info, StreamingContext context) : base(info, context) { }
        public Error(string? message) : base(message) { }
        public Error(string? message, Exception? innerException) : base(message, innerException) { }
        public Error(Exception exception) : base(exception.Message, exception) { }

        // TODO Should serialize for a http response by some kind a standard
        public string Serialize()
        {
            return Message;
        }
    }
}
