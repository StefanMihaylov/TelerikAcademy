namespace SubStringCounter.Service
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "StringOccurrence" in both code and config file together.
    public class StringOccurrence : IStringOccurrence
    {

        public int CountSubString(string original, string substring)
        {
            int result = 0;
            int index = -1;

            while ((index = original.IndexOf(substring, index + 1)) >= 0)
            {
                result++;
            }

            return result;
        }
    }
}
