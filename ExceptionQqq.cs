using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Qqq
{

        [Serializable]
        public sealed class Exception<TExceptionArgs> : Exception, ISerializable
            where TExceptionArgs : ExceptionArgs
        {
            private const string c_args = "Args";
            private readonly TExceptionArgs m_args;

            public TExceptionArgs Args { get { return m_args; } }

            public Exception(string message = null, Exception innerException = null)
                : this(null, message, innerException) { }

            public Exception(TExceptionArgs args, string message = null, 
                Exception innerException = null): base(message, innerException) { m_args = args;}

            public override string Message
            {
                get 
                { 
                    string baseMsg = base.Message;
                    return (m_args == null) ? baseMsg : baseMsg + " (" + m_args.Message + ")";
                }
            }

            public override bool Equals(object obj)
            {
                Exception<TExceptionArgs> other = obj as Exception<TExceptionArgs>;
                if (obj == null) return false;
                return Object.Equals(m_args, other.m_args) && base.Equals(obj);
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }

        [Serializable]
        public abstract class ExceptionArgs
        {
            public virtual string Message { get { return String.Empty; } }
        }

        [Serializable]
        public sealed class BadNumberExceptionArgs : ExceptionArgs
        {
            private readonly int m_num;

            public BadNumberExceptionArgs(int num) { m_num = num; }

            public int Num { get { return m_num; } }

            public override string Message 
            {
                get { return (m_num == null) ? base.Message : $"Число: {m_num} не подходит"; }
            }
        }

}
