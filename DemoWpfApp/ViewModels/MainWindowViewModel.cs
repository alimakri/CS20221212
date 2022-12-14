using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using DemoWpfApp.Bases;
using DemoWpfApp.Models;

namespace DemoWpfApp.ViewModels
{
    class MainWindowViewModel
    {
        #region Bindings
        public string Utilisateur { get; set; } = "Ali MAKRI";
        public List<PersonneModel> ListePersonne { get; set; }
        public PersonneModel PersonneSelect { get; set; }
        #endregion
        public ICommand OkCommand{ get; set;}
        public MainWindowViewModel()
        {
            // Command
            OkCommand = new RelayCommand(Ok, o=>true);  

            // Init
            ListePersonne = new List<PersonneModel>
            {
                new PersonneModel {Id= 1, Nom="Alice", Ville="Roman", Photo="Alice.png" },
                new PersonneModel {Id= 2, Nom="Morgane", Ville="marseille", Photo="morgane.png" },
                new PersonneModel {Id= 3, Nom="Denis", Ville="Villeurbanne", Photo="denis.png" }
            };

        }

        private void Ok(object obj)
        {
            MessageBox.Show("Hello");
        }
    }
}
