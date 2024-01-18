using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstructionMaterials
{
    /// <summary>
    /// Represents a type of brick with its three dimensions and your name
    /// </summary>
    public class Ladrillo
    {
        //PROPIERTIES
        /// <summary>
        /// Brick type name.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The only vertical dimension.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// The shortest horizontal dimension.
        /// </summary>
        public double Width { get; set; }
        /// <summary>
        /// The longest horizontal dimension.
        /// </summary>
        public double Lenght { get; set; }

        //INDEXER
        public double this[int i]
        {
            get
            {
                if (i == 0)
                {
                    return this.Height;
                }
                else if (i == 1)
                {
                    return this.Width;
                }
                else if (i == 2)
                {
                    return this.Lenght;
                }
                throw new Exception();
            }
            set
            {
                if (i == 0)
                {
                    this.Height = value;
                }
                else if (i == 1)
                {
                    this.Width = value;
                }
                else if (i == 2)
                {
                    this.Lenght = value;
                }
                else
                {
                    throw new Exception();
                }
            }
        }

        // CONSTRUCTOR 
        /// <summary>
        /// Create a Ladrillo object from three measurements. 
        /// </summary>
        /// <param name="height">Number that represents your height.</param>
        /// <param name="width">Number that represents your width.</param>
        /// <param name="lenght">Number that represents your lenght.</param>
        public Ladrillo(double height, double width, double lenght)
        {
            this.Height = height;
            this.Width = width;
            this.Lenght = lenght;
        }

        /// <summary>
        /// Creates a Brick object from three measurements and the name of the brick type.
        /// </summary>
        /// <param name="name">String representing the name of the brick type.</param>
        /// <param name="height">Number that represents your height.</param>
        /// <param name="width">Number that represents your width.</param>
        /// <param name="lenght">Number that represents your lenght.</param>
        public Ladrillo(string name, double height, double width, double lenght)
        {
            this.Name = name;
            this.Height = height;
            this.Width = width;
            this.Lenght = lenght;
        }

        /// <summary>
        /// Create brick type from an existing one.
        /// </summary>
        /// <param name="other">The argument that represents the properties of the brick type.</param>
        public Ladrillo(Ladrillo other)
        {
            this.Name = other.Name;
            this.Height = other.Height;
            this.Width = other.Width;
            this.Lenght = other.Lenght;
        }

        //METHODS
        /// <summary>
        /// Add the dimension of the joint to the height.
        /// </summary>
        /// <param name="joint">Mortar joint</param>
        public void AddJointHeight(double joint)
        {
            this.Height += joint;
        }

        /// <summary>
        /// Add the dimension of the joint to the lenght.
        /// </summary>
        /// <param name="joint">Mortar joint.</param>
        public void AddJointLenght(double joint)
        {
            this.Lenght += joint;
        }

        /// <summary>
        /// Add the dimension of the joint to the width.
        /// </summary>
        /// <param name="joint">Mortar joint</param>
        public void AddJointWidth(double joint)
        {
            this.Width += joint;
        }

        //STATIC METHODS
        /// <summary>
        /// Calculate the number of bricks in one linear meter based on a type of brick and joint size.
        /// </summary>
        /// <param name="propierty">This means that you can receive a function that takes a Brick object and returns a double value.(l => l.Lenght)</param>
        /// <param name="ladrillo">It takes an existing type of brick that it will operate with.</param>
        /// <param name="join">Joint size with which it will operate.</param>
        /// <returns>Returns a number of bricks.</returns>
        public static double QuantityInMeter(Func<Ladrillo, double> propierty, Ladrillo ladrillo, double join)
        {
            double medida = propierty(ladrillo);
            if (medida == ladrillo.Lenght)
            {
                return 100 / (ladrillo.Lenght + join);
            }
            else if (medida == ladrillo.Width)
            {
                return 100 / (ladrillo.Width + join);
            }
            else
            {
                return 100 / (ladrillo.Height + join);
            }
        }

        /// <summary>
        /// Calculate the number of bricks in one linear feet based on a type of brick and joint size.
        /// </summary>
        /// <param name="propierty">This means that you can receive a function that takes a Brick object and returns a double value.(l => l.Lenght)</param>
        /// <param name="ladrillo">It takes an existing type of brick that it will operate with.</param>
        /// <param name="join">Joint size with which it will operate.</param>
        /// <returns>Returns a number of bricks.</returns>
        public static double QuantityInFeets(Func<Ladrillo, double> propierty, Ladrillo ladrillo, double join)
        {
            double medida = propierty(ladrillo);
            if (medida == ladrillo.Lenght)
            {
                return 12 / (ladrillo.Lenght + join);
            }
            else if (medida == ladrillo.Width)
            {
                return 12 / (ladrillo.Width + join);
            }
            else
            {
                return 12 / (ladrillo.Height + join);
            }
        }

        //OVERLOADS
        /// <summary>
        /// Returns a string representation of this object. Use the 'override' modifier to tell C#
        /// that you want to use this method to turn objects into strings, rather than the original
        /// one that comes by default with generic objects (you want to override it). 
        /// </summary>
        /// <returns>Prints the name of the brick type, followed by its three measurements.</returns>
        public override string ToString()
        {
            return $"{Name} (height = {Height}, width = {Width}, lenght = {Lenght})";
        }

    }
}
