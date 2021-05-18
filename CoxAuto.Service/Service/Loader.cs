using CoxAuto.Loader.Model;
using CoxAuto.Service;
using CoxAuto.Service.Exceptions;
using CoxAuto.Service.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;



namespace CoxAuto.Loader.Service
{

    public class csvFileLoader : ICsvLoader
    {
        public IEnumerable<SalesDataModel> GetData(string path)
        {
            return Parse(LoadFile(path));
        }



        private IEnumerable<string> LoadFile(string path)
        {
            string[] inStream;
            try
            {
                inStream = File
                .ReadAllLinesAsync(path, System.Text.Encoding.UTF7)
                .GetAwaiter()
                .GetResult()
                .ToArray();
            }
            catch (Exception ex)
            {
                throw new CoxAutoException(Resource._load_error, ex);
            }

            return inStream;
        }

        private IEnumerable<SalesDataModel> Parse(IEnumerable<string> inStream)
        {
            var modelList = new List<SalesDataModel>();
            var regex = new Regex("((?<=\")[^\"]*(?=\"(,|$)+)|(?<=,|^)[^,\"]*(?=,|$))");

            try
            {
                foreach (string line in inStream.Skip<string>(1))
                {
                    var str = regex
                        .Matches(line)
                        .Cast<Match>()
                        .Select(m => m.Value)
                        .ToArray();

                    modelList.Add(new SalesDataModel(str));
                }
            }
            catch (Exception ex)
            {
                throw new CoxAutoException(Resource._parse_error, ex);
            }

            return modelList;
        }
    }
    public class xmlFileLoader : IXmlLoader
    {


        public IEnumerable<SalesDataModel> GetData(string path)
        {
            return new List<SalesDataModel> { };
        }

    }
    public class FileLoadManager: IFileLoadManager
    {

        private ICsvLoader _csvldr { get; }
        private IXmlLoader _xmlldr { get; }

        public FileLoadManager(ICsvLoader csvldr, IXmlLoader xmlldr)
        {
            _csvldr = csvldr;
            _xmlldr = xmlldr;
        }


        public IEnumerable<SalesDataModel> GetData(string path)

        {
            return true ?
                _csvldr.GetData(path) :
                _xmlldr.GetData(path);

        }
    }
}