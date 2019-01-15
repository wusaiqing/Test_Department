using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit.SRC.Design_Pattern
{
    class BuilderPattern
    {
    }
    //Product class
   public class Product 
    {
        IList<string> parts=new List<string>();
        public void add(string part) 
        {
                parts.Add(part);
        }
        public void show()
        {
            for (int i = 0; i < parts.LongCount(); i++) 
            {
                Console.WriteLine(parts[i]);
            }
        }
    }
    //Abstract Builder
    public interface Builder 
    {
         void BuilderHost();
         void BuilderScreen();
         void BuilderMouse();
         void BuilderKeyboard();
         Product GetProduct();
    }
    //Concrete Builder,SuperBuilder
    public class SuperBuilder:Builder 
    {
       private  Product product=new Product();
        public void BuilderHost()
        {
            product.add("超频主机");
        }
        public void BuilderScreen()
        {
            product.add("超大屏幕");
        }
        public void BuilderMouse() 
        {
            product.add("超级系统专用鼠标");
        }
        public void BuilderKeyboard() 
        {
            product.add("超级键盘");
        }
        public Product GetProduct() 
        {
            return product;
        }
    }
    //Concrete Builder,TinyBuilder
    public class TinyBuilder : Builder
    {
        private Product product = new Product();
        public void BuilderHost()
        {
            product.add("微型主机");
        }
        public void BuilderScreen()
        {
            product.add("小型屏幕");
        }
        public void BuilderMouse()
        {
            product.add("超小鼠标");
        }
        public void BuilderKeyboard()
        {
            product.add("微型键盘");
        }
        public Product GetProduct()
        {
            return product;
        }
    }
    //Director
    public class Director 
    {
        void Construct(Builder builder) 
        {
            builder.BuilderHost();
            builder.BuilderScreen();
            builder.BuilderMouse();
            builder.BuilderKeyboard();
        }
        //public static void Main(string[] Args) 
        //{
        //    Director director = new Director();
        //    Builder superBuilder = new SuperBuilder();
        //    Builder tinyBuilder = new TinyBuilder();
        //    director.Construct(superBuilder);
        //    director.Construct(tinyBuilder);
        //    Product product=tinyBuilder.GetProduct();
        //    product.show();
        //    Console.Read();
        //}
    }
}
