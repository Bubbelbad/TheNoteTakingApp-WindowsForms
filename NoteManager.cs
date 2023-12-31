﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TheNoteTakingApp__Windows_Forms_
{
    public class NoteManager
    {

        public List<Note> listOfNotes = new List<Note>();
        public static string path = "notes.csv";


        public void CreateNote (string author, string title, string category, bool secret, string message)
        {
            listOfNotes.Add(new Note(author, title, category, secret, message));
        }


        //Sending the info to CreatePanel, to edit and save the edited note
        public void ReplaceEditedNote(int editId, string author, string title, string category, bool secret, string message)
        {
            foreach (Note note in listOfNotes)
            {
                if (note.Id == editId)
                {
                    note.Author = author;
                    note.Title = title;
                    note.Category = category;
                    note.Secret = secret;
                    note.Message = message;
                }
            }
            File.Create(path).Close(); //Erasing all the previous text in path
            using (StreamWriter sw = new StreamWriter(path, true)) //Rewriting with the edited note updated.
            {
                foreach (Note note in listOfNotes)
                {
                    sw.WriteLine(note.GetCSV());
                }
            }
            Load();
        }


        //Save the most recent created note in CSV
        public void SaveRecentNote()
        {
            StreamWriter streamWriter = new StreamWriter(path, true); //Boolean here is to append instead of overwrite
            int index = listOfNotes.Count - 1;
            streamWriter.WriteLine(listOfNotes[index].GetCSV());
            streamWriter.Close();
        }


        //To load all notes from CSV-file
        public void Load()
        {
            listOfNotes.Clear();
            using (StreamReader reader = new StreamReader(path))
            {
                string line = reader.ReadLine();
                try
                {
                    while (line != null)
                    {
                        string[] strings = line.Split(",");
                        string author = strings[1];
                        string title = strings[2];
                        string category = strings[3];
                        bool secret = Convert.ToBoolean(strings[4]);
                        string message = strings[5];
                        message.Replace("|", ","); //Here I convert back the symbols from the CSV that I changed, so the reading is correct.
                        message.Replace("#,", "\r\n");

                        Note note = new Note(author, title, category, secret, message);
                        listOfNotes.Add(note);

                        line = reader.ReadLine();
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }


        public void DeleteNoteCSV(int index)
        {
            List<string> linesList = File.ReadAllLines(path).ToList();
            try
            {
                linesList.RemoveAt(index);
                File.WriteAllLines(path, linesList);
            }
            catch
            {
                return;
            }   
        }


        //Exporting opened file to chosen directory
        public bool ExportToText(string fileName, string location)
        {
            string file = System.IO.Path.Combine(location, fileName);
            try
            {
                System.IO.File.Create(file).Close();
                using (StreamWriter sw = new StreamWriter(file)) //Rewriting with the edited note updated.
                {
                    foreach (Note note in listOfNotes)
                    {
                        sw.WriteLine(note.GetText());
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        //Exporting chosen file to json
        public bool ExportToJson(string fileName, string location)
        {
            string file = System.IO.Path.Combine(location, fileName);
            try
            {
                System.IO.File.Create(file).Close();
                using (StreamWriter sw = new StreamWriter(file)) //Rewriting with the edited note updated.
                {
                    foreach (Note note in listOfNotes)
                    {
                        sw.WriteLine(note.GetJson());
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }


        //Changing path to read and save the new chosen CSV-file
        public void ChangePath(string newPath)
        {
            path = newPath;  
        }
    }
}
