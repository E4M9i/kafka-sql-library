namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class RootKeyword : StreamizKeyword
    {
        public RootKeyword()
            : base("ROOT", typeof(CreateKeyword))
        {

        }
    }
}
