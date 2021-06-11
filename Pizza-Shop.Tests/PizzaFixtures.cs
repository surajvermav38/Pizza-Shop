using System;
using Xunit;
using FluentAssertions;

namespace Pizza_Shop.Tests
{
    public class PizzaFixtures
    {

        [Fact]
        public void Pizza_must_be_added_to_cart_Pizzalist()
        {
            Cart cart = new Cart();
            cart.PizzaList.Add(new Pizza(1, "Corn Pizza", Pizza.Type.Veg, Pizza.Size.Small, 100), 1);
            cart.PizzaList.Count.Should().Be(1);
        }

        [Fact]
        public void Pizza_must_be_added_to_cart()
        {
            Cart cart = new Cart();
            cart.AddPizzaToCart(1, 1);
            cart.PizzaList.Count.Should().Be(1);
        }

        [Fact]
        public void Multiple_pizza_must_be_added_to_cart()
        {
            Cart cart = new Cart();
            cart.AddPizzaToCart(2, 4);
            cart.PizzaList[Menu.PizzaList[2 - 1]].Should().Be(4);
        }

        [Fact]
        public void Multiple_times_same_pizza_must_be_added_to_cart()
        {
            Cart cart = new Cart();
            cart.AddPizzaToCart(2, 1);
            cart.AddPizzaToCart(2, 3);
            cart.PizzaList[Menu.PizzaList[2 - 1]].Should().Be(4);
        }

        [Fact]
        public void Pizza_with_invalid_id_must_not_be_added_to_cart()
        {
            Cart cart = new Cart();
            cart.AddPizzaToCart(999, 4);
            cart.PizzaList.Count.Should().Be(0);
        }

        [Fact]
        public void Pizza_must_get_deleted_from_cart()
        {
            Cart cart = new Cart();
            cart.AddPizzaToCart(1, 1);
            cart.DeletePizzaFromCart(1);
            cart.PizzaList.Count.Should().Be(0);
        }


        [Fact]
        public void Cart_should_get_cleared()
        {
            Cart cart = new Cart();
            cart.AddPizzaToCart(1, 1);
            cart.AddPizzaToCart(2, 5);
            cart.ClearCart();
            cart.PizzaList.Count.Should().Be(0);
        }

        [Fact]
        public void Checkout_should_fail_if_minimum_value_constraint_fails()
        {
            Cart cart = new Cart();
            cart.AddPizzaToCart(1,1);
            cart.CheckOut().Should().BeFalse();
        }

        [Fact]
        public void Checkout_should_pass_if_minimum_value_constraint_satisfied()
        {
            Cart cart = new Cart();
            cart.AddPizzaToCart(1, 3);
            cart.CheckOut().Should().BeTrue();
        }

    }
}
