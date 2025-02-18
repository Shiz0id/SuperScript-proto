using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperScript
{ 
public static class FileMover
{
    public static bool MoveFile(string sourcePath, string destinationPath)
    {
        try
        {
            // Check if the source file exists
            if (!File.Exists(sourcePath))
                throw new FileNotFoundException($"The file was not found: {sourcePath}");

            // Move the file
            File.Move(sourcePath, destinationPath);
            Console.WriteLine("File moved successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error moving file: {ex.Message}");
            return false;
        }
    }
}

public static class FileDeleter
{
    public static bool DeleteFile(string filePath)
    {
        try
        {
            // Check if the file exists
            if (!File.Exists(filePath))
                throw new FileNotFoundException($"The file was not found: {filePath}");

            // Delete the file
            File.Delete(filePath);
            Console.WriteLine("File deleted successfully.");
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting file: {ex.Message}");
            return false;
        }
    }
}
    public static class FileRenamer
    {
        public static bool RenameFile(string sourcePath, string newName, string removeSpecific = "", bool removeLetters = false, bool removeNumbers = false)
        {
            try
            {
                // Check if the source file exists
                if (!File.Exists(sourcePath))
                    throw new FileNotFoundException($"The file was not found: {sourcePath}");

                // Get the directory of the source file
                string directory = Path.GetDirectoryName(sourcePath);

                // Optionally remove letters, numbers, or specific text
                if (removeLetters)
                {
                    newName = RemoveLetters(newName);
                }

                if (removeNumbers)
                {
                    newName = RemoveNumbers(newName);
                }

                if (!string.IsNullOrEmpty(removeSpecific))
                {
                    newName = RemoveSpecificText(newName, removeSpecific);  // Remove the specified text
                }

                // Construct the full path for the new file name
                string newFilePath = Path.Combine(directory, newName);

                // Rename the file
                File.Move(sourcePath, newFilePath);
                Console.WriteLine($"File renamed to: {newFilePath}");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error renaming file: {ex.Message}");
                return false;
            }
        }

        // Remove all alphabetic characters from the string
        private static string RemoveLetters(string input)
        {
            return Regex.Replace(input, "[a-zA-Z]", "");
        }

        // Remove all numeric characters from the string
        private static string RemoveNumbers(string input)
        {
            return Regex.Replace(input, "[0-9]", "");
        }

        // Remove specific text from the string
        private static string RemoveSpecificText(string input, string textToRemove)
        {
            return input.Replace(textToRemove, string.Empty);
        }
    }
}