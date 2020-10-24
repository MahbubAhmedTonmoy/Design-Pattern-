using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creational.Factory.AbstractFactory
{
    public interface IChair
    {
        public int SeatNumber { get; set; }
    }
    public class ComputerChair : IChair
    {
        public int SeatNumber { get; set; } = 1;
    }
    public class SofaChair : IChair
    {
        public int SeatNumber { get; set; } = 2;
    }
    public interface ITable
    {
        bool HasDrawar();
    }

    public class ComputerTable : ITable
    {
        public bool HasDrawar()
        {
            return true;
        }
    }

    public class DyningTable : ITable
    {
        public bool HasDrawar()
        {
            return false;
        }
    }

    public interface IFurnitureFactory
    {
        IChair CreateChair();
        ITable CreateTable();
    }
    public class HomeFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new SofaChair();
        }

        public ITable CreateTable()
        {
            return new DyningTable();
        }
    }
    public class OfficeFurnitureFactory : IFurnitureFactory
    {
        public IChair CreateChair()
        {
            return new ComputerChair();
        }

        public ITable CreateTable()
        {
            return new ComputerTable();
        }
    }
}
