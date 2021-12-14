using System;

namespace ConsoleApp1
{
    class Operators
    {
        #region NULL CONDITIONAL
        class NC
        {
            public string Prop1 { get; set; } = "asd";
        }

        public void NullConditional()
        {
            NC nc = null;
            // null, т.к. nc = null, Prop1 = "asd". не упадёт
            var a2 = nc?.Prop1;

            try
            {
                var a3 = nc.Prop1; // NullReferenceException
            }
            catch (NullReferenceException e)
            {
                // упадёт
            }

            nc = new NC();
            
            var a4 = nc?.Prop1; // не упадёт. значение свойства
            var a5 = nc.Prop1; // не упадёт. значение свойства
        }
        #endregion

        #region NULL COALESCING
        // The null-coalescing operator ?? returns the value of its left-hand operand if it isn't null;
        // otherwise, it evaluates the right-hand operand and returns its result
        public void NullCoalescing()
        {
            // если объект не нулл, то объект, иначе - значение

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
