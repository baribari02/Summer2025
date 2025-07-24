using PracticeProblem;
using System;
using static PracticeProblem.Manager;

namespace PracticeProblemApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager = new Manager();

            
            Console.WriteLine("All unique persons:");
            manager.PrintAllPersons();

            
            var john = manager.GetAllPersons().Find(p => p.Name == "John Doe");
            var jane = manager.GetAllPersons().Find(p => p.Name == "Jane Smith");
            var olivia = manager.GetAllPersons().Find(p => p.Name == "Olivia Stewart");
            Console.WriteLine($"Messages between {john.Name} and {jane.Name}: {manager.CountMessagesBetween(john, jane)}\n");

            
            Console.WriteLine($"Messages between {john.Name} and {jane.Name}:");
            manager.PrintMessagesBetween(john, jane);

            
            var date = new DateTime(2024, 6, 10);
            Console.WriteLine($"Messages on {date:yyyy-MM-dd}:");
            manager.PrintMessagesOnDate(date);

           
            Console.WriteLine($"Messages sent by {john.Name}:");
            manager.PrintMessagesFromSender(john);

            
            manager.SaveConversation(john, jane);

            
            Console.WriteLine("Unseen messages:");
            manager.PrintUnseenMessages();

           
            string forbiddenWord = "Jane";
            Console.WriteLine($"Last message received by {jane.Name} (forbidden word: '{forbiddenWord}'):");
            manager.PrintLastReceivedMessageWithForbidden(jane, forbiddenWord);

            Console.WriteLine($"All messages from Olivia:");
            var messages = manager.GetAllMessagesForPerson(olivia);
            foreach (var msg in messages)
                Console.WriteLine(msg);



            PartOfDay desiredPart = PartOfDay.Morning;

            foreach (var msg in messages)
            {
                var part = manager.GetPartOfDay(msg.Date);
                if (part == desiredPart)
                {
                    Console.WriteLine($"{msg.Date:yyyy-MM-dd HH:mm} - {part}: {msg.Content}");
                }
                else
                {
                    Console.WriteLine("There are no messages from this part of the day!");
                }
            }

            var word = "Hello";
            var foundMessages = manager.SearchMessagesByWord(jane, word);

            if (foundMessages.Count == 0)
            {
                Console.WriteLine($"There are no messages that contain the word \"{word}\" for {jane.Name}.");
            }
            else
            {
                Console.WriteLine($"Messages that contain the word \"{word}\" for {jane.Name}:");
                foreach (var msg in foundMessages)
                    Console.WriteLine(msg);
            }

            var correspondenceDict = manager.GetCorrespondenceDictionary();
            foreach (var person in correspondenceDict.Keys)
            {
                Console.WriteLine($"Person: {person.Name}");
                Console.WriteLine("Correspondent:");
                foreach (var correspondent in correspondenceDict[person])
                    Console.WriteLine($"  - {correspondent.Name}");
                Console.WriteLine();
            }
        }
    }
}