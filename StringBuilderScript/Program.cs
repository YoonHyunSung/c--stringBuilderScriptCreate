using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace StringBuilderScript
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder scriptWriter = new StringBuilder();
            int iRowNumber = -1;
            if ("Y".Equals(this.grvAplcn.GetRowCellValue(iRowNumber, "newTblAplcnYn").ToString().Trim()))
            {
                scriptWriter.WriteLine("CREATE TABLE AMISDBA." + this.txtRelTblNm.Text.ToString().Trim() + "  (");
                if ("C".Equals(grvAplcn.GetRowCellValue(iRowNumber, "dbAplcKindCd")))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {
                        if (i < arr.Length - 1)
                        {
                            lScriptCreate.Append(grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim()
                                                  + "  "
                                                  + grdTermView.GetRowCellValue(arr[i], "dataTypNm").ToString().Trim());
                            if (grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim() != null && grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim().Length > 0
                                && !"".Equals(grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim()))
                            {
                                lScriptCreate.Append(" "
                                                    + "default"
                                                    + '\''
                                                    + grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim()
                                                    + '\'');
                            }
                            if (grdTermView.GetRowCellValue(arr[i], "nullable").ToString().Trim() != "Y")
                            {
                                lScriptCreate.Append(" " + "NOT NULL");
                            }
                            lScriptCreate.Append("," + "\n");
                        }
                        else
                        {
                            lScriptCreate.Append(grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim()
                                            + "  "
                                            + grdTermView.GetRowCellValue(arr[i], "dataTypNm").ToString().Trim());
                            if (grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim() != null && grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim().Length > 0
                                && !"".Equals(grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim()))
                            {
                                lScriptCreate.Append(" "
                                                    + "default"
                                                    + '\''
                                                    + grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim()
                                                    + '\'');
                            }
                            if (grdTermView.GetRowCellValue(arr[i], "nullable").ToString().Trim() != "Y")
                            {
                                lScriptCreate.Append(" " + "NOT NULL");
                            }

                        }
                        if (lCommentString.Trim().Length < 1)
                        {
                            lCommentString = "comment on table"
                                             + "  "
                                             + "AMISDBA."
                                             + this.txtRelTblNm.Text.ToString().Trim()
                                             + "\n"
                                             + "is"
                                             + "  "
                                             + '\''
                                             + grdTermView.GetRowCellValue(arr[i], "columnComments").ToString().Trim()
                                             + '\''
                                             + ";";
                        }
                        else lCommentString = "comment on table"
                                             + "  "
                                             + "AMISDBA."
                                             + this.txtRelTblNm.Text.ToString().Trim()
                                             + "\n"
                                             + "is"
                                             + "  "
                                             + '\''
                                             + grdTermView.GetRowCellValue(arr[i], "columnComments").ToString().Trim()
                                             + '\''
                                             + ";"
                                             + "\n"
                                             + lCommentString;
                        if ("Y".Equals(grdTermView.GetRowCellValue(arr[i], "constraintType").ToString().Trim()))
                        {
                            if (lPKstring.Trim().Length < 1)
                                lPKstring = grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim();
                            else
                            {
                                lPKstring = grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim()
                                            + ","
                                            + "  "
                                            + lPKstring;
                            }
                        }

                    }
                    lFullName = lFullName + lScriptCreate.ToString() + "\n" + ")";
                    scriptWriter.WriteLine(lFullName);
                    scriptWriter.WriteLine(lCommentString);
                    scriptWriter.WriteLine("alter table AMISDBA.ZZANMUSER  add constraint PK_" + this.txtRelTblNm.Text.ToString().Trim() + " " + "primary key" + "  (" + lPKstring + ")");
                    scriptWriter.Close();
                    System.Diagnostics.Process.Start("Notepad.exe", FilePath);
                }
            }
            else
            {
                if ("C".Equals(grvAplcn.GetRowCellValue(iRowNumber, "dbAplcKindCd")))
                {
                    for (int i = 0; i < arr.Length; i++)
                    {

                        if ("수정".Equals(this.grdTermView.GetRowCellValue(arr[i], "comnChngCd").ToString().Trim()))
                        {
                            lScriptModify.Append("ALTER TABLE"
                                  + "  "
                                  + "AMISDBA."
                                  + this.txtRelTblNm.Text.ToString().Trim()
                                  + "  "
                                  + "MODIFY"
                                  + "  "
                                  + this.grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim()
                                  + "  "
                                  + this.grdTermView.GetRowCellValue(arr[i], "dataTypNm").ToString().Trim());
                            if (grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim() != null && grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim().Length > 0
                                && !"".Equals(grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim()))
                            {
                                lScriptModify.Append(" "
                                                    + "DEFAULT"
                                                    + '\''
                                                    + grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim()
                                                    + '\'');
                            }
                            if (grdTermView.GetRowCellValue(arr[i], "nullable").ToString().Trim() != "Y")
                            {
                                lScriptModify.Append(" " + "NOT NULL");
                            }
                            lScriptModify.Append(";"
                                                 + "\n");
                            ///PK설정우예하노.
                            ///PK는 제거 와 추가에 따라 스크립트 사항이 달라진다.
                        }
                        else if ("삭제".Equals(this.grdTermView.GetRowCellValue(arr[i], "comnChngCd").ToString().Trim()))
                        {
                            lScriptDrop.Append("ALTER TABLE"
                                              + "  "
                                              + "AMISDBA."
                                              + this.txtRelTblNm.Text.ToString().Trim()
                                              + "  "
                                              + "DROP COLUMN"
                                              + "  "
                                              + this.grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim()
                                              + ";"
                                              + "\n");
                        }
                        else if ("추가".Equals(this.grdTermView.GetRowCellValue(arr[i], "comnChngCd").ToString().Trim()))
                        {
                            lScriptAdd.Append("ALTER TABLE"
                                              + "  "
                                              + "AMISDBA."
                                              + this.txtRelTblNm.Text.ToString().Trim()
                                              + "  "
                                              + "ADD"
                                              + "  "
                                              + this.grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim()
                                              + "  "
                                              + this.grdTermView.GetRowCellValue(arr[i], "dataTypNm").ToString().Trim());
                            if (grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim() != null && grdTermView.GetRowCellValue(arr[i], "columnNm").ToString().Trim().Length > 0
                                && !"".Equals(grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim()))
                            {
                                lScriptAdd.Append(" "
                                                    + "DEFAULT"
                                                    + '\''
                                                    + grdTermView.GetRowCellValue(arr[i], "dataDefault").ToString().Trim()
                                                    + '\'');
                            }
                            if (grdTermView.GetRowCellValue(arr[i], "nullable").ToString().Trim() != "Y")
                            {
                                lScriptAdd.Append(" " + "NOT NULL");
                            }
                            lScriptAdd.Append(";"
                                            + "\n");
                        }
                    }
                }
                else
                {

                }
                scriptWriter.WriteLine("*****************************lScriptModify******************************");
                scriptWriter.WriteLine(lScriptModify);
                scriptWriter.WriteLine("*****************************lScriptAdd******************************");
                scriptWriter.WriteLine(lScriptAdd);
                scriptWriter.WriteLine("*****************************lScriptDrop******************************");
                scriptWriter.WriteLine(lScriptDrop);
                scriptWriter.Close();
                System.Diagnostics.Process.Start("Notepad.exe", FilePath);
            }
    }
}
g