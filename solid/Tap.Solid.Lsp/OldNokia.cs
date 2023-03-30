namespace Tap.Solid.Lsp
{
    internal class OldNokia : MobilePhone
    {
        internal override void SendSms(string phoneNumber)
        {
            //send SMS
        }

        internal override void MakePhoneCall(string phoneNumber)
        {
            //make phone call
        }

        internal override void SendEmail(string emailAdress)
        {
            throw new NotImplementedException();
        }

        internal override void BrowseWeb(string webAdress)
        {
            throw new NotImplementedException();
        }
    }
}
