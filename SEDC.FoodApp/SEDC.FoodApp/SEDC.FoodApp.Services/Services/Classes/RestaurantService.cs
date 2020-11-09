﻿using SEDC.FoodApp.DataAccess.Mongo.Repositories.Interfaces;
using SEDC.FoodApp.DomainModels.Models;
using SEDC.FoodApp.RequestModels.Models;
using SEDC.FoodApp.Services.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.FoodApp.Services.Services.Classes
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;

        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task CreateNewRestaurantAsync(RestaurantRequestModel model)
        {
            var dtoRestaurant = new Restaurant()
            {
                Name = model.Name,
                Address = model.Address,
                Municipality = model.Municipality,
                Menu = new List<MenuItem>()
            };

            await _restaurantRepository.InsertRestaurantAsync(dtoRestaurant);
        }

        public async Task<Restaurant> GetRestaurantByIdAsync(string id) 
        {
            return await _restaurantRepository.GetRestaurantByIdAsync(id);
        }

        public async Task<List<RestaurantRequestModel>> GetRestaurantsAsync()
        {
            var restaurantList = await _restaurantRepository.GetRestaurantsAsync();

            var mapToRestaurantRequestModel = new List<RestaurantRequestModel>();

            foreach (var restaurant in restaurantList)
            {
                var tempModel = new RestaurantRequestModel()
                {
                    Id = restaurant.Id,
                    Name = restaurant.Name,
                    Address = restaurant.Address,
                    Municipality = restaurant.Municipality,
                    Menu = restaurant.Menu
                };

                mapToRestaurantRequestModel.Add(tempModel);
            }

            return mapToRestaurantRequestModel;
        }

        public async Task DeleteRestaurantByIdAsync(string id) 
        {
            await _restaurantRepository.DeleteRestaurantByIdAsync(id);
        }

        public async Task UpdateRestaurantAsync(UpdateRestaunratRequestModel requestModel) 
        {
            var restaurant = await GetRestaurantByIdAsync(requestModel.Id);
            restaurant.Name = requestModel.Name;
            restaurant.Address = requestModel.Address;
            restaurant.Municipality = requestModel.Municipality;

            await _restaurantRepository.UpdateRestaurantAsync(restaurant);
        }
    }
}
