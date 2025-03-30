﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HubChatEjemplo.Models
{
    [Table("Users")]
    public class UserModel
    {
        [Key]
        public int Id { get; set; }
        public string Email {  get; set; }

        public string Nickname { get; set; }

        public bool Status { get; set; }

    }
}
