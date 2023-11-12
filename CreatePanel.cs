﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheNoteTakingApp__Windows_Forms_
{
    public partial class CreatePanel : UserControl
    {
        NoteManager NoteManager = null;
        ToolStripStatusLabel ToolStripStatusLabel1 = null;


        public CreatePanel()
        {
            InitializeComponent();
        }


        public void SetManager(NoteManager noteManager)
        {
            this.NoteManager = noteManager;
        }


        public void ImportToolStrip(ToolStripStatusLabel toolStripStatusLabel1)
        {
            this.ToolStripStatusLabel1 = toolStripStatusLabel1;
        }


        //Function to save the current written note: 
        private void button1_Click(object sender, EventArgs e)
        {
            string author = authorTextBox.Text;
            string title = titleTextBox.Text;
            string category = categoryComboBox.Text;
            string message = messageTextBox.Text;
            message = message.Replace(",", "|");
            message = message.Replace("\r\n", "#");
            bool secret = false;
            if (secretCheckBox.Checked)
            {
                secret = true;
            }

            NoteManager.CreateNote(author, title, category, secret, message);
            NoteManager.SaveRecentNote();
            ToolStripStatusLabel1.Text = "Success!";

            authorTextBox.Clear();
            titleTextBox.Clear();
            categoryLabel.ResetText();
            messageTextBox.Clear();
            secretCheckBox.Checked = false;
        }
    }
}