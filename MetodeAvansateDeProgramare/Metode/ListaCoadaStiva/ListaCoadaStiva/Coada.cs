namespace ListaCoadaStiva
{
    public class Coada
    {
        int[] values;
        int n;

        public Coada()
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

        public int StergereInceput()
        {
            // [1 2 3 4]
            // vector nou de dimensiune n-1:
            // [0 0 0]
            // [2 3 4]
            n--;
            int[] newValues = new int[n];
            for (int i = 0; i < n; i++)
            {
                newValues[i] = values[i + 1];
            }
            int value = values[0];
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
