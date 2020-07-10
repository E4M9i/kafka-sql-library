using Confluent.Kafka;
using Streamiz.Kafka.Net;
using Streamiz.Kafka.Net.SerDes;
using Streamiz.Kafka.SQL;
using System;
using System.Threading;

namespace SampleStart
{
    class Program
    {
        static void Main(string[] args)
        {
            CancellationTokenSource source = new CancellationTokenSource();

            var kafkaConfig = new StreamConfig<StringSerDes, StringSerDes>();
            kafkaConfig.ApplicationId = "test-app";
            kafkaConfig.BootstrapServers = "192.168.56.1:9092";
            kafkaConfig.SaslMechanism = SaslMechanism.Plain;
            kafkaConfig.SaslUsername = "admin";
            kafkaConfig.SaslPassword = "admin";
            kafkaConfig.SecurityProtocol = SecurityProtocol.SaslPlaintext;
            kafkaConfig.AutoOffsetReset = AutoOffsetReset.Earliest;
            kafkaConfig.NumStreamThreads = 1;

            var builder = SQLBuilder.Create(kafkaConfig);

            builder
                .Add("CREATE STREAM TO totot WITH (SELECT * FROM topic WHERE champI='TOTO')");

            var instance = builder.Build();

            Console.CancelKeyPress += (o, e) =>
            {
                source.Cancel();
                instance.Close();
            };

            instance.Start(source.Token);
        }
    }
}
