namespace DesignPatterns.Factory
{

    /// <summary>
    /// Factory Pattern Example
    /// 
    /// This example demonstrates the Factory Design Pattern by simulating a beverage preparation system.
    /// The creation of beverages (e.g., Tea, Coffee) is encapsulated in a factory class, decoupling
    /// the object instantiation logic from the client code that uses these beverages.
    /// 
    /// Benefits:
    /// - Open for extension: Adding a new beverage only requires implementing the IBeverage interface
    ///   and adding a new case in the factory. No changes are needed in the client code (e.g., Person).
    /// - Promotes loose coupling and adherence to SOLID principles.
    /// </summary>

    #region Definitions
    enum BeverageType
    {
        Coffee,
        Tea
    }

    /// <summary>
    /// In the factory pattern the common functions can be defined in an interface or an abstract class
    /// </summary>
    interface IBeverage
    {
        void Prepare();
    }

    /// <summary>
    /// Concrete implementation of a Tea beverage.
    /// </summary>
    class Tea : IBeverage
    {
        public void Prepare()
        {
           Console.WriteLine("Tea is being prepared");
        }
    }

    /// <summary>
    /// Concrete implementation of a Coffee beverage.
    /// </summary>
    class Coffee : IBeverage
    {
        public void Prepare()
        {
            Console.WriteLine("Coffee is being prepared");
        }
    }
    #endregion

    #region Factory
    /// <summary>
    /// Factory class responsible for creating instances of beverages based on the specified type.
    /// </summary>
    class BeverageFactory
    {
        public static IBeverage CreateBeverage(BeverageType type)
        {
            switch (type)
            {
                case BeverageType.Coffee:
                    return new Coffee();
                case BeverageType.Tea:
                    return new Tea();
                default:
                    throw new ArgumentException("Invalid beverage type");
            }
        }
    }
    #endregion

    #region Example
    class Person
    {
        public void PrepareDrink(BeverageType beverageType)
        {
            BeverageFactory.CreateBeverage(beverageType).Prepare();
        }
    }

    class Factory
    {
        public static void RunExample()
        {
            var person = new Person();
            person.PrepareDrink(BeverageType.Coffee);
            person.PrepareDrink(BeverageType.Tea);
        }
    }
    #endregion
}
