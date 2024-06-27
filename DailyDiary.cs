using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Daily_Diary
{
    public class DailyDiary
    {
        public  string filePath ;

        public void RunDiaryManager()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Welcome to Daily Diary Manager");
                Console.WriteLine("1. Read diary entries");
                Console.WriteLine("2. Add new entry");
                Console.WriteLine("3. Delete entry");
                Console.WriteLine("4. Count total entries");
                Console.WriteLine("5. Search entries");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ReadDiaryFile();
                            break;
                        case 2:
                            Console.Write("Enter date (YYYY-MM-DD): ");
                            String date = Console.ReadLine();
                            Console.Write("Enteryour content:");
                            String content= Console.ReadLine();
                            AddEntry(date, content);
                            break;
                        case 3:
                            DeleteEntry();
                            break;
                        case 4:
                            CountEntries();
                            break;
                        case 5:
                            SearchEntries();
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

                Console.WriteLine();
            }
        }

        public void ReadDiaryFile()
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    Console.WriteLine("Diary Entries:");
                    foreach (string line in lines)
                    {
                        Console.WriteLine(line);
                    }
                }
                else
                {
                    Console.WriteLine("Diary file does not exist or is empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading diary file: {ex.Message}");
            }
        }

        public void AddEntry(String time,string content)
        {
            try
            {
               
                if (DateTime.TryParse(time, out DateTime date))
                {
                
                  

                    Entry newEntry = new Entry { Date = date, Content = content };

                    using (StreamWriter writer = File.AppendText(filePath))
                    {
                        writer.WriteLine("\n");
                        writer.WriteLine($"{newEntry.Date:s}\n {newEntry.Content}\n");
                    }
                    Console.Clear();
                    Console.WriteLine("Entry added successfully!");
                }
                else
                {
                    Console.WriteLine("Invalid date format. Entry not added.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error adding entry: {ex.Message}");
            }
        }

        public void DeleteEntry()
        {
            try
            {
                Console.Write("Enter date to delete (YYYY-MM-DD): ");
                if (DateTime.TryParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date))
                {
                    List<string> lines = new List<string>(File.ReadAllLines(filePath));
                    bool found = false;

                    for (int i = 0; i < lines.Count - 1; i++)
                    {
                        if (lines[i].StartsWith(date.ToString("yyyy-MM-dd")))
                        {
                            lines.RemoveAt(i); 
                            lines.RemoveAt(i);
                            found = true;
                            break;
                        }
                    }

                    if (found)
                    {
                        File.WriteAllLines(filePath, lines);
                        Console.Clear();
                        Console.WriteLine($"Entries for {date.ToShortDateString()} deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"No entries found for {date.ToShortDateString()}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid date format. Entry not deleted.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting entry: {ex.Message}");
            }
        }

        public int CountEntries()
        {
            int count=0;
            try
            {
                if (File.Exists(filePath))
                {
                     count = File.ReadAllLines(filePath).Length;
                    Console.Clear();
                    Console.WriteLine($"Total entries: {count/3}");
                   
                }
                else
                {
                    Console.WriteLine("Diary file does not exist or is empty.");
                   
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error counting entries: {ex.Message}");
            }
            return count;
        }

        public void SearchEntries()
        {
            try
            {
                Console.Write("Enter search term (date or keyword): ");
                string searchTerm = Console.ReadLine();

                if (File.Exists(filePath))
                {
                    List<string> lines = File.ReadAllLines(filePath).ToList();
                    List<string> matchingEntries = lines.FindAll(line => line.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

                    if (matchingEntries.Any())
                    {
                        Console.Clear();
                        Console.WriteLine($"Search Results for '{searchTerm}':");
                        foreach (string entry in matchingEntries)
                        {
                            Console.WriteLine(entry);
                        }
                    }
                    else
                    {
                        Console.WriteLine($"No entries found matching '{searchTerm}'.");
                    }
                }
                else
                {
                    Console.WriteLine("Diary file does not exist or is empty.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error searching entries: {ex.Message}");
            }
        }
    
}
}
