using CoxAuto.Loader.Model;
using CoxAuto.Loader.Service;
using System.Collections.Generic;


namespace CoxAuto.Service.Service
{

    public interface IFileLoadManager
    {
        IEnumerable<SalesDataModel> GetData(string path);
    }


    public interface IXmlLoader : IFileLoadManager { };

    public interface ICsvLoader : IFileLoadManager { };

}
