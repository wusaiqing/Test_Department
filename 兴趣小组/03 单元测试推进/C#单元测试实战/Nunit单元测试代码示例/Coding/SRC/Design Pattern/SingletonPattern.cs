using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpUnit.SRC.Design_Pattern
{
    public class SingletonPattern
    {
        private static SingletonPattern singleton_instance = null;
        public static SingletonPattern getinstance()
        {
            if (singleton_instance==null)
                singleton_instance=new SingletonPattern();
            return singleton_instance;
        }
    }
}
