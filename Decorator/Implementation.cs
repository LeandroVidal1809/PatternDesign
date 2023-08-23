using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    /// <summary>
    /// Component
    /// </summary>
    public interface IMailService
    {

        bool SendMail(string message);
    }

    /// <summary>
    /// Concrete component 2
    /// </summary>
    public class CloudMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message {message}" +
                $"sent via {nameof(CloudMailService)}.");
            return true;
        }
    }

    public class OnPremiseMailService : IMailService
    {
        public bool SendMail(string message)
        {
            Console.WriteLine($"Message {message}" +
                $"sent via {nameof(OnPremiseMailService)}.");
            return true;
        }
    }

    //Decorator
    public abstract class MailServiceDecoratorBase : IMailService
    {
        private readonly IMailService _mailService;
        public MailServiceDecoratorBase( IMailService mailService ) 
        {
            _mailService = mailService;
        }

        public virtual bool SendMail(string message)
        {
            return _mailService.SendMail(message);  
        }
    }

    //Decorator
    public class StaticsDecorator : MailServiceDecoratorBase
    {
        public StaticsDecorator(IMailService mailService)
        :base(mailService)
        {

        }

        public override bool SendMail(string message) 
        {
            //Fake collection staticist
            Console.WriteLine($"Collection statistics in {nameof(StaticsDecorator)}.");
            return base.SendMail(message);
        }
    }

    public class MessageDatabaseDecorator : MailServiceDecoratorBase
    {
        /// <summary>
        /// fake Database
        /// </summary>
        public List<string> SentMessages { get; set; } = new List<string>();
        public MessageDatabaseDecorator(IMailService mailService) : base(mailService)
        {
        }
        public override bool SendMail(string message)
        {
            if(base.SendMail(message))
            {
                SentMessages.Add(message);
                return true;
            }
            return false;
        }
    }
}
