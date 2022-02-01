using System;
using System.Collections.Generic;
using System.Text;

namespace DesignPattern.Creational.Prototype
{
    public class client
    {
        public static void main()
        {
            ProtoTypeExample2 originalObject = new ProtoTypeExample2();
            originalObject.getData();

            Console.WriteLine("clone obj");
            Console.WriteLine("***********************");
            ProtoTypeExample2 cloneObj = (ProtoTypeExample2)originalObject.Clone();

        }
    }
    public class ProtoTypeExample2 : ICloneable
    {
        public string movieName { get; set; }
        public string releaseDate { get; set; }
        public List<string> genre { get; set; }
        public List<string> ratings { get; set; }

        public ProtoTypeExample2()
        {
            Console.WriteLine("default constructor");
        }
        public ProtoTypeExample2(string name, string realeaseDate, List<string> genre, List<string> ratings)
        {
            this.movieName = name;
            this.releaseDate = realeaseDate;
            this.genre = genre;
            this.ratings = ratings;
        }
        public void getData()
        {
            Console.WriteLine("get data external API");
            this.movieName = "dark night";
            this.releaseDate = "2022";
            this.genre.Add("drama");
            this.genre.Add("thriller");
            this.ratings.Add("IMDB:9");
            this.ratings.Add("RottenTomatoes:90");
            this.ratings.Add("MetaCritic:84%");
            Console.WriteLine("you have been charged 1$");
        }

        public object Clone()
        {
            //deep copy
            List<string> deepRating = new List<string>();
            deepRating.AddRange(this.ratings);
            //var cloneobj = (ProtoTypeExample2)this.MemberwiseClone(); // shollow
            //return cloneobj;
            return new ProtoTypeExample2(this.movieName, this.releaseDate, this.genre, deepRating); // 3 shollw, 1 deep 
        }
    }

    //https://levelup.gitconnected.com/5-ways-to-clone-an-object-in-c-d1374ec28efa
    /*
     * But before we start, I want to remind you about a shallow and deep copy concepts 
     * in .NET. Shallow copy has its own value types, but it shares reference types with
     * the original object. A deep copy has own value and reference types, that is, it 
     * is completely disconnected from the original object. A software engineer can create
     * a shallow copy simply by calling MemberwiseClone method, but a deep copy requires
     * some additional custom code to be written.
     */
}
