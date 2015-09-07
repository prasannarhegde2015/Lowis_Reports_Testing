using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Forms;
using System.Drawing;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using WellFloRegression.ObjectLibrary;
using Weatherford.Core.Logging;

namespace WellFloRegression
{
    [CodedUITest]
    public class DemoTests
    {
        private TestContext testContextInstance;
        private static string testProcess = "WellFlo";
        private ApplicationUnderTest testApp;
        public Common common = new Common();
        public GeneralData generalData = new GeneralData();
        public WellandFlowType wellType = new WellandFlowType();
        public FlowCorr flowCorr = new FlowCorr();

        private LogMessageSource _log = new LogMessageSource();

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

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Close the app after all tests are finished
            Playback.Initialize();
            try
            {
                Process[] processes = Process.GetProcessesByName(testProcess);

                foreach (Process process in processes)
                {
                    ApplicationUnderTest app = ApplicationUnderTest.FromProcess(process);
                    app.Close();
                }
            }
            finally
            {
                Playback.Cleanup();
            }
        }

        [TestInitialize()]
        public void TestInitialize()
        {
            // Launch Calculator if not already running
            if (Process.GetProcessesByName(testProcess).Length == 0)
            {
                testApp = ApplicationUnderTest.Launch(@"C:\Program Files (x86)\Weatherford\WellFlo\WellFlo.exe");
                common.Maximized = true;
            }
            // Initialize logging
            LogMessageRouter.Instance.AddDestination(new LogMessageWriterCSV("C:\\Logs\\", "DemoTestLogs"));
            LogMessageRouter.Instance.Ready();

            _log.Log(LogMessageSeverity.Information, "Demo Test Initialized");
        }

        [TestCleanup()]
        public void TestCleanup()
        {
            // If test failed, then close the app. The next test will restart it
            if (testContextInstance.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                testApp.Close();
            }
        }

        [TestMethod, Description("Open, create new, select multifrac, heavy oil pcp, close")]
        public void TestCase1()
        {
            _log.Log(LogMessageSeverity.Information, "Starting Test Case 1");

            try
            {
                common.createNew.Click();
                _log.Log(LogMessageSeverity.Information, "Create new model clicked");

                common.config.Click();
                _log.Log(LogMessageSeverity.Information, "Configuration Clicked");

                Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;
                _log.Log(LogMessageSeverity.Information, "Waiting for all threads to finish processing");

                wellType.tree.Click();
                _log.Log(LogMessageSeverity.Information, "Well and Flow Type clicked");

                Playback.PlaybackSettings.WaitForReadyLevel = WaitForReadyLevel.AllThreads;
                _log.Log(LogMessageSeverity.Information, "Waiting on all threads");

                wellType.pcp.Click();
                _log.Log(LogMessageSeverity.Information, "PCP cliekced");

                wellType.producer.Click();
                _log.Log(LogMessageSeverity.Information, "Producer clicked");

                wellType.tubing.Click();
                _log.Log(LogMessageSeverity.Information, "Tubing clicked");

                wellType.heavyoil.Click();
                _log.Log(LogMessageSeverity.Information, "Heavy oil clicked");

                wellType.multifrac.Click();
                _log.Log(LogMessageSeverity.Information, "Multifrac clicked");

                wellType.multiphase.Click();
                _log.Log(LogMessageSeverity.Information, "Multiphase clicked");

                common.apply.Click();
                
                _log.Log(LogMessageSeverity.Information, "Apply clicked");

                _log.Log(LogMessageSeverity.Information, "Test Case 1 finished running");
            }
            catch (Exception ex)
            {
                _log.Log(LogMessageSeverity.Error, "Test Case 1 failed with error: " + ((ex.InnerException != null) ? ex.InnerException.Message : ex.Message));
            }
        }

        [TestMethod, Description("Open, create new, select vertical, heavy oil, esp, gray well and riser flow corr, close")]
        public void TestCase2()
        {
            common.createNew.Click();
            wellType.tree.Click();
            wellType.esp.Click();
            wellType.producer.Click();
            wellType.tubing.Click();
            wellType.heavyoil.Click();
            wellType.vertical.Click();
            common.apply.Click();
            flowCorr.tree.Click();
            flowCorr.wellRiserCorr("Gray");
            flowCorr.chokeA.Text = "4";
            common.apply.Click();
        }
    }
}
