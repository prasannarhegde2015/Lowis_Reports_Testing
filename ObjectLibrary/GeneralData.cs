using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UITest.Extension;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;
using CUITe.Controls.WinControls;
using CUITe.Controls.WpfControls;
using CUITe.Controls.HtmlControls;
using CUITe.Controls.TelerikControls;
using CUITe.Controls.SilverlightControls;
namespace WellFloRegression.ObjectLibrary
{
    public class GeneralData : CUITe_WinWindow
    {
        public GeneralData() : base("Name=WellFlo") { }

        public CUITe_WinTreeItem tree { get { return Get<CUITe_WinTreeItem>("Name=General Data"); } }

        //General Data Section
        public CUITe_WinEdit company { get { return Get<CUITe_WinEdit>("Name=Company"); } }
        public CUITe_WinEdit field { get { return Get<CUITe_WinEdit>("Name=Field"); } }
        public CUITe_WinEdit wellname { get { return Get<CUITe_WinEdit>("Name=Well"); } }
        public CUITe_WinEdit location { get { return Get<CUITe_WinEdit>("Name=Location"); } }
        public CUITe_WinEdit platform { get { return Get<CUITe_WinEdit>("Name=Platform"); } }
        public CUITe_WinEdit analyst { get { return Get<CUITe_WinEdit>("Name=Analyst"); } }
        public CUITe_WinEdit objective { get { return Get<CUITe_WinEdit>("Name=Objective"); } }
        public CUITe_WinCalendar date { get { return Get<CUITe_WinCalendar>("ControlType=DateTimePicker"); } }
        public CUITe_WinEdit notes { get { return Get<CUITe_WinEdit>("Name=Notes"); } }
    }
}
