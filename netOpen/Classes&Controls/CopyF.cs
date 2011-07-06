using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.IO;
using System.Threading;


namespace netOpen
{
    class CopyF
    {
        private string src, dst;
        private bool Ovr;

        /// <summary>
        /// Копирует файл в указанное место
        /// </summary>
        public CopyF()
        {
            src = "";
            dst = "";
            Ovr = false;
        }

        /// <summary>
        /// Копирует файл в указанное место
        /// </summary>
        /// <param name="_SourceFile">Путь к файлу-источнику</param>
        /// <param name="_DestenationFile">Путь к папке-приёмнику</param>
        public CopyF(string _SourceFile,string _DestenationFile)
        {
            OverWrite = false;
            SourceFile = _SourceFile;
            DestenationFile = _DestenationFile;
        }

        /// <summary>
        /// Копирует файл в указанное место
        /// </summary>
        /// <param name="_SourceFile">Путь к файлу-источнику</param>
        /// <param name="_DestenationFile">Путь к папке-приёмнику</param>
        /// <param name="_OverWrite">Флаг перезаписи файла</param>
        public CopyF(string _SourceFile, string _DestenationFile,bool _OverWrite)
        {
            OverWrite = _OverWrite;
            SourceFile = _SourceFile;
            DestenationFile = _DestenationFile;

        }

        /// <summary>
        /// Путь к файлу-источнику
        /// </summary>
        public string SourceFile
        {
            get { return src; }
            set { src = value; }
        }

        /// <summary>
        /// Путь к папке-приёмнику
        /// </summary>
        public string DestenationFile
        {
            get { return dst; }
            set { dst = value; }
        }

        /// <summary>
        /// Флаг перезаписи файла
        /// </summary>
        public bool OverWrite
        {
            get { return Ovr; }
            set { Ovr = value; }
        }

        /// <summary>
        /// Запускает процесс копирования с заданными настройками
        /// </summary>
        public void CopyIt()
        {
            try
            {
                MessageBox.Show(SourceFile +"\n"+ DestenationFile);
                /*if (!CopyFile(SourceFile, DestenationFile, OverWrite))
                    MessageBox.Show("Не удаётся скопировать файл!", "Ошибка", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);*/
                Thread cpthr = new Thread(new ThreadStart(ThrStart));

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ThrStart()
        {
            File.Copy(SourceFile, DestenationFile);
        }

        [DllImport("kernel32.dll",EntryPoint="CopyFileW",
           CharSet = CharSet.Unicode, ExactSpelling = true,
           CallingConvention = CallingConvention.StdCall,
           SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CopyFile(
                   [MarshalAs(UnmanagedType.LPStr)] string lpExistingFileName,
                   [MarshalAs(UnmanagedType.LPStr)] string lpNewFileName,
                   [MarshalAs(UnmanagedType.Bool)] bool bFailIfExists);

        /*[DllImport("KERNEL32.DLL", EntryPoint="CopyFileExW",  SetLastError=true,
            CharSet=CharSet.Unicode, ExactSpelling=true,
            CallingConvention=CallingConvention.StdCall)]
        public static extern bool CopyFileEx(
            [MarshalAs(UnmanagedType.LPWStr)] string src,
            [MarshalAs(UnmanagedType.LPWStr)] string dst,
            CopyProgressRoutine progressRoutine,
            object lpData,
            ref bool bCancel,
            uint dwCopyFlags
            );*/

       

    }
}
