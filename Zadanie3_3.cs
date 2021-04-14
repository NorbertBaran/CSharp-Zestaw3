using System;
using System.Collections;
using System.Collections.Generic;

namespace Cw3{
    class Zadanie3_3{
        public static void Main3(string[] args){

            ArrayCompositionQueue compositionQueue = new ArrayCompositionQueue();

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

    class ArrayCompositionQueue{
        int Size{
            get => PointerEnd - PointerBegin + 1;
        }
        private int PointerBegin = 0;
        private int PointerEnd = -1;
        private static int Unit = 10000;
        Object[] array = new object[Unit];
        Array array2 = new Array[Unit];

        public void Enqueue(Object value){
            if(PointerEnd == array.Length - 1){
                Object[] newArray = new object[array.Length + Unit];
                for(int i=PointerBegin; i<=PointerEnd; i++)
                    newArray[i-PointerBegin]=array[i];
                array = newArray;
                PointerEnd = PointerEnd - PointerBegin;
                PointerBegin = 0;
            }
            PointerEnd++;
            array[PointerEnd] = value;
        }

        public Object Dequeue(){
            if(Size == 0)
                return null;
            Object first = array[PointerBegin];
            if(PointerBegin == PointerEnd){
                array = new object[Unit];
                PointerBegin = -1;
                PointerEnd = -1;
            }
            PointerBegin++;
            return first;
        }
    }

}