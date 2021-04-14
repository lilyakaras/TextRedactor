using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab_5_WinForms
{
    public partial class Form1 : Form
    {
        string path = "";
        bool IsSave = false;
        int size = 10;
        string searchWord = "";
        public Form1()
        {
            InitializeComponent();
            richTextBox1.ForeColor = Color.Black;
            notifyIcon1.Visible = false;
            notifyIcon1.Icon = Properties.Resources.file_document_icon_143784;
            this.Icon = Properties.Resources.file_document_icon_143784;
            menuStrip1.Visible = true;
            this.MainMenuStrip = menuStrip1;
            richTextBox1.AllowDrop = true;
            richTextBox1.DragEnter += RichTextBox1_DragEnter;
            richTextBox1.DragDrop += RichTextBox1_DragDrop;
            foreach (FontFamily item in FontFamily.Families)
            {
                toolStripComboBox1.Items.Add(item.Name);
            }
            toolStripComboBox1.SelectedItem = "Times New Roman";

            for (int i = 4; i < 73; i++)
            {
                toolStripComboBox2.Items.Add(i);
                i++;
            }
            toolStripComboBox2.SelectedItem = 10;
        }

        private void RichTextBox1_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            try
            {
                richTextBox1.LoadFile(files[0], RichTextBoxStreamType.RichText);
            }
            catch (Exception)
            {
                richTextBox1.LoadFile(files[0], RichTextBoxStreamType.PlainText);
            }
        }

        private void RichTextBox1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip2.Visible = false;
            menuStrip1.Visible = true;
            this.MainMenuStrip = menuStrip2;
            englishToolStripMenuItem.Checked = true;
            UkrToolStripMenuItem.Checked = false;
            UkraToolStripMenuItem1.Checked = false;
            englishToolStripMenuItem1.Checked = true;
            contextMenuStrip2.Enabled = false;
            contextMenuStrip1.Enabled = true;
            richTextBox1.ContextMenuStrip = contextMenuStrip1;
        }
        private void UkrToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menuStrip1.Visible = false;
            menuStrip2.Visible = true;
            this.MainMenuStrip = menuStrip1;
            UkrToolStripMenuItem.Checked = true;
            englishToolStripMenuItem.Checked = false;
            UkraToolStripMenuItem1.Checked = true;
            englishToolStripMenuItem1.Checked = false;
            contextMenuStrip1.Enabled = false;
            contextMenuStrip2.Enabled = true;
            richTextBox1.ContextMenuStrip = contextMenuStrip2;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Karas Liliya Redactor 2020", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|docx files (*.docx)|*.docx";
            openFileDialog1.FilterIndex = 1;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = openFileDialog1.FileName;
                try
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.RichText);
                }
                catch (Exception)
                {
                    richTextBox1.LoadFile(openFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|doc files (*.doc)|*.doc"; ;
            saveFileDialog1.FilterIndex = 1;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                path = saveFileDialog1.FileName;
                IsSave = true;
                if (saveFileDialog1.FilterIndex == 1 || saveFileDialog1.FilterIndex == 3)
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                else
                    richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|doc files (*.doc)|*.doc"; ;
            saveFileDialog1.FilterIndex = 1;
            if (path != "")//вже вказаний шлях
            {
                IsSave = true;
                try
                {
                    richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);
                }
                catch (Exception)
                {
                    richTextBox1.SaveFile(path, RichTextBoxStreamType.PlainText);
                }
            }
            else
            {//вказати шлях файлу

                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    path = saveFileDialog1.FileName;
                    IsSave = true;
                    if (saveFileDialog1.FilterIndex == 1 || saveFileDialog1.FilterIndex == 3)
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                    else
                        richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                }
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Form1_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Hide();
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }

        private void findToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
        }

        public void Findd(string text)
        {
            string text2 = richTextBox1.Text;
            int index = 0;
            while (index < text2.LastIndexOf(text))
            {
                richTextBox1.Find(text, index, RichTextBoxFinds.WholeWord);
                richTextBox1.SelectionBackColor = Color.Yellow;
                index = text2.IndexOf(text, index) + 1;
                searchWord = text;
            }
            richTextBox1.Select(richTextBox1.Text.Length, 0);//курсив на кінець

        }
        public void FindReplace(string word, string newword)
        {
            string text2 = richTextBox1.Text;
            int index = 0;
            while (index < text2.LastIndexOf(word))
            {
                index = richTextBox1.Find(word, index, RichTextBoxFinds.WholeWord);
                richTextBox1.SelectionBackColor = Color.Yellow;
                index += word.Length;
                richTextBox1.SelectedText = newword;
                searchWord = newword;
            }
        }
        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3(this);
            form3.Show();
        }

        private void richTextBox1_MouseLeave(object sender, EventArgs e)
        {
            string text2 = richTextBox1.Text;
            int index = 0;
            if (searchWord != "")
            {
                while (index < text2.LastIndexOf(searchWord))
                {
                    richTextBox1.Find(searchWord, index, RichTextBoxFinds.WholeWord);
                    richTextBox1.SelectionBackColor = Color.White;
                    index = text2.IndexOf(searchWord, index) + 1;
                }
                richTextBox1.Select(richTextBox1.Text.Length, 0);//курсив на кінець
                searchWord = "";
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionFont = fontDialog1.Font;
            }
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionColor = colorDialog1.Color;
            }
        }

        private void backColorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.SelectionBackColor = colorDialog1.Color;
            }
        }

        private void leftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Left;
        }

        private void centerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
        }

        private void rightToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectionAlignment = HorizontalAlignment.Right;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            if (toolStripButton16.Checked)
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), size, FontStyle.Bold);
            else
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), size, FontStyle.Regular);
        }

        private void toolStripButton13_Click(object sender, EventArgs e)
        {
            if (toolStripButton13.Checked)
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), size, FontStyle.Italic);
            else
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), size, FontStyle.Regular);
        }

        private void toolStripButton14_Click(object sender, EventArgs e)
        {
            if (toolStripButton14.Checked)
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), size, FontStyle.Underline);
            else
                richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), size, FontStyle.Regular);
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "Symbols: " + richTextBox1.Text.Length.ToString() + " Row: " + (richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length - 1) + 1) + " Col: " + (richTextBox1.SelectionStart - richTextBox1.GetFirstCharIndexFromLine(richTextBox1.GetLineFromCharIndex(richTextBox1.Text.Length)) + 1);
            IsSave = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (!IsSave)
            {
                saveFileDialog1.Filter = "rtf files (*.rtf)|*.rtf|txt files (*.txt)|*.txt|doc files (*.doc)|*.doc"; ;
                saveFileDialog1.FilterIndex = 1;
                DialogResult result = MessageBox.Show("Do you want to save?", "Save", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    if (path != "")
                    {
                        try
                        {
                            richTextBox1.SaveFile(path, RichTextBoxStreamType.RichText);//2 параметр вказуєм тип який зберігаємо
                        }
                        catch (Exception)
                        {
                            richTextBox1.SaveFile(path, RichTextBoxStreamType.PlainText);
                        }
                    }
                    else
                    {
                        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                        {
                            if (saveFileDialog1.FilterIndex == 1 || saveFileDialog1.FilterIndex == 3)
                                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.RichText);
                            else
                                richTextBox1.SaveFile(saveFileDialog1.FileName, RichTextBoxStreamType.PlainText);
                        }
                    }
                }
            }
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), size, this.Font.Style);
        }

        private void toolStripComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            size = Convert.ToInt32(toolStripComboBox2.SelectedItem);
            richTextBox1.SelectionFont = new Font(toolStripComboBox1.SelectedItem.ToString(), size, this.Font.Style);
        }
    }
}
