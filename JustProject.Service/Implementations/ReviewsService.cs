using JustProject.DAL.Repositories;
using JustProject.Domain.Entity;
using JustProject.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JustProject.Service.Implementations
{
    public class ReviewsService : IReviewsService
    {
        private readonly ReviewsRepositoy _repositoy;
        public ReviewsService(ReviewsRepositoy repositoy)
        {
            _repositoy = repositoy;
        }
        public async Task<IEnumerable<Reviews>> GetReviews()
        {
            return await _repositoy.GetAll();
        }
    }
}
