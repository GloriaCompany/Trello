﻿using System;

namespace TrelloApp.Models
{
    public class UserModel
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int AvatarID { get; set; }
    }
}
