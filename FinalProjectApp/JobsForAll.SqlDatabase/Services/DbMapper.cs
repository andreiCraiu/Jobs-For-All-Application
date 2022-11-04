using JobsForAll.Library.Models;
using JobsForAll.SqlDatabase.Contracts;
using JobsForAll.SqlDatabase.Models;
using System;

namespace JobsForAll.SqlDatabase.Services
{
    internal class DbMapper : IDbMapper
    {
        public ApplicationUser MapToApplicationUser(DbApplicationUser model) => new()
        {
            UserName = model.UserName,
            NormalizedUserName = model.NormalizedUserName,
            Email = model.Email,
            NormalizedEmail = model.NormalizedEmail,
            EmailConfirmed = model.EmailConfirmed,
            PasswordHash = model.PasswordHash,
            SecurityStamp = model.SecurityStamp,
            ConcurrencyStamp = model.ConcurrencyStamp,
            PhoneNumber = model.PhoneNumber,
            PhoneNumberConfirmed = model.PhoneNumberConfirmed,
            TwoFactorEnabled = model.TwoFactorEnabled,
            LockoutEnd = model.LockoutEnd,
            LockoutEnabled = model.LockoutEnabled,
            AccessFailedCount = model.AccessFailedCount,
            Id = model.Id,
            Address = model.Address,
            Postcode = model.Postcode,
            Profession = model.Profession,
            Details = model.Details,
            Rating = model.Rating,
            JobsFinished = model.JobsFinished,
            Role = MapToRole(model.Role),

        };

        public Comment MapToComment(DbComment model) => new()
        {
            Id = model.Id,
            Body = model.Body,
            Like = model.Like,
            Dislike = model.Dislike,
            Author = model.Author,
        };

        public Job MapToJob(DbJob model) => new()
        {
            ID = model.ID,
            JobTitle = model.JobTitle,
            JobCategory = model.JobCategory,
            Price = model.Price,
            IsPriceNegociable = model.IsPriceNegociable,
            Description = model.Description,
        };

        public DbMessage MapToDbMessage(Message message) => new()
        {
            Content = message.Content,
            SendTime = message.SendTime,
            SenderId = message.SenderId,
            ReceiverId = message.ReceiverId,
        };

        public MessageViewModel MapToMessage(DbMessage model) => new()
        {
            Content = model.Content,
            Id = model.ID,
            ReceiverId = model.ReceiverId,
            SenderId = model.SenderId,
            SendTime = model.SendTime,
        };

        public DbJob MapToDbJob(Job model) => new()
        {
            JobTitle = model.JobTitle,
            JobCategory = model.JobCategory,
            Price = model.Price,
            IsPriceNegociable = model.IsPriceNegociable,
            Description = model.Description,
        };

        //
        private static Role MapToRole(DbRole theirGender)
        {
            switch (theirGender)
            {
                case DbRole.Admin:
                    return Role.Admin;
                case DbRole.JobRequester:
                    return Role.JobRequester;
                case DbRole.JobFinder:
                    return Role.JobFinder;
                case DbRole.Both:
                    return Role.Both;
                default:
                    throw new ArgumentOutOfRangeException(nameof(theirGender), theirGender, null);
            }
        }
    }
}
