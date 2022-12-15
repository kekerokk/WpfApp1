using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WpfApp1
{
    internal class Controller
    {
        private Model _model;

        public Controller(Model model)
        {
            _model = model;
        }
        public void BeverageChoosed(int index)
        {
            _model.BeverageChoose(index);
        }
        public void FoodChoosed(int index)
        {
            _model.FoodChoose(index);   
        }
        public void AdditiveToBeverageChoosed(int index)
        {
            _model.BeverageAdditiveChoose(index);
        }
        public void AdditiveToFoodChoosed(int index)
        {
            _model.FoodAdditiveChoose(index);
        }
        public void ComprehensiveSetChoosed()
        {
            _model.ComprehensiveSetChoose();
        }
        public string GetOrderInfo()
        {
            return _model.GetOrderInfo();
        }
    }
}
