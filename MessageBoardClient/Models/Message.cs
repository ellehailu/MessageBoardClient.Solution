using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;

namespace MessageBoardClient.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Subject { get; set; }
        public string Group { get; set; }
        public string Body { get; set; }

        public static List<Message> GetMessages()
        {
            Task<string> apiCallTask = ApiHelper.GetAll();
            string result = apiCallTask.Result;

            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
            List<Message> messageList = JsonConvert.DeserializeObject<List<Message>>(jsonResponse.ToString());

            return messageList;
        }

        public static Message GetDetails(int id)
        {
            Task<string> apiCallTask = ApiHelper.Get(id);
            string result = apiCallTask.Result;

            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
            Message message = JsonConvert.DeserializeObject<Message>(jsonResponse.ToString());

            return message;
        }

        public static void Post(Message message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            ApiHelper.Post(jsonMessage);
        }

        public static void Put(Message message)
        {
            string jsonMessage = JsonConvert.SerializeObject(message);
            ApiHelper.Put(message.MessageId, jsonMessage);
        }

        public static void Delete(int id)
        {
            ApiHelper.Delete(id);
        }
    }
}