using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AI
{
    class RichTextBoxWriter : TextWriter
    {
        private RichTextBox _textBox;

        public RichTextBoxWriter(RichTextBox textbox)
        {
            _textBox = textbox;
        }


        public override void Write(char value)
        {
           // base.Write(value);
            this._textBox.BeginInvoke(new Action(() =>
            {
                this._textBox.AppendText(value.ToString());
                _textBox.SelectionStart = _textBox.Text.Length;
                _textBox.ScrollToCaret();
            }));
           
            // When character data is written, append it to the text box.
         
        }

        public override System.Text.Encoding Encoding {
            get { return System.Text.Encoding.UTF8; }
        }
    }
}
