using System.Diagnostics;
using HyperMoose.Utilities;
using MooseCode;

namespace HyperMoose.Forms;

public partial class Form1 : Form
{
    private readonly MooseTranslator _translator;
    private readonly HashSet<char> _validCharacters;

    public Form1()
    {
        _translator = new();
        _validCharacters = new(_translator.GetValidCharacters(), new CharIgnoreCaseComparer());
        InitializeComponent();
    }

    private void Form1_Activated(object sender, EventArgs e)
    {
        listBox1.DataSource = FileHelper.GetSavedGroups();
        listBox1.ValueMember = nameof(Herd.Name);
        listBox1.DisplayMember = nameof(Herd.Name);
    }

    private void btnFriendEdit_Click(object sender, EventArgs e)
    {
        EditDataFile("groups.ini");
    }

    private async void textBox1_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (e.KeyChar == '\r')
        {
            var herd = listBox1.SelectedItem as Herd;
            await BroadcastAsync(textBox1.Text, herd!);

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
        var herd = listBox1.SelectedItem as Herd;
        await BroadcastAsync(textBox1.Text, herd!);
    }

    private async Task BroadcastAsync(string message, Herd herd)
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
                    await connection.SendMessageAsync(encoded);
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

    private static void EditDataFile(string name)
    {
        string directory = FileHelper.GetDataDirectory();
        string file = Path.Combine(directory, name);

        if (!File.Exists(file))
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string contents = FileHelper.GetEmbeddedResource(name);
            File.WriteAllText(file, contents);
        }
        Process.Start(new ProcessStartInfo()
        {
            FileName = file,
            WorkingDirectory = directory,
            UseShellExecute = true,
        });
    }
}
