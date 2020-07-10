using Streamiz.Kafka.SQL.Error;
using Streamiz.Kafka.SQL.Internal;
using Streamiz.Kafka.SQL.Parser.Internal.Keywords;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using System.Threading;

namespace Streamiz.Kafka.SQL.Parser
{
    internal class StreamizParser : IParser
    {
        private static List<StreamizKeyword> allStaticAuthorizedKeywords = new List<StreamizKeyword>
        {
            new CreateKeyword(),
            new StreamKeyword(),
            new ToKeyword(),
            new WithKeyword(),
            new SelectKeyword(),
            new FromKeyword(),
            new WhereKeyword()
        };

        public IStreamizQuery Parse(string commandText)
        {
            List<StreamizKeyword> keywords = new List<StreamizKeyword>();
            commandText = RemoveSpaces(commandText);
            var words = commandText.Split(" ");
            StreamizKeyword previousWord = null;
            StreamizKeyword currentWord = null;

            foreach (var w in words)
            {
                if(previousWord == null)
                {
                    if (w.ToUpper().Equals("CREATE"))
                    {
                        currentWord = new CreateKeyword();
                        previousWord = new RootKeyword();
                        keywords.Add(previousWord);
                    }
                    else
                        throw new StreamizSyntaxException("First keyword in command text must be CREATE");
                }
                else
                {
                    if (previousWord is ToKeyword)
                        currentWord = new TopicToKeyword(w);
                    else if (previousWord is FromKeyword)
                        currentWord = new TopicSourceKeyword(w);
                    else if (previousWord is SelectKeyword)
                        currentWord = new SelectFieldsKeyword(w.Split(","));
                    else if (previousWord is WhereKeyword)
                        currentWord = new PredicatesKeyword(w.Replace(")", "").Split(","));
                    else
                    {
                        string s = w;
                        if (previousWord is WithKeyword)
                            s = s.Replace("(", "");
                        else if (previousWord is TopicSourceKeyword)
                            s = s.Replace(")", "");

                        var k = allStaticAuthorizedKeywords.FirstOrDefault(f => f.Name.Equals(s.ToUpper()));
                        if (k != null)
                            currentWord = k;
                        else
                            throw new StreamizSyntaxException($"Invalid streamiz syntax. Previous terms was {previousWord.Name}, Current terms can not be {w}");
                    }
                }

                previousWord.AddNextKeyword(currentWord);
                keywords.Add(currentWord);
                previousWord = currentWord;
            }

            return new StreamizQuery(keywords);
        }

        private string RemoveSpaces(string commandText)
        {
            var c = commandText.TrimStart().TrimEnd();
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < c.Length; ++i)
            {
                sb.Append(c[i]);

                if (c[i] == ' ' && c[i + 1] == ' ')
                    ++i;
            }
            
            return sb.ToString();
        }
    }
}
