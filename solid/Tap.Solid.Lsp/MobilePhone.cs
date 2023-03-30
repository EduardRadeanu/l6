namespace Tap.Solid.Lsp
{
    internal abstract class MobilePhone
    {
        internal abstract void MakePhoneCall(string phoneNumber);
        internal abstract void SendSms(string phoneNumber);
        internal abstract void SendEmail(string emailAddress);
        internal abstract void BrowseWeb(string webAddress);
    }
}
