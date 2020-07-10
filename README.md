 # .NET Library for building kafka streams using SQL syntax &middot; [![GitHub license](https://img.shields.io/badge/license-MIT-green.svg)](https://github.com/LGouellec/kafka-sql-library/blob/master/LICENSE)


----

Streamiz Kafka SQL is .NET library for building .net kafka streams using SQL syntax.

It's allowed to help you to build stream processing applications using [Streamiz Kafka .NET](https://github.com/LGouellec/kafka-streams-dotnet).
It's supported .NET Standard 2.1.

This project is being written. Thanks for you contribution !

# Usage

There, a sample streamiz sql application :

``` csharp
static void Main(string[] args)
{
    CancellationTokenSource source = new CancellationTokenSource();

    var builder = SQLBuilder.Create();

    builder
        .Add("CREATE STREAM TO totot WITH (SELECT * FROM topic WHERE champI = 'TOTO')");

    var instance = builder.Build();

    Console.CancelKeyPress += (o, e) => {
        source.Cancel();
        instance.Close();
    };

    instance.Start(source.Token);
}
```