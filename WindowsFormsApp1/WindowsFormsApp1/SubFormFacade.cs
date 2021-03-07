using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class SubFormFacade
    {
        public static string GetFileName()
        {
            using(var form = new SaveFileDialog())
            {
                form.Filter = "CSVファイル|.csv";
                form.FileName = "test";

                form.ShowDialog();

                return form.FileName;
            }
        } 

        public static string GetImportTargetFileName()
        {
            using(var form = new OpenFileDialog())
            {
                form.Filter = "CSVファイル|.csv";
                form.FileName = "test";

                form.ShowDialog();

                return form.FileName;
            }
        }
    }
}
