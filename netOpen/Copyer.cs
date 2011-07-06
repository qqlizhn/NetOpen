using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Security.Permissions;
using System.Security.Principal;
using System.Security;
using System.Windows.Forms;

namespace netOpen
{
   public class Copyer
    {
        public CopyInfo CurrentInfo;
        public int BufferSize { get; set; }
        public event Action<int> ChangedProgress;
        public event Action<bool> CopyComplete;
        private int Percent,prPer;

        public Copyer(CopyInfo Info)
        {
            CurrentInfo = Info;
            BufferSize = 32768;
        }

        public Copyer(string SourcePath,string DestenationPath)
        {
            CurrentInfo = new CopyInfo(SourcePath, DestenationPath);
            BufferSize = 32768;
        }

       //[PrincipalPermission(SecurityAction.Demand, Role = @"BUILTIN\Administrators")]
        public void CopyIt()
        {
            decimal FileL=0;
            decimal i=0;
            decimal onep = 0;
            //CheckAdministrator();
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            // Check using the PrincipalPermissionAttribute

            FileIOPermission fileOpenPermission = new FileIOPermission(FileIOPermissionAccess.Read, CurrentInfo.SourcePath);
            FileIOPermission fileWrtitePerission = new FileIOPermission(FileIOPermissionAccess.Write, CurrentInfo.DestenationPath);
            try
            {
                //CheckAdministrator();
                fileOpenPermission.Demand();
                fileWrtitePerission.Demand();
                FileStream fs = new FileStream(CurrentInfo.SourcePath, FileMode.Open, FileAccess.Read);
                FileStream ds = new FileStream(CurrentInfo.DestenationPath, FileMode.CreateNew, FileAccess.Write);
                BinaryReader br = new BinaryReader(fs);
                BinaryWriter bw = new BinaryWriter(ds);
                FileL = fs.Length;
                onep = FileL / 100;
                if (FileL < BufferSize)
                {
                    bw.Write(br.ReadBytes((int)FileL));
                    Percent = 100;
                    CopyComplete(true);
                }
                else
                    while (i < FileL)
                    {
                        if (i + BufferSize > FileL)
                        {
                            bw.Write(br.ReadBytes((int)(FileL - i)));
                            i = FileL;
                        }
                        else
                        {
                            bw.Write(br.ReadBytes(BufferSize));
                            if (prPer!=Percent)
                            ChangedProgress(Percent);
                            i += BufferSize;
                        }
                        //Percent = (int)(Math.Round(i / FileL * 100,MidpointRounding.AwayFromZero));
                        prPer = Percent;
                        Percent = (int)Math.Round((i / onep), MidpointRounding.ToEven);
                        if (i == FileL) { Percent = 100; CopyComplete(true); }

                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\n"+ex.GetType().ToString(),"CopyProblem");
                MessageBox.Show("1st"+CurrentInfo.SourcePath + "\n" +"2nd"+CurrentInfo.DestenationPath, "Pathes");
                if (ex.GetType().Name == "UnauthorizedAccessException")
                {
                    MessageBox.Show(ex.GetType().Name.ToString());
                    //PrincipalPermission principalPerm = new PrincipalPermission(null, "Администраторы");
                    //principalPerm.Demand();
                    // Check using PrincipalPermission class.
                    PrincipalPermission principalPerm = new PrincipalPermission(null, "Administrators");
                    principalPerm.Demand();
                }
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Role = @"BUILTIN\Administrators")]
        static void CheckAdministrator()
        {
            MessageBox.Show("User is an administrator");
        }

        static void ChPer(int Percent)
        { }
    }
}
