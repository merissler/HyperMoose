using System.Diagnostics;
using System.Drawing.Text;
using System.Xml.Linq;
using HyperMoose.Models;
using HyperMoose.Utilities;
using MooseCode;

namespace HyperMoose.Forms;

public partial class Form1 : Form
{
    private readonly MooseTranslator _translator;
    private readonly HashSet<char> _validCharacters;

    private bool _loading = false;
    private string? _selection;

    public Form1()
    {
        _translator = new();
        _validCharacters = new(_translator.GetValidCharacters(), new CharIgnoreCaseComparer());

        InitializeComponent();
        numericUpDown1.Value = Program.PORT;

        var fonts = new InstalledFontCollection();
        var usable = fonts.Families
            .Where(f => f.IsStyleAvailable(FontStyle.Regular))
            .Select(f => f.Name)
            .OrderBy(name => name);

        foreach (string font in usable)
        {
            comboBox1.Items.Add(font);
        }
        comboBox1.SelectedItem = Font.Name;
    }

    private void Form1_Activated(object sender, EventArgs e)
    {
        try
        {
            _loading = true;

            var groups = FileHelper.GetSavedGroups();
            listBox1.DataSource = groups;
            listBox1.ValueMember = nameof(Herd.Name);
            listBox1.DisplayMember = nameof(Herd.Name);
            listBox1.SelectedIndex = Array.FindIndex(groups, herd => herd.Name == _selection);
        }
        finally
        {
            _loading = false;
        }
    }

    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!_loading)
        {
            if (listBox1.SelectedItem is Herd herd)
            {
                _selection = herd.Name;
            }
        }
    }

    private void btnFriendEdit_Click(object sender, EventArgs e)
    {
        string directory = FileHelper.GetDataDirectory();
        string file = Path.Combine(directory, "groups.ini");

        if (!File.Exists(file))
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string contents = Properties.Resources.groups_ini;
            File.WriteAllText(file, contents);
        }
        Process.Start(new ProcessStartInfo()
        {
            FileName = file,
            WorkingDirectory = directory,
            UseShellExecute = true,
        });
    }

    private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboBox1.SelectedItem is string font)
        {
            try
            {
                comboBox1.Font = FontHelper.ReplaceFontFamily(comboBox1.Font, font);
                textBox1.Font = FontHelper.ReplaceFontFamily(textBox1.Font, font);
            }
            catch { }
        }
    }

    private async void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            string message = textBox1.Text;
            var herd = listBox1.SelectedItem as Herd;
            int port = Convert.ToInt32(numericUpDown1.Value);

            await BroadcastAsync(textBox1.Text, herd!, port);
            e.Handled = true;
        }
        else if (!char.IsControl(e.KeyChar) && !_validCharacters.Contains(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void textBox1_TextChanged(object sender, EventArgs e)
    {
        int cursor = textBox1.SelectionStart;

        var filtered = textBox1.Text.Where(_validCharacters.Contains);
        textBox1.Text = new string([.. filtered]);

        textBox1.SelectionStart = cursor;
    }

    private async void btnSpeech_Click(object sender, EventArgs e)
    {
        string message = textBox1.Text;
        var herd = listBox1.SelectedItem as Herd;
        int port = Convert.ToInt32(numericUpDown1.Value);

        await BroadcastAsync(textBox1.Text, herd!, port);
    }

    private async Task BroadcastAsync(string message, Herd herd, int port)
    {
        try
        {
            listBox2.Items.Clear();

            textBox1.Enabled = false;
            btnSpeech.Enabled = false;
            Cursor = Cursors.WaitCursor;

            foreach (var moose in herd)
            {
                try
                {
                    listBox2.Items.Add($"Messaging {moose.Hostname}");

                    using var connection = new MooseConnection();
                    await connection.OpenAsync(moose.Hostname, Program.PORT);

                    string encoded = _translator.Encode(message);
                    string? font = comboBox1.SelectedItem as string;
                    var mm = new MooseMessage(encoded, font);

                    await connection.SendMessageAsync(mm);
                }
                catch (Exception ex)
                {
                    listBox2.Items.Add($"ERROR: {ex.Message}");
                }
            }
            listBox2.Items.Add($"Finished");
        }
        finally
        {
            textBox1.Clear();
            textBox1.Enabled = true;
            btnSpeech.Enabled = true;
            Cursor = Cursors.Default;
        }
    }
}
