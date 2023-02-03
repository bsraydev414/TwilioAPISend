using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace smsapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SmsController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> SendSms(string to, string message)
        {
            // Your Twilio account SID and auth token
            const string accountSid = "youtwillioaccountsid";
            const string authToken = "yourtwilioauthtoken";

            // Initialize the Twilio client
            TwilioClient.Init(accountSid, authToken);

            // Send the SMS message
            var result = await MessageResource.CreateAsync(
                to: to,
                from: "youtwilionumber",
                body: message);

            // Return the result
            return Ok(result);
        }
    }
}
