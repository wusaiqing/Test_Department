using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit.SRC
{
    //Simple Factory
    //Drink interface
    public interface Buy
    {
        void NormalBuyDrink();
    }
    public class CoffeeBuy : Buy
    {
        public void NormalBuyDrink()
        {
            Console.WriteLine("买咖啡喝");
        }
    }
    public class ColaBuy : Buy
    {
        public void NormalBuyDrink()
        {
            Console.WriteLine("买可乐喝");
        }
    }
    public class WaterBuy : Buy
    {
        public void NormalBuyDrink()
        {
            Console.WriteLine("买水喝");
        }
    }
    //SimpleFactory
    public class SimpleFactory 
    {
        public static Buy BuyChoice(string a) 
        {
            if (a.Equals("Coffee"))
                return new CoffeeBuy();
            else if (a.Equals("Cola"))
                return new ColaBuy();
            else return new WaterBuy();
        }
    }
    //////工厂方法模式的工厂
    ////public interface Factory
    ////{
    ////    Buy BuyChoice();
    ////}
    //////CoffeeFactory
    ////public class CoffeeFactory : Factory
    ////{
    ////    public Buy BuyChoice()
    ////    {
    ////        return new CoffeeBuy();
    ////    }
    ////}
    //////ColaFactory
    ////public class ColaFactory : Factory
    ////{
    ////    public Buy BuyChoice()
    ////    {
    ////        return new ColaBuy();
    ////    }
    ////}
    //////WaterFactory
    ////public class WaterFactory : Factory
    ////{
    ////    public Buy BuyChoice()
    ////    {
    ////        return new WaterBuy();
    ////    }
    ////}

    public class Choice
    {
        // static void Main(String[] args)
        //{
        //    //顾客在抽象工厂模式下的购买情况
        //    Buy buy = SimpleFactory.BuyChoice("Cola");
        //    Buy buy1 = SimpleFactory.BuyChoice("Coffee");
        //    buy.NormalBuyDrink();
        //    buy1.NormalBuyDrink();
        //}
    }
}
