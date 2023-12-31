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
    public partial class ViewPanel : UserControl
    {
        NoteManager NoteManager;
        ToolStripStatusLabel ToolStripStatusLabel1;
        CreatePanel CreatePanel;


        public ViewPanel()
        {
            InitializeComponent();
        }


        //Importing the same Manager as every panel has to edit the notes
        public void SetManager(NoteManager noteManager)
        {
            this.NoteManager = noteManager;
            foreach (Note note in NoteManager.listOfNotes)
            {
                availableListBox.Items.Add($"{note.Title}");
            }
        }


        public void SetCreatePanel(CreatePanel createPanel)
        {
            this.CreatePanel = createPanel;
        }


        public void SetStatusLabel()
        {
            ToolStripStatusLabel1.Text = "view page";
        }


        public void ImportToolStrip(ToolStripStatusLabel toolStripStatusLabel1)
        {
            this.ToolStripStatusLabel1 = toolStripStatusLabel1;
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = availableListBox.SelectedIndex;
            try
            {
                ToolStripStatusLabel1.Text = NoteManager.listOfNotes[index].Category.ToLower();
            }
            catch
            {
                ToolStripStatusLabel1.Text = "";
            }

            if (index > -1)
            {
                Note note = NoteManager.listOfNotes[index];

                title2.Text = note.Title;
                author2.Text = note.Author;
                category2.Text = note.Category;
                note.Message = note.Message.Replace("|", ",");
                note.Message = note.Message.Replace("#", "\r\n");
                messageTextBox.Text = note.Message;
            }
        }


        public void RefreshListBox()
        {
            availableListBox.Items.Clear();
            int index = 0;
            foreach (Note note in NoteManager.listOfNotes)
            {
                try
                {
                    if (note.Title == availableListBox.Items[index].ToString())
                    {
                        index++;
                    }
                }
                catch
                {
                    availableListBox.Items.Add($"{note.Title}");
                    index++;
                }
            }
        }


        //Removes selected note from file, list and listBox
        private void deleteBtn_Click(object sender, EventArgs e)
        {
            int index = availableListBox.SelectedIndex;
            if (index > -1)
            {
                NoteManager.DeleteNoteCSV(index);
                NoteManager.listOfNotes.RemoveAt(index);
                availableListBox.Items.RemoveAt(index);
                RefreshListBox();
                title2.Text = "";
                author2.Text = "";
                category2.Text = "";
                messageTextBox.Clear();
            }
            ToolStripStatusLabel1.Text = "Note successfully deleted";
        }


        //Function to edit existing note. This sends the note to createPanel with all the info. 
        private void editButton_Click(object sender, EventArgs e)
        {
            int index = availableListBox.SelectedIndex;
            if (index > -1)
            {
                CreatePanel.EditNote(NoteManager.listOfNotes[index]);
                CreatePanel.Visible = true;
                Visible = false;
                title2.Text = "";
                author2.Text = "";
                category2.Text = "";
                messageTextBox.Clear();
            }
        }
    }
}
