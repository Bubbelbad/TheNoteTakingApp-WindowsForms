﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace TheNoteTakingApp__Windows_Forms_
{
    public partial class ExportForm : Form
    {

        string filePath;
        string fileName;
        NoteManager noteManager;


        public ExportForm()
        {
            InitializeComponent();
        }


        public void SetManager(NoteManager noteManager1)
        {
            noteManager = noteManager1;
        }


        public string AddFileEnding()
        {
            fileName = fileTextBox.Text + ".txt";
            return fileName;
        }


        //To choose dialog window - choosing directory for file
        private void folderButton_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    filePath = fbd.SelectedPath;
                    folderPathLabel.Text = filePath.ToString();
                    AddFileEnding();
                }
            }
        }


        //Making sure all the info is there before calling noteManager.ExportToText()
        private void exportButton_Click(object sender, EventArgs e)
        {
            if (folderPathLabel.Text != "" && filePath != "" && fileTextBox.Text != "")
            {
                bool status = noteManager.ExportToText(fileName, filePath);
                if (!status)
                {
                    MessageBox.Show("Not a valid file name or folder path - try again");
                    fileTextBox.Text = "";
                    folderPathLabel.Text = "";
                }
                else
                {
                    Close();
                }
            }
            else if (fileTextBox.Text == "")
            {
                fileErrorLabel.Text = "Write a file name";
            }
            else if (folderPathLabel.Text == "")
            {
                directoryErrorLabel.Text = "Choose directory";
            }
        }
    }
}
