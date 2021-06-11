using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Shop
{
   public class Menu
    {
      public static List<Pizza> PizzaList = new List<Pizza> {
          new Pizza(1,"Corn Pizza",Pizza.Type.Veg,Pizza.Size.Small,100),
          new Pizza(2,"Corn Pizza",Pizza.Type.Veg,Pizza.Size.Medium,200),
          new Pizza(3,"Corn Pizza",Pizza.Type.Veg,Pizza.Size.Large,300),
          new Pizza(4,"Chicken Pizza",Pizza.Type.NonVeg,Pizza.Size.Small,150),
          new Pizza(5,"Chicken Pizza",Pizza.Type.NonVeg,Pizza.Size.Medium,250),
          new Pizza(6,"Onion Pizza",Pizza.Type.Veg,Pizza.Size.Small,100),
          new Pizza(7,"Onion Pizza",Pizza.Type.Veg,Pizza.Size.Medium,200),
          new Pizza(8,"Onion Pizza",Pizza.Type.Veg,Pizza.Size.Large,300),
         };

        public static void Show()
        {
            Console.WriteLine("<-MENU->");
            foreach (var pizza in PizzaList) {
                pizza.ShowPizzaDetails();
            }
            
        }

        public static bool ValidatePizzaId(int inputId)
        {
          bool validationResult = false;
          foreach(var pizza in PizzaList)
            {
                if(pizza.Id == inputId)
                { validationResult = true;
                    break;
                }
            }
            return validationResult;
        }
    }
}
