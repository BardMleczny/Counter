using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Counter.Models
{
    class Counter
    {
        public string Name { get; set; }
        public int BaseValue { get; set; }
        public int Value { get; set; }
        public string Color { get; set; }
        public int Id { get; set; }

        public Counter(string name, int baseValue, int value, string color, int id)
        {
            Name = name;
            BaseValue = baseValue;
            Value = value;
            Color = color;
            Id = id;
        }

        //public Microsoft.Maui.Graphics.Color GetColor()
        //{
        //    return new Microsoft.Maui.Graphics.Color(Color.Red, Color.Green, Color.Blue);
        //}
    }
}
