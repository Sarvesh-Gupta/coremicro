using System;

namespace MicroCore.Services.Activities.Domain.Models
{
    public class Activity
    {
        protected Activity()
        {
        }

        public Activity(Guid id,
            string name,
            Category category,
            string description,
            Guid userId,
            DateTime createdAt)
        {
            Id = id;
            Name = name;
            Category = category.Name;
            Description = description;
            UserId  = userId;
            CreatedAt = createdAt;
        }
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Category { get; protected set; }

        public Guid UserId { get; protected set; }

        public string Description { get; set; }

        public DateTime CreatedAt { get; protected set; }
    }
}