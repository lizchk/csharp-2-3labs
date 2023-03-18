using KMA.Lab02.Yakovenko.ViewModels;
using System.Windows.Controls;

namespace KMA.Lab02.Yakovenko.Views
{
    public partial class FormView : UserControl
    {
        private FormViewModel _viewModel;
        public FormView()
        {
            InitializeComponent();
            DataContext = _viewModel = new FormViewModel();
        }
    }
}
