using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.Structs;

namespace WpfApp1
{
    public partial class MainWindow : Window
    {
        private Controller _controller;

        
        public MainWindow()
        {
            InitializeComponent();
            ComprehensiveSet.Content = $"{ComprehensiveSet.Content}.\nнапиток с добавкой\n+ еда с добавкой";

            Model model = new Model();
            _controller = new Controller(model);

            model.OnBeverageOrderChanging += RefreshBeverageOrder;
            model.OnFoodOrderChanging += RefreshFoodOrder;
        }
        private void BeverageSelect(object sender, RoutedEventArgs e)
        {
            Button btn;
            if (sender is Button)
                btn = (Button)sender;
            else
            {
                MessageBox.Show("This is not Button");
                return;
            }

            DisableBeverages();
            EnableBeverageAdditives(Convert.ToString(btn.Content));

            _controller.BeverageChoosed(Convert.ToInt16(btn.Tag));
        }
        private void FoodSelect(object sender, RoutedEventArgs e)
        {
            Button btn;
            if (sender is Button)
                btn = (Button)sender;
            else
            {
                MessageBox.Show("This is not Button");
                return;
            }

            DisableFood();
            EnableFoodAdditives(Convert.ToString(btn.Content));

            _controller.FoodChoosed(Convert.ToInt16(btn.Tag));
        }
        private void AdditiveToBeverageSelect(object sender, RoutedEventArgs e)
        {
            Button btn;
            if (sender is Button)
                btn = (Button)sender;
            else
            {
                MessageBox.Show("This is not Button");
                return;
            }

            btn.IsEnabled = false;

            _controller.AdditiveToBeverageChoosed(Convert.ToUInt16(btn.Tag));
        }
        private void AdditiveToFoodSelect(object sender, RoutedEventArgs e)
        {
            Button btn;
            if (sender is Button)
                btn = (Button)sender;
            else
            {
                MessageBox.Show("This is not Button");
                return;
            }

            btn.IsEnabled = false;
            if (btn.Name == "AddSugar")
            {
                PlusSugar.IsEnabled = false;
                MinusSugar.IsEnabled = false;
            }

            _controller.AdditiveToFoodChoosed(Convert.ToUInt16(btn.Tag));
        }
        private void SugarChanging(object sender, RoutedEventArgs e)
        {
            Button btn;
            if (sender is Button)
                btn = (Button)sender;
            else
            {
                MessageBox.Show("This is not Button");
                return;
            }

            int SugarPortions = Convert.ToInt16(PortionsOfSugar.Text);
            if (Convert.ToString(btn.Content) == "+")
            {
                SugarPortions++;
                if(SugarPortions == 5)
                    PlusSugar.IsEnabled = false;
                MinusSugar.IsEnabled = true;
            }
            if (Convert.ToString(btn.Content) == "-")
            {
                SugarPortions--;
                if (SugarPortions == 0)
                    MinusSugar.IsEnabled = false;
                PlusSugar.IsEnabled = true;
            }
            PortionsOfSugar.Text = Convert.ToString(SugarPortions);
        }
        private void GetOrder(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(_controller.GetOrderInfo());
        }

        private void DisableBeverages()
        {
            ComprehensiveSet.IsEnabled = false;
            AddLatteButton.IsEnabled = false;
            AddCappuccinoButton.IsEnabled = false;
            AddExpressoButton.IsEnabled = false;
            AddBlackTeaButton.IsEnabled = false;
            AddGreenTeaButton.IsEnabled = false;
        }
        private void DisableFood()
        {
            ComprehensiveSet.IsEnabled = false;
            AddBun.IsEnabled = false;
            AddBread.IsEnabled = false;
            AddJam.IsEnabled = false;
        }
        private void EnableFoodAdditives(string foodName)
        {
            if (foodName == "Булочка" || foodName == "Хлеб")
            {
                AddCheese.IsEnabled = true;
                AddHam.IsEnabled = true;
            }
        }
        private void EnableBeverageAdditives(string beverageName)
        {
            if (beverageName == "Cappuccino")
            {
                AddSugar.IsEnabled = true;
                PlusSugar.IsEnabled = true;
                AddSyrup.IsEnabled = true;
            }
            else
            {
                AddSugar.IsEnabled = true;
                PlusSugar.IsEnabled = true;
                AddMilk.IsEnabled = true;
                AddSyrup.IsEnabled = true;
            }
        }
        private void RefreshBeverageOrder(string productName,int cost)
        {
            OrderBeverageText.Text += $"{productName}\n" ;
            OrderValue.Text = $"{cost}";
        }
        private void RefreshFoodOrder(string productName, int cost)
        {
            OrderFoodText.Text += $"{productName}\n";
            OrderValue.Text = $"{cost}"; 
        }
    }
}
