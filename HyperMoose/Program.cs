using System.Net;
using System.Net.Sockets;
using HyperMoose.Forms;
using HyperMoose.Utilities;

namespace HyperMoose;

internal static class Program
{
    public const int PORT = 7777;

    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new TrayAppContext());
    }

    internal class TrayAppContext : ApplicationContext
    {
        private readonly CancellationTokenSource _cts;
        private readonly Control _ui;

        private readonly TcpListener _listener;
        private readonly NotifyIcon _notifyIcon;

        public TrayAppContext()
        {
            _cts = new();
            _ui = new Control();
            _ui.CreateControl();

            _listener = new(IPAddress.Any, PORT);
            _listener.Start();

            _ = ListenAsync(_cts.Token);

            var menu = new ContextMenuStrip();
            menu.Items.Add("ALIVE", null, OnOpen);
            menu.Items.Add("DEATH", null, OnExit);

            _notifyIcon = new()
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath),
                ContextMenuStrip = menu,
                Text = nameof(HyperMoose),
                Visible = true,
            };
            _notifyIcon.DoubleClick += OnOpen;
        }

        private void OnOpen(object? sender, EventArgs e)
        {
            var form = new Form1();
            form.Show();
        }

        private void OnExit(object? sender, EventArgs e)
        {
            _cts.Cancel();
            _listener.Stop();

            _notifyIcon.Visible = false;
            _notifyIcon.Dispose();

            Application.Exit();
        }

        private async Task ListenAsync(CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                var client = await _listener.AcceptTcpClientAsync(cancellationToken);
                _ = HandleClientAsync(client, cancellationToken);
            }
        }

        private async Task HandleClientAsync(TcpClient client, CancellationToken cancellationToken)
        {
            using var connection = new MooseConnection(client);

            while (!cancellationToken.IsCancellationRequested)
            {
                string? message = await connection.ReadMessageAsync(cancellationToken);

                if (!string.IsNullOrWhiteSpace(message))
                {
                    string sender;

                    if (client.Client.RemoteEndPoint is IPEndPoint endpoint)
                    {
                        sender = await GetNameAsync(endpoint, cancellationToken);
                    }
                    else sender = "Anonymous";

                    _ui.BeginInvoke(() =>
                    {
                        var frm = new frmMoose(sender, message);
                        frm.Show();
                        frm.FormClosed += (s, e) => frm.Dispose();
                    });
                }
                else break;
            }
        }

        private static async Task<string> GetNameAsync(IPEndPoint endpoint, CancellationToken cancellationToken)
        {
            string name = "Unidentified";
            try
            {
                foreach (var herd in FileHelper.GetSavedGroups())
                {
                    if (herd.Count == 1)
                    {
                        var moose = herd[0];

                        if (IPAddress.TryParse(moose.Hostname, out var ip))
                        {
                            if (ip.Equals(endpoint.Address))
                            {
                                name = moose.Name;
                            }
                        }
                        else
                        {
                            var ips = await Dns.GetHostAddressesAsync(moose.Hostname, cancellationToken);

                            if (ips.Contains(endpoint.Address))
                            {
                                name = moose.Name;
                            }
                        }
                    }
                }
            }
            catch { }

            return name;
        }
    }
}
