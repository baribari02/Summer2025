using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace PracticeProblem
{
  
    internal class Manager
    {
        private string txtPath = "Messages.txt";
        private List<Message> messages;
        private List<Person> persons;

        public Manager()
        {
            messages = TXTreader.ReadMessagesTXT(txtPath);
            getUniquePersons();
        }

        public Person getPerson(int id)
        {
            return persons.FirstOrDefault(p => p.Id == id);
        }

        private void getUniquePersons()
        {
            persons = messages
                .SelectMany(m => new[] { m.Sender, m.Receiver })
                .Distinct()
                .ToList();
        }

        public List<Person> GetAllPersons() => new List<Person>(persons);

        
        public void PrintAllPersons()
        {
            foreach (var p in persons)
                Console.WriteLine(p);
            Console.WriteLine();
        }

        
        public int CountMessagesBetween(Person p1, Person p2)
        {
            return messages.Count(m =>
                (m.Sender.Equals(p1) && m.Receiver.Equals(p2)) ||
                (m.Sender.Equals(p2) && m.Receiver.Equals(p1)));
        }

        
        public void PrintMessagesBetween(Person p1, Person p2)
        {
            var msgs = messages
                .Where(m =>
                    (m.Sender.Equals(p1) && m.Receiver.Equals(p2)) ||
                    (m.Sender.Equals(p2) && m.Receiver.Equals(p1)))
                .OrderBy(m => m.Date)
                .ToList();

            foreach (var msg in msgs)
                Console.WriteLine(msg);
            Console.WriteLine();
        }

        
        public void PrintMessagesOnDate(DateTime date)
        {
            var msgs = messages
                .Where(m => m.Date.Date == date.Date)
                .OrderBy(m => m.Date)
                .ToList();

            foreach (var msg in msgs)
                Console.WriteLine(msg);
            Console.WriteLine();
        }

        
        public void PrintMessagesFromSender(Person sender)
        {
            var msgs = messages
                .Where(m => m.Sender.Equals(sender))
                .OrderBy(m => m.Date)
                .ToList();

            foreach (var msg in msgs)
                Console.WriteLine(msg);
            Console.WriteLine();
        }

        public void SaveConversation(Person p1, Person p2)
        {
            var conv = messages
                .Where(m =>
                    (m.Sender.Equals(p1) && m.Receiver.Equals(p2)) ||
                    (m.Sender.Equals(p2) && m.Receiver.Equals(p1)))
                .OrderBy(m => m.Date)
                .ToList();

            using (StreamWriter writer = new StreamWriter("conv.txt"))
            {
                foreach (var m in conv)
                {
                    writer.WriteLine(m.ToString());
                }
            }
            Console.WriteLine($"Conversation saved to {"conv.txt"}\n");
        }


        public void PrintUnseenMessages()
        {
            var unseen = messages.Where(m => !m.Seen).OrderBy(m => m.Date).ToList();
            foreach (var msg in unseen)
                Console.WriteLine(msg);
            Console.WriteLine();
        }


        public void PrintLastReceivedMessageWithForbidden(Person receiver, string forbiddenWord)
        {
            var lastMsg = messages
                .Where(m => m.Receiver.Equals(receiver))
                .OrderByDescending(m => m.Date)
                .FirstOrDefault();

            if (lastMsg == null)
            {
                Console.WriteLine("No message found.");
                return;
            }

            string content = lastMsg.Content;
            if (!string.IsNullOrEmpty(forbiddenWord) &&
                content.IndexOf(forbiddenWord, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                string stars = new string('*', forbiddenWord.Length);
            }
            var displayMsg = new Message(lastMsg.Date, lastMsg.Sender, lastMsg.Receiver, content, lastMsg.Seen);
            Console.WriteLine(displayMsg);
            Console.WriteLine();
        }

        public List<Message> GetAllMessagesForPerson(Person person)
        {
            return messages
                .Where(m => m.Sender.Equals(person) || m.Receiver.Equals(person))
                .OrderBy(m => m.Date)
                .ToList();
        }

        public enum PartOfDay { Night, Morning, Afternoon, Evening }

        public PartOfDay GetPartOfDay(DateTime date)
        {
            if (date.Hour >= 5 && date.Hour < 12) return PartOfDay.Morning;
            if (date.Hour >= 12 && date.Hour < 17) return PartOfDay.Afternoon;
            if (date.Hour >= 17 && date.Hour < 22) return PartOfDay.Evening;
            return PartOfDay.Night;
        }

        public List<Message> SearchMessagesByWord(Person person, string word)
        {
            return messages
                .Where(m => (m.Sender.Equals(person) || m.Receiver.Equals(person)) &&
                            m.Content != null &&
                            m.Content.IndexOf(word, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }

        public Dictionary<Person, List<Person>> GetCorrespondenceDictionary()
        {
            var dict = new Dictionary<Person, HashSet<Person>>();

            foreach (var msg in messages)
            {
                if (!dict.ContainsKey(msg.Sender))
                    dict[msg.Sender] = new HashSet<Person>();
                if (!dict.ContainsKey(msg.Receiver))
                    dict[msg.Receiver] = new HashSet<Person>();

                dict[msg.Sender].Add(msg.Receiver);
                dict[msg.Receiver].Add(msg.Sender);
            }

            var result = new Dictionary<Person, List<Person>>();
            foreach (var pair in dict)
                result[pair.Key] = pair.Value.ToList();

            return result;
        }

    }
}