using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using SystemMaintenance.DTO;
using EVOFramework;
using EVOFramework.Database;
using CommonLib;
using SystemMaintenance;
using SystemMaintenance.Forms;
using System.Reflection;
using System.Drawing;
using EVOFramework.Windows.Forms;
using SystemMaintenance.Controller;
using EVOFramework.IO;
using EVOFramework.Data;
using System.Diagnostics;
using System.Globalization;
using System.Xml.XPath;

namespace StarterKit
{
    static class Program
    {
        [ThreadStatic]
        private static MenuFrame m_menuFrame = null;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if (RunAutoUpdate(args))
            {
                //ถ้าใน method RunAutoUpdate ทำงาน
                //แล้ว return true; แปลว่า ให้มัน run autoupdate เฉยๆ ไม่ต้อง new thread
                //เพราะauto update จะจัดการเปิดโปรแกรมให้ใหม่ 
                //(ซึ่ง autoupdate จะ set param ให้เวลา run อีกรอบ จะทำให้ method return false

                //แต่ถ้า return false; แปลว่าหา path ไม่เจอ ก็ให้มันทำงานได้เลย
            }
            else
            {

                //Set default culture to English-United state
                //set default date to dd/MM/yyyy
                Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

                CultureInfo culture = new System.Globalization.CultureInfo("en-US");
                culture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
                culture.DateTimeFormat.ShortTimePattern = "HH:mm";
                culture.DateTimeFormat.LongTimePattern = "HH:mm:ss";
                culture.DateTimeFormat.DateSeparator = "/";
                Thread.CurrentThread.CurrentCulture = culture;


                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.ThrowException);

