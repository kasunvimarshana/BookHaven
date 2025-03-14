﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHaven.Enums;

namespace BookHaven.Models
{
    class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string FullName { get; set; }

        public UserRole Role { get; set; }

        public string Email { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
