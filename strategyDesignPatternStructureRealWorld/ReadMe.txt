The classes and objects participating in this pattern are:

1. Strategy  (SortStrategy)
    declares an interface common to all supported algorithms. Context uses this interface to call the algorithm defined by a ConcreteStrategy
2. ConcreteStrategy  (QuickSort, ShellSort, MergeSort)
   implements the algorithm using the Strategy interface
3. Context  (SortedList)
    is configured with a ConcreteStrategy object
    maintains a reference to a Strategy object
    may define an interface that lets Strategy access its data.
