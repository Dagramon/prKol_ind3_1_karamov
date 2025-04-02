using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prKol_ind3_1_karamov
{
    class OneArray
    {
        private int[] array;
        public int[] Array
        {
            get { return array; }
            set { array = value; }
        }
        public void CreateArray(int[] arr)
        {
            Array = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                Array[i] = arr[i];
            }
        }
    }
}
