using System;
using System.Collections;

namespace IteratorPattern
{
    abstract class IteratorAbstract
    {
        public abstract object First();
        public abstract object Next();
        public abstract bool IsDone();
        public abstract object CurrentItem();
    }

    abstract class AggregateAbstract
    {
        public abstract IteratorAbstract CreateIterator();
    }
    class AggregateConcrete : AggregateAbstract
    {
        /// <summary>
        /// In iterator pattern - We dont want to expose arraylist to outside. We also want outside client can browse through arraylist.
        /// </summary>
        private ArrayList _items = new ArrayList();

        public override IteratorAbstract CreateIterator()
        {
            return new IteratorConcrete(this);
        }

        public int Count
        {
            get { return _items.Count; }
        }

        public object this[int index]
        {
            get { return _items[index]; }
            set { _items.Insert(index, value); }
        }
    }

    class IteratorConcrete : IteratorAbstract
    {
        private AggregateConcrete _aggregate;
        private int _current = 0;

        public IteratorConcrete(AggregateConcrete aggregate)
        {
            this._aggregate = aggregate;
        }

        public override object First()
        {
            return _aggregate[0];
        }

        public override object Next()
        {
            object ret = null;
            if (_current < _aggregate.Count - 1)
            {
                ret = _aggregate[++_current];
            }
            return ret;
        }

        public override bool IsDone()
        {
            return _current >= _aggregate.Count;
        }

        public override object CurrentItem()
        {
            return _aggregate[_current];
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            AggregateConcrete a = new AggregateConcrete();
            a[0] = "item 1";
            a[1] = "item 2";
            a[2] = "item 3";
            a[3] = "item 4";


            // Create Iterator and provide aggregate

            IteratorAbstract i = a.CreateIterator();

            Console.WriteLine("Iterating over collection:");

            object item = i.First();
            while (item != null)
            {
                Console.WriteLine(item);
                item = i.Next();
            }

            // Wait for user

            Console.ReadKey();
        }

    }
}
