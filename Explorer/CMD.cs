using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Explorer
{
    internal static class CMD
    {
      


       public static DirectoryInfo CurDir { get; set; }
       

        static CMD()
        {
            CurDir = new DirectoryInfo(".");
         
        }


       public static void CLS()
       {
            Console.Clear();
           
       }

        public static void Dir(string str = ".")
        {
            try
            {
                DirectoryInfo dir = new DirectoryInfo(str);           
                Console.WriteLine("Dirictories: ");
                foreach (var direct in dir.GetDirectories())
                {
                    Console.WriteLine($"Directory Name: {direct.Name,-15} Time create: {direct.CreationTime,-15}\n");
                }

                Console.WriteLine("Files: ");
                foreach (var file in dir.GetFiles())
                {
                    Console.WriteLine($"{file.CreationTime,-15}\t\t\t{file.Name,-15} \t\t\t{file.Length,-15}\t\t\t{file.Attributes,-15}");

                }

                CurDir = dir;

            }
            catch(Exception ex)
            {
                CMD.CathExeption(ex);
            }
            
            
        }

        public static void CreateDirectory(string path = ".")
        {
            try
            {
                Directory.CreateDirectory(path);
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("*" + " ");
                    System.Threading.Thread.Sleep(200);

                    Console.WriteLine($"Directory Created! Path: {path}");
                }
            }
            catch (Exception ex)
            {
                CMD.CathExeption(ex);
            }
        }

        public static void DeleteDirectory(string path = ".")
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("*" + " ");
                    System.Threading.Thread.Sleep(200);
                }
                Directory.Delete(path);
                Console.WriteLine($"Deleted Complete! Path: {path}");
               
            }
            catch(Exception ex) {

                CMD.CathExeption(ex);            
                                    
            }

        }

        public static void ShowHistory(List<string>history)
        {
            Console.WriteLine("Command History:");
 
            foreach (var item in history) {
            
                Console.WriteLine(item);
                     
            }

        }

        public static void CreateFile(string path = ".")
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Console.Write("*" + " ");
                    System.Threading.Thread.Sleep(200);
                }
                File.Create(path);
                Console.WriteLine($"File Created! Path: {path}");
            }
            catch(Exception ex)
            {
                CMD.CathExeption(ex);
            }

        }


        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
                Console.WriteLine($"Delete complete! path: {path}");
            }
            catch (Exception ex) { 
               
                CMD.CathExeption(ex);
            
            }

        }


        public static void ShowFile(string path)
        {
            try
            {
                string str = File.ReadAllText(path);

                Console.WriteLine($"{str}");
            }
            catch (Exception ex)
            {
                CMD.CathExeption(ex);

            }

        }

        public static void Search(string path)
        {
            if (File.Exists(path))
            {
                Console.WriteLine($"File in the path: {path} EXISTS");

            }
            else
            {
                Console.WriteLine($"File in the path: {path} NOT EXISTS");
            }
           
        }


        public static void CathExeption(Exception ex)
        {
            Console.WriteLine(ex.Message);

        }
       

        public static void MoveDir(string path, string moveTo)
        {

            try
            {
                var dr = new DirectoryInfo(path);
                dr.MoveTo(moveTo);
            }
            catch(Exception ex)
            {
                CMD.CathExeption(ex);
            }
          
        }

        public static void CopyDir(string path,string copyTo)
        {
            try
            {
                var dr = new DirectoryInfo(path);

                var files = dr.GetFiles();     
                
          
                var newdr = new DirectoryInfo(copyTo);
                if (!newdr.Exists)
                {
                    newdr.Create();
                }
                
                foreach (var file in files) {

                    string tmpPath = newdr.FullName + @"\" + file.Name;
                    file.CopyTo(tmpPath);      
                   
                }
                 
            }
            catch(Exception ex)
            {
                CMD.CathExeption(ex);
            }


        }
        

        public static void Copy(string path,string copyTo)
        {
            try
            {
                var fl = new FileInfo(path);
                fl.CopyTo(copyTo);              
                Console.WriteLine("Copy Complete");
            }
            catch(Exception ex)
            {
                CMD.CathExeption(ex);
            }                       
        }

        public static void Move(string path,string moveTo)
        {
            try
            {
                var fl = new FileInfo(path);
                fl.MoveTo(moveTo);
                Console.WriteLine("Move Complete");
            }
            catch(Exception ex) { 
                
                CMD.CathExeption(ex); 
            
            
            }

        }
        public static void Help()
        {
            Console.WriteLine("Actual command:" +
                "\nDir\t\tShow files and directroris in directory" +
                "\n\nClear\t\tClearing console" +
                "\n\nMkdir\t\tCreating directory by path" +
                "\n\nRD\t\tDeleting directory by path" +
                "\n\nShows\t\tShows text in the file" +
                "\n\nHistory\t\tShows command history entered" +
                "\n\nCopy\t\tCopies file from path for path" +
                "\n\nMove\t\tMove file from path for path"+
                "\n\nCdir\t\tCopy directory from path to path"+
                "\n\nMdir\t\tMove directory from path to path"+
                "\n\nHelp\t\tShow command list"+
                "\n\nExit\t\tExit from cmd");


        }

    }
}
