using System.Net;
using System.Net.Sockets;

public class UDPSender
{
  private UdpClient udpClient;
  IPEndPoint groupEP;

  public UDPSender(int port)
  {
    init(port);
  }

  private void init(int port)
  {
    udpClient = new UdpClient();
    groupEP = new IPEndPoint(IPAddress.Broadcast, port);
  }
  
  public byte[] receive()
  {
    return udpClient.Receive(ref groupEP);
  }

  public void send(byte[] data)
  {
    udpClient.Send(data, data.Length, groupEP);
  }

  public void close()
  {
    udpClient.Dispose();
  }
}