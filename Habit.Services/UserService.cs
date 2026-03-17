using Habit.Core.RepositoryContract;
using Habit.Core.ServiceContract;
using Microsoft.AspNetCore.Http;
using ReHabit.Api.Helpers;
using ReHabit.Habit.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Habit.Services
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ImageUpload _imageUpload;
        public UserService(IUserRepository userRepository, ImageUpload imageUpload)
        {
            _userRepository = userRepository;
            _imageUpload = imageUpload;
        }
        public async Task<string?> UploadUserImageProfile(int userId,IFormFile image)
        {
            var user = await _userRepository.GetByIdAsync(userId);
            if (user == null)
            {
                return null;
            }
            if (image == null || image.Length < 0)
                return null;

            var imageUrl = await _imageUpload.SaveImageAsync(image);
            await _userRepository.UploadUserProileImage(user, imageUrl);
            return imageUrl;
        }
    }
}
