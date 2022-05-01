using M12Assignment.Models.Wrappers;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace M12Assignment.Models
{
    public class RoomSession
    {
        private const string RoomCookieKey = "myRoom";

        private ISession session {  get; set; }
        public RoomSession(ISession session)
        {
            this.session = session;
        }

        public void SetMyRoom(Room myRoom)
        {
            session.SetObject(RoomCookieKey, myRoom);
        }
        public Room GetMyRoom()
        {
            return session.GetObject<Room>(RoomCookieKey);
        }
    }
}