                // Enter life-cycle main form.
                try
                {
                    while (true)
                    {
                        LoginForm form = new LoginForm();
                        if (form.ShowDialog() == DialogResult.Cancel)
                            return;

                        //UserController userController = new UserController();
                        //if (!userController.Login("SYSTEM".ToNZString(), "SYSTEM".ToNZString()))
                        //    return;

                        //=========================
                        LoadConfiguration();

#warning Injection to load plugins
                        string path = System.IO.Path.Combine(Application.StartupPath, @"Rubik.Forms.DLL");
                        InternalScreenCache.GetInstance().LoadScreensFromAssembly(path);

                        try
                        {
                            Assembly tkpFormAsm = Assembly.LoadFile(path);
                            Common.Version.Value = tkpFormAsm.GetName().Version.ToString();
                            Common.UpdateDate.Value = GetBuildDate(tkpFormAsm.GetName().Version);

                            //FileInfo tkpFileInfo = new FileInfo(path);
                            //Common.UpdateDate.Value = tkpFileInfo.CreationTime.ToString("yyyy/MM/dd");
                            //Common.UpdateDate.Value = DataDefine.PROGRAM_DATE;

                        }
                        catch (Exception err)
                        {
                            System.Diagnostics.Debug.WriteLine(err.Message);
                            Common.Version.Value = string.Empty;
                            Common.UpdateDate.Value = string.Empty;
                        }

                        // --------------
                        Thread LoadReportTread = new Thread(new ThreadStart(LoadDummyReport));
                        LoadReportTread.Start();
                        // ==============

                        m_menuFrame = new MenuFrame();

                        Application.Run(m_menuFrame);

                        // if user choose to close menu form, terminate application.
                        if (!m_menuFrame.IsLogout)
                        {
                            return;
                        }
                    }  // end while


                }
                catch (ValidateException err)
                {
                    MessageDialog.ShowBusiness(null, err.ErrorResults[0].Message);
                    if (m_menuFrame != null && !m_menuFrame.IsDisposed)
                        m_menuFrame.Dispose();
                }
                catch (BusinessException err)
                {
                    MessageDialog.ShowBusiness(null, err.Error.Message);
                    if (m_menuFrame != null && !m_menuFrame.IsDisposed)
                        m_menuFrame.Dispose();
                }
                catch (Exception err)
                {
                    Console.WriteLine(err.Message);

                    //MessageDialog.ShowSingleItem(null, "Error", err.StackTrace, MessageDialogIcon.Error);
                    ErrorDialog errorDialog = new ErrorDialog();
                    errorDialog.Message = @"Connection failed. " + System.Environment.NewLine + err.Message;
                    errorDialog.StackTrace = err.StackTrace;
                    errorDialog.ShowDialog();

                    if (m_menuFrame != null && !m_menuFrame.IsDisposed)
                        m_menuFrame.Dispose();


                    //TODO: Remark LoginForm for customer TAKEI
                    Application.ExitThread();
                    Application.Restart();
                }
            }
        }

        private static string GetBuildDate(Version argApplicationVersion)
        {
            string strBuildDate = "";

            try
            {
                System.DateTime dateBuild = new System.DateTime(2000, 1, 1);
                int Builld = argApplicationVersion.Build;
                dateBuild = dateBuild.AddDays(Builld);

                strBuildDate = dateBuild.ToString("dd/MM/yyyy");
            }
            catch
            {
                strBuildDate = argApplicationVersion.ToString();
            }

            return strBuildDate;
        }

        private static void LoadDummyReport()
        {
            FakeReportForLoadLibrary rptFake = new FakeReportForLoadLibrary();
        }

        static void LoadConfiguration()
        {
            IniFile iniFile = new IniFile(System.IO.Path.Combine(Application.StartupPath, Common.CONFIG_FILENAME));
            string strAppearance = iniFile.Read(ConfigIniSection.Application, "Appearance", string.Empty);
            iniFile.Dispose();

            if (System.IO.File.Exists(System.IO.Path.Combine(Application.StartupPath, strAppearance)))
            {
                AppearanceList aprList = AppearanceSerializer.Deserialize(strAppearance);
                AppearanceManager.RegisterAppearance(aprList);
            }
            else
            {
                if (strAppearance != string.Empty)
                {
                    MessageDialog.ShowBusiness(null, null, "Not found appearance configuration file.");
                }

                //Unregister appearance and use system appearance.
                AppearanceManager.UnregisterAppearance();
            }

        }


        private static bool RunAutoUpdate(string[] args)
        {
            //ถ้าเป็น debug mode ก็ไม่ต้อง check อะไร return true ไปได้เลย
            //#if (DEBUG)
            //            return false;
            //#endif


            bool ret = false;

            ConfigurationController prc = new ConfigurationController();
            Map<string, string> mapConfig = prc.LoadConfiguration();

            string strAutoUpdatePath = mapConfig[ConfigurationController.S_KEY_AUTOUPDATE_PATH].Value;
            string strAutoUpdateFileName = mapConfig[ConfigurationController.S_KEY_AUTOUPDATE_FILENAME].Value;


            try
            {
                XPathDocument document = new XPathDocument(AppDomain.CurrentDomain.BaseDirectory + "AutoUpdate.exe.config");
                XPathNavigator navigator = document.CreateNavigator();
                XPathNodeIterator nodes = navigator.Select("/configuration/remotepath");
                if (nodes.MoveNext())
                {
                    strAutoUpdatePath = nodes.Current.Value;
                }
            }
            catch
            {

            }



            if (ConnectToAutoUpdateServer(strAutoUpdatePath))
            {

                //clear readonly ออก ไม่งั้นมันจะ copy ทับไม่ได้
                ResetAttributeFiles(System.Environment.CurrentDirectory);

                //  If not have argument - Check AutoUpdate.exe for run
                if (args.Length == 0)
                {
                    //ถ้ามี file autoupdate ใน folder ค่อย run ให้มัน update
                    string strAutoUpdateFullPath = Application.StartupPath + "\\" + strAutoUpdateFileName;

                    FileInfo fInfo = new FileInfo(strAutoUpdateFullPath);
                    if (fInfo.Exists)
                    {
                        RunAutoUpdateProcess(strAutoUpdateFullPath);
                        ret = true;
                    }
                }
                else if (args.Length >= 1)
                {
                    ret = false;
                    ////มันจะcheck กับ autoupdate หลังจากที่ทำ autoupdate เสร็จ
                    ////แล้วมันจะrun program ใหม่โดย ส่ง parameter มาอีกที ว่าเป็นตัว autoupdate run
                    ////โดยset ที่ Argument ของ program autoupdate
                    //if (args[0].ToLower() == "SkipUpdate".ToLower())
                    //{
                    //    //ถ้ามันเท่า ก็ไม่ต้องทำอะไร
                    //}
                    //else
                    //{
                    //    //ยังไม่ได้ทำ เพราะว่า autoupdate มันไม่ support ให้มี argument
                    //}
                }
            }


            return ret;
        }

        private static void ResetAttributeFiles(string path)
        {
            if (File.Exists(path))
            {
                // This path is a file
                ProcessFile(path);
            }
            else if (Directory.Exists(path))
            {
                // This path is a directory
                ProcessDirectory(path);
            }
        }

        private static void ProcessFile(string path)
        {
            FileInfo fi = new FileInfo(path);

            try
            {
                fi.IsReadOnly = false;
            }
            catch (Exception ex)
            {

            }
        }

        private static void ProcessDirectory(string targetDirectory)
        {
            // Process the list of files found in the directory.
            string[] fileEntries = Directory.GetFiles(targetDirectory);
            foreach (string fileName in fileEntries)
            {
                ProcessFile(fileName);
            }

            // Recurse into subdirectories of this directory.
            string[] subdirectoryEntries = Directory.GetDirectories(targetDirectory);
            foreach (string subdirectory in subdirectoryEntries)
            {
                ProcessDirectory(subdirectory);
            }
        }

        private static void RunAutoUpdateProcess(string strAutoUpdateFullPath)
        {
            try
            {
                Process AutoUpdateProcess = new Process();

                AutoUpdateProcess.StartInfo.FileName = strAutoUpdateFullPath;//Application.StartupPath + "\\" + AUTO_UPDATE_APPLICATION_NAME;
                AutoUpdateProcess.Start();

            }
            catch (Exception ex)
            {
                MessageDialog.ShowBusiness((IWin32Window)null, ex.Message);
            }

        }

        private static bool ConnectToAutoUpdateServer(string strAutoUpdatePth)
        {
            bool blnResult;

            try
            {
                blnResult = false;

                string AutoUpdatePath = @"";

                try
                {

                    AutoUpdatePath = strAutoUpdatePth;
                }
                catch
                {
                    AutoUpdatePath = @"";
                }

                try
                {
                    FileSystemWatcher watcher = new FileSystemWatcher(AutoUpdatePath);
                    blnResult = true;
                }
                catch
                {
                    blnResult = false;
                }

            }
            catch (Exception ex)
            {
                throw ex;

            }

            return blnResult;
        }
    }
}
