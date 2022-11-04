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
            var dbMessage = mapper.MapToDbMessage(message);
            //todo:save si sender si receiver
            dataCore.Messages.Add(dbMessage);
            dataCore.SaveChanges();
        }

        public IEnumerable<MessageViewModel> GetMessages()
        {
            var messages = dataCore.Messages.AsEnumerable().Select(mapper.MapToMessage);

            return messages;
        }

        public async Task SaveUserChangesAsync(ApplicationUser user)
        {
            var dbUser = dataCore.ApplicationUsers.Where(it => it.Id == user.Id).FirstOrDefault();
            if (dbUser == null)
                throw new Exception("Userul nu exista");

            dbUser.Address = user.Address;
            //todo: si ce mai vrei update
            await dataCore.SaveChangesAsync();
        }

        public ApplicationUser? GetUserByEmail(string email) => dataCore
            .ApplicationUsers
            .Select(mapper.MapToApplicationUser)
            .FirstOrDefault(user => user.Email == email);

        public ApplicationUser? GetUserById(string userId) => dataCore
            .ApplicationUsers
            .Select(mapper.MapToApplicationUser)
            .FirstOrDefault(user => user.Id == userId);

        public async Task SaveComents(Comment comment, UserComment userComment)
        {
            var dbComment = new DbComment
            {
                Body = comment.Body,
                Like = comment.Like,
                Dislike = comment.Dislike,
                Author = comment.Author,
            };
            // var dbUserComment = new DbUserComment
            // {
            //     Id = 0,
            //     ApplicationUser = null,
            //     Comment = null
            // };
            await dataCore.Comments.AddAsync(dbComment);
            //todo: await dataCore.UserComments.AddAsync(dbUserComment);
            await dataCore.SaveChangesAsync();
        }

        public IEnumerable<Comment> GetUserCommentsById(string id) =>
            from comment in dataCore.UserComments
            where comment.ApplicationUser.Id == id
            select mapper.MapToComment(comment.Comment);

        public Job? GetJobById(int jobId) => dataCore
            .Jobs
            .Where(it => it.ID == jobId)
            .AsEnumerable()
            .Select(mapper.MapToJob)
            .FirstOrDefault();

        public async Task AddJobs(Job job, JobRequester jobRequester)
        {
            var dbJob = mapper.MapToDbJob(job);
            await dataCore.Jobs.AddAsync(dbJob);
            //todo: await dataCore.JobRequesters.AddAsync(jobRequester);
            await dataCore.SaveChangesAsync();
        }

        public void RemoveJobRequestsAndJob(Job job)
        {
            //var jobRequester = Queryable.FirstOrDefault<JobRequester>(dataCore.JobRequesters, jobsRequests => object.Equals(jobsRequests.Job, job));
            var existingJob = dataCore.Jobs.Where(it => it.ID == job.ID).FirstOrDefault();
            if (existingJob == null)
                throw new Exception("Jobul nu exista");

            //todo: dataCore.JobRequesters.Remove((JobRequester)jobRequester);
            dataCore.Jobs.Remove(existingJob);
            dataCore.SaveChanges();
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
            var toConfirm = dataCore.ApplicationUsers
                .Where(it => it.Email == email && it.SecurityStamp == confirmationToken)
                .FirstOrDefault();
            if (toConfirm == null)
                return false;

            toConfirm.EmailConfirmed = true;
            // dataCore.Entry(toConfirm).State = EntityState.Modified;
            dataCore.ApplicationUsers.Update(toConfirm);
            await dataCore.SaveChangesAsync();

            return true;
        }

        public IEnumerable<ApplicationUser> GetUsersByUserName(string filterString) => dataCore
            .ApplicationUsers
            .Where(user => user.UserName.Contains(filterString))
            .AsEnumerable()
            .Select(mapper.MapToApplicationUser)
            .ToList();

        public IEnumerable<ApplicationUser> GetAllUsers() => dataCore
            .ApplicationUsers
            .Select(mapper.MapToApplicationUser);

        public void RemoveUser(ApplicationUser user)
        {
            var existingUser = dataCore.ApplicationUsers.Where(it => it.Id == user.Id).FirstOrDefault();
            if (existingUser == null)
                throw new Exception("Userul nu exista");

            dataCore.ApplicationUsers.Remove(existingUser);
            dataCore.SaveChanges();
        }

        //

        private readonly IDataCore dataCore;
        private readonly IDbMapper mapper;
    }
}
