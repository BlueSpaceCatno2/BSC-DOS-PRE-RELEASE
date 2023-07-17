using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Transactions;
using System.Linq.Expressions;
using System;
using System.Windows;
using Microsoft.Win32;
using System.Reflection;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Security;
using System;
using System.Collections;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Program
{




    public static void Main(string[] args)
    {
        string Warnings = null;
        try
        {
            Console.SetWindowSize(120, 30);
        }
        catch (Exception e)
        {

            try
            {
                int result = Int32.Parse(Warnings);
                Console.WriteLine(result);
            }
            catch (FormatException)
            {
                Console.WriteLine($"'{Warnings}'");
            }
        }

        String uno = "Zero";

        String COLORREAD = "Blue is cuel";

        String Command = "NA";

        Boolean Worked = false;

        //functions\\
        void Color()
        {

            DoStuff();
            if (COLORREAD == "Blue is cuel")
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
            }
            else
            {
                try
                {
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), COLORREAD);
                    Console.ForegroundColor = color;
                }
                catch (Exception e)
                {
                    Console.WriteLine("INVALID COLOR ID");
                }
            }
        }
        void fileoperation()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("FILE MODE ENTERED");
            while (!(Command.ToUpper() == "CLOSE" || (Command.ToUpper() == "-CLOSE")))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("type -filehelp for a list of file based commands");
                BeepNSleep();
                Console.WriteLine("type -close to exit file mode");
                BeepNSleep();
                Color();
                Console.Write("User: ");

                Command = Console.ReadLine();

                if (Command.ToUpper() == "FILEHELP" || Command.ToUpper() == "-FILEHELP")
                {
                    Worked = true;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("BSC-DOS Help:");
                    DoStuff();
                    Thread.Sleep(200);
                    Console.WriteLine("Showing Command list:");
                    DoStuff();
                    Thread.Sleep(200);
                    Console.WriteLine("-FileHelp - Command list");
                    BeepNSleep();
                    Console.WriteLine("-CopyFile - copy a file's contents to another UNSTABLE");
                    BeepNSleep();
                    Console.WriteLine("-Delete - delete a file and/or its contents. UNSTABLE");
                    BeepNSleep();
                    Console.WriteLine("-DiskSpace - display free space on disks");
                    BeepNSleep();
                    Console.WriteLine("-Write - write a file");
                    BeepNSleep();
                    Console.WriteLine("-Read - read a files contents");
                    continue;

                }



                if (Command.ToUpper() == "COPPYFILE" || Command.ToUpper() == "-COPPYFILE")
                {
                    try
                    {



                        Console.WriteLine("Enter first file name");
                        String NAME = Console.ReadLine();
                        Console.WriteLine(@"Enter drive path EX = C:\");
                        string DRIVE = Console.ReadLine();

                        Console.WriteLine("Enter folder (Type string of folders if needed)");
                        string Folder = Console.ReadLine();
                        Console.WriteLine("Enter File extension (dont add dot)");
                        string TYPE = Console.ReadLine();

                        string Path = DRIVE + @"\" + Folder + @"\" + NAME + "." + TYPE;

                        Console.WriteLine("Enter second file name");
                        String NAME2 = Console.ReadLine();
                        Console.WriteLine(@"Enter drive path EX = C:\");
                        string DRIVE2 = Console.ReadLine();

                        Console.WriteLine("Enter folder (Type string of folders if needed)");
                        string Folder2 = Console.ReadLine();
                        Console.WriteLine("Enter File extension (dont add dot)");
                        string TYPE2 = Console.ReadLine();
                        string Path2 = DRIVE2 + @"\" + Folder2 + @"\" + NAME2 + "." + TYPE2;
                        File.Copy(Path, Path2);
                        Worked = true;
                        continue;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error 004 File error couldnt process");
                        Console.WriteLine(e);
                    }
                }

                if (Command.ToUpper() == "DELETE" || Command.ToUpper() == "-DELETE")
                {
                    Console.WriteLine("Enter file name");
                    String NAME = Console.ReadLine();
                    Console.WriteLine(@"Enter drive path EX = C:\");
                    string DRIVE = Console.ReadLine();
                    Console.WriteLine("Enter File extension (dont add dot)");
                    string TYPE = Console.ReadLine();

                    Console.WriteLine("Enter folder (Type string of folders if needed)");
                    string Folder = Console.ReadLine();
                    Console.WriteLine("Enter file contents");
                    string Contents = Console.ReadLine();

                    string Path = DRIVE + @"\" + Folder + @"\" + NAME + "." + TYPE;
                    try
                    {
                        if (File.Exists(@Path))
                        {
                            File.Delete(@Path);
                        }
                        else
                        {
                            Console.WriteLine("Invalid path");
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error 004 File error couldnt process");
                        Console.WriteLine(e);
                    }



                    Worked = true;
                    continue;
                }

                if (Command.ToUpper() == "DISKSPACE" || Command.ToUpper() == "-DISKSPACE")
                {
                    DriveInfo[] allDrives = DriveInfo.GetDrives();

                    foreach (DriveInfo d in allDrives)
                    {
                        Console.WriteLine("Drive {0}", d.Name);
                        DoStuff();
                        Console.WriteLine("  File type: {0}", d.DriveType);
                        BeepNSleep();
                        if (d.IsReady == true)
                        {
                            Console.WriteLine("  Volume label: {0}", d.VolumeLabel);
                            DoStuff();
                            Console.WriteLine("  File system: {0}", d.DriveFormat);
                            DoStuff();
                            Console.WriteLine(
                                "  Available space to current user:{0, 15} bytes",
                                d.AvailableFreeSpace);
                            DoStuff();

                            Console.WriteLine(
                                "  Total available space:          {0, 15} bytes",
                                d.TotalFreeSpace);
                            DoStuff();

                            Console.WriteLine(
                                "  Total size of drive:            {0, 15} bytes ",
                                d.TotalSize);

                        }
                    }
                    Worked = true;
                    continue;
                }
                if (Command.ToUpper() == "DIRCONT" || Command.ToUpper() == "-DIRCONT")
                {
                    Console.WriteLine("Enter File Path");
                    String DIR = Console.ReadLine();
                    int READ = 0;
                    try
                    {
                        var searchTerm = "SEARCH_TERM";
                        var searchDirectory = new System.IO.DirectoryInfo(DIR);

                        var queryMatchingFiles =
                                from file in searchDirectory.GetFiles()
                                where file.Extension == ".txt"
                                let fileContent = System.IO.File.ReadAllText(file.FullName)
                                where fileContent.Contains(searchTerm)
                                select file.FullName;

                        foreach (string file in Directory.EnumerateFiles(DIR))
                        {
                            Console.WriteLine(file);
                            Console.Beep();
                        }
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error " + e);
                    }
                    Worked = true;
                    continue;
                }
                if (Command.ToUpper() == "READ" || Command.ToUpper() == "-READ")
                {
                    try
                    {
                        Console.WriteLine("Enter file name");
                        String NAME = Console.ReadLine();
                        Console.WriteLine(@"Enter drive path EX = C:\");
                        string DRIVE = Console.ReadLine();
                        Console.WriteLine("Enter File extension (dont add dot)");
                        string TYPE = Console.ReadLine();

                        Console.WriteLine("Enter folder (Type string of folders if needed)");
                        string Folder = Console.ReadLine();

                        string Path = DRIVE + @"\" + Folder + @"\" + NAME + "." + TYPE;

                        string contents = File.ReadAllText(@Path);
                        Console.WriteLine(contents);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                    Worked = true;
                    continue;
                }



                if (Command.ToUpper() == "WRITE" || Command.ToUpper() == "-WRITE")
                {
                    Console.WriteLine("Enter file name");
                    String NAME = Console.ReadLine();
                    Console.WriteLine(@"Enter drive path EX = C:\");
                    string DRIVE = Console.ReadLine();
                    Console.WriteLine("Enter File extension (dont add dot)");
                    string TYPE = Console.ReadLine();

                    Console.WriteLine("Enter folder (Type string of folders if needed)");
                    string Folder = Console.ReadLine();
                    Console.WriteLine("Enter file contents");
                    string Contents = Console.ReadLine();

                    string Path = DRIVE + @"\" + Folder + @"\" + NAME + "." + TYPE;
                    try
                    {
                        File.WriteAllText(@Path, Contents);
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error 004 File error couldnt process");
                        Console.WriteLine(e);
                    }
                    Worked = true;
                    continue;
                }

                if (Command.ToUpper() == "CLOSE" || Command.ToUpper() == "-CLOSE")
                {
                    Worked = true;
                    continue;
                }

                if (Command.ToUpper() == "FILE_MODE" || Command.ToUpper() == "-FILE_MODE")
                {
                    //invalid command
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error operating " + Command);
                    Console.WriteLine(" mode is already active ");
                    Console.WriteLine(" Error #005 improper usage");
                    Console.Beep(3000, 1000);
                    Color();

                    Worked = true;
                    continue;
                }



                //error detection
                if (Worked == false & !(Command == ""))
                {

                    //invalid command
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error operating command" + Command);
                    Console.WriteLine(" is not recognised as a script or function.");
                    Console.WriteLine(" Error #001");
                    Console.Beep(3000, 1000);
                    Color();


                    Worked = false;
                    continue;
                }
                else
                {
                    if (Worked == false & Command == "")
                        Console.ForegroundColor = ConsoleColor.Red;
                    {
                        //no information
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error operating command " + Command);
                        Console.WriteLine(" No information detected inside.");
                        Console.WriteLine(" Error #002");
                        Console.Beep(3000, 1000);
                        Color();


                        continue;
                    }

                }







            }

        }
















                void BeepNSleep()
        {
            Console.Beep();
            Thread.Sleep(100);
        }




        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Yellow;
        String dos = "Zero";
        Thread.Sleep(20);
        int repeat = 25;
        //set verion ID and codename
        string DevKey = "";
        double version = 0.105;
        //show BSC-DOS screen
        for (int i = 0; i < repeat; i++)
        {
            Thread.Sleep(20);
            Console.Write("--");

        }
        Thread.Sleep(100);
        DoStuff();
        Console.Write("Welcome to");
        Console.ForegroundColor = ConsoleColor.Blue;
        Thread.Sleep(50);
        Console.Write(" BSC");
        Console.ForegroundColor = ConsoleColor.Yellow;
        Thread.Sleep(50);
        DoStuff();
        Console.Write("-DOS");
        Thread.Sleep(100);
        for (int i = 0; i < repeat; i++)
        {
            Thread.Sleep(20);
            Console.Write("--");
        }
        Thread.Sleep(20);
        BeepNSleep();
        Console.WriteLine(" ");
        BeepNSleep();
        repeat = 25;
        //start console
        for (int i = 0; i < repeat; i++)
        {
            Thread.Sleep(20);
            Console.Write("  ");
        }
        Thread.Sleep(20);
        BeepNSleep();
        Console.Write("Enter Command below");
        BeepNSleep();
        Thread.Sleep(20);
        for (int i = 0; i < repeat; i++)
        {
            Thread.Sleep(20);
            Console.Write("  ");
        }
        DoStuff();
        Thread.Sleep(200);
        Console.WriteLine("             Type -help for a list of commands");
        DoStuff();
        while (true)
        {
            Color();
            Console.Write("User: ");

            Command = Console.ReadLine();


            Console.ForegroundColor = ConsoleColor.Yellow;
            if (Command.ToUpper() == "HELP" || Command.ToUpper() == "-HELP")
            {
                Worked = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("BSC-DOS Help:");
                DoStuff();
                Thread.Sleep(200);
                Console.WriteLine("Showing Command list:");
                DoStuff();
                Thread.Sleep(200);
                Console.WriteLine("-Add - Add a number");
                BeepNSleep();
                Console.WriteLine("-Subtract - Subtract a number");
                BeepNSleep();
                Console.WriteLine("-Multiply - Multiply a number");
                BeepNSleep();
                Console.WriteLine("-Divide - Divide a number");
                BeepNSleep();
                Console.WriteLine("-HighlightColor  --> -Help (Built In) - Highlight color of text");
                BeepNSleep();
                Console.WriteLine("-TextColor  --> -Help (Built In) - Color of text");
                BeepNSleep();
                Console.WriteLine("-Help - Command list");
                BeepNSleep();
                Console.WriteLine("-Clear -  Clear the command pallette");
                BeepNSleep();
                Console.WriteLine("-Exit / Closeapp - Exit / close the app");
                BeepNSleep();
                Console.WriteLine("-Restart - Restarts the computer.");
                BeepNSleep();
                Console.WriteLine("-Run - Runs a program (Unstable)");
                BeepNSleep();
                Console.WriteLine("-CurrentTime - Disply system time and date");
                BeepNSleep();
                Console.WriteLine("-LockCurrentTime - Display system time forever (close program to reset)");
                BeepNSleep();
                Console.WriteLine("-File_Mode - enter file mode");
                BeepNSleep();
                Console.WriteLine("-Shutdown - shutdown PC");
                BeepNSleep();
                Console.WriteLine("-System_Status Display system status");
                BeepNSleep();
                Console.WriteLine("-Current_Version Display system update history");
                BeepNSleep();
                Console.WriteLine("-Message - send a message via email");
                BeepNSleep();
                Console.WriteLine("-ProcessList - get a list of all processed running on the PC");
                continue;

            }
            if (Command.ToUpper() == "SUBTRACT" || Command.ToUpper() == "-SUBTRACT")
            {

                Worked = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insert First digit");
                DoStuff();
                Color();
                uno = Console.ReadLine();
                DoStuff();
                Int32.TryParse(uno, out int UNO);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insert Second digit");
                Color();
                dos = Console.ReadLine();
                DoStuff();
                Int32.TryParse(dos, out int DOS);
                int DELTAV = UNO - DOS;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(UNO + " - " + DOS + " = " + DELTAV);
                DoStuff();
                continue;
            }
            if (Command.ToUpper() == "ADD" || Command.ToUpper() == "-ADD")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insert First digit");
                DoStuff();
                Color();
                uno = Console.ReadLine();
                DoStuff();
                Int32.TryParse(uno, out int UNO);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insert Second digit");
                Color();
                dos = Console.ReadLine();
                DoStuff();
                Int32.TryParse(dos, out int DOS);
                int DELTAV = UNO + DOS;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(UNO + " + " + DOS + " = " + DELTAV);
                DoStuff();
                continue;

            }
            if (Command.ToUpper() == "MULTIPLY")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insert First digit");
                DoStuff();
                Color();
                uno = Console.ReadLine();
                DoStuff();
                Int32.TryParse(uno, out int UNO);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insert Second digit");
                Color();
                dos = Console.ReadLine();
                DoStuff();
                Int32.TryParse(dos, out int DOS);
                int DELTAV = UNO * DOS;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(UNO + " X " + DOS + " = " + DELTAV);
                DoStuff();
                continue;

            }
            if (Command.ToUpper() == "DIVIDE" || Command.ToUpper() == "-DIVIDE")
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insert First digit");
                DoStuff();
                Color();
                uno = Console.ReadLine();
                DoStuff();
                Int32.TryParse(uno, out int UNO);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Insert Second digit");
                Color();
                dos = Console.ReadLine();
                DoStuff();
                Int32.TryParse(dos, out int DOS);
                int DELTAV = UNO / DOS;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(UNO + " / " + DOS + " = " + DELTAV);
                DoStuff();
                continue;

            }
            if (Command.ToUpper() == "HIGHLIGHTCOLOR" || Command.ToUpper() == "-HIGHLIGHTCOLOR")
            {
                Worked = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("type a valid color or -help for a list of colors");
                COLORREAD = Console.ReadLine();
                if (COLORREAD.ToUpper() == "-HELP")
                {
                    Console.WriteLine("List of valid colors:");
                    Console.WriteLine("Yellow, DarkYellow, Red, DarkRed, Blue, DarkBlue, Cyan");
                    Console.WriteLine("DarkCyan, Green, DarkGreen, Magenta, DarkMagenta, White, Black");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!INSERT EXACT TEXT INCLUDING CAPITALS!");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
                if (COLORREAD == "Yellow" || COLORREAD == "Darkyellow" || COLORREAD == "Red" || COLORREAD == "DarkRed" || COLORREAD == "Blue" || COLORREAD == "DarkBlue" || COLORREAD == "Cyan" || COLORREAD == "DarkCyan" || COLORREAD == "Green" || COLORREAD == "DarkGreen" || COLORREAD == "Magenta" || COLORREAD == "DarkMagenta" || COLORREAD == "White" || COLORREAD == "Black")
                {
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), COLORREAD);
                    Console.BackgroundColor = color;
                }
                Console.WriteLine("Preview");
                Worked = true;

            }
            if (Command.ToUpper() == "TEXTCOLOR" || Command.ToUpper() == "-TEXTCOLOR")
            {
                Worked = true;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("type a valid color or -help for a list of colors");
                COLORREAD = Console.ReadLine();
                if (COLORREAD.ToUpper() == "-HELP")
                {
                    Console.WriteLine("List of valid colors:");
                    Console.WriteLine("Yellow, DarkYellow, Red, DarkRed, Blue, DarkBlue, Cyan");
                    Console.WriteLine("DarkCyan, Green, DarkGreen, Magenta, DarkMagenta, White, Black");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("!INSERT EXACT TEXT INCLUDING CAPITALS!");
                    Console.ForegroundColor = ConsoleColor.Yellow;

                }
                if (COLORREAD == "Yellow" || COLORREAD == "Darkyellow" || COLORREAD == "Red" || COLORREAD == "DarkRed" || COLORREAD == "Blue" || COLORREAD == "DarkBlue" || COLORREAD == "Cyan" || COLORREAD == "DarkCyan" || COLORREAD == "Green" || COLORREAD == "DarkGreen" || COLORREAD == "Magenta" || COLORREAD == "DarkMagenta" || COLORREAD == "White" || COLORREAD == "Black")
                {
                    ConsoleColor color = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), COLORREAD);
                    Console.ForegroundColor = color;
                }
                Console.WriteLine("Preview");
                Worked = true;
                continue;

            }

            if (Command.ToUpper() == "CLEAR" || Command.ToUpper() == "-CLEAR")
            {
                Console.Clear();
                int nono = 30;
                for (int i = 0; i < nono; i++)
                {
                    Thread.Sleep(20);
                    Console.Write("-");

                }
                Thread.Sleep(100);
                DoStuff();
                Console.Write("Welcome to");
                Console.ForegroundColor = ConsoleColor.Blue;
                Thread.Sleep(50);
                Console.Write(" BSC");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Thread.Sleep(50);
                DoStuff();
                Console.Write("-DOS");
                Thread.Sleep(100);
                for (int i = 0; i < nono; i++)
                {
                    Thread.Sleep(20);
                    Console.Write("-");
                }
                Thread.Sleep(800);
                Console.WriteLine("");

                DoStuff();

                Console.WriteLine("                             Enter Command below                              ");
                DoStuff();
                Thread.Sleep(200);
                Console.WriteLine("Type -help for a list of commands");
                DoStuff();
                continue;

            }

            if (Command.ToUpper() == "RESTART" || Command.ToUpper() == "-RESTART")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Are you are you want to instantly restart your device, any unsaved data will be lost. Y or N?");

                string? result = Console.ReadLine();
                result = result.ToUpper();
                if (result == "Y")
                {
                    RegisterApplicationRestart(Process.GetCurrentProcess().MainModule.FileName, 0);

                    IntPtr tokenHandle = IntPtr.Zero;

                    try
                    {
                        // get process token
                        if (!OpenProcessToken(Process.GetCurrentProcess().Handle,
                            TOKEN_QUERY | TOKEN_ADJUST_PRIVILEGES,
                            out tokenHandle))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error(),
                                "Failed to open process token handle");
                        }

                        // lookup the shutdown privilege
                        TOKEN_PRIVILEGES tokenPrivs = new TOKEN_PRIVILEGES();
                        tokenPrivs.PrivilegeCount = 1;
                        tokenPrivs.Privileges = new LUID_AND_ATTRIBUTES[1];
                        tokenPrivs.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;

                        if (!LookupPrivilegeValue(null,
                            SE_SHUTDOWN_NAME,
                            out tokenPrivs.Privileges[0].Luid))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error(),
                                "Failed to open lookup shutdown privilege");
                        }

                        // add the shutdown privilege to the process token
                        if (!AdjustTokenPrivileges(tokenHandle,
                            false,
                            ref tokenPrivs,
                            0,
                            IntPtr.Zero,
                            IntPtr.Zero))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error(),
                                "Failed to adjust process token privileges");
                        }

                        // reboot
                        if (!ExitWindowsEx(ExitWindows.RestartApps | ExitWindows.Reboot, ShutdownReason.MajorOther | ShutdownReason.MinorOther | ShutdownReason.FlagPlanned))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error(),
                                "Failed to reboot system");
                        }
                    }
                    catch (Exception ex)
                    {
                        // close the process token
                        if (tokenHandle != IntPtr.Zero)
                        {
                            CloseHandle(tokenHandle);
                        }
                        Console.WriteLine("Error 003 Restart error");
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.Beep(5000, 1000);
                    }
                }
                else if (result == "N")
                {
                    Console.WriteLine("Restart cancelled.");
                }
                else
                {
                    Console.WriteLine("Invalid command, aborting command.");
                    Console.Beep(3000, 1000);
                }
                continue;

            }

            if (Command.ToUpper() == "EXIT" || Command.ToUpper() == "-EXIT" || Command.ToUpper() == "CLOSEAPP" || Command.ToUpper() == "-CLOSEAPP")
            {
                Random rand = new();


                for (int o = 10; o < repeat; o++)
                {
                    for (int i = 1; i <= 10; i++)
                        Console.WriteLine("Closing Files " + "{0} -> {1}", i, rand.Next() + "//Program_Files//" + 1 + "//datafiles");
                    Thread.Sleep(50);
                    for (int i = 1; i <= 10; i++)
                        Console.WriteLine("Resetting data " + "{0} -> {1}", i, rand.Next() + "//users//" + 1 + "//datafiles");
                    Thread.Sleep(50);
                }
                Console.Clear();
                Environment.Exit(0);
                continue;

            }

            if (Command.ToUpper() == "RUN" || Command.ToUpper() == "-RUN")
            {

                string? openfile = "";
                Console.WriteLine("Enter file Path");
                openfile = Console.ReadLine();

                Process process = new();


                using Process pProcess = new();
                process.StartInfo.FileName = openfile;
                process.StartInfo.Arguments = "";
                process.StartInfo.UseShellExecute = false;
                process.StartInfo.RedirectStandardInput = true;
                process.StartInfo.RedirectStandardOutput = true;
                process.StartInfo.RedirectStandardError = true;
                //* Set your output and error (asynchronous) handlers
                process.OutputDataReceived += new DataReceivedEventHandler(OutputHandler);
                process.ErrorDataReceived += new DataReceivedEventHandler(OutputHandler);
                //* Start process and handlers
                process.Start();
                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
                continue;



            }


            if (Command.ToUpper() == "CURRENTTIME" || Command.ToUpper() == "-CURRENTTIME")
            {


                DateTime now = DateTime.Now;
                Console.WriteLine(now.ToString("F"));


                Worked = true;
                continue;
            }



            if (Command.ToUpper() == "LOCKCURRENTTIME" || Command.ToUpper() == "-LOCKCURRENTTIME")
            {
                while (true)
                {

                    DateTime now = DateTime.Now;
                    Console.WriteLine(now.ToString("F"));
                    Thread.Sleep(1);
                    continue;
                }
            }


            if (Command.ToUpper() == "SEARCH" || Command.ToUpper() == "-SEARCH")
            {
                string request = "start https://www.bing.com";
                ProcessStartInfo ps = new ProcessStartInfo
                {
                    FileName = request,
                    UseShellExecute = true
                };
                Process.Start(ps);
            }







            if (Command.ToUpper() == "SHUTDOWN" || Command.ToUpper() == "-SHUTDOWN")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Are you are you want to instantly shutdown your device, any unsaved data will be lost. Y or N?");

                string? result = Console.ReadLine();
                result = result.ToUpper();
                if (result == "Y")
                {
                    RegisterApplicationRestart(Process.GetCurrentProcess().MainModule.FileName, 0);

                    IntPtr tokenHandle = IntPtr.Zero;

                    try
                    {
                        // get process token
                        if (!OpenProcessToken(Process.GetCurrentProcess().Handle,
                            TOKEN_QUERY | TOKEN_ADJUST_PRIVILEGES,
                            out tokenHandle))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error(),
                                "Failed to open process token handle");
                        }

                        // lookup the shutdown privilege
                        TOKEN_PRIVILEGES tokenPrivs = new TOKEN_PRIVILEGES();
                        tokenPrivs.PrivilegeCount = 1;
                        tokenPrivs.Privileges = new LUID_AND_ATTRIBUTES[1];
                        tokenPrivs.Privileges[0].Attributes = SE_PRIVILEGE_ENABLED;

                        if (!LookupPrivilegeValue(null,
                            SE_SHUTDOWN_NAME,
                            out tokenPrivs.Privileges[0].Luid))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error(),
                                "Failed to open lookup shutdown privilege");
                        }

                        // add the shutdown privilege to the process token
                        if (!AdjustTokenPrivileges(tokenHandle,
                            false,
                            ref tokenPrivs,
                            0,
                            IntPtr.Zero,
                            IntPtr.Zero))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error(),
                                "Failed to adjust process token privileges");
                        }

                        // shutdown
                        if (!ExitWindowsEx(ExitWindows.RestartApps | ExitWindows.ShutDown, ShutdownReason.MajorOther | ShutdownReason.MinorOther | ShutdownReason.FlagPlanned))
                        {
                            throw new Win32Exception(Marshal.GetLastWin32Error(),
                                "Failed to shutdown system");
                        }
                    }
                    catch (Exception ex)
                    {
                        // close the process token
                        if (tokenHandle != IntPtr.Zero)
                        {
                            CloseHandle(tokenHandle);
                        }
                        Console.WriteLine("Error 003 Shutdown error");
                        Console.WriteLine($"An error occurred: {ex.Message}");
                        Console.Beep(5000, 1000);
                    }
                }
                else if (result == "N")
                {
                    Console.WriteLine("Shutdown cancelled.");
                }
                else
                {
                    Console.WriteLine("Invalid command, aborting command.");
                    Console.Beep(3000, 1000);
                }
                Worked = true;
                continue;
            }





            if (Command.ToUpper() == "CURRENT_VERSION" || Command.ToUpper() == "-CURRENT_VERSION")
            {
                Console.WriteLine("BSC-DOS Major Update History:");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.0.1 - added subtraction and addition functions");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.0.5 - Added multiplication and division, title");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.1.0 - Animated title writing, screen size, textcolor/ highlightcolor");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.1.5 - Added -help list, bugfixes ");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.5.5 - Added Time/Date ");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.7.0 - Added Basic file reading/writing");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.7.1 - Removed file reading/writing due to errors");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.7.2 - Re-Added Basic file reading/writing");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.8.0 - DiskSpace Reading");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.9.2 - Added Restart, Shutdown");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.0.9.6 - Added CoppyFiles");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.1.0.0 - Added More file functions");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.1.0.5 - Added System_Status command");
                Thread.Sleep(200);
                DoStuff();
                Console.WriteLine("V 0.1.0.5 - Added Proper os being used sensor");

                Worked = true;
                continue;
            }


            if (Command.ToUpper() == "SYSTEM_STATUS" || Command.ToUpper() == "-SYSTEM_STATUS")
            {

                Assembly assem = Assembly.GetEntryAssembly();
                AssemblyName assemName = assem.GetName();
                Version ver = assemName.Version;
                bool isWindows = System.Runtime.InteropServices.RuntimeInformation
                                   .IsOSPlatform(OSPlatform.Windows);
                Console.WriteLine("Proper OS in use: " + isWindows);
                Console.WriteLine("Systsem Verserion: " + version + ver.ToString() + DevKey);
                String warnings = Warnings;
                if (Warnings != null)
                {
                    warnings = "Warnings detected " + Warnings;
                }
                else
                {
                    warnings = "no warnings.";
                }
                Console.WriteLine("BSC-DOS Warnings: " + warnings);
                Worked = true;
                continue;
            }






            if (Command.ToUpper() == "SYSTEMINFO" || Command.ToUpper() == "-SYSTEMINFO")
            {

                Worked = true;
                continue;
            }

            if (Command.ToUpper() == "MESSAGE" || Command.ToUpper() == "-MESSAGE")
            {


                string sendMail = "";
                try
                {
                    Console.WriteLine("Enter your email name");
                    Console.Beep();
                    string fromEmail1 = Console.ReadLine();
                    Console.WriteLine("Enter email your platform i.e outlook, gmail");
                    Console.Beep();
                    String TARGETPLATFORM1 = Console.ReadLine();
                    Console.Beep();
                    string fromEmail = fromEmail1 + "@" + TARGETPLATFORM1 + ".com";
                    Console.WriteLine("Enter target email name");
                    Console.Beep();
                    string fromEmail2 = Console.ReadLine();
                    Console.WriteLine("Enter target email i.e outlook, gmail");
                    Console.Beep();
                    String TARGETPLATFORM = Console.ReadLine();
                    string Target = fromEmail2 + "@" + TARGETPLATFORM + ".com";

                    string body = Console.ReadLine();
                    MailMessage mailMessage = new MailMessage(fromEmail, "to" + Target + "@gmail.com", "Subject", body);
                    mailMessage.IsBodyHtml = true;
                    SmtpClient smtpClient = new SmtpClient("smtp." + TARGETPLATFORM1 + ".com", 587);
                    SmtpClient smtpClient1 = new SmtpClient("smtp." + TARGETPLATFORM + ".com", 587);
                    smtpClient.EnableSsl = true;
                    smtpClient.UseDefaultCredentials = false;
                    smtpClient.Credentials = new NetworkCredential(fromEmail, frompassword);
                    smtpClient.Send(mailMessage);
                }
                catch (Exception ex)
                {
                    sendMail = ex.Message.ToString();
                    Console.WriteLine(ex.ToString());
                }
                Console.WriteLine(sendMail);

                Worked = true;
                continue;
            }
            if (Command.ToUpper() == "PROCESSLIST" || Command.ToUpper() == "-PROCESSLIST")
            {
                Process[] processlist = Process.GetProcesses();

                foreach (Process theprocess in processlist)
                {
                    Console.WriteLine($"{theprocess.ProcessName}" + "  Process ID " + $"{theprocess.Id}" + " Process Threads " + $"{theprocess.Threads}");
                    Console.Beep();
                }
                Worked = true;
                continue;
            }



            if (Command.ToUpper() == "FILE_MODE" || Command.ToUpper() == "-FILE_MODE")
            {
                fileoperation();
                Worked = true;
                continue;
            }





            //error detection
            if (Worked == false & !(Command == ""))
            {

                //invalid command
                Console.ForegroundColor = ConsoleColor.Red;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error operating command" + Command);
                Console.WriteLine(" is not recognised as a script or function.");
                Console.WriteLine(" Error #001");
                Console.Beep(3000, 1000);
                Color();


                Worked = false;
                continue;
            }
            else
            {
                if (Worked == false & Command == "")
                    Console.ForegroundColor = ConsoleColor.Red;
                {
                    //no information
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error operating command " + Command);
                    Console.WriteLine(" No information detected inside.");
                    Console.WriteLine(" Error #002");
                    Console.Beep(3000, 1000);
                    Color();


                    continue;
                }

            }
        }









        void DoStuff()
        {
            Console.Beep();
        }
    }


    static void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine)
    {
        Console.WriteLine(outLine.Data);
    }

    [DllImport("kernel32.dll", SetLastError = true)]
    static extern int RegisterApplicationRestart([MarshalAs(UnmanagedType.LPWStr)] string commandLineArgs, int Flags);

    [Flags]
    enum ExitWindows : uint
    {
        //1 of
        LogOff = 0x00,
        ShutDown = 0x01,
        Reboot = 0x02,
        PowerOff = 0x08,
        RestartApps = 0x40,
        //1 of
        Force = 0x04,
        ForceIfHung = 0x10,
    }

    [Flags]
    enum ShutdownReason : uint
    {
        MajorApplication = 0x00040000,
        MajorHardware = 0x00010000,
        MajorLegacyApi = 0x00070000,
        MajorOperatingSystem = 0x00020000,
        MajorOther = 0x00000000,
        MajorPower = 0x00060000,
        MajorSoftware = 0x00030000,
        MajorSystem = 0x00050000,

        MinorBlueScreen = 0x0000000F,
        MinorCordUnplugged = 0x0000000b,
        MinorDisk = 0x00000007,
        MinorEnvironment = 0x0000000c,
        MinorHardwareDriver = 0x0000000d,
        MinorHotfix = 0x00000011,
        MinorHung = 0x00000005,
        MinorInstallation = 0x00000002,
        MinorMaintenance = 0x00000001,
        MinorMMC = 0x00000019,
        MinorNetworkConnectivity = 0x00000014,
        MinorNetworkCard = 0x00000009,
        MinorOther = 0x00000000,
        MinorOtherDriver = 0x0000000e,
        MinorPowerSupply = 0x0000000a,
        MinorProcessor = 0x00000008,
        MinorReconfig = 0x00000004,
        MinorSecurity = 0x00000013,
        MinorSecurityFix = 0x00000012,
        MinorSecurityFixUninstall = 0x00000018,
        MinorServicePack = 0x00000010,
        MinorServicePackUninstall = 0x00000016,
        MinorTermSrv = 0x00000020,
        MinorUnstable = 0x00000006,
        MinorUpgrade = 0x00000003,
        MinorWMI = 0x00000015,

        FlagUserDefined = 0x40000000,
        FlagPlanned = 0x80000000
    }

    [StructLayout(LayoutKind.Sequential)]
    struct LUID
    {
        public uint LowPart;
        public int HighPart;
    }

    [StructLayout(LayoutKind.Sequential)]
    struct LUID_AND_ATTRIBUTES
    {
        public LUID Luid;
        public UInt32 Attributes;
    }

    struct TOKEN_PRIVILEGES
    {
        public UInt32 PrivilegeCount;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public LUID_AND_ATTRIBUTES[] Privileges;
    }

    const UInt32 TOKEN_QUERY = 0x0008;
    const UInt32 TOKEN_ADJUST_PRIVILEGES = 0x0020;
    const UInt32 SE_PRIVILEGE_ENABLED = 0x00000002;
    const string SE_SHUTDOWN_NAME = "SeShutdownPrivilege";
    private static SecureString? frompassword;

    [DllImport("user32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool ExitWindowsEx(ExitWindows uFlags,
        ShutdownReason dwReason);

    [DllImport("advapi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool OpenProcessToken(IntPtr ProcessHandle,
        UInt32 DesiredAccess,
        out IntPtr TokenHandle);

    [DllImport("advapi32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool LookupPrivilegeValue(string lpSystemName,
        string lpName,
        out LUID lpLuid);

    [DllImport("kernel32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool CloseHandle(IntPtr hObject);

    [DllImport("advapi32.dll", SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool AdjustTokenPrivileges(IntPtr TokenHandle,
        [MarshalAs(UnmanagedType.Bool)] bool DisableAllPrivileges,
        ref TOKEN_PRIVILEGES NewState,
        UInt32 Zero,
        IntPtr Null1,
        IntPtr Null2);
}








//command frame




//if (Command.ToUpper() == "" || Command.ToUpper() == "-")
//{
//
//Worked = true;
//continue;
//}










