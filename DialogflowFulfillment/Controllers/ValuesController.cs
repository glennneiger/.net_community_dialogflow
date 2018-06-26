using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Google.Apis.Dialogflow.v2.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace DialogflowFulfillment.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpPost]
        public JsonResult Post([FromBody] dynamic value)
        {
            HttpContext.Response.Headers.Add("Content-Type", "application/json");
            
            Console.WriteLine(value);
            return Json(new GoogleCloudDialogflowV2beta1WebhookResponse()
            {
                FulfillmentText = "Hello from World",
                ETag = "test",
//                FulfillmentMessages = new List<GoogleCloudDialogflowV2beta1IntentMessage>()
//                {
//                    
//                    new GoogleCloudDialogflowV2beta1IntentMessage()
//                    {
//                        ETag = "test",
//                        SimpleResponses = new GoogleCloudDialogflowV2beta1IntentMessageSimpleResponses()
//                        {
//                            SimpleResponses = new List<GoogleCloudDialogflowV2beta1IntentMessageSimpleResponse>()
//                            {
//                                new GoogleCloudDialogflowV2beta1IntentMessageSimpleResponse()
//                                {
//                                    DisplayText = "this is a simple response",
//                                    TextToSpeech = "this is a simple response",
//                                    ETag = "test"
//                                }
//                            }
//                        }
//                    }
//                }, 
                
                Payload = new Dictionary<string, object>()
                {
                    { "google", JObject.Parse(@"{
                        'expect_user_response': true,
                        'rich_response': {
                        'items': [
                        {
                        'simple_response': {
                        'text_to_speech': 'our move was top. I moved left'
                    }
                    },
                    {
                        'basic_card': {
                        'image': {
                        'url': 'https://server/010200000.png',
                        'accessibility_text': 'Tic Tac Toe game board'
                    }
                    }
                }
                    ]
                    }
                    }")
                        
                    }
                }
            });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
//        [HttpPost]
//        public void Post([FromBody] string value)
//        {
//        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}