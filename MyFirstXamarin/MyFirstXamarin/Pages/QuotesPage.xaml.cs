using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MyFirstXamarin
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class QuotesPage : ContentPage
    {
        public int Index { get; set; }
        private string[] Quotes { get; set; }

        public QuotesPage()
        {
            InitializeComponent();
            Quotes = new string[]
            {
                "First quote",
                "Second quote",
                "Third quote",
                "Forthquote"
            };
            Index = 0;
            quotes.Text = Quotes[Index];
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            Index++;
            if (Index > Quotes.Length-1)
            {
                Index = 0;
            }
            quotes.Text = Quotes[Index];
        }
    }
}