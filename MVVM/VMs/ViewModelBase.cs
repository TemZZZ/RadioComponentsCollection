using System.ComponentModel;
using System.Runtime.CompilerServices;
using MVVM.Annotations;

namespace MVVM.VMs
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged(
            [CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(
                propertyName));
        }
    }
}
