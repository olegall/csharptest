using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Operators
    {
        #region NULL CONDITIONAL
        class NullConditional_
        {
            public string Prop1 { get; set; } = "asd";
        }

        public void NullConditional()
        {
            NullConditional_ nc = null;
            // null, т.к. nc = null, Prop1 = "asd". не упадёт
            var a2 = nc?.Prop1;

            try
            {
                var a3 = nc.Prop1;
            }
            catch
            {
                // упадёт
            }

            nc = new NullConditional_();
            // не упадёт. значение свойства
            var a4 = nc?.Prop1;

            // не упадёт. значение свойства
            var a5 = nc.Prop1;
        }
        #endregion

        #region NULL COALESCING
        public void NullCoalescing()
        {
            object obj = null;
            var a1 = obj ?? 100; // 100
            //var a2 = obj ??= 100; // 100 // для нового C#
            obj = new object();
            var a3 = obj ?? 100; // {object}
            //var a4 = obj ??= 100; // {object} // для нового C#

            object value = null; // "aaa"
            try
            {
                var a5 = value ?? throw new ArgumentNullException(nameof(value), "Name cannot be null");
            }
            catch
            {
            }
        }
        #endregion
    }
}
