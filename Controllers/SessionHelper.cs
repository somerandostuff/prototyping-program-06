using Newtonsoft.Json;

namespace Assignment_2_NEW.Controllers
{
    public static class SessionHelper
    {
        public static T? GetObjectFromJson<T>(this ISession Session, string Key)
        {
            var Value = Session.GetString(Key);
            return Value == null ? default : JsonConvert.DeserializeObject<T>(Value);
        }

        public static void SetObjectAsJson(this ISession Session, string Key, object Value)
        {
            Session.SetString(Key, JsonConvert.SerializeObject(Value));
        }
    }
}
