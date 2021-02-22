using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
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
using Oiski.Common.Repository;
using Oiski.School.EUCCoffeeShop_H2_2021.CoffeeShop;
using Oiski.School.EUCCoffeeShop_H2_2021.Utility;

namespace Oiski.School.EUCCoffeeShop_H2_2021.GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// Initialize a new instance of type <see cref="MainWindow"/>
        /// </summary>
        public MainWindow ()
        {
            InitializeComponent ();

            if ( !File.Exists (CoffeeRepo.filePath) )   //  Build the Coffee Recipes if it does not exist
            {
                BuildCoffees ();
            }
        }

        private void OnWindowClosing ( object _sender, CancelEventArgs _e )
        {
            _e.Cancel = true;

            if ( _sender is Window window )
            {
                window.Hide ();
            }
        }

        private void MissingLogic ( object _sender, RoutedEventArgs _r )
        {
            if ( _r.Source is Button btn && btn.Command == null && btn.CommandParameter == null )
            {
                btn.IsEnabled = false;
                MessageBox.Show ("No Commands Attached");
            }

            _r.Handled = true;
        }

        /// <summary>
        /// Build recipes
        /// </summary>
        private void BuildCoffees ()
        {
            Ingredient beans = new Ingredient ("Coffee Beans");
            Ingredient milk = new Ingredient ("Milk");
            Ingredient choco = new Ingredient ("Chocolate");

            Coffee latte = new Coffee ()
            {
                Name = "Latte",
                Description = "Latte Latte Latte"
            };

            latte.Ingredients.Add (beans);
            latte.Ingredients.Add (milk);

            Coffee espresso = new Coffee ()
            {
                Name = "Espresso",
                Description = "Direkte i blodbanen"
            };

            espresso.Ingredients.Add (beans);

            Coffee mocha = new Coffee ()
            {
                Name = "Mocha",
                Description = "Because you're worth it!"
            };

            mocha.Ingredients.Add (beans);
            mocha.Ingredients.Add (milk);
            mocha.Ingredients.Add (choco);

            CoffeeRepo.Link.InsertData (latte);
            CoffeeRepo.Link.InsertData (espresso);
            CoffeeRepo.Link.InsertData (mocha);
        }
    }
}
