﻿namespace EstimationPoker.ApiService.Models
{
    public class HashedCredentials
    {
        public byte[] Password { get; set; }
        public byte[] Salt { get; set; }
    }
}
