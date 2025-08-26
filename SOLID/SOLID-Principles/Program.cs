using SOLID_Principles.EncapsulateWhatVaries;

namespace SOLID_Principles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Before before = new Before();
            before.OrderPizza(PizzaConstants.CheesePizza);
            Console.WriteLine("-------------------------");
            After after = new After();
            after.OrderPizza(PizzaConstants.CheesePizza);
        }
    }
}
