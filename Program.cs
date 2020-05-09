using System;
using System.Text;
using System.Threading.Tasks;

class Program
{
  const int PORT = 7777;

  static async Task Main(string[] args)
  {
    UDPSender udpSender = new UDPSender("192.168.1.202", PORT);
    udpSender.send(Encoding.UTF8.GetBytes(args[0]));
    
    var receivedBytes = await udpSender.receiveAsync(1);
    var receivedMessage = Encoding.UTF8.GetString(receivedBytes);

    Console.WriteLine(receivedMessage);

    udpSender.close();
  }
}
