using System.Net.Sockets;

namespace HyperMoose.Utilities;

internal class MooseConnection : IDisposable
{
    private const int TIMEOUT = 1000;

    private readonly TcpClient _client;
    private NetworkStream? _stream;
    private StreamReader? _reader;
    private StreamWriter? _writer;

    public MooseConnection() => _client = new();

    public MooseConnection(TcpClient client)
    {
        _client = client;
        _stream = client.GetStream();
    }

    public async Task OpenAsync(string host, int port)
    {
        using (var cts = new CancellationTokenSource())
        {
            cts.CancelAfter(TIMEOUT);
            await _client.ConnectAsync(host, port, cts.Token);
        }
        _stream = _client.GetStream();
    }

    public Task SendMessageAsync(string message, CancellationToken cancellationToken = default)
    {
        _writer ??= new StreamWriter(_stream!) { AutoFlush = true };
        return _writer.WriteLineAsync(message.AsMemory(), cancellationToken);
    }

    public ValueTask<string?> ReadMessageAsync(CancellationToken cancellationToken = default)
    {
        _reader ??= new StreamReader(_stream!);
        return _reader.ReadLineAsync(cancellationToken);
    }

    public void Dispose()
    {
        _client?.Dispose();
        _stream?.Dispose();
        _reader?.Dispose();
        _writer?.Dispose();
    }
}
