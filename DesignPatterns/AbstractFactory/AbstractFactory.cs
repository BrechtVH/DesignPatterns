namespace DesignPatterns.AbstractFactory
{

    /// <summary>
    /// Factory Pattern Example
    /// 
    /// This example demonstrates the Factory Design Pattern by simulating a barista creating a hot beverage and cold beverage.
    /// The abstract factory pattern is mainly used when having a family of product(IColdBeverage,IHotBeverage) and variants of these products(Coffee, Tea).
    /// The creation of beverages (e.g., Tea, Coffee) is encapsulated in a factory class, decoupling
    /// the object instantiation logic from the client code that consumes these beverages.
    /// 
    /// Benefits:
    /// - Open for extension: Adding a new beverage only requires implementing the IBeverage interface
    ///   and adding a new case in the factory. No changes are needed in the client code (e.g., Person).
    /// - Promotes loose coupling and adherence to SOLID principles.
    /// </summary>

    #region Definitions

    /// <summary>
    /// Product interface A
    /// </summary>
    interface IColdBeverage
    {
        void Prepare();
    }

    /// <summary>
    /// Product interface B
    /// </summary>
    interface IHotBeverage
    {
        void Prepare();
    }

    /// <summary>
    /// Concrete Product A - Cofffee
    /// </summary>
    class IcedCoffee : IColdBeverage
    {
        public void Prepare()
        {
            Console.WriteLine("Iced coffee is being prepared");
        }
    }

    /// <summary>
    /// Concrete Product A - Tea
    /// </summary>
    class IcedTea : IColdBeverage
    {
        public void Prepare()
        {
            Console.WriteLine("Iced tea is being prepared");
        }
    }

    /// <summary>
    /// Concrete Produce B - Coffee
    /// </summary>
    class Coffee : IHotBeverage
    {
        public void Prepare()
        {
            Console.WriteLine("Hot coffee is being prepared");
        }
    }

    /// <summary>
    /// Concrete Produce B - Tea
    /// </summary>
    class Tea : IHotBeverage
    {
        public void Prepare()
        {
            Console.WriteLine("Hot tea is being prepared");
        }
    }
    #endregion

    #region Abstract Factory
    /// <summary>
    /// Abstract Factory Interface
    /// </summary>
    interface IBeverageFactory
    {
        IColdBeverage CreateColdBeverage();
        IHotBeverage CreateHotBeverage();
    }

    /// <summary>
    /// Concrete Factory for Coffee
    /// </summary>
    class CoffeeFactory : IBeverageFactory
    {
        public IColdBeverage CreateColdBeverage()
        {
            return new IcedCoffee();
        }

        public IHotBeverage CreateHotBeverage()
        {
            return new Coffee();
        }
    }

    /// <summary>
    /// Concrete Factory for Tea
    /// </summary>
    class TeaFactory : IBeverageFactory
    {
        public IColdBeverage CreateColdBeverage()
        {
            return new IcedTea();
        }

        public IHotBeverage CreateHotBeverage()
        {
            return new Tea();
        }
    }
    #endregion

    #region Example
    class Barista
    {
        public static void PrepareDrinks(IBeverageFactory factory)
        {
            var hotBeverage = factory.CreateHotBeverage();
            hotBeverage.Prepare();

            var coldBeverage = factory.CreateColdBeverage();
            coldBeverage.Prepare();
        }
    }

    class AbstractFactory
    {
        public static void RunExample()
        {
            Console.WriteLine("Preparing coffee beverages:");
            Barista.PrepareDrinks(new CoffeeFactory());

            Console.WriteLine();

            Console.WriteLine("Preparing tea beverages:");
            Barista.PrepareDrinks(new TeaFactory());
        }
    }
    #endregion
}
