
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using System.Net.Http;

//locals
using BlazorApp.Shared;

//3rd party
using SendGrid;
using SendGrid.Helpers.Mail;

namespace BlazorApp.Api
{
    public static class ContactUs
    {
        [FunctionName("Send")]
        public static  async Task<IActionResult> Send([HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = null)] HttpRequestMessage req,
            ILogger log)
        {
            string result = "";

            //get the object passed in
            dynamic person = await req.Content.ReadAsAsync<ContactMeModel>();

            //put code here to handle the submit.  For this example, we are just witting it out to a folder
            if (!string.IsNullOrEmpty(person.Name))
            {
                try
                {
                    var response = SendViaEmail(person);
                    if(response)
                    {
                        return new BadRequestObjectResult("Send Failed");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return new BadRequestObjectResult("Unable to save contact to data store");
                }
            }

            return new OkObjectResult(result);
        }

        private static async Task<bool> SendViaEmail(ContactMeModel person)
        {
            bool result = false;
            var client = new SendGridClient("XXX-Send Grid API-Key");
            var message = $"Recieved a contact us from {person.Name}.{Environment.NewLine}  {person.Name} can be reached at {person.PhoneNumber} or {person.Email}. They asked: {person.Message}";
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("Support@yourcompany.com", "Support"),
                Subject = "Contact Us",
                HtmlContent = message
            };
            msg.AddTo(new EmailAddress("Sales@yourcompany.com"));
            var response = await client.SendEmailAsync(msg);

            result = response.IsSuccessStatusCode;
            return result;
        }
    }
}
