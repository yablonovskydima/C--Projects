using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

//string path = @"C:\Users\User\Desktop\test.txt";

//using (FileStream file = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None)) 
//{
//    byte[] buffer = Encoding.Default.GetBytes("Hello world!");
//    file.Write(buffer, 0, buffer.Length);
//}

//using (FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None)) 
//{
//    byte[] buffer = new byte[(int)file.Length];
//    file.Read(buffer, 0, buffer.Length);
//    Console.WriteLine(Encoding.Default.GetString(buffer));
//}

//using (StreamWriter file = new StreamWriter(path, true)) 
//{
//    file.WriteLine("\nHello Again!");
//}

//using (StreamReader file = new StreamReader(path)) 
//{
//    Console.WriteLine(file.ReadToEnd());
//}

//string path1 = @"C:\Users\User\Desktop\test1.bin";

//using (FileStream file = new FileStream(path1, FileMode.Create, FileAccess.Write, FileShare.None)) 
//{
//    using (BinaryWriter bnr = new BinaryWriter(file))
//    {
//        bnr.Write("Hello");
//        bnr.Write(1);
//        bnr.Write(2.5);
//    }
//}

//using (FileStream file = new FileStream(path1, FileMode.Open, FileAccess.Read, FileShare.None))
//{
//    using (BinaryReader bnr = new BinaryReader(file))
//    {
//        Console.WriteLine(bnr.ReadString());
//        Console.WriteLine(bnr.ReadInt32());
//        Console.WriteLine(bnr.ReadDouble());
//    }
//}


//string path = @"C:\Users\User\Desktop\dir";
//string filename = path + @"\testfile.txt";
//DirectoryInfo directory = new DirectoryInfo(path);
//Console.WriteLine(directory.FullName);
//Console.WriteLine(directory.LastAccessTime);

//if(!directory.Exists)
//    directory.Create();

//Console.WriteLine();

//using FileStream file = File.Create(filename);
//Console.WriteLine(Path.GetFileName(filename));
//Console.WriteLine(Path.GetDirectoryName(filename));
//Console.WriteLine(File.GetCreationTime(filename));

//if (directory.Exists)
//{
//    file.Flush();
//    file.Close();
//    File.Delete(filename);
//    directory.Delete();
//}



