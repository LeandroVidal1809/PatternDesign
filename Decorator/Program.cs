using Decorator;
using System.Diagnostics;
using System.Net.Http.Headers;

Console.Title = "Decorator";
// instanciate mail service
var cloudMailService =  new CloudMailService();
cloudMailService.SendMail("Hi there");


var onpremiseMailService = new OnPremiseMailService();
onpremiseMailService.SendMail("Hi there");

//add Behavior
var staticticsDecorator = new StaticsDecorator(cloudMailService);
staticticsDecorator.SendMail($"Hi there via {nameof(staticticsDecorator)} wrapper");

// add Behavior 
var messageDatabaseDecorator =  new MessageDatabaseDecorator(onpremiseMailService);
messageDatabaseDecorator.SendMail($"Hi there via {nameof(messageDatabaseDecorator)} wrapper , message 1");
messageDatabaseDecorator.SendMail($"Hi there via {nameof(messageDatabaseDecorator)} wrapper , message 2");


foreach (var item in messageDatabaseDecorator.SentMessages)
{
    Console.WriteLine($"Store message:{item}");
}