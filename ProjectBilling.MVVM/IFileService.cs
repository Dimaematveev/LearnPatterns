using System.Collections.Generic;

namespace MVVM
{
    public interface IFileService
    {
        List<PhoneViewModel> Open(string filename);
        void Save(string filename, List<PhoneViewModel> phonesList);
    }
}