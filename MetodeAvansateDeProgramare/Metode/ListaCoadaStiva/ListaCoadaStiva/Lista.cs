namespace ListaCoadaStiva
{
    public class Lista
    {
        int[] values;
        int n;

        public Lista()
        {
            n = 0;
            values = new int[n];
        }

        public void AdaugareOrdonata(int value)
        {
            n++;
            int count = 0; // numara cate valori sunt mai mici decat value
            int[] newValues = new int[n];
            for (int i = 0; i < n - 1; i++)
            {
                if (values[i] <= value)
                {
                    count++;
                    newValues[i] = values[i];
                }
                else
                {
                    newValues[i + 1] = values[i];
                }
            }
            newValues[count] = value;
            values = newValues;
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
