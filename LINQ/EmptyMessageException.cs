using System;

namespace PracticeProblem
{
    
    internal class EmptyMessageException : Exception
    {
        public Message EmptyMsg { get; }
        public EmptyMessageException(Message message)
            : base("Message content is empty.")
        {
            EmptyMsg = message;
        }

        public override string ToString()
        {
            return $"EmptyMessageException: {Message} | Message Info: {EmptyMsg}";
        }
    }
}
