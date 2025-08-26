using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles.EncapsulateWhatVaries
{
    public class Before
    {
        Pizza pizza = new CheesePizza();
        public void OrderPizza(string type)
        {
            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza();
                    break;
                case "veggie":
                    pizza = new VegeterianPizza();
                    break;
                case "chicken":
                    pizza = new ChickenPizza();
                    break;
                default:
                    throw new ArgumentException($"Unknown pizza type: {type}");
            }
            pizza.Prepare();
            pizza.Bake();
            pizza.Box();
            Console.WriteLine($"Ordered a {pizza}");
        }
    }
    public class  Pizza
    {
        public virtual string Title => $"{nameof(Pizza)}";
        public virtual decimal Price => 10m;
        public virtual string Ingredients => "dough, sauce, cheese";
        public void Prepare()
        {
            Console.WriteLine($"Preparing {Title}");
            Console.WriteLine($"Adding ingredients: {Ingredients}");
        }
        public void Bake()
        {
            Console.WriteLine("Baking pizza at 350 degrees for 25 minutes.");
        }
        public void Box()
        {
            Console.WriteLine("Placing pizza in official PizzaStore box.");
        }
        public override string ToString()
        {
            return $"{Title} : {Price:C}";
        }

    }

    public class CheesePizza : Pizza
    {
        public override string Title => "Cheese Pizza";
        public override decimal Price => 12m;
        public override string Ingredients => "dough, sauce, cheese";
    }
    public class VegeterianPizza : Pizza
    {
        public override string Title => "Vegeterian Pizza";
        public override decimal Price => 15m;
        public override string Ingredients => "dough, sauce, cheese, veggies";
    }
    public class ChickenPizza : Pizza
    {
        public override string Title => "Chicken Pizza";
        public override decimal Price => 18m;
        public override string Ingredients => "dough, sauce, cheese, chicken";
    }
}
