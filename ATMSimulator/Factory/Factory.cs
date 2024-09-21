// namespace ATMSimulator.Factory;
//
// class Client
// {
//     public void Main()
//     {
//         ClientCode(new ConcreteCreator1());
//         Console.WriteLine("");
//
//         Console.WriteLine("App: Launched with the ConcreteCreator2.");
//         ClientCode(new ConcreteCreator2());
//     }
//
//     // The client code works with an instance of a concrete creator, albeit
//     // through its base interface. As long as the client keeps working with
//     // the creator via the base interface, you can pass it any creator's
//     // subclass.
//     public void ClientCode(OptionFactory optionFactory)
//     {
//         optionFactory.BuildOption();
//     }
// }