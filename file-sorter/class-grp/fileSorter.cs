using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace file_sorter.class_grp
{
    public class FileSorter
    {
        public string FolderPath = "";


        public void LeMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine
                (
                "====================\n" +
                "» PRESS x to quit «\n" +
                "====================\n"

                );
            Console.ForegroundColor = ConsoleColor.Gray;

                        
            while(true) 
            {
                Console.WriteLine("path of folder to sort :");
                string FolderPath = Console.ReadLine();
                if (FolderPath == "x".ToLower())
                {
                    break;
                    
                }
                Sorter(FolderPath);

            }
        }

        private void Sorter(string FolderPath)
        {
            //ask user to enter folder path to sort
            
            
            if (Directory.Exists(FolderPath))
            {
                Organizer(FolderPath);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("and voila~ it is done!\n");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
            else 
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("no directory found\n");
                Console.ForegroundColor = ConsoleColor.Gray;

            }
        }

        private void Organizer(string folderPath)
        {
            DirectoryInfo folder = new DirectoryInfo(folderPath);
            //we go through each file in a given folder and move them around
            foreach (FileInfo file in folder.GetFiles())
            {
                string categoryFolder = GetFolder(file.Extension);
                string destinationPath = Path.Combine(folderPath, categoryFolder, file.Name);

                // Create the category folder if it doesn't exist
                Directory.CreateDirectory(Path.Combine(folderPath, categoryFolder));

                // Move the file to the appropriate folder
                file.MoveTo(destinationPath);
            }
        }

        private string GetFolder(string fileExtension)
        {
            //define where the different file types go
            //here the code is thought for my specific needs
            switch (fileExtension.ToLower())
            {
                case ".jpg":
                case ".png":
                case ".gif":
                case ".svg":
                    return "Finished";
                case ".psd":
                case ".csp":
                    return "Work_files";
                case ".pdf":
                case ".docx":
                     return "Writings";
                default:
                    return "misc";
            }
        }

    }

}

