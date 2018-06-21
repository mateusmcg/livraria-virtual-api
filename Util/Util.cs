using System;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

public static class Util
{
    public static void Audit(object previousStatue, object newState, ActionType actionType)
    {
        var client = new HttpClient();
        var postBody = JsonConvert.SerializeObject(new
        {
            ExecutionDate = DateTime.Now,
            UserId = 123,
            ActionType = actionType,
            ObjectPreviousState = previousStatue,
            ObjectNewState = newState
        });
        client.PostAsync("", new StringContent(postBody, Encoding.UTF8, "application/json"));
    }
}