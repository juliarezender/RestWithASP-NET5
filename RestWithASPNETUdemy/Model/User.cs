﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASPNETUdemy.Model
{
    [Table("users")]
    public class User
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("user_name")]
        public string UserName { get; set; }
        [Column("full_name")]
        public string FullName { get; set; }
        [Column("password")]
        public string PassWordId { get; set; }
        [Column("refresh_token")]
        public string RefresToken { get; set; }
        [Column("refresh_token_expiry_time")]
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}