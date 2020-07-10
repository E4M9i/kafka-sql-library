using Streamiz.Kafka.SQL.Error;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal abstract class StreamizKeyword
    {
        public IEnumerable<Type> NextAuthorizedKeywords { get; set; }
        public List<StreamizKeyword> Next { get; set; } = new List<StreamizKeyword>();
        public string Name { get; }
        public int BeginPosition { get; internal set; }
        public int EndPosition { get; internal set; }
        public bool Optional { get; set; }

        public StreamizKeyword(string name, bool optional, params Type[] nextAuthorized)
        {
            if (nextAuthorized.Count() > 0 && nextAuthorized.FirstOrDefault(t => !t.IsAssignableFrom(typeof(StreamizKeyword))) == null)
                throw new StreamizKeywordException($"NextAuthorized must always child class which inherited from StreamizKeyword class");

            Name = name;
            Optional = optional;
            NextAuthorizedKeywords = nextAuthorized;
        }

        public StreamizKeyword(string name, params Type[] nextAuthorized)
            : this(name, false, nextAuthorized) { }


        public override int GetHashCode() => Name.GetHashCode();

        public override bool Equals(object obj) => 
            obj is StreamizKeyword &&
                obj.GetType().Equals(GetType()) &&
                (obj as StreamizKeyword).Name.Equals(Name);

        public T GetKeyword<T>()
            where T : StreamizKeyword
        {
            var kw = Next.FirstOrDefault(n => n is T);
            if (kw == null)
            {
                foreach (var kp in Next)
                {
                    T t = kp.GetKeyword<T>();
                    if (t != null)
                        return t;
                }
                throw new StreamizKeywordException($"None keyword found for this type {typeof(T).Name}");
            }
            return (T)kw;
        }

        public void AddNextKeyword(StreamizKeyword n)
        {
            if (!Next.Contains(n))
                Next.Add(n);
        }
    }
}