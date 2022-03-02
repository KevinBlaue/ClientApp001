using De.HsFlensburg.ClientApp001.Logic.Ui.ViewModels;
using De.HsFlensburg.ClientApp001.Service.MessageBus;
using De.HsFlensburg.ClientApp001.Service.MessageBus.MessageBusMessages;

namespace De.HsFlensburg.ClientApp001.Ui.Desktop.MessageBusLogic
{
    public class MessageListener
    {
        public bool BindableProperty => true;
        public MessageListener()
        {
            InitMessenger();
        }

        private void InitMessenger()
        {
            ServiceBus.Instance.Register<OpenNewBookWindowMessage>(this, OpenNewBookWindow);
        }

        private void OpenNewBookWindow()
        {
            NewBookWindow myWindow = new NewBookWindow();
            myWindow.ShowDialog();
        }
    }
}