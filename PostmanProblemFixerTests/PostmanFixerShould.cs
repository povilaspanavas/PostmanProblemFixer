using Microsoft.VisualStudio.TestTools.UnitTesting;
using PostmanProblemFixer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PostmanProblemFixer.Tests
{
    [TestClass]
    public class PostmanFixerShould
    {
        [TestMethod]
        public void FixCurl_When_AndroidFormatIsUsed()
        {
            // arrange
            var curl = @"curl -X POST -H “Content-Type: Application/Json” -H “Platform: Android” -H “Version-Code: 10.4” -H “Poq-App-Id: 76"" - H “Poq - User - Id: 7abd4b21 - a918 - 49ca - 937a - 1733cf83df43” -H “Currency - Code: GBP” -H “Authorization: Basic ZGFuaWVsLmJlbml0b0Bwb3FzdHVkaW8uY29tOjJTSjdnazhHS1ZJPQ==” --data $‘{“billingAddress”:{“address1”:“City road 58"",“city”:“London”,“country”:“United Kingdom”,“countryId”:“GB”,“firstName”:“other”,“id”:10729919,“isDefaultBilling”:true,“isDefaultShipping”:false,“lastName”:“guy”,“phone”:“7378670676”,“postCode”:“EC1Y 2AL”},“deliveryOption”:{“optionCode”:“missguided_deliveryrule_UK_Standard_Delivery_3-5_days”,“price”:3.99,“title”:“UK Standard Delivery 3-5 days”},“paymentOption”:{“paymentMethodToken”:“card_1ENj79DFyS8YC87yQGmjckVV”,“stripeCustomerId”:“cus_ErS1xLW4Sa4uW5""},“poqOrderId”:273478,“shippingAddress”:{“address1”:“City road 58"",“city”:“London”,“country”:“United Kingdom”,“countryId”:“GB”,“firstName”:“dan”,“id”:10729917,“isDefaultBilling”:false,“isDefaultShipping”:false,“lastName”:“ben”,“phone”:“7378670676”,“postCode”:“EC1Y 2AL”},“subtotalPrice”:6.0,“totalPrice”:9.99,“vouchers”:[]}’ https://lalala.azure-api.net/checkout/postorder/76/7abd4b21-a918-49ca-937a-1733cf83df43";

            // act
            var result = PostmanFixer.FixCurl(curl);

            // assert
            Assert.IsTrue(result.StartsWith("curl https://lalala.azure-api.net/checkout/postorder/76/7abd4b21-a918-49ca-937a-1733cf83df43 -X POST -H \"Cont"));
        }

        [TestMethod()]
        public void FixCurl_When_CharlesFormatIsUsed()
        {
            // arrange
            var curl = @"curl -H 'Host: poqapiuat.azure-api.net' -H 'Poq-App-Id: 228' -H 'Accept: application/json' -H 'Version-Code: 12.4' -H 'platform: ipad' -H 'Poq-User-Id: ECE0BB21-85BF-4E3D-9900-436D90A4EF85' -H 'Accept-Language: en-us' -H 'User-Agent: Oasis%20-%20UAT/13.0.2.344 CFNetwork/975.0.3 Darwin/18.2.0' -H 'Currency-Code: GBP' -H 'Content-Type: application/json' -H 'appUserAgent: Poq-Native-iOS-App' --data-binary '{
  ""orderId"" : 252350,
  ""voucherAmount"" : 2.9900000000000002,
  ""deliveryCost"" : 2.9900000000000002,
  ""totalPrice"" : 10,
  ""externalOrderId"" : ""06051441""
}' --compressed 'https://lalala.azure-api.net/CartTransfer/apps/228/Complete?poqUserId=ECE0BB21-85BF-4E3D-9900-436D90A4EF85'";

            // act
            var result = PostmanFixer.FixCurl(curl);

            // assert
            Assert.IsTrue(result.StartsWith("curl 'https://lalala.azure-api.net/CartTransfer/apps/228/Complete?poqUserId=ECE0BB21-85BF-4E3D-9900-436D90A4EF85' -H 'Host: p"));
        }
    }
}