using JustProject.DAL.Interfaces;
using JustProject.DAL.Repositories;
using JustProject.Domain.Entity;
using JustProject.Domain.Response;
using JustProject.Domain.ViewModels;
using JustProject.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace JustProject.Service.Implementations
{
    public class UserTestsService : IUserTestsService
    {
        private readonly IBaseRepository<UserTests> _userTestsRepository;
        public UserTestsService(IBaseRepository<UserTests> repository)
        {
            _userTestsRepository = repository;
        }

        public async Task<UserTests> Get(int id)
        {
            try
            {
                var test = (await _userTestsRepository.GetAll()).FirstOrDefault(x=>x.Id == id);
                return test;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IEnumerable<UserTests>> GetAll()
        {
            try
            {         
                var tests = await _userTestsRepository.GetAll();
                return tests;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
