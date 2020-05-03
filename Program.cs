using System;
using System.Text;

class Program
{
  static void Main(string[] args)
  {
    UDPSender udpSender = new UDPSender(7777);
    udpSender.send(Encoding.UTF8.GetBytes($"from sender: {DateTime.Now})"));

    var receivedMessage = Encoding.UTF8.GetString(udpSender.receive());
    Console.WriteLine(receivedMessage);

    udpSender.close();
  }
}
