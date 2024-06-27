namespace Daily_Diary
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DailyDiary diary = new DailyDiary();
                diary.filePath = Path.Combine(Environment.CurrentDirectory, "data.txt");
                diary.RunDiaryManager();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());

            }
        }
    }
}
