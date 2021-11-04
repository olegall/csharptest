using System;
using System.Threading;

namespace Multithreading
{
    public class Synchronizer<TImpl, TIRead, TIWrite> where TImpl : TIRead, TIWrite
    {
        ReaderWriterLockSlim _lock = new ReaderWriterLockSlim();
        TImpl _shared;

        public Synchronizer(TImpl shared)
        {
            _shared = shared;
        }

        public void Read(Action<TIRead> functor)
        {
            _lock.EnterReadLock();
            try
            {
                functor(_shared);
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }

        public void Write(Action<TIWrite> functor)
        {
            _lock.EnterWriteLock();
            try
            {
                functor(_shared);
            }
            finally
            {
                _lock.ExitWriteLock();
            }
        }

        public void ExecuteParallel_1()
        {
            var sync = new Synchronizer<string, string, string>("initial_");

            /*var actions = new Actions();
            actions.Add(() => sync.Assign((res) => res + "foo"));
            actions.Add(() => sync.Assign((res) => res + "bar"));

            actions.ExecuteParallel();*/

            string result = null;
            sync.Read(delegate (string val) { result = val; });
            //Assert.AreEqual(true, "initial_foobar" == result || result == "initial_barfoo");
        }
    }
}
