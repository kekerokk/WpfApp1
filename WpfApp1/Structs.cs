using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Structs
{
    internal struct Food : IMenu
    {
        private string name;
        private int cost;
        public Food(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
        public int GetCost() => cost;
        public string GetName() => name;
    }
    internal struct Beverages : IMenu
    {
        private string name;
        private int cost;
        private string composition = "";
        public Beverages(string name,int cost,string composition)
        {
            this.name = name;
            this.cost = cost;
            this.composition = composition;
        }
        public Beverages(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
        public int GetCost() => cost;
        public string GetName() => name;
        public string GetInfo()=> composition;
    }
    internal struct AdditiveToBeverage : IMenu
    {
        private string name;
        private int cost;
        public AdditiveToBeverage(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
        public int GetCost() => cost;
        public string GetName() => name;
    }
    internal struct AdditiveToFood : IMenu
    {
        private string name;
        private int cost;
        public AdditiveToFood(string name, int cost)
        {
            this.name = name;
            this.cost = cost;
        }
        public int GetCost() => cost;

        public string GetName() => name;
    }
    struct Order // отвечает за состав заказа в деталях
    {
        /*private string name;
        private string composition
        {
            set
            {
                if(composition.Contains("Хлеб") && (composition.Contains("Ветчина") || composition.Contains("Сыр")))
                    name = "Бутерброд";
            }
            get
            {
                return composition;
            }
        }*/
        private Beverages beverage;
        private List<string> additivesToBeverage = new List<string>();
        private Food food;
        private List<string> additivesToFood = new List<string>();

        public Order()
        {
        }
        /*public Order(Beverages beverage)
        {
            this.beverage = beverage;
        }
        public Order(Food food)
        {
            this.food = food;
        }*/
        public void AddBeverageToOrder(Beverages beverage) => this.beverage = beverage;
        public void AddFoodToOrder(Food food) => this.food = food;
        public void AddCompositionToBeverage(string additive) => additivesToBeverage.Add(additive);
        public void AddCompositionToFood(string additive) => additivesToFood.Add(additive);
        public string GetBeverageComposition() => beverage.GetInfo();
        public string GetBeverageName() => beverage.GetName();
        public string GetFoodName() => food.GetName();
        public override string ToString()
        {
            string additivesForBeverage = beverage.GetInfo();
            string additivesForFood = food.GetName();
            string FoodName = food.GetName();

            foreach (string str in additivesToBeverage)
            {
                additivesForBeverage += $" + {str}";
            }

            foreach (string str in additivesToFood)
            {
                additivesForFood += $" + {str}";
            }

            if ((FoodName == "Хлеб" || FoodName == "Булочка") && (additivesForFood.Contains("Ветчина") || additivesForFood.Contains("Сыр")))
            {
                FoodName = "Бутерброд";
            }

            return $"{beverage.GetName()}({additivesForBeverage})\n" +
            $"{FoodName}({additivesForFood})";
        }
    }
    interface IMenu
    {
        public int GetCost();
        public string GetName();
    }
}
