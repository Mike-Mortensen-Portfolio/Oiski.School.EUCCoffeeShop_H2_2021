using Oiski.School.EUCCoffeeShop_H2_2021.Utility;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace Oiski.School.EUCCoffeeShop_H2_2021.GUI
{
    /// <summary>
    /// Interaction logic for StorageWindow.xaml
    /// </summary>
    public partial class RecipeWindow : Window
    {
        private ObservableCollection<string> coffees;

        public RecipeWindow ()
        {
            InitializeComponent ();
            coffees = new ObservableCollection<string> ();

            foreach ( CoffeeShop.Coffee coffee in CoffeeRepo.Link.GetEnumerable () )
            {
                coffees.Add (coffee.Name);
            }

            coffeeList.ItemsSource = coffees;
            coffeeList.SelectedItem = coffeeList.Items[ 0 ];
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

        private void coffeeList_SelectionChanged ( object sender, SelectionChangedEventArgs e )
        {
            if ( sender is ComboBox cmbx )
            {
                CoffeeShop.Coffee cof = CoffeeRepo.Link.GetEnumerable ().ToList ().Find (item => item.Name == cmbx.SelectedItem.ToString ());
                coffeeDisplay.Text = $"Name: {cof.Name}{Environment.NewLine}Description: {cof.Description}{Environment.NewLine}Ingredients:{Environment.NewLine}{cof.GetIngredientsAsString}";
            }
        }
    }
}
