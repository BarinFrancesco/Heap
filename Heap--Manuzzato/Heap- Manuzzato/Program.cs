namespace Heap__Manuzzato
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 0;

            Heap heap = new Heap();

            while (true) 
            {
                do
                {


                    Console.WriteLine("Insert a number in the heap (or 'exit' to quit):");

                    
                } while (!int.TryParse(Console.ReadLine(), out n) || n<0);

              
                    heap.Insert(n);

                PrintHeap(heap);
            }

           
        }

        static void PrintHeap(Heap heap)
        {
            for (int i = 1; i <= heap.Count; i++)
            {
                Console.Write( "[" + heap[i] + " ]");
            }
            Console.WriteLine();
        }
    }
}