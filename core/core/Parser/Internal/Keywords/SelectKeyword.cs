namespace Streamiz.Kafka.SQL.Parser.Internal.Keywords
{
    internal class SelectKeyword : StreamizKeyword
    {
        public SelectKeyword()
            : base("SELECT", typeof(SelectFieldsKeyword))
        {

        }
    }
}
