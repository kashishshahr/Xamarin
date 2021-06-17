
using System;
using System.IO;

using Xamarin.Forms;

namespace Notes.Views
{
    public partial class NotesPage : ContentPage
    {
        string _fileName = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "notes_xamarin.txt");
        public NotesPage()
        {
            InitializeComponent();
            if (File.Exists(_fileName))
            {
                editor.Text = File.ReadAllText(_fileName);
            }
        }

        private void OnSaveBtnClicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, editor.Text);
            DisplayAlert("Alert",
                        "Saved",
                        "OK",_fileName);
        }

        private void OnDeleteBtnClicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
            {
                File.Delete(_fileName);
                DisplayAlert("Alert",
                        "Deleted",
                        "OK");
            }
            editor.Text = string.Empty;
            editor.BackgroundColor = Color.White;

        }

        private void OnTextChange(object sender, TextChangedEventArgs e)
        {
            if (editor.Text == string.Empty)
            {
                editor.BackgroundColor = Color.White;

            }
            else
            {
                editor.BackgroundColor = Color.Black;
            }
        }
    }
}