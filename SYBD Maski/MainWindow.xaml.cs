using Microsoft.Data.SqlClient;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SYBD_Maski
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
            //var products = new ObservableCollection<Product>
            //{
            //    new Product { Name = "Продукт 1", Articul = "12345", Description = "Краткое описание 1", Cost = "1000 руб.", ImageSource = "/picture1.png" },
            //    new Product { Name = "Продукт 2", Articul = "67890", Description = "Краткое описание 2", Cost = "2000 руб.", ImageSource = "/picture2.png" },
            //    new Product { Name = "Продукт 3", Articul = "24680", Description = "Краткое описание 3", Cost = "1500 руб.", ImageSource = "/picture3.png" }
            //};

            //// Установка данных для списка
            //TileList.ItemsSource = products;
            Func.LoadData(null);

        }
        int Position = 0;
        private void Window_Activated(object sender, EventArgs e)
        {
            if (Connection.PagesProduct.Count != 0)
                ListTovarov.ItemsSource = Connection.PagesProduct[0];
            else
                MessageBox.Show("Список товаров пуст", "Error");

            int Pages = Connection.PagesProduct.Count;
            if (Pages <= 4) 
            {
                if(Pages != 4)
                {
                    if(Pages != 3)
                    {
                        if(Pages != 2)
                            LinkLab_2.Visibility = Visibility.Hidden;
                        LinkLab_3.Visibility = Visibility.Hidden;
                    }
                    LinkLab_4.Visibility = Visibility.Hidden;
                }
                LinkLab_NEXT.Visibility = Visibility.Hidden;
            }
        }
        private void Action_4(object sender, RoutedEventArgs e)
        {
            ListTovarov.ItemsSource = "";
            ListTovarov.ItemsSource = Connection.PagesProduct[Position + 3];
        }

        private void Action_Next(object sender, RoutedEventArgs e)
        {
            Position += 1;
            HB_1.Inlines.Clear();
            HB_2.Inlines.Clear();
            HB_3.Inlines.Clear();
            HB_4.Inlines.Clear();
            HB_1.Inlines.Add($"{Position + 1}");
            HB_2.Inlines.Add($"{Position + 2}");
            HB_3.Inlines.Add($"{Position + 3}");
            HB_4.Inlines.Add($"{Position + 4}");
            LinkLab_BACK.Visibility = Visibility.Visible;
            if (Position + 4 == Connection.PagesProduct.Count)
            {
                LinkLab_NEXT.Visibility = Visibility.Hidden;
            }
        }

        private void Action_3(object sender, RoutedEventArgs e)
        {
            ListTovarov.ItemsSource = "";
            ListTovarov.ItemsSource = Connection.PagesProduct[Position + 2];
        }

        private void Action_2(object sender, RoutedEventArgs e)
        {
            ListTovarov.ItemsSource = "";
            ListTovarov.ItemsSource = Connection.PagesProduct[Position + 1];
        }

        private void Action_1(object sender, RoutedEventArgs e)
        {
            ListTovarov.ItemsSource = "";
            ListTovarov.ItemsSource = Connection.PagesProduct[Position + 0];
        }

        private void Action_Back(object sender, RoutedEventArgs e)
        {
            Position -= 1;
            HB_1.Inlines.Clear();
            HB_2.Inlines.Clear();
            HB_3.Inlines.Clear();
            HB_4.Inlines.Clear();
            HB_1.Inlines.Add($"{Position + 1}");
            HB_2.Inlines.Add($"{Position + 2}");
            HB_3.Inlines.Add($"{Position + 3}");
            HB_4.Inlines.Add($"{Position + 4}");
            LinkLab_NEXT.Visibility = Visibility.Visible;
            if (Position == 0)
            {
                LinkLab_BACK.Visibility = Visibility.Hidden;
            }

        }

        //private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    string shearch = textBox.Text;
        //    ListTovarov.ItemsSource = null;
        //    Connection.PagesProduct.Clear();
        //    Func.LoadData(shearch);
            
        //}

    }
}