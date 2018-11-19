namespace MicroCore.Common
{
    using System;
    public class CreateActivity : IAuthenticatedCommand
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }

        public string Category { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}