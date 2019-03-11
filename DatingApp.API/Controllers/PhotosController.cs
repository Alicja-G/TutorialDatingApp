using System.Threading.Tasks;
using AutoMapper;
using CloudinaryDotNet;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DatingApp.API.Controllers
{

    [Authorize]
    [Route("api/users/{userId}/photos")]
    [ApiController]
    public class PhotosController : ControllerBase
    {
private readonly IDatingRepository _repo;
private readonly IOptions<CloudinarySettings> _cloudinaryConfig; 
private readonly IMapper _mapper;
        private Cloudinary _cloudinary;

        public PhotosController(IDatingRepository repo, IMapper mapper, 
        IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this._cloudinaryConfig = cloudinaryConfig;
            this._repo = repo;
            this._mapper = mapper; 

            var acc = new Account(
                _cloudinaryConfig.Value.CloudName,
                _cloudinaryConfig.Value.ApiKey,
                _cloudinaryConfig.Value.ApiSecrets
            ); 

            _cloudinary = new Cloudinary(acc); 
        }

        [HttpPost]
        public async Task<IActionResult> AddPhotoForUser(int userId,
         PhotoForCreationDto photoForCreationDto) 
        {
            
        }

    }


    
}