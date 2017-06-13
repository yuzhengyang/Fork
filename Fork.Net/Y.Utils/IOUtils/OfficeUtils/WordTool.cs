////############################################################
////      https://github.com/yuzhengyang
////      author:yuzhengyang
////############################################################
//using Microsoft.Office.Interop.Word;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Y.Utils.IOUtils.OfficeUtils
//{
//    public class WordTool
//    {
//        private _Application wordApp = null;
//        private _Document wordDoc = null;
//        public _Application Application
//        {
//            get
//            {
//                return wordApp;
//            }
//            set
//            {
//                wordApp = value;
//            }
//        }
//        public _Document Document
//        {
//            get
//            {
//                return wordDoc;
//            }
//            set
//            {
//                wordDoc = value;
//            }
//        }

//        //通过模板创建新文档
//        public void CreateNewDocument(string filePath)
//        {
//            killWinWordProcess();
//            wordApp = new Application();
//            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
//            wordApp.Visible = false;
//            object missing = System.Reflection.Missing.Value;
//            object templateName = filePath;
//            wordDoc = wordApp.Documents.Open(ref templateName, ref missing,
//            ref missing, ref missing, ref missing, ref missing, ref missing,
//            ref missing, ref missing, ref missing, ref missing, ref missing,
//            ref missing, ref missing, ref missing, ref missing);
//        }

//        //保存新文件
//        public void SaveDocument(string filePath)
//        {
//            object fileName = filePath;
//            object format = WdSaveFormat.wdFormatDocument;//保存格式
//            object miss = System.Reflection.Missing.Value;
//            wordDoc.SaveAs(ref fileName, ref format, ref miss,
//            ref miss, ref miss, ref miss, ref miss,
//            ref miss, ref miss, ref miss, ref miss,
//            ref miss, ref miss, ref miss, ref miss,
//            ref miss);
//            //关闭wordDoc，wordApp对象
//            object SaveChanges = WdSaveOptions.wdSaveChanges;
//            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
//            object RouteDocument = false;
//            wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
//            wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
//        }

//        //在书签处插入值
//        public bool InsertValue(string bookmark, string value)
//        {
//            object bkObj = bookmark;
//            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
//            {
//                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
//                wordApp.Selection.TypeText(value);
//                return true;
//            }
//            return false;
//        }

//        //插入表格,bookmark书签
//        public Table InsertTable(string bookmark, int rows, int columns, float width)
//        {
//            object miss = System.Reflection.Missing.Value;
//            object oStart = bookmark;
//            Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//表格插入位置
//            Table newTable = wordDoc.Tables.Add(range, rows, columns, ref miss, ref miss);
//            //设置表的格式
//            newTable.Borders.Enable = 1; //允许有边框，默认没有边框(为0时报错，1为实线边框，2、3为虚线边框，以后的数字没试过)
//            newTable.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth050pt;//边框宽度
//            if (width != 0)
//            {
//                newTable.PreferredWidth = width;//表格宽度
//            }
//            newTable.AllowPageBreaks = false;
//            return newTable;
//        }

//        //合并单元格 表名,开始行号,开始列号,结束行号,结束列号
//        public void MergeCell(Microsoft.Office.Interop.Word.Table table, int row1, int column1, int row2, int column2)
//        {
//            table.Cell(row1, column1).Merge(table.Cell(row2, column2));
//        }

//        //设置表格内容对齐方式Align水平方向，Vertical垂直方向(左对齐，居中对齐，右对齐分别对应Align和Vertical的值为-1,0,1)
//        public void SetParagraph_Table(Microsoft.Office.Interop.Word.Table table, int Align, int Vertical)
//        {
//            switch (Align)
//            {
//                case -1:
//                    table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft; break;//左对齐
//                    case0: table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter; break;//水平居中
//                    case1: table.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight; break;//右对齐
//            }
//            switch (Vertical)
//            {
//                case -1:
//                    table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalTop; break;//顶端对齐
//                    case0: table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; break;//垂直居中
//                    case1: table.Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom; break;//底端对齐
//            }
//        }

//        //设置表格字体
//        public void SetFont_Table(Microsoft.Office.Interop.Word.Table table, string fontName, double size)
//        {
//            if (size != 0)
//            {
//                table.Range.Font.Size = Convert.ToSingle(size);
//            }
//            if (fontName != "")
//            {
//                table.Range.Font.Name = fontName;
//            }
//        }

