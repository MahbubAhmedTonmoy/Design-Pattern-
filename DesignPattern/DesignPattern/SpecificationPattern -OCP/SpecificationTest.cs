using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DesignPattern.SpecificationPattern__OCP
{
    public class SpecificationTest
    {
        [Fact]
        public void SholdReturnGreeenProduct()
        {
            var apple = new Product("Apple", Color.green, Size.S);
            var tree = new Product("tree", Color.green, Size.L);
            var house = new Product("house", Color.red, Size.XL);
            var shop = new Product("shop", Color.blue, Size.S);

            List<Product> products = new List<Product> { apple, tree, house, shop };
            var pf = new ProductFilter();
            var greenProduct = pf.FilterByColor(products, Color.green);
            greenProduct.Count().Should().Be(2);
        }
        [Fact]
        public void SholdReturnGreeenProductBetterResult()
        {
            var apple = new Product("Apple", Color.green, Size.S);
            var tree = new Product("tree", Color.green, Size.L);
            var house = new Product("house", Color.red, Size.XL);
            var shop = new Product("shop", Color.blue, Size.S);

            List<Product> products = new List<Product> { apple, tree, house, shop };
            var pf = new BetterFilter();
            var greenProduct = pf.Filter(products, new ColorSpecification(Color.green));
            greenProduct.Count().Should().Be(2);
        }

        [Fact]
        public void SholdReturnAndBetterResult()
        {
            var apple = new Product("Apple", Color.green, Size.S);
            var tree = new Product("tree", Color.green, Size.L);
            var house = new Product("house", Color.red, Size.XL);
            var shop = new Product("shop", Color.blue, Size.S);

            List<Product> products = new List<Product> { apple, tree, house, shop };
            var pf = new BetterFilter();
            var greenProduct = pf.Filter(products, 
                new AndSpecification<Product>(new ColorSpecification(Color.green),
                new SizeSpecification(Size.S)));
            greenProduct.Count().Should().Be(1);
        }
    }
}
