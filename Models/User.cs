﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Tunify_Platform.Models
{
    public class User
    {

        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime JoinDate { get; set; }
        public int SubscriptionId { get; set; }
        public Subscription Subscriptions { get; set; }
        public ICollection<Playlist> Playlists { get; set; }
    }
}
