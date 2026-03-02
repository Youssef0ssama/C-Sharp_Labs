using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace DominoServer
{
    public class ClientWrapper
    {
        private TcpClient _client;
        private StreamReader _reader;
        private StreamWriter _writer;
        public string PlayerName { get; set; }

        public event Action<ClientWrapper, string> MessageReceived;
        public event Action<ClientWrapper> Disconnected;

        public ClientWrapper(TcpClient client)
        {
            _client = client;
            NetworkStream stream = _client.GetStream();
            _reader = new StreamReader(stream);
            _writer = new StreamWriter(stream) { AutoFlush = true };
        }

        public void Send(string message)
        {
            try { _writer.WriteLine(message); } catch { }
        }

        public async Task ListenAsync()
        {
            try
            {
                while (true)
                {
                    string msg = await _reader.ReadLineAsync();
                    if (msg == null) break;
                    MessageReceived?.Invoke(this, msg);
                }
            }
            catch { }
            finally { Disconnected?.Invoke(this); }
        }
    }
}