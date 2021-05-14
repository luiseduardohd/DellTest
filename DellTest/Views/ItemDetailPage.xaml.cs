using System.ComponentModel;
using Xamarin.Forms;
using DellTest.ViewModels;

namespace DellTest.Views
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