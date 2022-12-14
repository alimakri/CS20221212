using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DemoWpfApp.Bases;

namespace DemoWpfApp.ViewModels
{
    class MainWindowViewModel
    {
        public string Utilisateur { get; set; } = "Ali MAKRI";
        public ICommand OkCommand{ get; set;}
        public MainWindowViewModel()
        {
            OkCommand = new RelayCommand();
        }
    }
}
