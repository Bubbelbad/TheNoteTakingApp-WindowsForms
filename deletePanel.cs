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
    public partial class deletePanel : UserControl
    {
        NoteManager NoteManager = null;
        public deletePanel()
        {
            InitializeComponent();
        }

        public void SetManager(NoteManager noteManager)
        {
            this.NoteManager = noteManager;
        }
    }
}