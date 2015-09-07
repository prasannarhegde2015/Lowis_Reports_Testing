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
    public class Common : CUITe_WinWindow
    {
        public Common() : base("Name=WellFlo") { }


        //Project Tasks
        public CUITe_WinButton openExisting { get { return Get<CUITe_WinButton>("Name=Open an existing model"); } }
        public CUITe_WinButton createNew { get { return Get<CUITe_WinButton>("Name=Create a new model"); } }
        public CUITe_WinEdit filename { get { return Get<CUITe_WinEdit>("Name=File name:"); } }
        public CUITe_WinSplitButton open { get { return Get<CUITe_WinSplitButton>("Name=Open"); } }

        //Mode Explorer Bar
        public CUITe_WinButton config { get { return Get<CUITe_WinButton>("Name=Configuration"); } }
        public CUITe_WinButton tuning { get { return Get<CUITe_WinButton>("Name=Tuning"); } }
        public CUITe_WinButton analysis { get { return Get<CUITe_WinButton>("Name=Analysis"); } }
        public CUITe_WinButton design { get { return Get<CUITe_WinButton>("Name=Design"); } }

        //General buttons
        public CUITe_WinButton apply { get { return Get<CUITe_WinButton>("Name=Apply"); } }
        public CUITe_WinButton back { get { return Get<CUITe_WinButton>("Name=<<<Back"); } }
        public CUITe_WinButton forward { get { return Get<CUITe_WinButton>("Name=Forward>>>"); } }
        public CUITe_WinButton undo { get { return Get<CUITe_WinButton>("Name=Undo"); } }
        public CUITe_WinButton help { get { return Get<CUITe_WinButton>("Name=Help"); } }
        public CUITe_WinButton transposeGrid { get { return Get<CUITe_WinButton>("Name=Transpose grid"); } }
        public CUITe_WinButton addRow { get { return Get<CUITe_WinButton>("Name=Add a new row"); } }
        public CUITe_WinButton insert { get { return Get<CUITe_WinButton>("Name=Insert a row before the current row"); } }
        public CUITe_WinButton delete { get { return Get<CUITe_WinButton>("Name=Delete current row"); } }
        public CUITe_WinButton addRemoveColumns { get { return Get<CUITe_WinButton>("Name=Add or remove columns"); } }
        public CUITe_WinButton import { get { return Get<CUITe_WinButton>("Name=Import data from external source"); } }
        public CUITe_WinButton catalogData { get { return Get<CUITe_WinButton>("Name=Select row from catalog"); } }
        public CUITe_WinButton print { get { return Get<CUITe_WinButton>("Name=Print"); } }

    }
}
