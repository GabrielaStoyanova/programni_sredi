using Microsoft.Extensions.Logging;
using Welcome.Model;
using Welcome.View;
using Welcome.ViewModel;
using WelcomeExtended.Loggers;
using WelcomeExtended.Others;


namespace WelcomeExtended
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("WelcomeExtended");
            //to start this project => right-click on the project and choose
            // "Set as Startup Project" and then the selected project will be
            // highlighted with bold white color

            //FIRST TASK
            // Example usage of HashLogger
            HashLogger logger = new HashLogger("Example 1");
            logger.Log(LogLevel.Information, new EventId(1), "Logging information", null, (state, ex) => state.ToString());
            logger.Log(LogLevel.Error, new EventId(2), "Logging error", null, (state, ex) => state.ToString());

            // Get recorded messages
            string[] recordedMessages = logger.GetRecordedMessages();
            foreach (string message in recordedMessages)
            {
                Console.WriteLine(message);
            }

            //SECOND TASK
            HashLogger logger1 = new HashLogger("Example 2");
            logger1.Log(LogLevel.Warning, new EventId(1), "Logging Warning", null, (state, ex) => state.ToString());
            logger1.Log(LogLevel.Error, new EventId(2), "Logging error", null, (state, ex) => state.ToString());

            // Print event for eventId 1
            string eventMessage = logger1.PrintEvent(1);
            Console.WriteLine(eventMessage);

            // Print event for eventId 2
            eventMessage = logger1.PrintEvent(2);
            Console.WriteLine(eventMessage);

            HashLogger logger2 = new HashLogger("Example");
            logger2.Log(LogLevel.Critical, new EventId(1), "Logging critical", null, (state, ex) => state.ToString());
            logger2.Log(LogLevel.Error, new EventId(2), "Logging error", null, (state, ex) => state.ToString());

            // Delete event for eventId 1
            bool deleted = logger2.DeleteEvent(1);
            if (deleted)
            {
                Console.WriteLine("Event with ID 1 deleted successfully.");
                string[] recordedMessagesAfterDeletion = logger2.GetRecordedMessages();
                foreach (string message in recordedMessages)
                {
                    Console.WriteLine(message);
                }
            }
            else
            {
                Console.WriteLine("Event with ID 1 not found.");
            }

            // Delete event for eventId 3 (non-existent event)
            deleted = logger2.DeleteEvent(3);
            if (deleted)
            {
                Console.WriteLine("Event with ID 3 deleted successfully.");
            }
            else
            {
                Console.WriteLine("Event with ID 3 not found.");
            }

            try
            {
                var user = new User {
                    Names = "John Smith",
                    Password = "password",
                    Role = Welcome.Others.UserRolesEnum.STUDENT
                };
                var viewModel = new UserViewModel(user);
                var view = new UserView(viewModel);
                view.Display();
                view.DisplayError();
            }catch (Exception ex)
            {
                var log = new ActionOnError(Delegates.Log3);
                log(ex.Message);
            }finally
            {
                Console.WriteLine("Executed in any case!");
            }
        }
    }
}
