using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Задание 6.1
//Запрограммируйте класс Money (объект класса оперирует одной валютой) для работы с деньгами.
//В классе должны быть предусмотрены поле для хранения целой части денег (доллары, евро, гривны и т.д.) и поле
//для хранения копеек (центы, евроценты, копейки и т.д.).
//Реализовать методы для вывода суммы на экран, задания значений для частей.
//На базе класса Money создать класс Product для работы
//с продуктом или товаром. Реализовать метод, позволяющий уменьшить цену на заданное число.
//Для каждого из классов реализовать необходимые методы и поля.
namespace Money1
{
    class Money
    {
        protected int dollar;
        protected int cent;

        public Money(int d = 0, int c = 0)
        {
           
          dollar = d;
          cent = c;
        }

        
        public int  Dollar // Свойство
        {
            get  { return dollar; }
            set
            {
                if (value > 0)
                    dollar = value;
            }
        }
       
        public int Cent 
        {
            get  { return cent; }
            set
            {
                if ( (value > 0) && (value < 100))
                    cent = value;
            }
        }

        public override string ToString()
        {
            return $"Dollars = {dollar} and cents = {cent}";
        }
    }
    class Product : Money
    {
        private string nameProduct;
        public Product() { }
        public Product(string name, int d = 0, int c = 0): base(d,c)
        {
            nameProduct = name;
        }

        public string NameProduct
        {
            get { return nameProduct; }
            set {
                if (value != "")
                    nameProduct = value;
                else
                    throw new Exception("No name");
                 }
        }

        public override string ToString()
        {
            return $"Product {nameProduct} has price {base.ToString()}";
        }
        public void SetPrice()
        { try
            {
                Console.WriteLine("Please specify the product: ");
                NameProduct = Console.ReadLine();
                Console.WriteLine("Please enter a price for product");
                Console.WriteLine("Dollar:");
                Dollar = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("cents:");
                Cent = Convert.ToInt32(Console.ReadLine());
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }
        public void Discount()
        {
        Console.WriteLine("Enter a discount in %:");
        double discount=Convert.ToDouble(Console.ReadLine());
            
            double price = Dollar + Cent * 0.01; //5.35

            price = price - price * discount * 0.01;
            Console.WriteLine(price);
            Dollar = (int)price;

            double res = Math.Round(price, 2);
            Cent = (int)(price * 100) % 100;

        }

    }
    class Program
    {
        static void Main(string[] args)
        {

            Product product = new Product("Milk", 5, 25);
            Console.WriteLine(product);

            product.Discount();
            Console.WriteLine(product);
         //   Console.WriteLine(product.ToString());
            
            Product product1 = new Product();
            product1.SetPrice();
            Console.WriteLine(product1);

        }
    }
}
