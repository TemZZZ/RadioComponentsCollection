using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    internal class MainViewModel : ViewModelBase
    {
        private readonly PresentationRootRegistry _presentationRootRegistry;
        public MainViewModel(
            PresentationRootRegistry presentationRootRegistry)
        {
            _presentationRootRegistry = presentationRootRegistry;
        }
    }
}
