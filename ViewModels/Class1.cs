using System.Threading;
using System.Windows;
using System.Windows.Input;
using TFlex.DOCs.Model;
using TFlex.DOCs.Model.References;
using TFlex.DOCs.UI.Client.Common.ViewModels.Base;
using TFlex.DOCs.UI.Client.Common.ViewModels.Layout.Common;
using TFlex.DOCs.UI.Client.Common.ViewModels.References;
using TFlex.DOCs.UI.Utils.Helpers;

namespace mybutton.ViewModels
{
    class Class1 : ViewModel, IUserControlViewModel
    {
        public ICommand ButtonCommand { get; }
        private ReferenceObject _referenceObject;


        //Конструкторы
        public Class1() : base(null)
        {
            ButtonCommand = new RelayCommand(ExecuteButtonCommand);
        }

        public Class1(LayoutViewModel owner) : base(owner)
        { }

        public Class1(ViewModel owner, ServerConnection connection = null) : base(owner, connection)
        { }


        private void ExecuteButtonCommand(object parameter)
        {
            MessageBox.Show($"Кнопка нажата!\n {_referenceObject.ToString()}");
        }

        public object LoadData(DataObjectViewModel viewModel, CancellationToken cancellationToken)
        {
            ReferenceObject referenceObject = GetReferenceObject(viewModel);

            if (referenceObject is not null)
            {
                Connection = referenceObject.Reference.Connection;
                DispatcherHelper.CheckBeginInvokeOnUI(() =>
                {
                    _referenceObject = referenceObject;
                });
            }

            return viewModel;

        }

        public void ReadDataToObject(DataObjectViewModel viewModel)
        {
            MessageBox.Show("call ReadDataToObject");
        }

        public void RefreshUI(object loadedData, CancellationToken cancellationToken)
        {

        }
        private ReferenceObject GetReferenceObject(DataObjectViewModel viewModel)
        {
            if (viewModel is not ReferenceObjectViewModel rvm)
                return null;

            return rvm.ReferenceObject;
        }
    }
}
