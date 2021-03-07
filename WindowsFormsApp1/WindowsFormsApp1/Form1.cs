using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly CsvImportExport _csvImportExport;

        private IEnumerable<string> Headers => new List<string> {"基本" + Environment.NewLine + "人1,人2,人3,人14", "応用" };

        private IEnumerable<string> BasicSettings => new List<string>
        {
            "田中,佐藤,伊能,井上"
        };

        private IEnumerable<string> AppSetting => new List<string>
        {
            "aaa,bbb", 
            "ccc,ddd"
        };

        public Form1()
        {
            _csvImportExport = new CsvImportExport(Headers);
            InitializeComponent();
        }

        public void Export()
        {
            _csvImportExport.SetCsvSettings(Headers.ToList()[0], BasicSettings);
            _csvImportExport.SetCsvSettings(Headers.ToList()[1], AppSetting);
            _csvImportExport.Export();
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            Export();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _csvImportExport.Import();
        }
    }
}
