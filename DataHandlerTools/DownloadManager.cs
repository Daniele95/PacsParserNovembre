using LiteDB;
using QueryTools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Utilities;

namespace DataHandlerTools
{

    public class downloadedFileInfo : query
    {
        public string PatientName { get; set; } = "";
        public string StudyDescription { get; set; } = "";
        [BsonId]
        public string SeriesInstanceUID { get; set; } = "";
        public string SeriesDescription { get; set; } = "";
        public string InstanceNumber { get; set; } = "";
        public string FileStoragePath { get; set; } = "";
    }

    public class DownloadManager : fileCreatorAndListener
    {

        public DownloadManager(string fullPath) : base(fullPath)
        {

        }

        public void Add(downloadedFileInfo aDownloadedFile)
        {
            using (var db = new LiteDatabase(@"C:/Users/daniele/Desktop/DATABASE/database.db"))
            {
                var downloadedFiles = db.GetCollection<downloadedFileInfo> ("downloadedFiles");
                downloadedFiles.Insert(aDownloadedFile);
                downloadedFiles.Update(aDownloadedFile);

                var downloadedFile1 = downloadedFiles.FindById("1.3.6.1.4.1.5962.1.1.0.0.0.1196527414.5534.0.8");
                Console.WriteLine(downloadedFile1.PatientName + " "
                   + downloadedFile1.SeriesDescription);
                
                IEnumerable <downloadedFileInfo> filteredElements;
                filteredElements = downloadedFiles.Find(i => i.PatientName.Equals("Doe^Archibald"));
                foreach (downloadedFileInfo fileDownloaded in filteredElements)
                {
                    MessageBox.Show(fileDownloaded.SeriesDescription);
                }

                downloadedFiles.EnsureIndex("SeriesInstanceUID");
              //  downloadedFiles.Delete("1.3.6.1.4.1.5962.1.1.0.0.0.1196527414.5534.0.8");

            }
        }


        public override void onCreated(object o, FileSystemEventArgs e)
        {
            string[] splitted = e.FullPath.Split('.');
            string extension = splitted[splitted.Length - 1];
            // if dicom: convert it to xml
            if (extension != "xml")
            {
                queryTools.IsFileClosed(e.FullPath, true);
                dicom2xml(e.FullPath);
            }
            else // if xml: read it  and store file and store info into database
            {
                queryTools.IsFileClosed(e.FullPath, true);
                downloadedFileInfo downloadedFile = readDownloadedXml(e.FullPath);

                string folderStoragePath = @"C:\Users\daniele\Desktop\DATABASE\files\" + downloadedFile.PatientName+ "/" + downloadedFile.StudyDescription+"/"+ downloadedFile.SeriesDescription;
                System.IO.Directory.CreateDirectory(folderStoragePath);

                string fileStoragePath = folderStoragePath + "/" + downloadedFile.InstanceNumber + ".dcm";
                downloadedFile.FileStoragePath = fileStoragePath;
                string filePath = e.FullPath.Substring(0, e.FullPath.Length - 4); //whithout extension .xml
                try { 
                    File.Move(filePath, fileStoragePath);

                    Add(downloadedFile);
                } catch(Exception)
                {
                    MessageBox.Show("File already exists in database!");
                    File.Delete(filePath);
                }

            }
        }

        public static void dicom2xml(string path)
        {
            string arguments = " " + path + " " + path + ".xml";
            queryTools.initProcess("dcm2xml", arguments);
        }

        public static downloadedFileInfo readDownloadedXml(string path)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(path);
            downloadedFileInfo downloadedFile = new downloadedFileInfo();
            foreach (string dicomTag in downloadedFile.getKeys()) { 
                if(dicomTag != "FileStoragePath") { 
                    string myTag = findTag(doc, dicomTag);
                    downloadedFile.setValueOfTag(dicomTag, myTag.Replace(' ', '_'));
                }
            }
            File.Delete(path);
            return downloadedFile;
        }


        static string findTag(XmlDocument doc, string dicomTagName)
        {

            XmlNodeList xnList;
            xnList = doc.SelectNodes("/file-format/data-set/element[@name='" + dicomTagName + "']");
            string result = "";
            if (xnList.Count > 0)
                result = xnList[0].InnerText;
            return result;
        }

    }
}
