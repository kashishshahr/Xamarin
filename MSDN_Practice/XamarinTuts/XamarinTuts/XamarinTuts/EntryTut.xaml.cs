using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XamarinTuts
{
    public partial class EntryTut : ContentPage
    {
        public EntryTut()
        {
            InitializeComponent();
        }

        void OnEntryTextChanged(object sender, TextChangedEventArgs e)
        {

            string oldText = e.OldTextValue;
            string newText = e.NewTextValue;
            label.Text = oldText;
            label1.Text = newText;
            if (label.TextColor == Color.Blue)
            {
                label.TextColor = Color.Gray;

            }
        }

        void OnEntryCompleted(object sender, EventArgs e)
        {
            string text = ((Entry)sender).Text;
            label.Text = "Done";
            if(label.TextColor!=Color.Blue)
                label.TextColor =Color.Blue;
            label1.Text = "";
            
        }
    }
}