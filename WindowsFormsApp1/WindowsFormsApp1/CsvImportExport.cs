using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class CsvImportExport
    {
        private readonly Dictionary<string, List<string>> _settings = new Dictionary<string, List<string>>();

        internal CsvImportExport(IEnumerable<string> headers)
        {
            foreach (var header in headers)
            {
                _settings.Add(header, new List<string>());
            }
        }

        public void Export()
        {
            var fileName = SubFormFacade.GetFileName();
            using (var sw = new StreamWriter(fileName, false, Encoding.UTF8))
            {
                foreach (var setting in _settings)
                {
                    sw.WriteLine(setting.Key);
                    setting.Value.ForEach(s =>
                    {
                        sw.WriteLine(s);
                    });
                    sw.WriteLine(string.Empty);
                }
            }
        }

        public IDictionary<string, List<string>> Import()
        {
            var fileName = SubFormFacade.GetImportTargetFileName();

            using (var sr = new StreamReader(fileName))
            {
                var fileContent = new List<string>();
                string line;

                string text = string.Empty;

                var file = sr.ReadToEnd();

                foreach (var header in _settings.Keys.ToList())
                {
                    file = file.Replace(header + Environment.NewLine, string.Empty);
                }

                string[] del = { Environment.NewLine + Environment.NewLine };
                var dataList = file.Split(del, StringSplitOptions.None).ToList();

                string[] spliter = { Environment.NewLine };

                var temp = dataList.Select(data => data.Split(spliter, StringSplitOptions.RemoveEmptyEntries)).ToList();


                var dataDic = new Dictionary<string, List<string>>();
                var index = 0;
                foreach (var header in _settings.Keys.ToList())
                {
                    dataDic.Add(header, temp[index].ToList());
                }
            }

            return new Dictionary<string, List<string>>();

        }

        public void SetCsvSettings(string header, IEnumerable<string> settings)
        {
            if(!IsSupportedHeader(header)) return;
            _settings[header] = settings.ToList();
        }

        private bool IsSupportedHeader(string header)
        {
            return _settings.Keys.Contains((header));
        }
    }
}
