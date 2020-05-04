using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

public class UDPSender
{
  private UdpClient udpClient;
  private IPEndPoint endPointBroadcast;

  public UDPSender(int port)
  {
    init(port);
  }

  private void init(int port)
  {
    udpClient = new UdpClient();
    endPointBroadcast = new IPEndPoint(IPAddress.Broadcast, port);
  }
  
  public async Task<byte[]> receiveAsync(int retries)
  {
    return await Task<byte[]>.Run(() =>
    {
      while(retries >= 0)
      {
        if (udpClient.Available > 0)
          return udpClient.Receive(ref endPointBroadcast);
        
        retries--;
        Thread.Sleep(1000);
      }

      return new byte[] {};
    });
  }

  public void send(byte[] data)
  {
    udpClient.Send(data, data.Length, endPointBroadcast);
  }

  public void close()
  {
    udpClient.Dispose();
  }
}