using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaCoadaStiva
{
    public class Stiva
    {
        int[] values;
        int n;

        public Stiva()
        {
            n = 0;
            values = new int[n];
        }

        public void AdaugareFinal(int value)
        {
            // [1 2 3 4]
            // vector nou de dimensiune n+1:
            // [0 0 0 0 0]
            // [1 2 3 4 0]
            // [1 2 3 4 5]
            n++;
            int[] newValues = new int[n];
            for (int i = 0; i < n - 1; i++)
            {
                newValues[i] = values[i];
            }
            newValues[n - 1] = value;
            values = newValues;
        }

        public int StergereFinal()
        {
            // [1 2 3 4]
            // vector nou de dimensiune n-1:
            // [0 0 0]
            // [1 2 3]
            n--;
            int[] newValues = new int[n];
            for (int i = 0; i < n; i++)
            {
                newValues[i] = values[i];
            }
            int value = values[n];
            values = newValues;
            return value;
        }

        public override string ToString()
        {
            var result = "";
            for (int i = 0; i < n; i++)
            {
                result = $"{result}{values[i]} ";
            }
            return result;
        }
    }
}
