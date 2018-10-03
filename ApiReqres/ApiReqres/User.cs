using System;
using System.Text.RegularExpressions;

namespace ApiReqres
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        public User(string apiResult)
        {
            Id = Int32.Parse(Regex.Match(apiResult, @"""id"":(\w*),").Groups[1].Value);
            FirstName = Regex.Match(apiResult, "\"first_name\":\"(\\w*)\",").Groups[1].Value;
            LastName = Regex.Match(apiResult, "\"last_name\":\"(\\w*)\",").Groups[1].Value;
            Avatar = Regex.Match(apiResult, "\"avatar\":\"(\\S*)\"").Groups[1].Value;
        }
    }
}
