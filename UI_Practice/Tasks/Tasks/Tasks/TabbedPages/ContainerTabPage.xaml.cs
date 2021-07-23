using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tasks.TabbedPages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContainerTabPage : TabbedPage
    {
        public ContainerTabPage()
        {
            InitializeComponent();
        }
    }
}