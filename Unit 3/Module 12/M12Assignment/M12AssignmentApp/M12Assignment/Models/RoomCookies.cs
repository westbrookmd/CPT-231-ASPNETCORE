using M12Assignment.Models.Wrappers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace M12Assignment.Models
{
    public class RoomCookies
    {
        private const string RoomCookieKey = "myRoom";
        private const string RoomHistoryCookieKey = "myRoomHistory";
        private const string Delimiter = "|||";
        private IRequestCookieCollection requestCookies { get; set; }
        private IResponseCookies responseCookies { get; set; }

        public RoomCookies(IRequestCookieCollection requestCookies, IResponseCookies responseCookies)
        {
            this.requestCookies = requestCookies;
            this.responseCookies = responseCookies;
        }
        public void SetMyRoomId(Room myRoom)
        {
            string id = myRoom.RoomId.ToString();
            CookieOptions cookieOptions = new CookieOptions { Expires = System.DateTime.Now.AddDays(30) };
            RemoveMyRoom();
            responseCookies.Append(RoomCookieKey, id, cookieOptions);
            AddRoomToHistory(myRoom);
        }
        public int GetMyRoomId()
        {
            int id;
            //Non-wrapper version of requesting cookies
            string cookie = requestCookies[RoomCookieKey];
            if (string.IsNullOrEmpty(cookie))
            {
                id = 1;
            }
            else
            {
                if(int.TryParse(cookie, out int roomId))
                {
                    id = roomId;
                }
                else
                {
                    id = 1;
                }
            }
            return id;
        }
        public void AddRoomToHistory(Room newRoom)
        {
            List<Room> historyRooms = GetRoomHistory();
            //Had to implement IComparable<Room> to get this working
            historyRooms.Sort();
            //Only try to remove a cookie if there are ids that exist
            if (historyRooms.Count > 0)
            {
                RemoveRoomHistory();
            }
            //make sure the newRoom id isn't already within the cookie (to prevent duplicates)
            if (historyRooms.Where(r => r.RoomId == newRoom.RoomId).Count() == 0)
            {
                historyRooms.Add(newRoom);
            }
            CookieOptions options = new CookieOptions { Expires = DateTime.Now.AddDays(30) };
            //Saving every cookie in JSON (with the wrapper) for flexibility
            responseCookies.AppendAndSerialize(RoomHistoryCookieKey, historyRooms, Delimiter, options);
        }
        public List<Room> GetRoomHistory()
        {
            //Deserialize the json object before returning it
            return requestCookies.DeserializeObject<Room>(RoomHistoryCookieKey, Delimiter);
        }
        public void RemoveMyRoom()
        {
            if(responseCookies != null)
            {
                responseCookies.Delete(RoomCookieKey);
            }
        }
        public void RemoveRoomHistory()
        {
            if (responseCookies != null)
            {
                responseCookies.Delete(RoomHistoryCookieKey);
            }
        }
    }
}
