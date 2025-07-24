using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace PracticeProblem
{
    internal static class TXTreader
    {
        public static List<Message> ReadMessagesTXT(string filePath)
        {
            var messages = new List<Message>();
            foreach (var line in File.ReadAllLines(filePath))
            {
                try
                {
                    var parts = line.Split(new[] { "##" }, StringSplitOptions.None);
                    if (parts.Length != 5) continue;

                    DateTime date = DateTime.Parse(parts[0], CultureInfo.InvariantCulture);
                    Person sender = ParsePerson(parts[1]);
                    Person receiver = ParsePerson(parts[2]);
                    string content = parts[3];
                    bool seen = bool.Parse(parts[4]);
                    var msg = new Message(date, sender, receiver, content, seen);
                    messages.Add(msg);
                }
                catch (EmptyMessageException ex)
                {
                    Console.WriteLine($"Empty message encountered: {ex}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to parse line: {line} | Error: {ex.Message}");
                }
            }
            return messages;
        }

        private static Person ParsePerson(string input)
        {
            
            int openIdx = input.IndexOf('(');
            int closeIdx = input.IndexOf(')');
            string name = input.Substring(0, openIdx);
            var data = input.Substring(openIdx + 1, closeIdx - openIdx - 1).Split(',');
            int id = int.Parse(data[0]);
            string email = data[1];
            int? age = data.Length > 2 ? int.Parse(data[2]) : (int?)null;
            return new Person(id, name, email, age);
        }
    }
}
