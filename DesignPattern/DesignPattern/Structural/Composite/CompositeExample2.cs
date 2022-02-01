using System;
using System.Collections.Generic;
using System.Text;

/// <summary>
/// 3 Components are exists here. i) Component: A interface ii) Composit: A children who can
/// store other children(Node/Leaf) iii) Leaf: A children implement Component
/// ছোট ছোট অবজেক্ট নিয়ে কমপ্লেক্স অবজেক্ট হয়। 
/// অবজেক্ট গুলো ট্রি স্ট্রাকচার এ থাকে, কাজ করে এমন  ভাবে যেনো  মনে হয় তারা আলাদা অবজেক্ট
/// </summary>
namespace DesignPattern.Structural.Composite
{
    public interface IComponent
    {
        void DisplayPrice();
    }
    public class Leaf : IComponent
    {
        public int Price { get; set; }
        public string Name { get; set; }
        public Leaf(string name, int price)
        {
            this.Name = name;
            this.Price = price;
        }

        public void DisplayPrice()
        {
            Console.WriteLine($"{this.Name} price: {this.Price}");
        }
    }

    ///use Builder patter when large Composite tree
    ///use iterators to traverse Composite tree
    ///use Visitor to execute an operation over an entire Composite tree
    ///
    public class Composite : IComponent
    {
        private string Name { get; set; }
        List<IComponent> components = new List<IComponent>();
        public Composite(string name)
        {
            this.Name = name;
        }
        public void AddComponent(IComponent component)
        {
            components.Add(component);
        }

        public void DisplayPrice()
        {
            Console.WriteLine(Name);
            foreach (var item in components)
            {
                item.DisplayPrice();
            }
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {

            //Creating Leaf Objects
            IComponent hardDisk = new Leaf("Hard Disk", 2000);
            IComponent ram = new Leaf("RAM", 3000);
            IComponent cpu = new Leaf("CPU", 2000);
            IComponent mouse = new Leaf("Mouse", 2000);
            IComponent keyboard = new Leaf("Keyboard", 2000);
            //Creating composite objects
            Composite motherBoard = new Composite("Peripherals");
            Composite cabinet = new Composite("Cabinet");
            Composite peripherals = new Composite("Peripherals");
            Composite computer = new Composite("Computer");
            //Creating tree structure
            //Ading CPU and RAM in Mother board
            motherBoard.AddComponent(cpu);
            motherBoard.AddComponent(ram);
            //Ading mother board and hard disk in Cabinet
            cabinet.AddComponent(motherBoard);
            cabinet.AddComponent(hardDisk);
            //Ading mouse and keyborad in peripherals
            peripherals.AddComponent(mouse);
            peripherals.AddComponent(keyboard);
            //Ading cabinet and peripherals in computer
            computer.AddComponent(cabinet);
            computer.AddComponent(peripherals);
            //To display the Price of Computer
            computer.DisplayPrice();
            Console.WriteLine();
            //To display the Price of Keyboard
            keyboard.DisplayPrice();
            Console.WriteLine();
            //To display the Price of Cabinet
            cabinet.DisplayPrice();
            Console.Read();
        }
    }
}
