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
    public class FlowCorr : CUITe_WinWindow
    {
        public FlowCorr() : base("Name=WellFlo") { }

        public CUITe_WinTreeItem tree { get { return Get<CUITe_WinTreeItem>("Name=Flow Correlations"); } }

        public CUITe_WinCheckBox chkCorrSwitch { get { return Get<CUITe_WinCheckBox>("Name=chkCorrSwitch"); } }
        public CUITe_WinCheckBox chkAngleCorr { get { return Get<CUITe_WinCheckBox>("Name=chkAngleCorr"); } }

        public CUITe_WinEdit txtCorrMD { get { return Get<CUITe_WinEdit>("Name=Change correlation at MD:"); } }
        public CUITe_WinEdit wellRiserLFactor { get { return Get<CUITe_WinEdit>("Name=Well and Riser L Factor"); } }
        public CUITe_WinEdit chokeLFactor { get { return Get<CUITe_WinEdit>("Name=Subcritical choke L Factor"); } }
        public CUITe_WinEdit chokeA { get { return Get<CUITe_WinEdit>("Name=A"); } }
        public CUITe_WinEdit chokeB { get { return Get<CUITe_WinEdit>("Name=B"); } }
        public CUITe_WinEdit chokeC { get { return Get<CUITe_WinEdit>("Name=C"); } }
        public CUITe_WinEdit liquidLoadingVariable { get { return Get<CUITe_WinEdit>("Name=Variable"); } }

        #region Functions
        public void wellRiserCorr(string name)
        {
            MethodInfo method = this.FlowCorrUIMap.GetType().GetMethod("WellRiser" + name);
            method.Invoke(this.FlowCorrUIMap, null);
        }

        public void downcomerCorr(string name)
        {
            MethodInfo method = this.FlowCorrUIMap.GetType().GetMethod("Downcomer" + name);
            method.Invoke(this.FlowCorrUIMap, null);
        }

        public void pipelineCorr(string name)
        {
            MethodInfo method = this.FlowCorrUIMap.GetType().GetMethod("Pipeline" + name);
            method.Invoke(this.FlowCorrUIMap, null);
        }

        public void chokeCorr(string name)
        {
            MethodInfo method = this.FlowCorrUIMap.GetType().GetMethod("Choke" + name);
            method.Invoke(this.FlowCorrUIMap, null);
        }

        public void liquidLoadingCorr(string name)
        {
            MethodInfo method = this.FlowCorrUIMap.GetType().GetMethod("LiquidLoading" + name);
            method.Invoke(this.FlowCorrUIMap, null);
        }

        public void downcomerLFactor(double value)
        {
            this.FlowCorrUIMap.DowncomerLFactor(value);
        }

        public void pipelineLFactor(double value)
        {
            this.FlowCorrUIMap.PipelineLFactor(value);
        }
        #endregion

        #region Maps
        public FlowCorrUIMap FlowCorrUIMap
        {
            get
            {
                if ((this.flowCorrMap == null))
                {
                    this.flowCorrMap = new FlowCorrUIMap();
                }

                return this.flowCorrMap;
            }
        }

        public FlowCorrUIMap flowCorrMap;
        #endregion
    }
}
