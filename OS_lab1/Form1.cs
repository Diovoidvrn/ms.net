using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace OS_lab1
{
    public partial class Form1 : Form
    {
        private ThreadingService _service;
        public Form1()
        {
            InitializeComponent();       
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            Action<string> bufferPush = (message) =>
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    var bufferBuilder = new StringBuilder();
                    bufferBuilder.AppendLine(message);
                    bufferBuilder.AppendLine(richTextBox_buffer.Text);
                    var regex = new Regex(@"\n+");
                    richTextBox_buffer.Text =regex.Replace(bufferBuilder.ToString(), "\n");
                }));
            };
            Action<string> bufferPop = (message) =>
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    var bufferText = richTextBox_buffer.Text;
                    int index = bufferText.IndexOf(message);
                    bufferText = bufferText.Substring(0, index)
                        + bufferText.Substring(index + message.Length);
                    var regex = new Regex(@"\n+");
                    richTextBox_buffer.Text = regex.Replace(bufferText, "\n");
                }));
            };
            Action<string> readerPrint = (message) =>
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    var readerBuilder = new StringBuilder();
                    readerBuilder.AppendLine(richTextBox_reader.Text);
                    readerBuilder.AppendLine(message);
                    richTextBox_reader.Text = readerBuilder.ToString();
                }));
            };
            Action<string> writerPrint = (message) =>
            {
                BeginInvoke(new MethodInvoker(() =>
                {
                    var readerBuilder = new StringBuilder();
                    readerBuilder.AppendLine(richTextBox_writers.Text);
                    readerBuilder.AppendLine(message);
                    richTextBox_writers.Text = readerBuilder.ToString();
                }));
            };

            _service = new ThreadingService(bufferPush, bufferPop, readerPrint, writerPrint);
            _service.Start();
        }

        private void button_reader_pause_Click(object sender, EventArgs e)
        {
            if (_service is null) return;

            if (String.Equals(button_pause_reader.Text, "Pause Reader"))
            {
                button_pause_reader.Text = "Resume Reader";
                _service.PauseReader();
            }
            else
            {
                button_pause_reader.Text = "Pause Reader";
                _service.ResumeReader();
            }
        }

        private void button_writers_pause_Click(object sender, EventArgs e)
        {
            if (_service is null) return;

            if (String.Equals(button_pause_writers.Text, "Pause Writers"))
            {
                button_pause_writers.Text = "Resume Writers";
                _service.PauseWriters();
            }
            else
            {
                button_pause_writers.Text = "Pause Writers";
                _service.ResumeWriters();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _service?.Stop();
        }
    }
}
