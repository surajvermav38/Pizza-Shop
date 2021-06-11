using System;
using System.Collections.Generic;
using System.Text;

namespace Pizza_Shop
{
    public class Cart
    {
        public Dictionary<Pizza, int> PizzaList = new Dictionary<Pizza, int>();
        private int _totalPrice=0;

        public void AddPizzaToCart(int pizzaId, int count)
        {
            if (Menu.ValidatePizzaId(pizzaId) == true)
            {
                if (this.IsPizzaInCart(pizzaId) == true)
                {
                    PizzaList[Menu.PizzaList[pizzaId - 1]] += count;
                }
                else
                {
                    PizzaList.Add(Menu.PizzaList[pizzaId - 1], count);
                }
                UpdateTotalPrice();
                Console.WriteLine("Pizza added to cart successfully! ");
            }

        }

        public void DeletePizzaFromCart(int pizzaId)
        {
            PizzaList.Remove(Menu.PizzaList[pizzaId - 1]);
            UpdateTotalPrice();
            Console.WriteLine("Pizza removed from cart successfully! ");
        }

        public void ShowCart()
        {
            if (PizzaList.Count == 0)
            {
                Console.WriteLine("Cart is Empty!!");
            }
            else
            {
                Console.WriteLine("<-Pizza's in your Cart->");
                foreach (KeyValuePair<Pizza, int> pizza in PizzaList)
                {
                    pizza.Key.ShowPizzaDetails();
                    Console.WriteLine(" X " + pizza.Value);
                }

                Console.WriteLine("Total amount to be paid :" + _totalPrice);
            }

        }

        public void ClearCart()
        {
            PizzaList.Clear();
            UpdateTotalPrice();
            Console.WriteLine("Cart is now Empty!!");
        }

        public Boolean CheckOut()
        {
            UpdateTotalPrice();
            if (_totalPrice < 300)
            {
                Console.WriteLine(" Minimum cart value for order is Rs.300! ");
                Console.WriteLine(" Add items worth Rs." + (300 - _totalPrice) + " more to complete the order.");
                return false;
            }
            else
            {
                Console.WriteLine(" Your order has been placed successfully! ");
                Console.WriteLine(" Summary of your Order--> ");
                ShowCart();
                return true;
            }
        }

        public bool IsPizzaInCart(int pizzaId)
        {
            bool validationResult = false;
            foreach (KeyValuePair<Pizza, int> pizza in PizzaList)
            {
                if (pizza.Key.Id == pizzaId)
                {
                    validationResult = true;
                    break;
                }
            }
            return validationResult;
        }


        #region private methods 

        public void UpdateTotalPrice()
        {
            _totalPrice = 0;
            foreach (KeyValuePair<Pizza, int> pizza in PizzaList)
            {
                _totalPrice += pizza.Key.Price * pizza.Value;
            }
        }
        #endregion 
    }
}
