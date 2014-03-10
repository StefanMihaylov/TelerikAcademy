namespace SubstringExtention
{
    using System.Text;

    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder str, int start, int length)
        {
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                result.Append(str[start + i]);
            }
            return result;
        }

        public static StringBuilder Substring(this StringBuilder str, int start)
        {
            return str.Substring(start, str.Length - start);
        }
    }
}
