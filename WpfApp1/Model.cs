using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using WpfApp1.Structs;

namespace WpfApp1
{
    internal class Model
    {
        public Action<Beverages, int> OnBeverageOrderChanging;
        public Action<string, int> OnFoodOrderChanging;
        public Func<int> GettingSugarInfo;

        private int _orderValue = 0,_numberOfAvailableBeverage,_numberOfAvailableFood;
        private bool _isCompSetChoose;

        private Order _order = new Order();
        private readonly List<Beverages> _beveragesList = new List<Beverages>() { new Beverages("Latte",100, "Expresso + Молоко"),
        new Beverages("Cappuccino",100, "Expresso + Молоко + Молочная пенка"),
        new Beverages("Expresso",100,""),
        new Beverages("Чай черный",50,""),
        new Beverages("Чай зеленый",50,"") };
        private readonly List<Food> _foodList = new List<Food>() { new Food("Булочка", 30),
        new Food("Хлеб",10),
        new Food("Джем",40) };
        private readonly List<AdditiveToBeverage> _additiveToBeverageList = new List<AdditiveToBeverage>() { new AdditiveToBeverage("Сахар",0),
        new AdditiveToBeverage("Молоко",15),
        new AdditiveToBeverage("Сироп",15) };
        private readonly List<AdditiveToFood> _additiveToFoodList = new List<AdditiveToFood>() { new AdditiveToFood("Ветчина",20),
        new AdditiveToFood("Сыр",20) };
        //
        /*private List<Product> _products = new List<Product>() { new Product("Latte",100),
        new Product("Cappuccino",100),
        new Product("Expresso",100),
        new Product("Чай черный",50),
        new Product("Чай зеленый",50),

        new Product("Сахар",0),
        new Product("Молоко",15),
        new Product("Сироп",15),

        new Product("Булочка", 30),
        new Product("Хлеб",10),
        new Product("Джем",40),

        new Product("Ветчина",20),
        new Product("Сыр",20) };*/
        public void BeverageChoose(int index)
        {
            string beverage = _beveragesList[index].GetName();
            int cost = _beveragesList[index].GetCost();

            _order.AddBeverageToOrder(_beveragesList[index]);
            OrderCostChange(cost);

            OnBeverageOrderChanging?.Invoke(_beveragesList[index],,_orderValue);
        }
        public void FoodChoose(int index)
        {
            string food = _foodList[index].GetName();
            int cost = _foodList[index].GetCost();

            _order.AddFoodToOrder(_foodList[index]);
            OrderCostChange(cost);

            OnFoodOrderChanging?.Invoke(food, _orderValue);
        }
        public void BeverageAdditiveChoose(int index)
        {
            string additive = _additiveToBeverageList[index].GetName();
            int cost = _additiveToBeverageList[index].GetCost();

            if (additive == "Сахар")
                additive += $"({GettingSugarInfo?.Invoke()})";

            _order.AddCompositionToBeverage(additive);
            OrderCostChange(cost);

            OnBeverageOrderChanging?.Invoke(additive, _orderValue);
        }
        public void FoodAdditiveChoose(int index)
        {
            string additive = _additiveToFoodList[index].GetName();
            int cost = _additiveToFoodList[index].GetCost();

            _order.AddCompositionToFood(additive);
            OrderCostChange(cost);

            OnFoodOrderChanging?.Invoke(additive, _orderValue);
        }
        public void ComprehensiveSetChoose()
        {
            _isCompSetChoose = true;
            _orderValue = 150;
        }
        public void OrderCostChange(int cost)
        {
            if (!_isCompSetChoose)
                _orderValue += cost;
        }
        public string GetOrderInfo()
        {
            return _order.ToString();
        }
    }
}
