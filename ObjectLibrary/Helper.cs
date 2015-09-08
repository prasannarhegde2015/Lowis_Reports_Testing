using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Data;
using System.Data.Odbc;
using System.Configuration;

namespace Lowis_Reports_Testing.ObjectLibrary
{
    class Helper
    {
        private DataTable _dtRep = new DataTable();
        public DataTable dtRep
        {
            get { return _dtRep; }
            set { _dtRep = value; }
        }
        int counter = 1;
        public DataTable dtFromExcelFile(string filepath, string sheetname)
        {
            try
            {
                DataTable dtble = new DataTable();

                OdbcConnection oconn = new OdbcConnection();
                oconn.ConnectionString = ConfigurationManager.ConnectionStrings["ReportLinks"].ToString() + filepath;
                string odbccmdtext = "Select * from [" + sheetname + "$]";
                OdbcCommand ocmd = new OdbcCommand(odbccmdtext, oconn);
                oconn.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(ocmd);
                da.Fill(dtble);
                oconn.Close();
                return dtble;
            }
            catch
            {
                throw new Exception();
            }

        }

        public DataTable dtFromExcelFile(string filepath, string sheetname, string filtercolumnName,string filtervalue)
        {
            try
            {
                DataTable dtble = new DataTable();

                OdbcConnection oconn = new OdbcConnection();
                oconn.ConnectionString = ConfigurationManager.ConnectionStrings["ReportLinks"].ToString() + filepath;
                string odbccmdtext = "Select * from [" + sheetname + "$]  where " + filtercolumnName + "='" + filtervalue + "'";
                OdbcCommand ocmd = new OdbcCommand(odbccmdtext, oconn);
                oconn.Open();
                OdbcDataAdapter da = new OdbcDataAdapter(ocmd);
                da.Fill(dtble);
                oconn.Close();
                return dtble;
            }
            catch
            {
                throw new Exception();
            }

        }
        public void AreEqual(string tcnameid, string linkName, string VerifyParameter, string exp, string act, LReportPane.CompareType compareOperator)
        {
            
            if (counter == 1)
            {
                dtRep.Columns.Add("TestCaseNameORId");
                dtRep.Columns.Add("LinkName");
                dtRep.Columns.Add("VerifyParameter");
                dtRep.Columns.Add("Expected");
                dtRep.Columns.Add("Actual");
                dtRep.Columns.Add("Result");
            }
            DataRow dr = dtRep.NewRow();
            switch (compareOperator.ToString().ToLower())
            #region OperatorsofVerify
            {
            
                   case  "equal" :

                      {
                          if (exp.Length > 0 )
                          {
                              if (exp.ToLower().Trim() == act.ToLower().Trim())
                              {
                                  dr["TestCaseNameORId"] = tcnameid;
                                  dr["LinkName"] = linkName;
                                  dr["VerifyParameter"] = VerifyParameter;
                                  dr["Expected"] = exp;
                                  dr["Actual"] = trimcustom(act);
                                  dr["Result"] = "Pass";
                              }
                              else
                              {
                                  dr["TestCaseNameORId"] = tcnameid;
                                  dr["LinkName"] = linkName;
                                  dr["VerifyParameter"] = VerifyParameter;
                                  dr["Expected"] = exp;
                                  dr["Actual"] = trimcustom(act);
                                  dr["Result"] = "Fail";
                              }
                          }
                            break;
                    }
                   case "contains":
                      {
                          if (exp.Length > 0)
                          {
                              if (cleanIntermediateWhiteSpaces(trimcustom(act)).ToLower().Contains(cleanIntermediateWhiteSpaces(trimcustom(exp)).ToLower()))
                              {
                                  dr["TestCaseNameORId"] = tcnameid;
                                  dr["LinkName"] = linkName;
                                  dr["VerifyParameter"] = VerifyParameter;
                                  dr["Expected"] = exp;
                                  dr["Actual"] = trimcustom(act);
                                  dr["Result"] = "Pass";
                              }
                              else
                              {
                                  dr["TestCaseNameORId"] = tcnameid;
                                  dr["LinkName"] = linkName;
                                  dr["VerifyParameter"] = VerifyParameter;
                                  dr["Expected"] = exp;
                                  dr["Actual"] = trimcustom(act);
                                  dr["Result"] = "Fail";
                              }
                          }
                          break;
                      }

                   case "tolerance":
                      {
                          break;
                      }

                   case "decimalround":
                      {
                          break;
                      }
                 default : 
                    {
                        break;
                    }

            }
            #endregion


            if (dr["TestCaseNameORId"].ToString().Length > 0)
            {
                dtRep.Rows.Add(dr);
            }
            counter++;
        }

        public void LogtoFileCSV(DataTable dtin)
        {
            char delm = '\u0022';
            StringBuilder sb = new StringBuilder();

            if (System.IO.File.Exists(ConfigurationManager.AppSettings["logfile"]) == false)
            {
                //Adding Header Row only once
                for (int kk = 0; kk < dtin.Columns.Count; kk++)
                {
                    sb.Append(delm + dtin.Columns[kk].ColumnName.ToString() + delm + ",");
                    
                }

                sb.Append(Environment.NewLine);
            }
            
            for (int i = 0; i < dtin.Rows.Count; i++)
            {
                for (int kk = 0; kk < dtin.Columns.Count; kk++)
                {
                    sb.Append(delm + dtin.Rows[i][kk].ToString() + delm + ",");
                }
                sb.Append(Environment.NewLine);
            }

            System.IO.File.AppendAllText(ConfigurationManager.AppSettings["logfile"], sb.ToString());
        }

        private string trimcustom(string inp)
        {
            string op = "";
            char[] chartotrim = { ' ', '\n', '\t' };
            op = inp.Trim(chartotrim);
            string fop = op.Replace('\n', '_');
            fop = fop.Replace('\r', '_');
            if (fop.Length > 255)
            {
                // trim charts to 255 only 
                fop = fop.Substring(0, 255);
            }
            return fop;
        }
        public void LogtoTextFile(string msg)
        {
            System.IO.File.AppendAllText(ConfigurationManager.AppSettings["logtextfile"], "[" + System.DateTime.Now.ToString() + "] :" + msg + System.Environment.NewLine);


        }
        private string cleanIntermediateWhiteSpaces(string strinput)
        {

           string  pattn = "\\s+" ;
           Regex re = new Regex(pattn);
           string retstring = re.Replace(strinput, "_");
           return retstring;
        
        }
    }
}