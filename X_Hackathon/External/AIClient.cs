using OpenAI;
using OpenAI.Assistants;
using OpenAI.Files;
using System.ClientModel;
using System.Text;
using System.Threading;

namespace X_Hackathon.External
{
    public class AIClient
    {
        public async Task<string> InterpretAirWayBillsAsync(List<Tuple<Stream, string, Uri>> files)
        {
#pragma warning disable OPENAI001 // Assistant class is in Evaluation and subject to change
            OpenAIClient openAIClient = new(Environment.GetEnvironmentVariable("OpenAIKey"));
            OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
            AssistantClient assistantClient = openAIClient.GetAssistantClient();

            AssistantCreationOptions assistantOptions = new()
            {
                Name = "GroundLink",
                Instructions =
                    "You are an assistant that interprets Export Customs Document, including but not limited to AirwayBills, Commercial Invoice, Packing List."                
            };

            Assistant assistant = assistantClient.CreateAssistant("gpt-4o", assistantOptions);

            var messages = new List<MessageContent>() {
                        "From this airway bills can you list down all the data for each airway bill. the Values that you should collect are, Headers are as follows: Shipper's name, Reference Number, The amount, Type of Goods, Origin, Destination, Number of Pieces, weight, volume\r\n\r\nGenerate the file in .json array only, always make sure it starts with [] bracket, ensure all datatypes of json are string, Always Add Property Uri Where it contains the link to the file, do not explain",
                    };
            foreach(var awb in files)
            {
                messages.Add(MessageContent.FromImageUri(awb.Item3, MessageImageDetail.Auto ));
            }
            // Now we'll create a thread with a user query about the data already associated with the assistant, then run it
            ThreadCreationOptions threadOptions = new()
            {
                InitialMessages = {
                    new ThreadInitializationMessage(MessageRole.User , messages)
                    
                    //"From this airway bills can you list down all the data for each airway bill. the Values that you should collect are, Headers are as follows: Shipper's name, Reference Number, The amount, Type of Goods, Origin, Destination, Number of Pieces, weight, volume\r\n\r\nGenerate the file in .csv" 
                }

            };

            ThreadRun threadRun = assistantClient.CreateThreadAndRun(assistant.Id, threadOptions);

            // Check back to see when the run is done
            do
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                threadRun = assistantClient.GetRun(threadRun.ThreadId, threadRun.Id);
            } while (!threadRun.Status.IsTerminal);

            // Finally, we'll print out the full history for the thread that includes the augmented generation
            CollectionResult<ThreadMessage> threadmessages
                = assistantClient.GetMessages(threadRun.ThreadId, new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending });

