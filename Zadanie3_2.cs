using System;
using System.Collections;

namespace Cw3{
    class Zadanie3_2{
        public static void Main2(string[] args){
            ArrayListInheritanceQueue inheritanceQueue = new ArrayListInheritanceQueue();
            
            inheritanceQueue.Enqueue(1);
            inheritanceQueue.Enqueue(12);
            inheritanceQueue.Enqueue(-3);

            Console.WriteLine(inheritanceQueue.Dequeue());
            Console.WriteLine(inheritanceQueue.Dequeue());
            inheritanceQueue.Enqueue(7);
            Console.WriteLine(inheritanceQueue.Dequeue());
            Console.WriteLine(inheritanceQueue.Dequeue());
            Console.WriteLine(inheritanceQueue.Dequeue());

            ArrayListCompositionQueue compositionQueue = new ArrayListCompositionQueue();

            compositionQueue.Enqueue(1);
            compositionQueue.Enqueue(12);
            compositionQueue.Enqueue(-3);

            Console.WriteLine(compositionQueue.Dequeue());
            Console.WriteLine(compositionQueue.Dequeue());
            compositionQueue.Enqueue(7);
            Console.WriteLine(compositionQueue.Dequeue());
            Console.WriteLine(compositionQueue.Dequeue());
            Console.WriteLine(compositionQueue.Dequeue());
        }
    }

    class ArrayListInheritanceQueue : ArrayList{
        public void Enqueue(Object value){
            this.Add(value);
        }
        public Object Dequeue(){
            if(this.Count == 0)
                return null;
            Object first = this[0];
            this.RemoveAt(0);
            return first;
        }
    }

    class ArrayListCompositionQueue{
        ArrayList arrayList = new ArrayList();

        public void Enqueue(Object value){
            arrayList.Add(value);
        }
        public Object Dequeue(){
            if(arrayList.Count == 0)
                return null;
            Object first = arrayList[0];
            arrayList.RemoveAt(0);
            return first;
        }
    }

}