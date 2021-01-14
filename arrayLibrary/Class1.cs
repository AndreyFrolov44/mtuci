using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace arrayLibrary
{
    public class Class1
    {
        public static void enter_mas(int n, int max, int min, params double[] masPtr)
        {
            Random a = new Random();

            for (int i = 0; i < n; i++)
                masPtr[i] = (double)(a.Next(min, max) % 900) + Math.Round(a.NextDouble(), 2);
        }

        public static void output_mas(DataGridView grid, params double[] aPtz)
        {
            grid.ColumnCount = aPtz.GetLength(0);
            grid.RowCount = 2;

            for (int i = 0; i < aPtz.GetLength(0); i++)
            {
                grid.Rows[0].Cells[i].Value = "[" + i + "]";
                grid.Rows[1].Cells[i].Value = aPtz[i];
            }

            int width = 0;

            for (int s = 0; s < aPtz.GetLength(0); s++)
            {
                width += grid.Columns[s].Width;
            }

            if (width > 900) grid.Width = 900;
            else grid.Width = width;
        }

        public static void set_mas(int n, double[] masPtr, int positionFirst, int positionLast, params double[] rezmasPtr)
        {
            int j = 0;
            for (int i = positionFirst; i <= positionLast; i++)
            {
                rezmasPtr[j] = masPtr[i];
                j++;
            }
        }

        public static void set_count(int n, ref int k, ref double sum, ref int positionFirst, ref int positionLast, params double[] masPtr)
        {
            for (int i = n - 1; i >= 0; i--)
            {
                if (masPtr[i] > 0)
                {
                    positionLast = i;
                    break;
                }
            }

            for (int i = 0; i < n; i++)
            {
                if (masPtr[i] > 0)
                {
                    positionFirst = i;
                    break;
                }
            }

            for (int i = positionFirst; i <= positionLast; i++)
            {
                k ++;
                sum += masPtr[i];
            }
        }

        public static void add()
        {
            var k = new ADOX.Catalog();
            try
            {
                k.Create("provider=Microsoft.Jet.OLEDB.4.0; data source=bd.mdb;");
                MessageBox.Show("БД успешно создана");
            }
            catch(System.Runtime.InteropServices.COMException sit)
            {
                MessageBox.Show(sit.Message);
            }
            finally
            {
                k = null;
            }
        }

        public static void add_structdouble()
        {
            var p = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source=bd.mdb;");
            p.Open();

            var c = new OleDbCommand("CREATE TABLE [Arrays]([Номер элемента] char(100), " + "[Исходный массив] char(20), [Результирующий массив] char(200))", p);
            try
            {
                c.ExecuteNonQuery();
                MessageBox.Show("Структура данных записана");
            }
            catch(Exception situation)
            {
                MessageBox.Show(situation.Message);
            }
            p.Close();
        }

        public static void add_zap_double(double[] mas, double[] rezmas, int len, int j)
        {
            var p = new OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0; data source=bd.mdb;");
            p.Open();

            for(int i = 0; i < len; i++)
            {
                if (i < j)
                {
                    var c = new OleDbCommand("INSERT INTO [Arrays]([Номер элемента],[Исходный массив],[Результирующий массив]) " + "VALUES('" + (i) + "', '" + mas[i] + "', '" + rezmas[i] + "')");
                    c.Connection = p;
                    c.ExecuteNonQuery();

                }
                else
                {
                    var c = new OleDbCommand("INSERT INTO [Arrays]([Номер элемента],[Исходный массив],[Результирующий массив]) " + "VALUES('" + (i) + "', '" + mas[i] + "', '')");
                    c.Connection = p;
                    c.ExecuteNonQuery();
                }
            }

            p.Close();
            MessageBox.Show("В таблицу БД была добавлена запись", "Информация", MessageBoxButtons.OK, MessageBoxIcon.None);

        }

        public static double[] get_mas(DataGridView DGV)
        {
            double[] arr = new double[DGV.ColumnCount];
            for (int i = 0; i < DGV.ColumnCount; i++)
            {
                arr[i] = (double)DGV.Rows[1].Cells[i].Value;
            }
            return arr;
        }

        public static void add_pdf(int lenght, double[] mas, double[] rezMas, int j)
        {
            Document document = new Document();
            var Zap = PdfWriter.GetInstance(document, new System.IO.FileStream("Massivs.pdf", System.IO.FileMode.Create));
            document.Open();
            var Shrift = BaseFont.CreateFont(@"C:\Windows\Fonts\times.ttf", "CP1251", BaseFont.EMBEDDED);

            var ft = new Font(Shrift, 10, Font.NORMAL, BaseColor.BLUE);
            var tabl = new PdfPTable(3);
            var cell = new PdfPCell();
            cell.HorizontalAlignment = 1;

            cell.Colspan = 1;
            cell.Border = 15;
            cell.FixedHeight = 16.0F;

            cell.Phrase = new Phrase("Номер элемента", ft);
            tabl.AddCell(cell);
            cell.Phrase = new Phrase("Входной массив", ft);
            tabl.AddCell(cell);
            cell.Phrase = new Phrase("Результирующий массив", ft);
            tabl.AddCell(cell);

            cell.BackgroundColor = BaseColor.LIGHT_GRAY;
            cell.Colspan = 1;
            cell.Border = 15;
            

            for(int i = 0; i < lenght; i++)
            {
                if(i < j)
                {
                    cell.Phrase = new Phrase(i.ToString(), ft);
                    tabl.AddCell(cell);

                    cell.Phrase = new Phrase(mas[i].ToString(), ft);
                    tabl.AddCell(cell);

                    cell.Phrase = new Phrase(rezMas[i].ToString(), ft);
                    tabl.AddCell(cell);
                }

                else
                {
                    cell.Phrase = new Phrase(i.ToString(), ft);
                    tabl.AddCell(cell);

                    cell.Phrase = new Phrase(mas[i].ToString(), ft);
                    tabl.AddCell(cell);

                    cell.Phrase = new Phrase("", ft);
                    tabl.AddCell(cell);
                }
            }

            tabl.TotalWidth = document.PageSize.Width - 200;
            tabl.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 30, Zap.DirectContent);

            document.Close();
            Zap.Close();
            System.Diagnostics.Process.Start("IExplore.exe", System.IO.Directory.GetCurrentDirectory() + @"\Massivs.pdf");
        }

        public static void ZapisBloknot(int k, int j, double[] mas, double[] rezMas)
        {
            StreamWriter file = File.CreateText("Массивы.txt");

            file.WriteLine("Исходный массив");

            for(int i = 0; i < k; i++)
            {
                file.WriteLine(mas[i]);
            }

            file.WriteLine("\nРезультирующий массив");

            for(int i = 0; i < j; i++)
            {
                file.WriteLine(rezMas[i]);
            }

            file.Close();

            System.Diagnostics.Process.Start("Массивы.txt");
        }

        public static void ZapisWordIsx(int length, int res_length, double[] mas, double[] rezMas) 
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            var Wrd = new Microsoft.Office.Interop.Word.Application();
            Wrd.Visible = true;
            var inf = Type.Missing;
            string str;
            var Doc = Wrd.Documents.Add(inf, inf, inf, inf);

            Object t1 = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object t2 = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;

            Microsoft.Office.Interop.Word.Table tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, length, 3, t1, t2);

            tbl.Cell(1, 1).Range.InsertAfter("Номер элемента");
            tbl.Cell(1, 2).Range.InsertAfter("Исходный массив");
            tbl.Cell(1, 3).Range.InsertAfter("Результирующий массив");

            for (int i = 1; i < length; i++)
            {
                tbl.Cell(i + 1, 1).Range.InsertAfter(Convert.ToString(i));
                tbl.Cell(i + 1, 2).Range.InsertAfter(Convert.ToString(mas[i]));
                if(i < res_length)
                    tbl.Cell(i + 1, 3).Range.InsertAfter(Convert.ToString(rezMas[i]));
            }
        }

        public static void ZapisExcel(int length, int res_length, double[] mas, double[] rezMas)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.Add();
            workSheet.Name = "Массивы";
            workSheet.Cells[1, 1] = "Номер элемента";
            workSheet.Cells[1, 2] = "Исходный масиив";
            workSheet.Cells[1, 3] = "Результирующий массив";
            for (int i = 0; i < length; i++)
            {
                workSheet.Cells[i + 2, 1] = i;
                workSheet.Cells[i + 2, 2] = mas[i];
                if (i < res_length)
                    workSheet.Cells[i + 2, 3] = rezMas[i];
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;

            Microsoft.Office.Interop.Excel.Range range1 = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[length + 1, 3]];

            range1.Cells.Font.Name = "Times New Roman";
            range1.Cells.Font.Size = 14;
            range1.Cells.Columns.AutoFit();

            range1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;

        }

        public static void Excel(int length, int res_length, int[] mas, int[] rezMas)
        {
            Microsoft.Office.Interop.Excel.Application excelApp = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook workBook;
            Microsoft.Office.Interop.Excel.Worksheet workSheet;
            workBook = excelApp.Workbooks.Add();
            workSheet = (Microsoft.Office.Interop.Excel.Worksheet)workBook.Worksheets.Add();
            workSheet.Name = "Массивы";
            workSheet.Cells[1, 1] = "Номер вопроса";
            workSheet.Cells[1, 2] = "Не решено";
            workSheet.Cells[1, 3] = "Решено верно";
            for (int i = 0; i < length; i++)
            {
                workSheet.Cells[i + 2, 1] = i;
                if (mas[i] == 0) workSheet.Cells[i + 2, 3] = "";
                else workSheet.Cells[i + 2, 3] = mas[i];
                try
                {
                    
                    workSheet.Cells[i + 2, 2] = rezMas[i];
                }
                catch
                {
                    workSheet.Cells[i + 2, 2] = "";
                }
            }
            excelApp.Visible = true;
            excelApp.UserControl = true;

            Microsoft.Office.Interop.Excel.Range range1 = workSheet.Range[workSheet.Cells[1, 1], workSheet.Cells[length + 1, 3]];

            range1.Cells.Font.Name = "Times New Roman";
            range1.Cells.Font.Size = 14;
            range1.Cells.Columns.AutoFit();

            range1.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
        }

        public static void WordIsx(int length, int res_length, int[] mas, int[] rezMas)
        {
            Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();

            var Wrd = new Microsoft.Office.Interop.Word.Application();
            Wrd.Visible = true;
            var inf = Type.Missing;
            string str;
            var Doc = Wrd.Documents.Add(inf, inf, inf, inf);

            Object t1 = Microsoft.Office.Interop.Word.WdDefaultTableBehavior.wdWord9TableBehavior;
            Object t2 = Microsoft.Office.Interop.Word.WdAutoFitBehavior.wdAutoFitContent;

            Microsoft.Office.Interop.Word.Table tbl = Wrd.ActiveDocument.Tables.Add(Wrd.Selection.Range, 17, 3, t1, t2);

            tbl.Cell(1, 1).Range.InsertAfter("Номер элемента");
            tbl.Cell(1, 2).Range.InsertAfter("Не решено");
            tbl.Cell(1, 3).Range.InsertAfter("Решено верно");

            for (int i = 0; i < length; i++)
            {
                tbl.Cell(i + 2, 1).Range.InsertAfter(Convert.ToString(i));
                if (mas[i] == 0) tbl.Cell(i + 2, 3).Range.InsertAfter("");
                else tbl.Cell(i + 2, 3).Range.InsertAfter(Convert.ToString(mas[i]));

                try
                {
                    tbl.Cell(i + 2, 2).Range.InsertAfter(Convert.ToString(rezMas[i]));
                }
                catch
                {
                    tbl.Cell(i + 2, 2).Range.InsertAfter("");
                }
            }
        }
    }
}
