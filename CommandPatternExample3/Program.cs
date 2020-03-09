using System;

namespace CommandPatternExample3
{
    
    public interface ICommand
    {
        void Execute();
    }

    public class OpenCommand : ICommand
    {
        private Document document;

        public OpenCommand(Document doc)
        {
            document = doc;
        }

        public void Execute()
        {
            document.Open();
        }
    }

    class SaveCommand : ICommand
    {
        private Document document;

        public SaveCommand(Document doc)
        {
            document = doc;
        }

        public void Execute()
        {
            document.Save();
        }
    }

    class CloseCommand : ICommand
    {
        private Document document;

        public CloseCommand(Document doc)
        {
            document = doc;
        }

        public void Execute()
        {
            document.Close();
        }
    }

    /// <summary>
    /// Receiver 
    /// </summary>
    public class Document
    {
        public void Open()
        {
            Console.WriteLine("Document Opened");
        }

        public void Save()
        {
            Console.WriteLine("Document Saved");
        }

        public void Close()
        {
            Console.WriteLine("Document Closed");
        }
    }

    /// <summary>
    /// Invoker 
    /// </summary>
    public class MenuOptions
    {
        private ICommand openCommand;
        private ICommand saveCommand;
        private ICommand closeCommand;

        public MenuOptions(ICommand open, ICommand save, ICommand close)
        {
            this.openCommand = open;
            this.saveCommand = save;
            this.closeCommand = close;
        }

        public void clickOpen()
        {
            openCommand.Execute();
        }

        public void clickSave()
        {
            saveCommand.Execute();
        }

        public void clickClose()
        {
            closeCommand.Execute();
        }
    }




    class Program
    {
        static void Main(string[] args)
        {
            //Receiver
            Document document = new Document();

            //Command
            ICommand openCommand = new OpenCommand(document);
            ICommand saveCommand = new SaveCommand(document);
            ICommand closeCommand = new CloseCommand(document);

            // Invoker --> Command objects will be passed to the invoker object
            MenuOptions menu = new MenuOptions(openCommand, saveCommand, closeCommand);

            // Set and Execute command
            menu.clickOpen();
            menu.clickSave();
            menu.clickClose();

            Console.ReadKey();

        }
    }
}
