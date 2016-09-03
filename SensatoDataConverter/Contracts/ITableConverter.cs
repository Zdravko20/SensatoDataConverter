namespace TableConverter.Contracts
{
    public interface ITableConverter
    {
        void ConvertToTable(string[] fileLines, string filePath, int[] selectedFrames);
    }
}
