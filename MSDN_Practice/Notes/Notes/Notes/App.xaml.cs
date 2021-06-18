using System;
using System.IO;
using Notes.Data;
using Xamarin.Forms;

namespace Notes
{
    public partial class App : Application
    {
        static NoteDatabase _database;

        // Create the _database connection as a singleton.
        public static NoteDatabase Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new NoteDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}