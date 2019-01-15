using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit.SRC
{
    ////AbstractFactory Method
    //class AbstractFactory
    //{

    //}
    public interface Food 
    {
        string  GetEatable();
    }
    public class Meat:Food 
    {
        public string GetEatable() 
        {
            return "Meat";
        }
    }
    public class Baozi : Food
    {
        public string GetEatable()
        {
            return "Baozi";
        }
    }
    //public interface TableWare
    //{

    //}
    public interface TableWare 
    {
         string GetTool();
    }
    public class Chopsticks : TableWare 
    {
        public string GetTool() 
        {
            return "Chopsticks";
        }
    }
    public class Spoon : TableWare 
    {
        public string GetTool() 
        {
            return "spoon";
        }
    }
    public interface KitchenFactory 
    {
         Food GetFood();
         TableWare GetTableWare();
    }
    //WestKitchen
    public class WestKitchen :KitchenFactory
    {
        public Food GetFood() 
        {
            return new Meat();
        }
        public TableWare GetTableWare() 
        {
            return new Spoon();
        }
    }
    //EastKitchen
    public class EastKitchen : KitchenFactory
    {
        public Food GetFood() 
        {
            return new Baozi();
        }
        public TableWare GetTableWare() 
        {
            return new Chopsticks();
        }
    }
    public class Customer 
    {
        public void Eat(KitchenFactory k) 
        {
            Console.WriteLine("A Customer use " + k.GetTableWare().GetTool() + " to eat "+k.GetFood().GetEatable());
        }
        //public static void Main(string[] Args) 
        //{
        //    Customer c = new Customer();
        //    KitchenFactory wk = new WestKitchen();
        //    KitchenFactory ek = new EastKitchen();
        //    c.Eat(wk);
        //    c.Eat(ek);
        //    Console.Read();
        //}
    }
}
