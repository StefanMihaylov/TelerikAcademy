namespace RandomDataGenetaror
{
    public interface IRandomGenerator
    {
        int GetNumber(int min, int max);

        string GetString(int length);

        string GetString(int min, int max);

        bool GetChance(int persent);
    }
}
