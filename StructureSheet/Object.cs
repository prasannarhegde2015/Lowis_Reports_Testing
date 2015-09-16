using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lowis_Reports_Testing.ObjectLibrary;
using System.Data;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UITesting.WinControls;
using Microsoft.VisualStudio.TestTools.UITesting.WpfControls;
using Microsoft.VisualStudio.TestTools.UITesting.HtmlControls;

namespace Lowis_Reports_Testing.StructureSheet
{
    class UIObect
    {

        Helper hlp = new Helper();

        public void AddData(string filename, string testcase)
        {
            DataTable dt1 = hlp.dtFromExcelFile(filename, "Template");
            DataTable dt2 = hlp.dtFromExcelFile(filename, "ExpectedData", "TestCase", testcase);
            UITestControl UIcurrentparent = null;
            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                string controlValue = "";
                string parentType = dt1.Rows[i]["ParentType"].ToString();
                string parentSearchBy = dt1.Rows[i]["parentSearchBy"].ToString();
                string parentSearchValue = dt1.Rows[i]["parentSearchValue"].ToString();
                string pTechnology = dt1.Rows[i]["Technology"].ToString();
                string controlType = dt1.Rows[i]["ControlType"].ToString();
                string technologyControl = dt1.Rows[i]["TechnologyControl"].ToString();
                string field = dt1.Rows[i]["Field"].ToString();
                string index = dt1.Rows[i]["Index"].ToString();
                string searchBy = dt1.Rows[i]["SearchBy"].ToString();
                string searchValue = dt1.Rows[i]["SearchValue"].ToString();
                string pOperator = dt1.Rows[i]["pOperator"].ToString();
                string cOperator = dt1.Rows[i]["cOperator"].ToString();
                if (field.Length > 0)
                {
                    controlValue = dt2.Rows[0][field].ToString();
                }

                if (parentType.Length > 0)
                {
                    switch (parentType.ToLower())
                    {

                        #region Window
                        case "window":
                            {
                                if (pTechnology.ToLower() == "msaa")
                                {
                                    WinWindow uiwindow = new WinWindow();
                                    if (pOperator == "=")
                                    {
                                        uiwindow.SearchProperties.Add(parentSearchBy, parentSearchValue);
                                    }
                                    else if (pOperator == "~")
                                    {
                                        uiwindow.SearchProperties.Add(parentSearchBy, parentSearchValue, PropertyExpressionOperator.Contains);
                                    }
                                    UIcurrentparent = uiwindow;
                                }
                                else if (pTechnology == "uia")
                                {
                                    WpfWindow uiwindow = new WpfWindow();
                                    if (pOperator == "=")
                                    {
                                        uiwindow.SearchProperties.Add(parentSearchBy, parentSearchValue);
                                    }
                                    else if (pOperator == "~")
                                    {
                                        uiwindow.SearchProperties.Add(parentSearchBy, parentSearchValue, PropertyExpressionOperator.Contains);
                                    }
                                    UIcurrentparent = uiwindow;

                                }
                                break;
                            }
                        #endregion

                        #region client
                        case "client":
                            {
                                if (pTechnology.ToLower() == "msaa")
                                {
                                    WinClient uicleint = new WinClient(UIcurrentparent);
                                    if (pOperator == "=")
                                    {
                                        uicleint.SearchProperties.Add(parentSearchBy, parentSearchValue);
                                    }
                                    else if (pOperator == "~")
                                    {
                                        uicleint.SearchProperties.Add(parentSearchBy, parentSearchValue, PropertyExpressionOperator.Contains);
                                    }
                                    UIcurrentparent = uicleint;
                                }
                                else if (pTechnology.ToLower() == "uia")
                                {
                                    // to do
                                }
                                break;
                            }
                        #endregion

                        #region docuemnt
                        case "document":
                            {
                                if (pTechnology.ToLower() == "web")
                                {
                                    HtmlDocument uidoc = new HtmlDocument(UIcurrentparent);
                                    if (pOperator == "=")
                                    {
                                        uidoc.SearchProperties.Add(parentSearchBy, parentSearchValue);
                                    }
                                    else if (pOperator == "~")
                                    {
                                        uidoc.SearchProperties.Add(parentSearchBy, parentSearchValue, PropertyExpressionOperator.Contains);
                                    }
                                    UIcurrentparent = uidoc;
                                }
                                else if (pTechnology.ToLower() == "uia")
                                {

                                    // to do
                                }
                                break;
                            }

#endregion

                    }
                }
                if (controlType.Length > 0)
                {
                    switch (controlType.ToLower())
                    {
                        #region edit
                        case "edit":
                            {
                                if (technologyControl == "MSAA")
                                {
                                    // to do
                                }
                                else if (technologyControl == "UIA")
                                {
                                    // to do
                                }
                                else if (technologyControl == "Web")
                                {
                                    HtmlEdit uiedit = new HtmlEdit(UIcurrentparent);
                                    if (cOperator == "=")
                                    {
                                        uiedit.SearchProperties.Add(searchBy, searchValue);
                                    }
                                    else if (cOperator == "~")
                                    {
                                        uiedit.SearchProperties.Add(searchBy, searchValue, PropertyExpressionOperator.Contains);
                                    }

                                    if (controlValue.Length > 0)
                                    {

                                        uiedit.Text = controlValue;
                                    }
                                }



                                break;
                            }
                        #endregion
                        #region button
                        case "button":
                            {
                                if (technologyControl == "MSAA")
                                {
                                    // to do
                                }
                                else if (technologyControl == "UIA")
                                {
                                    // to do
                                }
                                else if (technologyControl == "Web")
                                {
                                    HtmlButton ucntl= new HtmlButton(UIcurrentparent);
                                    if (cOperator == "=")
                                    {
                                        ucntl.SearchProperties.Add(searchBy, searchValue);
                                        if (index.Length > 0)
                                        {
                                            ucntl.SearchProperties.Add("TagInstance", index);
                                        }
                                    }
                                    else if (cOperator == "~")
                                    {
                                        ucntl.SearchProperties.Add(searchBy, searchValue, PropertyExpressionOperator.Contains);
                                    }

                                    if (controlValue.Length > 0)
                                    {
                                        
                                        Mouse.Click(ucntl);
                                    }
                                }
                                break;
                            }
                        #endregion
                        #region image
                        case "image":
                            {
                                if (technologyControl == "MSAA")
                                {
                                    // to do
                                }
                                else if (technologyControl == "UIA")
                                {
                                    // to do
                                }
                                else if (technologyControl == "Web")
                                {
                                    HtmlImage ucntl = new HtmlImage(UIcurrentparent);
                                    if (cOperator == "=")
                                    {
                                        ucntl.SearchProperties.Add(searchBy, searchValue);
                                        if (index.Length > 0)
                                        {
                                            ucntl.SearchProperties.Add("TagInstance", index);
                                        }
                                    }
                                    else if (cOperator == "~")
                                    {
                                        ucntl.SearchProperties.Add(searchBy, searchValue, PropertyExpressionOperator.Contains);
                                    }

                                    if (controlValue.Length > 0)
                                    {

                                        Mouse.Click(ucntl);
                                    }
                                }
                                break;
                            }
                        #endregion
                        #region Dropdown
                        case "dropdown" :
                            {
                                if (technologyControl == "MSAA")
                                {
                                    // to do
                                }
                                else if (technologyControl == "UIA")
                                {
                                    // to do
                                }
                                else if (technologyControl == "Web")
                                {
                                    HtmlComboBox ucntl = new HtmlComboBox(UIcurrentparent);
                                    if (cOperator == "=" )
                                    {
                                        if (searchValue.Length > 0)
                                        {
                                            ucntl.SearchProperties.Add(searchBy, searchValue);
                                        }
                                        if (index.Length > 0)
                                        {
                                            ucntl.SearchProperties.Add("TagInstance", index);
                                        }
                                    }
                                    else if (cOperator == "~")
                                    {
                                        ucntl.SearchProperties.Add(searchBy, searchValue, PropertyExpressionOperator.Contains);
                                    }

                                    if (controlValue.Length > 0)
                                    {

                                        ucntl.SelectedItem = controlValue;
                                        hlp.LogtoTextFile("Entered Value in ComboBox");
                                    }
                                }
                                break;
                            }
                        #endregion 
                    }
                }








            }


        }


    }
}
