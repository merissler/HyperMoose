using System.Diagnostics;
using System.Runtime.InteropServices;
using HyperMoose.Utilities;
using MooseCode;

namespace HyperMoose.Forms;

public partial class frmMoose : Form
{
    private readonly MooseTranslator _translator;
    private readonly bool _scuba;

    private bool _translated = false;

    public frmMoose(MooseTranslator translator, string sender, string message, string? font = null)
    {
        InitializeComponent();

        _translator = translator;
        _scuba = Process.GetProcessesByName("DesktopAquarium").Length > 0;
        pictureBox1.Image = _scuba ? Properties.Resources.moose_scuba : Properties.Resources.moose;

        if (!string.IsNullOrWhiteSpace(font))
        {
            try
            {
                Font = FontHelper.ReplaceFontFamily(Font, font);
            }
            catch { }
        }
        label2.Text = sender;
        label1.Text = message;

        var screen = Screen.PrimaryScreen!.WorkingArea;
        int x = screen.Right - Width;
        int y = screen.Bottom - Height;
        Location = new Point(x, y);
    }

    private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            ReleaseCapture();
            _ = SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
        }
    }

    private void label1_SizeChanged(object sender, EventArgs e)
    {
        int right = _scuba ? 360 : 380;
        int min = right - label2.Width;
        int left = Math.Min(Width - label1.Width, min);
        label2.Left = left;
        label1.Left = left;
        label1.MaximumSize = new Size(Width - label1.Left, label1.MaximumSize.Height);
    }

    private void label1_DoubleClick(object sender, EventArgs e)
    {
        if (!_translated)
        {
            label1.Text = _translator.Decode(label1.Text);
            _translated = true;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Close();
    }

    private const int WM_NCLBUTTONDOWN = 0xA1;
    private const int HTCAPTION = 0x2;

    [DllImport("user32.dll")]
    private static extern bool ReleaseCapture();

    [DllImport("user32.dll")]
    private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);
}
