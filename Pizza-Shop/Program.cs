using System;

namespace Pizza_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("<><> Welcome to Pizza World!! <><>");
            ShowHelp();
            Cart cart = new Cart();
            while (1==1)
            {
                string input = Console.ReadLine();
                if (input.Equals("EXIT"))
                    break;

                switch (input)
                {
                    case "MENU":
                        Menu.Show();
                        break;

                    case "CART":
                        cart.ShowCart();
                        break;

                    case "CHECKOUT":
                        cart.CheckOut();
                        break;

                    case "HELP":
                        ShowHelp();
                        break;

                    case "CLEAR":
                        cart.ClearCart();
                        break;

                    case "DELETE":
                        {
                            if (cart.PizzaList.Count == 0)
                            { Console.WriteLine("Cart is Empty!!");
                            }
                            else
                            {
                                Console.WriteLine("Enter id of Pizza to delete from cart:");
                                int inputId = Convert.ToInt32(Console.ReadLine());
                                if(cart.IsPizzaInCart(inputId) == true)
                                {
                                    cart.DeletePizzaFromCart(inputId);
                                }else
                                {
                                    Console.WriteLine("Pizza does not exist in cart! Enter valid ID");
                                }
                                
                            }   
                        }
                        break;

                    case "ADD":
                        {
                            Console.WriteLine("Enter id of Pizza to add to cart:");
                            int inputId = Convert.ToInt32(Console.ReadLine());
                            if (Menu.ValidatePizzaId(inputId) == true) {
                                if(cart.IsPizzaInCart(inputId)== true)
                                {
                                    Console.WriteLine("This Pizza already exist in cart! How many more to add?");
                                } 
                                else
                                {
                                    Console.WriteLine("How many of this pizza to add?");
                                }
                               
                                int inputCount = Convert.ToInt32(Console.ReadLine());
                                if (inputCount < 0) {
                                    Console.WriteLine("Sorry!Can't add negative values!");
                                }
                                else
                                {
                                    cart.AddPizzaToCart(inputId, inputCount);
                                }
                            }else
                            {
                                Console.WriteLine("Invalid Pizza Id entered!");
                            }
                           
                        }
                        
                        break;
                    default:
                        Console.WriteLine("Enter Valid Command*");
                        break;
                }

            }
          
           
            Console.ReadKey();
        }

        static void ShowHelp()
        {
            Console.WriteLine("Enter the given text to perform actions as given:");
            Console.WriteLine("MENU     --Displays the menu");
            Console.WriteLine("CART     --Displays the current items in cart");
            Console.WriteLine("CLEAR    --Clears the cart");
            Console.WriteLine("ADD      --To add item to cart");
            Console.WriteLine("DELETE   --To delete item from cart");
            Console.WriteLine("CHECKOUT --Places the order from current cart items");
            Console.WriteLine("HELP     --Displays the commands to help");
            Console.WriteLine("EXIT     --Exits the screen");

        }
    }
}
