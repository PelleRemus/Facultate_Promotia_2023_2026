namespace ReversePolishNotation
{
    public class Stackk
    {
        public int[] Values { get; set; }
        public int Length { get; set; }

        public Stackk()
        {
            Length = 0;
            Values = new int[Length];
        }

        public void AddEnd(int value)
        {
            Length++;
            int[] values = new int[Length];

            for (int i = 0; i < Length - 1; i++)
                values[i] = Values[i];

            values[Length - 1] = value;
            Values = values;
        }

        public int DeleteEnd()
        {
            Length--;
            int[] values = new int[Length];
            int value = Values[Length];

            for (int i = 0; i < Length; i++)
                values[i] = Values[i];

            Values = values;
            return value;
        }
    }
}
