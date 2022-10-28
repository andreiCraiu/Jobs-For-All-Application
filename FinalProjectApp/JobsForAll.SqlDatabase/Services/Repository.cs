using JobsForAll.Library.Contracts;
using JobsForAll.Library.Models;
using JobsForAll.SqlDatabase.Contracts;
using JobsForAll.SqlDatabase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JobsForAll.SqlDatabase.Services
{
    internal class Repository : IRepository
    {
        public Repository(IDataCore dataCore, IDbMapper mapper)
        {
            this.dataCore = dataCore;
            this.mapper = mapper;
        }

        public void AddMessages(Message message)
        {
            //repository.Messages.Add(databaseMessage);
            //repository.SaveChanges();
        }

        public IEnumerable<MessageViewModel> GetMessages()
        {
            var messages = dataCore.Messages.Select(
                m => new MessageViewModel
                {
                    Content = m.Content,
                    Id = m.ID,
                    ReceiverId = m.ReceiverId,
                    SenderId = m.SenderId,
                    SendTime = m.SendTime,
                });

            return messages;
        }

        public ApplicationUser? GetApplicationUsers(string id)
        {
            return dataCore.ApplicationUsers.Select(mapper.MapToApplicationUser).FirstOrDefault(user => user.Id == id);
        }

        public Task SaveUserChangesAsync(ApplicationUser user)
        {

            //todo: verificare daca exista user
            var dbUser = dataCore.ApplicationUsers.Where(it => it.Id == user.Id).FirstOrDefault();
            dbUser.Address = user.Address;
            dataCore.SaveChanges();
            return Task.CompletedTask;//todo: cauta pe net cum trebuie sa fie
        }

        public ApplicationUser GetUserByEmail(string email)
        {
            var userr = dataCore.ApplicationUsers.FirstOrDefault(user => user.Email == email);
            return new ApplicationUser();
        }

        public ApplicationUser? GetUserById(string userId)
        {
            return dataCore.ApplicationUsers.Select(mapper.MapToApplicationUser).FirstOrDefault(user => user.Id == userId);
        }

        public async Task SaveComents(Comment comment, UserComment userComment)
        {
            var dbComment = new DbComment()
            {
                Author = comment.Author,
            };
            var dbUserComment = new DbUserComment()
            {
                Id = userComment.Id,
            };
            await dataCore.Comments.AddAsync(dbComment);
            await dataCore.UserComments.AddAsync(dbUserComment);
            //todo: await dataCore.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetUserCommentsById(string id) => from comment in dataCore.UserComments
                                                                      where comment.ApplicationUser.Id == id
                                                                      select mapper.MapToComment(comment.Comment);

        public Job? GetJobById(int id) => dataCore
            .Jobs
            .Where(it => it.ID == id)
            .AsEnumerable()
            .Select(mapper.MapToJob)
            .FirstOrDefault();

        public async Task AddJobs(Job job, JobRequester jobRequester)
        {
            // await dataCore.Jobs.AddAsync(job);
            // await dataCore.JobRequesters.AddAsync(jobRequester);
            // await dataCore.SaveChangesAsync();
        }

        public void RemoveJobRequestsAndJob(Job job)
        {
            //var jobRequester = Queryable.FirstOrDefault<JobRequester>(repository.JobRequesters, jobsRequests => object.Equals(jobsRequests.Job, job));
            //repository.JobRequesters.Remove((JobRequester)jobRequester);
            //repository.Jobs.Remove(job);
            //repository.SaveChanges();
        }

        public IEnumerable<Job> GetJobsByUserId(string userId)
        {
            //var jobRequesters = from jobRequester in repository.JobRequesters
            //                    where jobRequester.ApplicationUser.Id == user.Id
            //                    select jobRequester;
            //var jobs = Queryable.Select<JobRequester, Job>(jobRequesters, job => job.Job);
            return Array.Empty<Job>();
        }

        public async Task<bool> ConfirmUser(string email, string confirmationToken)
        {
            //var toConfirm = dataCore.ApplicationUsers
            //    .Where(u => u.Email == email && u.SecurityStamp == confirmationToken)
            //    .FirstOrDefault();
            //if (toConfirm != null)
            //{
            //    toConfirm.EmailConfirmed = true;
            //    dataCore.Entry(toConfirm).State = EntityState.Modified;
            //    await dataCore.SaveChangesAsync();

            //    return true;
            //}

            //return false;
            return true;
        }

        public IEnumerable<ApplicationUser> GetUsersByUserName(string filterString) => dataCore
            .ApplicationUsers
            .Where(user => user.UserName.Contains(filterString))
            .AsEnumerable()
            .Select(mapper.MapToApplicationUser)
            .ToList();

        public IEnumerable<ApplicationUser> GetAllUsers() => dataCore.ApplicationUsers.Select(mapper.MapToApplicationUser);

        //

        private readonly IDataCore dataCore;
        private readonly IDbMapper mapper;
    }
}
