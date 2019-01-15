using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit.SRC
{
    ////由于工厂模式和抽象工厂模式里面的类名都是一致的，因此需要注释掉其中一个，以免发生冲突
    //class FactoryMethod
    //{
    //}
    ////Simple Factory
    ////Drink interface
    //public interface Buy
    //{
    //    void NormalBuyDrink();
    //    void SportsBuyDrink();
    //}
    //public class CoffeeBuy : Buy
    //{
    //    public void NormalBuyDrink()
    //    {
    //        Console.WriteLine("买咖啡喝");
    //    }
    //    public void SportsBuyDrink()
    //    {
    //        Console.WriteLine("买运动型咖啡喝");
    //    }
    //}
    //public class ColaBuy : Buy
    //{
    //    public void NormalBuyDrink()
    //    {
    //        Console.WriteLine("买可乐喝");
    //    }
    //    public void SportsBuyDrink()
    //    {
    //        Console.WriteLine("买运动型可乐喝");
    //    }
    //}
    //public class WaterBuy : Buy
    //{
    //    public void NormalBuyDrink()
    //    {
    //        Console.WriteLine("买水喝");
    //    }
    //    public void SportsBuyDrink()
    //    {
    //        Console.WriteLine("买运动型矿泉水喝");
    //    }
    //}
    ////工厂方法模式的工厂
    //public interface Factory
    //{
    //    Buy BuyChoice();
    //}
    ////CoffeeFactory
    //public class CoffeeFactory : Factory
    //{
    //    public Buy BuyChoice()
    //    {
    //        return new CoffeeBuy();
    //    }
    //}
    ////ColaFactory
    //public class ColaFactory : Factory
    //{
    //    public Buy BuyChoice()
    //    {
    //        return new ColaBuy();
    //    }
    //}
    ////WaterFactory
    //public class WaterFactory : Factory
    //{
    //    public Buy BuyChoice()
    //    {
    //        return new WaterBuy();
    //    }
    //}

    ////note:Because of the Main method can only have one in program,it's commented;
    //public class Choice
    //{
        //static void Main(String[] args)
        //{
        //    ////顾客在抽象工厂模式下的购买情况
        //    //Buy buy = SimpleFactory.BuyDrink("Cola");
        //    //Buy buy1 = SimpleFactory.BuyDrink("Coffee");
        //    //buy.BuyDrink();
        //    //buy1.BuyDrink();
        //    //顾客在工厂模式下的购买情况
        //    Console.WriteLine("以下为工厂模式");
        //    WaterFactory factory = new WaterFactory();
        //    Buy buy2 = factory.BuyChoice();
        //    buy2.NormalBuyDrink();
        //    buy2.SportsBuyDrink();
        //    Console.Read();
        //}
    //}
}
