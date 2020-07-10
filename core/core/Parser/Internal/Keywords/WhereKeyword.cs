namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class WhereKeyword : StreamizKeyword
    {
        public WhereKeyword()
            : base("WHERE", true, typeof(PredicatesKeyword))
        {

        }
    }
}