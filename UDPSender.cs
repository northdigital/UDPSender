using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

public class UDPSender
{
  private UdpClient udpClient;
  private IPEndPoint endPoint;

  public UDPSender(string ipAddress, int port)
  {
    init(ipAddress, port);
  }

  private void init(string ipAddress, int port)
  {
    udpClient = new UdpClient();    
    endPoint = new IPEndPoint(IPAddress.Parse(ipAddress), port);
  }
  
  public async Task<byte[]> receiveAsync(int retries)
  {
    return await Task<byte[]>.Run(() =>
    {
      while(retries >= 0)
      {
        if (udpClient.Available > 0)
          return udpClient.Receive(ref endPoint);
        
        retries--;
        Thread.Sleep(1000);
      }

      return new byte[] {};
    });
  }

  public void send(byte[] data)
  {
    udpClient.Send(data, data.Length, endPoint);
  }

  public void close()
  {
    udpClient.Dispose();
  }
}