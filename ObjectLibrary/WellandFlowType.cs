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
    public class WellandFlowType : CUITe_WinWindow
    {
        public WellandFlowType() : base("Name=WellFlo") { }

        public CUITe_WinTreeItem tree { get { return Get<CUITe_WinTreeItem>("Name=Well and Flow Type"); } }
        
        //WellType
        public CUITe_WinRadioButton producer { get { return Get<CUITe_WinRadioButton>("Name=Producer"); } }
        public CUITe_WinRadioButton injector { get { return Get<CUITe_WinRadioButton>("Name=Injector"); } }
        public CUITe_WinRadioButton pipeline { get { return Get<CUITe_WinRadioButton>("Name=Pipeline"); } }
        public CUITe_WinRadioButton none { get { return Get<CUITe_WinRadioButton>("Name=None"); } }
        public CUITe_WinRadioButton contGL { get { return Get<CUITe_WinRadioButton>("Name=Continuous Gas Lift"); } }
        public CUITe_WinRadioButton intGL { get { return Get<CUITe_WinRadioButton>("Name=Intermittent Gas Lift"); } }
        public CUITe_WinRadioButton esp { get { return Get<CUITe_WinRadioButton>("Name=ESP"); } }
        public CUITe_WinRadioButton pcp { get { return Get<CUITe_WinRadioButton>("Name=PCP"); } }
        public CUITe_WinRadioButton jetpump { get { return Get<CUITe_WinRadioButton>("Name=Jet Pump"); } }
        public CUITe_WinRadioButton plunger { get { return Get<CUITe_WinRadioButton>("Name=Plunger Lift"); } }
        public CUITe_WinRadioButton rrl { get { return Get<CUITe_WinRadioButton>("Name=ReciprocatingRod Lift"); } }
        public CUITe_WinRadioButton singlephase { get { return Get<CUITe_WinRadioButton>("Name=Single Phase Flow"); } }
        public CUITe_WinRadioButton multiphase { get { return Get<CUITe_WinRadioButton>("Name=Multiphase Flow"); } }
        public CUITe_WinRadioButton tubing { get { return Get<CUITe_WinRadioButton>("Name=Tubing"); } }
        public CUITe_WinRadioButton annular { get { return Get<CUITe_WinRadioButton>("Name=Annular"); } }
        public CUITe_WinRadioButton tubingandannular { get { return Get<CUITe_WinRadioButton>("Name=Tubing and Annular"); } }
        public CUITe_WinRadioButton reverse { get { return Get<CUITe_WinRadioButton>("Name=Reverse (Tubing)"); } }
        public CUITe_WinRadioButton standard { get { return Get<CUITe_WinRadioButton>("Name=Standard (Annular)"); } }
        public CUITe_WinRadioButton heavyoil { get { return Get<CUITe_WinRadioButton>("Name=Heavy Oil"); } }
        public CUITe_WinRadioButton blackoil { get { return Get<CUITe_WinRadioButton>("Name=Black Oil"); } }
        public CUITe_WinRadioButton volatileoil { get { return Get<CUITe_WinRadioButton>("Name=Volatile Oil"); } }
        public CUITe_WinRadioButton condensate { get { return Get<CUITe_WinRadioButton>("Name=Condensate"); } }
        public CUITe_WinRadioButton drygas { get { return Get<CUITe_WinRadioButton>("Name=Dry Gas"); } }
        public CUITe_WinRadioButton vertical { get { return Get<CUITe_WinRadioButton>("Name=Vertical"); } }
        public CUITe_WinRadioButton horizontal { get { return Get<CUITe_WinRadioButton>("Name=Horizontal"); } }
        public CUITe_WinRadioButton multifrac { get { return Get<CUITe_WinRadioButton>("Name=Multi Frac"); } }

    }
}
