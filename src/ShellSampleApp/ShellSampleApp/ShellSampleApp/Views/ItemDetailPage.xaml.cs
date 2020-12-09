using ShellSampleApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace ShellSampleApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}