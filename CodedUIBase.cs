using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.Configuration;
using System.Data;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Keyboard = Microsoft.VisualStudio.TestTools.UITesting.Keyboard;
using System.IO;
using Lowis_Reports_Testing.ObjectLibrary;



namespace Lowis_Reports_Testing
{

    public class CodedUIBase
    {
        string lowisclientbinlocation = ConfigurationManager.AppSettings["binpath"];
        string lowisserver = ConfigurationManager.AppSettings["servername"];
        string lowisusername = ConfigurationManager.AppSettings["username"];
        string lowispassword = ConfigurationManager.AppSettings["password"];
        protected ApplicationUnderTest TestApp;

        #region TEST_INITIALIZE
   
        public void LaunchLowisServer()
        {
            LowisConnectDialog lconndlg = new LowisConnectDialog();
            LowisSettingsDialog lsettings = new LowisSettingsDialog();
            LowisMainWindow lwin = new LowisMainWindow();
            try
            {
                TestApp = ApplicationUnderTest.Launch(lowisclientbinlocation);
                lconndlg.selectServer(lowisserver);
                if (lowisusername.Length == 0 && lowispassword.Length == 0)
                {
                    //use default readio button Simply connect
                    lconndlg.Settings.Click();
                    lsettings.storepath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).ToString(), "csstore", DateTime.Now.ToString("ddMMMyyyyhhmmss"));
                    lsettings.btnSavesettings.Click();
                    lconndlg.Connect.Click();
                    lwin.Analysis.WaitForControlReady();
                    lwin.Analysis.Click();

                }
                else
                {
                    lconndlg.usecredentails.Click();
                    lconndlg.txtuserName.Text = lowisusername;
                    lconndlg.txtuserName.Text = lowispassword;
                    lconndlg.Settings.Click();
                    lsettings.storepath.Text = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile).ToString(), "csstore", DateTime.Now.ToString("ddMMMyyyyhhmmss"));
                    lsettings.btnSavesettings.Click();
                    lconndlg.Connect.Click();
                    lwin.Analysis.WaitForControlReady();
                    lwin.Analysis.Click();

                }
            }
            catch (Exception ex)
            {
                TestContext.WriteLine("Encountered Exception: " + ex.Message);
            }
        }
        #endregion

        #region TEST_CLEANUP
    
        public void closeLowisCleint()
        {
            TestApp.Close();
        }
        #endregion

        #region UnitTestsDefaults
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }
        private TestContext testContextInstance;


        #endregion
    }
}
