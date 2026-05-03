using Apache.NMS;
using Apache.NMS.AMQP;

class Program
{
    static void Main(string[] args)
    {
        string brokerUri = "amqp://192.168.2.25:5672";

        IConnectionFactory factory = new NmsConnectionFactory(brokerUri);
        using (IConnection connection = factory.CreateConnection("admin", "admin"))
        {
            connection.Start();

            using (ISession session = connection.CreateSession())
            {
                IDestination destination = session.GetQueue("test");

                using (IMessageConsumer consumer = session.CreateConsumer(destination))
                {
                    IMessage message = consumer.Receive();

                    if (message is ITextMessage textMessage)
                    {
                        Console.WriteLine("Ontvangen: " + textMessage.Text);
                    }
                }
            }
        }
    }
}