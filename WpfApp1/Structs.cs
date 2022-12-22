﻿using System;
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
        private List<Beverages> beverageList  = new List<Beverages>();
        private List<string> additivesToBeverage = new List<string>();
        private List<Food> foodList = new List<Food>();
        private List<string> additivesToFood = new List<string>();

        public Order()
        {
        }
        public void AddBeverageToOrder(Beverages beverage) => beverageList.Add(beverage);
        public void AddFoodToOrder(Food food) => foodList.Add(food);
        public void AddCompositionToBeverage(string additive) => additivesToBeverage.Add(additive);
        public void AddCompositionToFood(string additive) => additivesToFood.Add(additive);
        public string GetBeverageComposition(int index) => beverageList[index].GetInfo();
        public string GetBeverageName(int index) => beverageList[index].GetName();
        public string GetFoodName(int index) => foodList[index].GetName();
        public override string ToString()
        {
            string additivesForBeverage = beverage.GetInfo();
            string additivesForFood = food.GetName();
            string beverageName = beverage.GetName();
            string foodName = food.GetName();
            string beverageOrder = "";
            string foodOrder = "";

            foreach (string str in additivesToBeverage)
            {
                additivesForBeverage += $" + {str}";
            }

            foreach (string str in additivesToFood)
            {
                additivesForFood += $" + {str}";
            }

            if ((foodName == "Хлеб" || foodName == "Булочка") && (additivesForFood.Contains("Ветчина") || additivesForFood.Contains("Сыр")))
            {
                foodName = "Бутерброд";
            }
            if(additivesForBeverage != "")
                beverageOrder = $"{beverageName}({additivesForBeverage})\n";
            if (additivesForFood != "")
                foodOrder = $"{foodName}({additivesForFood})";

            return $"{beverageOrder}{foodOrder}";
        }
    }
    interface IMenu
    {
        public int GetCost();
        public string GetName();
    }
}