            StringBuilder completeMessageBuilder =  new StringBuilder();
            foreach (ThreadMessage message in threadmessages)
            {
                Console.Write($"[{message.Role.ToString().ToUpper()}]: ");
                foreach (MessageContent contentItem in message.Content)
                {
                    if (!string.IsNullOrEmpty(contentItem.Text))
                    {
                        if(message.Role == MessageRole.Assistant )
                        {
                            completeMessageBuilder.Append(contentItem.Text);
                        }
                        Console.WriteLine($"{contentItem.Text}");
                    }
                }
                Console.WriteLine();
#pragma warning restore OPENAI001 // Assistant class is in Evaluation and subject to change
            }
            return completeMessageBuilder.ToString();
        }

        public async Task<string> InterpretPacketListsAsync(List<Tuple<Stream, string, Uri>> files)
        {
#pragma warning disable OPENAI001 // Assistant class is in Evaluation and subject to change
            OpenAIClient openAIClient = new(Environment.GetEnvironmentVariable("OpenAIKey"));
            OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
            AssistantClient assistantClient = openAIClient.GetAssistantClient();

            AssistantCreationOptions assistantOptions = new()
            {
                Name = "GroundLink",
                Instructions =
                    "You are an assistant that interprets Export Customs Document, including but not limited to AirwayBills, Commercial Invoice, Packing List."
            };

            Assistant assistant = assistantClient.CreateAssistant("gpt-4o", assistantOptions);

            var messages = new List<MessageContent>() {
                        "From this packing list can you list down all the data for each packing list. the Values that you should collect are, Headers are as follows: Shipper's Name, Reference Number, Type of Goods, Origin, Destination, Number of Pieces, Total weight, volume\r\n\r\n\r\n\r\nGenerate the file in .json array only, always make sure it starts with [] bracket, ensure all datatypes of json are string, Always Add Property Uri Where it contains the link to the file, do not explain",
                    };
            foreach (var awb in files)
            {
                messages.Add(MessageContent.FromImageUri(awb.Item3, MessageImageDetail.Auto));
            }
            ThreadCreationOptions threadOptions = new()
            {
                InitialMessages = {
                    new ThreadInitializationMessage(MessageRole.User , messages)
                }

            };

            ThreadRun threadRun = assistantClient.CreateThreadAndRun(assistant.Id, threadOptions);

            do
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                threadRun = assistantClient.GetRun(threadRun.ThreadId, threadRun.Id);
            } while (!threadRun.Status.IsTerminal);

            CollectionResult<ThreadMessage> threadmessages
                = assistantClient.GetMessages(threadRun.ThreadId, new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending });

            StringBuilder completeMessageBuilder = new StringBuilder();
            foreach (ThreadMessage message in threadmessages)
            {
                Console.Write($"[{message.Role.ToString().ToUpper()}]: ");
                foreach (MessageContent contentItem in message.Content)
                {
                    if (!string.IsNullOrEmpty(contentItem.Text))
                    {
                        if (message.Role == MessageRole.Assistant)
                        {
                            completeMessageBuilder.Append(contentItem.Text);
                        }
                        Console.WriteLine($"{contentItem.Text}");
                    }
                }
                Console.WriteLine();
#pragma warning restore OPENAI001 // Assistant class is in Evaluation and subject to change
            }
            return completeMessageBuilder.ToString();
        }

        public async Task<string> InterpretCommercialInvoiceAsync(List<Tuple<Stream, string, Uri>> files)
        {
#pragma warning disable OPENAI001 // Assistant class is in Evaluation and subject to change
            OpenAIClient openAIClient = new(Environment.GetEnvironmentVariable("OpenAIKey"));
            OpenAIFileClient fileClient = openAIClient.GetOpenAIFileClient();
            AssistantClient assistantClient = openAIClient.GetAssistantClient();

            AssistantCreationOptions assistantOptions = new()
            {
                Name = "GroundLink",
                Instructions =
                    "You are an assistant that interprets Export Customs Document, including but not limited to AirwayBills, Commercial Invoice, Packing List."
            };

            Assistant assistant = assistantClient.CreateAssistant("gpt-4o", assistantOptions);

            var messages = new List<MessageContent>() {
                        "From this Documents, can you list down all the data for each document. the Values that you should collect are, Headers are as follows: Shipper's Name, Reference Number, Code Identifier, The amount, Type of Goods, Origin, Destination, Number of Pieces, weight, volume, AWBNumber \r\n\r\n\r\n\r\nGenerate the file in .json array only, always make sure it starts with [] bracket, ensure all datatypes of json are string, Always Add Property Uri Where it contains the link to the file, do not explain",
                    };
            foreach (var awb in files)
            {
                messages.Add(MessageContent.FromImageUri(awb.Item3, MessageImageDetail.Auto));
            }
            ThreadCreationOptions threadOptions = new()
            {
                InitialMessages = {
                    new ThreadInitializationMessage(MessageRole.User , messages)
                }

            };

            ThreadRun threadRun = assistantClient.CreateThreadAndRun(assistant.Id, threadOptions);

            do
            {
                Thread.Sleep(TimeSpan.FromSeconds(1));
                threadRun = assistantClient.GetRun(threadRun.ThreadId, threadRun.Id);
            } while (!threadRun.Status.IsTerminal);

            CollectionResult<ThreadMessage> threadmessages
                = assistantClient.GetMessages(threadRun.ThreadId, new MessageCollectionOptions() { Order = MessageCollectionOrder.Ascending });

            StringBuilder completeMessageBuilder = new StringBuilder();
            foreach (ThreadMessage message in threadmessages)
            {
                Console.Write($"[{message.Role.ToString().ToUpper()}]: ");
                foreach (MessageContent contentItem in message.Content)
                {
                    if (!string.IsNullOrEmpty(contentItem.Text))
                    {
                        if (message.Role == MessageRole.Assistant)
                        {
                            completeMessageBuilder.Append(contentItem.Text);
                        }
                        Console.WriteLine($"{contentItem.Text}");
                    }
                }
                Console.WriteLine();
#pragma warning restore OPENAI001 // Assistant class is in Evaluation and subject to change
            }
            return completeMessageBuilder.ToString();
        }
    }
}
