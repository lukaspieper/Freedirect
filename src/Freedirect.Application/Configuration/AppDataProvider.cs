using System;
using System.IO;
using Freedirect.Core.ApplicationData;

namespace Freedirect.Application.Configuration
{
    public class AppDataProvider
    {
        private readonly string _path;
        private AppData _appData;

        public AppDataProvider()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            _path = Path.Combine(_path, "Freedirect");
            Directory.CreateDirectory(_path);

            _path = Path.Combine(_path, "Settings.xml");

            _appData = File.Exists(_path) ? XmlUtilities.DeSerializeObject<AppData>(_path) : new AppData();
        }

        public AppData GetAppData()
        {
            return _appData;
        }

        public void UpdateAppData(AppData entity)
        {
            XmlUtilities.SerializeObject(entity, _path);
            _appData = entity;
        }  
    }
}