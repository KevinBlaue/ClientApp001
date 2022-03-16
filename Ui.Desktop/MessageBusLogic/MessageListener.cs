using De.HsFlensburg.ClientApp001.Service.MessageBusWithParameter;
using De.HsFlensburg.ClientApp001.Service.MessageBusWithParameter.MessageBusMessages;
using De.HsFlensburg.ClientApp001.Service.MessageBusWithParameter.MessageBusWithParameterMessages;

namespace De.HsFlensburg.ClientApp001.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessengerWithParameter();
        }

        private void InitMessengerWithParameter()
        {
            Messenger.Instance.Register<OpenNewBookWindowMessage>(this, delegate (OpenNewBookWindowMessage message)
            {
                NewBookWindow myWindow = new NewBookWindow();
                myWindow.ShowDialog();
            });

            Messenger.Instance.Register<OpenStatistikWindowMessage>(this, delegate (OpenStatistikWindowMessage message)
            {
                StatistikWindow myWindow = new StatistikWindow();
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenEditBookWindowMessage>(this, delegate(OpenEditBookWindowMessage message)

            {
                EditBookWindow myWindow = new EditBookWindow();
                myWindow.ShowDialog();
            });
            Messenger.Instance.Register<OpenImportExportWindowMessage>(this, delegate (OpenImportExportWindowMessage message)
            {
                ImportExportWindow myWindow = new ImportExportWindow();
                myWindow.ShowDialog();
            });
        }
    }
}