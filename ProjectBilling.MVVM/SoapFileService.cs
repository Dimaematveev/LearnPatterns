using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Soap;

namespace MVVM
{
    public class SoapFileService : IFileService
    {
        public List<PhoneViewModel> Open(string filename)
        {
            Phone[] phones;
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.OpenOrCreate))
            {
                phones = (soapFormatter.Deserialize(fs) as Phone[]);
            }
            List<PhoneViewModel> phoneViewModels = phones.Select(x => new PhoneViewModel(x)).ToList();
            return phoneViewModels;
        }

        public void Save(string filename, List<PhoneViewModel> phonesList)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            using (FileStream fs = new FileStream(filename, FileMode.Create))
            {
                soapFormatter.Serialize(fs, phonesList.Select(x=>x.Phone).ToArray());
            }
        }
    }
}