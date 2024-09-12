using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace Explorer
{
    internal static class Menu
    {
        

        public static void MenuCMD()
        {  
            bool work = true;
           
            var history = new List<string>();

            while (work)
            {
                Console.Write(CMD.CurDir.FullName + ">");
                string input = Console.ReadLine();

                string command = Parse.TryParseCommand(input);
                string? path = Parse.TryParsePath(input); 
                switch (command)
                {
                 
                    case "Clear":
                        CMD.CLS();                     
                        break;

                    case "Exit":
                        work = false;                        
                        break;

                    case "Dir":
                    
                        CMD.Dir(path);                       
                        break;

                    case "Mkdir":                
                        CMD.CreateDirectory(path);
                        break;

                    case "RD":                   
                        CMD.DeleteDirectory(path);
                        break;

                    case "Mdir":               
                        Console.WriteLine("Enter path move to");
                        string moveDirTo = Console.ReadLine();
                        CMD.MoveDir(path, moveDirTo);
                        break;

                    case "Cdir":        
                        Console.WriteLine("Enter path copy to");
                        string copyDirTo = Console.ReadLine();
                        CMD.CopyDir(path, copyDirTo);
                        break;

                    case "Echo":
                    
                        CMD.CreateFile(path);
                        break;

                    case "RM":
                 
                        CMD.DeleteFile(path);
                        break;

                    case "Show":
                  
                        CMD.ShowFile(path);
                        break;

                    case "Copy":                  
                        Console.WriteLine("Enter path copy to");
                        string copyTo = Console.ReadLine();
                        CMD.Copy(path, copyTo);
                        break;

                    case "Move":
                  
                        Console.WriteLine("Enter path move to");
                        string moveTo = Console.ReadLine();
                        CMD.Move(path, moveTo);
                        break;

                    case "Find":
                 
                        CMD.Search(path);
                        break;

                    case "History":
                        CMD.ShowHistory(history);
                        break;
             
                    case "Help":
                        CMD.Help();
                        break;
                 
                    default:                        
                        continue;


                }
                history.Add(command);


            }












    }







    }
}
