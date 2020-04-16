using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace MovieManager

{
    public class ProjectRepository
    {
        private readonly string foldername = @"C:/Users/z6one/MovieManager";
        public void CreateFolder(string element)
        {


            string pathString = Path.Combine(foldername,element);


            //Create file in main folder

            if (!System.IO.Directory.Exists(pathString))
                try
                {
                    Directory.CreateDirectory(pathString);
                    
                }
                catch (IOException ee)
                {
                    MessageBox.Show(ee.Message);
                }

        }
        public string[] DirectoriesRetrive()
        {

            string[] files = System.IO.Directory.GetDirectories(foldername);


            return files;
        }

        public string[] DirectoriesRetrive(string element)
        {
            string pathstring = System.IO.Path.Combine(foldername, element);

            string[] files = System.IO.Directory.GetDirectories(pathstring);


            return files;
        }

        public string[] FileRetrive(string element)
        {
            string pathstring = System.IO.Path.Combine(foldername, element);

            string[] files = System.IO.Directory.GetFiles(pathstring);


            return files;
        }

        public string[] DeleteFile(string element)
        {

            string pathString = Path.Combine(foldername, element);
           

            //Delete file in main folder

            if (System.IO.File.Exists(pathString))
                try
                {
                    System.IO.File.Delete(pathString);
                }
                catch (System.IO.IOException ee)
                {
                    MessageBox.Show(ee.Message);
                }

            string[] files = System.IO.Directory.GetFiles(foldername);

            return files;
        }
        public void CreateFile(string element)
        {
            string pathString = Path.Combine(foldername, element);
            

            //Create file in main folder

            if (!System.IO.File.Exists(pathString))
                try
                {
                    using (System.IO.FileStream fs = System.IO.File.Create(pathString))
                    {
                        ///ok

                    }
                }
                catch (System.IO.IOException ee)
                {
                    MessageBox.Show(ee.Message);
                }

        }

        public void CopyFile(string typeFrom, string typeTo)
        {
            string pathString = Path.Combine(foldername, typeFrom);
            string pathString2 = Path.Combine(foldername, typeTo);

            if (System.IO.File.Exists(typeFrom))
                try
                {
                    System.IO.File.Copy(typeFrom, typeTo);
                }
                catch (System.IO.IOException ee)
                {
                    MessageBox.Show(ee.Message);
                }
        }

        public void ChangeTaskList(ListBox listtasks, string element)
        {

            string pathstring = System.IO.Path.Combine(foldername, element);

            System.IO.File.WriteAllText(pathstring, string.Empty);

            var fs = File.Open(pathstring, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            using (var sw = new StreamWriter(fs))
            {
                int m = listtasks.Items.Count;
                for (int i = 0; i < m; i++)
                {
                    var str = listtasks.Items[i].ToString();

                    sw.WriteLine(str);
                }

                sw.Close();
            }
            fs.Close();

        }

        public ListBox ReadFileToListBox(string element)
        {
            ListBox listtasks = new ListBox();
            string pathstring = System.IO.Path.Combine(foldername, element);

            ///System.IO.File.WriteAllText(pathstring, string.Empty);

            var fs = File.Open(pathstring, FileMode.OpenOrCreate, FileAccess.ReadWrite);

            using (var sw = new StreamReader(fs))
            {
                string str;

                while ((str = sw.ReadLine()) != null)
                {
                    listtasks.Items.Add(str);
                }

                sw.Close();
            }

            fs.Close();

            return listtasks;

        }
    }
}

