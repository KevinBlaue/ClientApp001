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
            InitMessengerWithParameter();
        }

        private void InitMessengerWithParameter()
        {
            /*Messenger.Instance.Register<OpenEditBookWindowMessage>(this, delegate(OpenEditBookWindowMessage message)
            {
                EditBookWindow myWindow = new EditBookWindow();
                myWindow.DataContext = message.Book;
                myWindow.ShowDialog();
            });*/
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