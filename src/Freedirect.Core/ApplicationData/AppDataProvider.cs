using System;
using System.IO;
using Freedirect.Core.Utilities;

namespace Freedirect.Core.ApplicationData
{
    public class AppDataProvider
    {
        private readonly string _path;
        private AppDataEntity _appDataEntity;

        public AppDataProvider()
        {
            _path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);

            _path = Path.Combine(_path, "Freedirect");
            Directory.CreateDirectory(_path);

            _path = Path.Combine(_path, "Settings.xml");

            _appDataEntity = File.Exists(_path) ? XmlUtilities.DeSerializeObject<AppDataEntity>(_path) : new AppDataEntity();
        }

        public AppDataEntity GetAppData()
        {
            return _appDataEntity;
        }

        public void UpdateAppData(AppDataEntity entity)
        {
            XmlUtilities.SerializeObject(entity, _path);
            _appDataEntity = entity;
        }  
    }
}