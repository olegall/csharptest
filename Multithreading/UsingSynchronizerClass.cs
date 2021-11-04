using System;

namespace Multithreading
{
    public interface IReadFromShared
    {
        string GetValue();
    }

    public interface IWriteToShared
    {
        void SetValue(string value);
    }

    public class MySharedClass : IReadFromShared, IWriteToShared
    {
        string _foo;

        public string GetValue()
        {
            return _foo;
        }

        public void SetValue(string value)
        {
            _foo = value;
        }
    }

    public class UsingSynchronizerClass
    {
        public void Foo(Synchronizer<MySharedClass, IReadFromShared, IWriteToShared> sync)
        {
            sync.Write(x => {
                x.SetValue("new value");
            });
            sync.Read(x =>
            {
                Console.WriteLine(x.GetValue());
            });
        }
    }
}
