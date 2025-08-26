using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Principles.EncapsulateWhatVaries
{
    public class After
    {
        Pizza2 pizza = new CheesePizza2();
        public void OrderPizza(string type)
        {
            Create(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Box();
            Console.WriteLine($"Ordered a {pizza}");
        }
        public void Create(string type)
        {
            switch (type)
            {
                case "cheese":
                    pizza = new CheesePizza2();
                    break;
                case "veggie":
                    pizza = new VegeterianPizza2();
                    break;
                case "chicken":
                    pizza = new ChickenPizza2();
                    break;
                default:
                    throw new ArgumentException($"Unknown pizza type: {type}");
            }
        }
    }
    public class Pizza2
    {
        public virtual string Title => $"{nameof(Pizza2)}";
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

    public class CheesePizza2 : Pizza2
    {
        public override string Title => "Cheese Pizza";
        public override decimal Price => 12m;
        public override string Ingredients => "dough, sauce, cheese";
    }
    public class VegeterianPizza2 : Pizza2
    {
        public override string Title => "Vegeterian Pizza";
        public override decimal Price => 15m;
        public override string Ingredients => "dough, sauce, cheese, veggies";
    }
    public class ChickenPizza2 : Pizza2
    {
        public override string Title => "Chicken Pizza";
        public override decimal Price => 18m;
        public override string Ingredients => "dough, sauce, cheese, chicken";
    }
}
