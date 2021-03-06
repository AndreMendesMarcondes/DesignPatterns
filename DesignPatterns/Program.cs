﻿using ChainOfResponsibility;
using ChainOfResponsibility.Chain;
using AbstractFactory;
using Strategy;
using Strategy.Strategy;
using System;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            RunAbstractFactory();
        }

        #region AbstractFactory
        static void RunAbstractFactory()
        {
            new AbstractFactory.Client().Main();
        }

        #endregion

        #region [ Chain ]
        static void RunChain()
        {
            var monkey = new MonkeyHandler();
            var squirrel = new SquirrelHandler();
            var dog = new DogHandler();

            monkey.SetNext(squirrel).SetNext(dog);

            Console.WriteLine("Chain: Monkey > Squirrel > Dog\n");
            ChainOfResponsibility.Client.ClientCode(monkey);
            Console.WriteLine();

            Console.WriteLine("Subchain: Squirrel > Dog\n");
            ChainOfResponsibility.Client.ClientCode(squirrel);
        }
        #endregion

        #region [ Strategy ]
        static void RunStrategy()
        {
            var context = new Context();

            Console.WriteLine("Client: Strategy is set to normal sorting.");
            context.SetStrategy(new ConcreteStrategyA());
            context.DoSomeBusinessLogic();

            Console.WriteLine();

            Console.WriteLine("Client: Strategy is set to reverse sorting.");
            context.SetStrategy(new ConcreteStrategyB());
            context.DoSomeBusinessLogic();
        }
        #endregion
    }
}
