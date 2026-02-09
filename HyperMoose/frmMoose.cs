using MooseCode;

namespace HyperMoose;

public partial class frmMoose : Form
{
    private bool _translated = false;

    public frmMoose(string sender, string message)
    {
        InitializeComponent();

        label2.Text = sender;
        label1.Text = message;

        var screen = Screen.PrimaryScreen!.WorkingArea;
        int x = screen.Right - Width;
        int y = screen.Bottom - Height;
        Location = new Point(x, y);
    }

    private void label1_SizeChanged(object sender, EventArgs e)
    {
        int min = 380 - label2.Width;
        int left = Math.Min(Right - label1.Width, min);
        label2.Left = left;
        label1.Left = left;
    }

    private void label1_DoubleClick(object sender, EventArgs e)
    {
        if (!_translated)
        {
            var translator = new MooseTranslator();
            label1.Text = translator.Decode(label1.Text);
            _translated = true;
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Close();
    }
}
