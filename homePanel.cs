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
    public partial class homePanel : UserControl
    {

        ToolStripStatusLabel statusLabel;

        public homePanel()
        {
            InitializeComponent();
            label1.Text = text1;
        }


        public void ImportToolStrip(ToolStripStatusLabel toolStripStatusLabel1)
        {
            this.statusLabel = toolStripStatusLabel1;
        }


        public void SetStatusLabel()
        {
            statusLabel.Text = "home page";
        }


        string text1 = "This is a Note Taking App made as a school assignment. \n\n" +
                       "It was a great way to practice file handling and trying out \n" +
                       "graphic design in Windows Forms.\n\n" +
                       "The hardest part was understanding how to save message \n" +
                       "as CSV, as it included commas and line change.\n" +
                       "Saving the .txt and .json with a chosen path was also \n" +
                       "a satisfying riddle to solve.\n\n\n\n" +
                       "Make sure to check out the tool strip menu:  \n\n" +
                       "• New Collection - lets the user open, name and create a new \n" +
                       "   file for a empty library\n" +
                       "• Open - lets the user open other CSV-files in the library\n" +
                       "• Export - gives you the possibility to export the current \n  open file to text or json\n";
    }
}
