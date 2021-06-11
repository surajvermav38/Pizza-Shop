using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Shop
{
   public class Pizza
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Size size;

        public int Price { get; set; }

        public Type type;

        public enum Type
        {
            Veg,
            NonVeg
        }
        public enum Size
        {
          Small,
          Medium,
          Large
        }

      public Pizza(int Id,string Name,Type type,Size size,int Price)
        {
            this.Id = Id;
            this.Name = Name;
            this.type = type;
            this.size = size;
            this.Price = Price;
        }
        public void ShowPizzaDetails()
        {
            Console.Write(this.Id + " | ");

            Console.Write(this.type + " | ");

            Console.Write(this.Name+" | ");   

            Console.Write(this.size+" | ");

            Console.Write(this.Price + " | ");
            Console.WriteLine();

        }
    }
}
