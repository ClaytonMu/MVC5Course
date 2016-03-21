using System;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace MVC5Course.Models
{
    public class TwoSpaceAtLeastAttribute : DataTypeAttribute
    {
        public TwoSpaceAtLeastAttribute() : base(DataType.Text)
        {

        }

        public override bool IsValid(object value)
        {
            string s = (string)value;

            return s.Count(p => p == ' ') >= 2;
        }
    }
}