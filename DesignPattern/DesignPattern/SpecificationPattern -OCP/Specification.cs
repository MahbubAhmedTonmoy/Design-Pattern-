using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern.SpecificationPattern__OCP
{
    class Specification
    {
    }
    public enum Color
    {
        red = 0, green, blue, yellow
    }
    public enum Size
    {
        S = 1 , M, L, XL, XXL
    }
    public class Product
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        public Size Size { get; set; }
        public Product(string name, Color color, Size size)
        {
            this.Name = name;
            this.Size = size;
            this.Color = color;
        }
    }
    //violate OCP
    public class ProductFilter
    {
        public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
        {
           return products.Where(x => x.Color == color);
        }
        public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
        {
            return products.Where(x => x.Size == size);
        }
        public IEnumerable<Product> FilterByColorAndSize(IEnumerable<Product> products,Color color, Size size)
        {
            return products.Where(x => x.Size == size && x.Color == color);
        }
    }

    public interface ISpecification<T>
    {
        bool IsSatisfied(T t);
    }
    public interface IFIlter<T>
    {
        IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> spec);
    }
    public class BetterFilter : IFIlter<Product>
    {
        public IEnumerable<Product> Filter(IEnumerable<Product> items,
            ISpecification<Product> spec)
        {
            return items.Where(x => spec.IsSatisfied(x));
        }
    }
    public class ColorSpecification : ISpecification<Product>
    {
        private Color color;
        public ColorSpecification(Color color)
        {
            this.color = color;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Color == color;
        }
    }
    public class SizeSpecification : ISpecification<Product>
    {
        private Size size;
        public SizeSpecification(Size size)
        {
            this.size = size;
        }
        public bool IsSatisfied(Product t)
        {
            return t.Size == size;
        }
    }
    public class AndSpecification<T> : ISpecification<Product>
    {
        private ISpecification<Product> color, size;
        public AndSpecification(ISpecification<Product> color, ISpecification<Product> size)
        {
            this.color = color;
            this.size = size;
        }
        public bool IsSatisfied(Product product)
        {
            return color.IsSatisfied(product) && size.IsSatisfied(product);
        }
    }
}
