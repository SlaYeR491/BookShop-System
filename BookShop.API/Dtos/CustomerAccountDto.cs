﻿namespace BookShop.API.Dtos
{
    public class CustomerAccountDto
    {
        public int Id { get; set; }
        public bool IsActive { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }    
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}
