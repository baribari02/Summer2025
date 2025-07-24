using System;

namespace PracticeProblem
{
    internal class Message
    {
        public DateTime Date { get; }
        public Person Sender { get; }
        public Person Receiver { get; }
        public string Content { get; }
        public bool Seen { get; }

        public Message(DateTime date, Person sender, Person receiver, string content, bool seen)
        {
            if (string.IsNullOrWhiteSpace(content))
                throw new EmptyMessageException(this);

            Date = date;
            Sender = sender;
            Receiver = receiver;
            Content = content;
            Seen = seen;
        }

        public override string ToString()
        {
            return $"{Date:G} | From: {Sender.Name} | To: {Receiver.Name} | Seen: {Seen} | Content: {Content}";
        }
    }
}
