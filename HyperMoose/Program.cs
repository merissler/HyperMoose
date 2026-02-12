using System.Diagnostics;
using System.Media;
using System.Net;
using System.Net.Sockets;
using HyperMoose.Forms;
using HyperMoose.Utilities;
using MooseCode;

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
        private readonly CancellationTokenSource _appCTS;

        private readonly Random _random;
        private readonly MooseTranslator _translator;
        private readonly Control _ui;

        private readonly Stream[] _stompSounds;
        private readonly Stream[] _muuahSounds;

        private readonly TcpListener _listener;
        private readonly NotifyIcon _notifyIcon;

        private Form1? _form;
        private CancellationTokenSource? _soundCTS;

        public TrayAppContext()
        {
            _appCTS = new();
            _random = new();
            _translator = new();
            _ui = new();
            _ui.CreateControl();

            _stompSounds = [Properties.Resources.stomp_1, Properties.Resources.stomp_2, Properties.Resources.stomp_3, Properties.Resources.stomp_4, Properties.Resources.stomp_5, Properties.Resources.stomp_6, Properties.Resources.stomp_7];
            _muuahSounds = [Properties.Resources.mmmh, Properties.Resources.mmmuuhh, Properties.Resources.MUuah, Properties.Resources.MUUuaaAaah, Properties.Resources.MUUUAAAH, Properties.Resources.MUUUAAH, Properties.Resources.muUUUuaah];

            _listener = new(IPAddress.Any, PORT);
            _listener.Start();
            _ = ListenAsync(_appCTS.Token);

            var menu = new ContextMenuStrip();
            menu.Items.Add("LIVE", null, OpenMainForm);
            menu.Items.Add("DIE", null, ExitApplication);

            _notifyIcon = new()
            {
                Icon = Icon.ExtractAssociatedIcon(Application.ExecutablePath),
                ContextMenuStrip = menu,
                Text = "HYPER MOOSE",
                Visible = true,
            };
            _notifyIcon.DoubleClick += OpenMainForm;
        }

        private void OpenMainForm(object? sender, EventArgs e)
        {
            if (_form is null)
            {
                _ui.BeginInvoke(() =>
                {
                    _form = new Form1();
                    _form.ShowDialog();
                    _form.Dispose();
                    _form = null;
                });
            }
            else _form.Activate();
        }

        private void ExitApplication(object? sender, EventArgs e)
        {
            _appCTS.Cancel();
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
                var mm = await connection.ReadMessageAsync(cancellationToken);

                if (mm is not null && !string.IsNullOrWhiteSpace(mm.MooseCode))
                {
                    string sender;

                    if (client.Client.RemoteEndPoint is IPEndPoint endpoint)
                    {
                        sender = await GetNameAsync(endpoint, cancellationToken);
                    }
                    else sender = "Anonymous";

                    _ui.BeginInvoke(() =>
                    {
                        var frm = new frmMoose(_translator, sender, mm.MooseCode, mm.FontFamily);
                        frm.Show();
                        frm.FormClosed += (s, e) => frm.Dispose();
                    });
                    _ = PlayMooseSoundsAsync(mm.MooseCode);
                }
                else break;
            }
        }

        private async Task PlayMooseSoundsAsync(string mooseCode)
        {
            try
            {
                var old = Interlocked.Exchange(ref _soundCTS, new());
                old?.Cancel();
                old?.Dispose();
                var cancellationToken = _soundCTS.Token;

                foreach (string token in MooseTranslator.EnumerateTokens(mooseCode))
                {
                    const string stomp = MooseTranslator.stomp;
                    const string MUUUAAAH = MooseTranslator.MUUUAAAH;
                    try
                    {
                        cancellationToken.ThrowIfCancellationRequested();
                        Stream? stream;

                        if (string.Equals(token, stomp, StringComparison.OrdinalIgnoreCase))
                        {
                            int index = _random.Next(_stompSounds.Length);
                            stream = _stompSounds[index];
                        }
                        else if (string.Equals(token, MUUUAAAH, StringComparison.OrdinalIgnoreCase))
                        {
                            int index = _random.Next(_muuahSounds.Length);
                            stream = _muuahSounds[index];
                        }
                        else stream = null;

                        if (stream is not null)
                        {
                            cancellationToken.ThrowIfCancellationRequested();

                            int delay = _random.Next(1000);
                            await Task.Delay(delay, cancellationToken);

                            if (stream.CanSeek) stream.Position = 0;
                            using var sound = new SoundPlayer(stream);
                            using var registration = cancellationToken.Register(sound.Stop);

                            await Task.Run(sound.PlaySync, cancellationToken);
                        }
                    }
                    catch { cancellationToken.ThrowIfCancellationRequested(); }
                }
            }
            catch (Exception ex)
            {
                if (ex is not OperationCanceledException && Debugger.IsAttached) throw;
            }
            finally
            {
                var old = Interlocked.Exchange(ref _soundCTS, null);
                old?.Cancel();
                old?.Dispose();
            }
        }

        private static async Task<string> GetNameAsync(IPEndPoint endpoint, CancellationToken cancellationToken)
        {
            string name = endpoint.Address.ToString();
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
