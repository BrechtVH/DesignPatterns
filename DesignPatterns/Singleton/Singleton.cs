namespace DesignPatterns.Singleton
{
    /// <summary>
    /// Singleton
    /// 
    /// A singleton is a pattern to ensure only one instance is created and provides a global point of access to it.
    /// In this example, we simulate a coffee machine.In a coffee bar, there is usually only one machine due to space limitations.
    /// 
    /// Benefits:
    /// - Ensuring only 1 instance of an object is created.
    /// - Provides a global point of access.
    /// 
    /// Remarks:
    /// - This example is a Naïve singelton, do not use this when it is needed in a multi-threaded environment. If multi-threading is needed, use a thread-safe singleton implementation by usingg a lock to create the object.
    /// </summary>
    
    #region Design Pattern
    /// <summary>
    /// The class that should only be initialized once
    /// </summary>
    class CoffeeMachine
    {
        private Guid Guid { get; set; } // Unique identifier for the coffee machine, this has nothing to do with the singleton pattern, but is used to show that the same instance is used for brewing coffee.

        public CoffeeMachine()
        {
            this.Guid = Guid.NewGuid();
        }

        public void BrewCoffee()
        {
            Console.WriteLine($"Brewing coffee... with machine guid: {Guid}");
        }
    }

    /// <summary>
    /// The singleton pattern for the coffee machine.
    /// </summary>
    class CoffeeMachineSingleton()
    {
        private static CoffeeMachine? _coffeeMachineInstance;

        public CoffeeMachine CoffeeMachine
        {
            get
            {
                if (_coffeeMachineInstance == null)
                    _coffeeMachineInstance = new CoffeeMachine();

                return _coffeeMachineInstance;
            }
        }

        public void BrewCoffee()
        {
            CoffeeMachine.BrewCoffee();
        }

    }
    #endregion

    #region Example

    sealed class Singleton()
    {
        public static void RunExample()
        {
            Console.WriteLine("Running Singleton Example: Coffee Machine");
            Console.WriteLine("Creating the coffee machine singleton");
            Console.WriteLine("Getting the coffee machine");
            var coffeemMachineSingleton = new CoffeeMachineSingleton();

            Console.WriteLine();
            Console.WriteLine("Brewing the first coffee");
            coffeemMachineSingleton.BrewCoffee();
            
            Console.WriteLine("Brewing the second coffee");
            coffeemMachineSingleton.BrewCoffee();

            Console.WriteLine("Both coffees were brewed on the same machine");
        }
    }
    #endregion
}
