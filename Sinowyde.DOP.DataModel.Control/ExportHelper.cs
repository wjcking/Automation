using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sinowyde.DOP.DataModel;
using System.Reflection;
using NPOI.HSSF.UserModel;
using NPOI.HPSF;
using NPOI.POIFS.FileSystem;
using NPOI.SS.UserModel;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using NPOI.SS.Util;
using System.Threading;
using System.Data;

namespace Sinowyde.DOP.DataModel.Control
{
    public class ExportHelper
    {
        private static List<Object> listType = new List<object>();
        private static bool IsExitType(Type type)
        {
            if (listType.Find(o => o.GetType() == type) == null)
            {
                return false;
            }
            return true;
        }

        public static void Import(string filePath,Action<string,bool> notice) 
        {
            new Thread(new ThreadStart(delegate()
            {
                #region 缓存列表
                List<Variable> variable = DOP.DataLogic.DOPDataLogic.Instance().GetAllBy<Variable>();
                #endregion 

                HSSFWorkbook hssfworkbook;
                using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
                ISheet sheet = hssfworkbook.GetSheetAt(0);
                
                DataTable dt = new DataTable();

                IRow row = sheet.GetRow(1);
                for (int j = 0; j < row.LastCellNum; j++)
                {

                    dt.Columns.Add(row.GetCell(j).StringCellValue);
                }
                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                rows.MoveNext();
                rows.MoveNext();
                rows.MoveNext();

                while (rows.MoveNext())
                {
                    IRow currentRow = (IRow)rows.Current;
                    DataRow dr = dt.NewRow();  
                    for (int j = 0; j < row.LastCellNum; j++)
                    {
                        dr[j] = currentRow.Cells[j].StringCellValue.Trim();
                    }
                    dt.Rows.Add(dr);
                }

                var a = 1;
                //先从数据库中取出所有的点
            })).Start();
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="list"></param>
        public static void Export(string filePath, List<Variable> list, Action<string,bool> dataLoading)
        {
            new Thread(new ThreadStart(delegate()
            {
                using (FileStream fs = File.Open(filePath, FileMode.Create))
                {
                    HSSFWorkbook workbook = new HSSFWorkbook();

                    //创建工作薄
                    HSSFSheet sheet = (HSSFSheet)workbook.CreateSheet("变量");

                    string fieldsPath = Application.StartupPath + "\\Fields.xml";
                    XElement fieldsXml = XElement.Load(fieldsPath);

                    IEnumerable<XElement> fieldNodes = from node in fieldsXml.Elements("Field")
                                                       select node;

                    #region 第一行 大标题 第二行 英文列 第三行 中文列
                    IRow rowTitle = sheet.CreateRow(0);
                    IRow rowDBColumn = sheet.CreateRow(1);
                    rowDBColumn.ZeroHeight = true; //隐藏DB列
                    IRow rowColumnName = sheet.CreateRow(2);

                    #region 单元格样式
                    ICellStyle style = workbook.CreateCellStyle();
                    style.Alignment = NPOI.SS.UserModel.HorizontalAlignment.Center;
                    IFont font = workbook.CreateFont();
                    font.FontHeight = 20 * 20;
                    style.SetFont(font);
                    #endregion

                    List<string> keys = new List<string>();
                    int indexTitle = 0;
                    int beginCol = 0;
                    int endCol = 0;
                    int colIndex = 0;
                    foreach (XElement item in fieldNodes)
                    {
                        ICell cell = rowTitle.CreateCell(beginCol, CellType.String);
                        cell.CellStyle = style;
                        cell.SetCellValue(item.Attribute("text").Value.Trim());
                        IEnumerable<XElement> childs = from child in item.Elements("Column") select child;
                        endCol = beginCol + childs.Count() - 1;// 0,12 -> 13,15 -> 16,25
                        sheet.AddMergedRegion(new NPOI.SS.Util.CellRangeAddress(0, 0, beginCol, endCol));

                        #region 第二行 英文列 第三行 中文列
                        foreach (XElement child in childs)
                        {
                            ICell childDbCell = rowDBColumn.CreateCell(colIndex, CellType.String);
                            string dbColumn = string.Format("{0}.{1}", child.Parent.Attribute("name").Value.Trim(), child.Attribute("name").Value.Trim());
                            childDbCell.SetCellValue(dbColumn);
                            ICell childShowCell = rowColumnName.CreateCell(colIndex, CellType.String);
                            childShowCell.SetCellValue(child.Attribute("text").Value.Trim());
                            keys.Add(child.Attribute("name").Value.Trim());
                            colIndex++;
                        }
                        #endregion
                        beginCol = endCol + 1;
                        indexTitle++;

                    }
                    #endregion

                    sheet.CreateFreezePane(sheet.GetRow(2).Cells.Count, 3);
                    int dataRowIndex = 3;

                    foreach (Variable item in list)
                    {
                        IRow dataRow = sheet.CreateRow(dataRowIndex);
                        foreach (ICell cell in rowDBColumn)
                        {
                            Type fieldType = null;
                            object res = GetValue(item, cell.StringCellValue, out fieldType);
                            AddCellValue(dataRow, cell.ColumnIndex, res);
                            AddDataEffective(sheet, fieldType, cell.ColumnIndex);
                        }
                        dataRowIndex++;
                        if (dataLoading != null) { dataLoading(string.Format("{0}（{1}/{2}）", "正在导出,请稍后", dataRowIndex - 3, list.Count), false); }
                        Thread.Sleep(100);
                    }

                    workbook.Write(fs);
                    workbook = null;
                    if (dataLoading != null) { dataLoading("完成导出", true); }
                }
            })).Start();

        }

        private static void AddCellValue(IRow row, int cellIndex, object value)
        {
            Type t = value.GetType();
            if (typeof(Boolean) == t)
            {
                row.CreateCell(cellIndex, CellType.String).SetCellValue((bool)value ? "是" : "否");
            }
            else if (typeof(float) == t)
            {
                row.CreateCell(cellIndex, CellType.Numeric).SetCellValue(((float)value).ToString("#0.00"));
            }
            else
            {
                row.CreateCell(cellIndex, CellType.String).SetCellValue(value.ToString());
            }

        }

        /// <summary>
        /// 添加数据有效性
        /// </summary>
        private static void AddDataEffective(HSSFSheet sheet, Type type, int index)
        {
            if (type != null && !IsExitType(type))
            {
                listType.Add(type);
                if (type.BaseType == typeof(Enum))
                {
                    CellRangeAddressList regions = new CellRangeAddressList(3, 65535, index, index);
                    DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(Enum.GetNames(type));
                    HSSFDataValidation dataValidate = new HSSFDataValidation(regions, constraint);
                    sheet.AddValidationData(dataValidate);
                }
                else if (type == typeof(Boolean))
                {
                    CellRangeAddressList regions = new CellRangeAddressList(3, 65535, index, index);
                    DVConstraint constraint = DVConstraint.CreateExplicitListConstraint(new string[] { "是", "否" });
                    HSSFDataValidation dataValidate = new HSSFDataValidation(regions, constraint);
                    sheet.AddValidationData(dataValidate);
                }
            }
        }

        private static object GetValue(Object obj, string key, out Type type)
        {
            object result = string.Empty;
            type = null;
            string[] columns = key.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
            System.Reflection.PropertyInfo propertyInfo = obj.GetType().GetProperty(columns[1]);
            if (propertyInfo != null)
            {
                object newItem = propertyInfo.GetValue(obj, null);
                if (newItem == null)
                {
                    return string.Empty;
                }
                if (columns.Length == 2)
                {
                    type = newItem.GetType();
                    return newItem;
                }
                else
                {
                    result = GetValue(newItem, String.Join(".", columns.Skip(1)), out type);
                }
            }
            return result;
        }

        private static object SetValue()
        {
            return new object();
        }
    }

}
