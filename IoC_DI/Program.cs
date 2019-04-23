using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IoC_DI
{
    public interface IEngine
    {
        int GetPower();
    }

    public class Engine : IEngine
    {
        public int GetPower()
        {
            return 106;
        }
    }

    public class Car
    {
        private readonly IEngine _engine;
        public string Model { get; set; }
        public string Type { get; set; }

        public Car()
        {

        }
        public Car(IEngine engine)
        {
            _engine = engine;
        }

        public void GetDescription()
        {
            Console.WriteLine($"This car is {Model} {Type}. The engine's horsepower of this car is { _engine.GetPower()} hp.");
        }
    }

    public class MyConfigModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IEngine>().To<Engine>();
            Bind<Car>().ToSelf();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            IKernel ninjectKernel = new StandardKernel(new MyConfigModule());
            var car = ninjectKernel.Get<Car>();
            car.Model = "Renault";
            car.Type = "Megane";
            car.GetDescription();
            Console.ReadLine();

        }
    }
}
