using KMA.Lab02.Yakovenko.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
