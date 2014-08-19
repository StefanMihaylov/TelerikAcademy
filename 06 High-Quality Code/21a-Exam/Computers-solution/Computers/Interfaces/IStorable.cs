namespace Computers.Interfaces
{
    public interface IStorable
    {
        int LoadRamValue();

        void SaveRamValue(int value);
    }
}