//        //是否使用边框,n表格的序号,use是或否
//        public void UseBorder(int n, bool use)
//        {
//            if (use)
//            {
//                wordDoc.Content.Tables[n].Borders.Enable = 1; //允许有边框，默认没有边框(为0时无边框，1为实线边框，2、3为虚线边框，以后的数字没试过)
//            }
//            else
//            {
//                wordDoc.Content.Tables[n].Borders.Enable = 2; //允许有边框，默认没有边框(为0时无边框，1为实线边框，2、3为虚线边框，以后的数字没试过)
//            }
//        }
//        //设置表格边框
//        public void UseBorder(int n, int type)
//        {
//            wordDoc.Content.Tables[n].Borders.Enable = type; //允许有边框，默认没有边框(为0时无边框，1为实线边框，2、3为虚线边框，以后的数字没试过)
//        }

//        //给表格插入一行,n表格的序号从1开始记
//        public void AddRow(int n)
//        {
//            object miss = System.Reflection.Missing.Value;
//            wordDoc.Content.Tables[n].Rows.Add(ref miss);
//        }

//        //给表格添加一行
//        public void AddRow(Microsoft.Office.Interop.Word.Table table)
//        {
//            object miss = System.Reflection.Missing.Value;
//            table.Rows.Add(ref miss);
//        }

//        //给表格插入rows行,n为表格的序号
//        public void AddRow(int n, int rows)
//        {
//            object miss = System.Reflection.Missing.Value;
//            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
//            for (int i = 0; i < rows; i++)
//            {
//                table.Rows.Add(ref miss);
//            }
//        }

//        //给表格中单元格插入元素，table所在表格，row行号，column列号，value插入的元素
//        public void InsertCell(Microsoft.Office.Interop.Word.Table table, int row, int column, string value)
//        {
//            table.Cell(row, column).Range.Text = value;
//        }

//        //给表格中单元格插入元素，n表格的序号从1开始记，row行号，column列号，value插入的元素
//        public void InsertCell(int n, int row, int column, string value)
//        {
//            wordDoc.Content.Tables[n].Cell(row, column).Range.Text = value;
//        }

//        //给表格插入一行数据，n为表格的序号，row行号，columns列数，values插入的值
//        public void InsertCell(int n, int row, int columns, string[] values)
//        {
//            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
//            for (int i = 0; i < columns; i++)
//            {
//                table.Cell(row, i + 1).Range.Text = values[i];
//            }
//        }

//        //插入图片
//        public void InsertPicture(string bookmark, string picturePath, float width, float hight)
//        {
//            object miss = System.Reflection.Missing.Value;
//            object oStart = bookmark;
//            Object linkToFile = false; //图片是否为外部链接
//            Object saveWithDocument = true; //图片是否随文档一起保存
//            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//图片插入位置
//            wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocument, ref range);
//            wordDoc.Application.ActiveDocument.InlineShapes[1].Width = width; //设置图片宽度
//            wordDoc.Application.ActiveDocument.InlineShapes[1].Height = hight; //设置图片高度
//        }

//        //在表格中插入图片-Y
//        public void InsertCell(Microsoft.Office.Interop.Word.Table table, int row, int column, string picturePath, float width, float hight, int idx)
//        {
//            Object linkToFile = false; //图片是否为外部链接
//            Object saveWithDocument = true; //图片是否随文档一起保存
//            object range = table.Cell(row, column).Range;//图片插入位置
//            wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocument, ref range);
//            wordDoc.Application.ActiveDocument.InlineShapes[idx].Width = width; //设置图片宽度
//            wordDoc.Application.ActiveDocument.InlineShapes[idx].Height = hight; //设置图片高度
//        }

//        //插入一段文字,text为文字内容
//        public void InsertText(string bookmark, string text)
//        {
//            object oStart = bookmark;
//            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;
//            Paragraph wp = wordDoc.Content.Paragraphs.Add(ref range);
//            wp.Format.SpaceBefore = 6;
//            wp.Range.Text = text;
//            wp.Format.SpaceAfter = 24;
//            wp.Range.InsertParagraphAfter();
//            wordDoc.Paragraphs.Last.Range.Text = "\n";
//        }

//        //杀掉winword.exe进程
//        public void killWinWordProcess()
//        {
//            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
//            foreach (System.Diagnostics.Process process in processes)
//            {
//                bool b = process.MainWindowTitle == "";
//                if (process.MainWindowTitle == "")
//                {
//                    process.Kill();
//                }
//            }
//        }
//    }
//}
