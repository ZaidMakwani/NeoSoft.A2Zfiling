using NeoSoft.A2Zfiling.Common.Helper.ApiHelper;
using NeoSoft.A2ZFiling.UI.Interfaces;
using NeoSoft.A2ZFiling.UI.ViewModels;

namespace NeoSoft.A2ZFiling.UI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IApiClient<CategoryVM> _httpClient;
        private readonly ILogger<CategoryService> _logger;

        public CategoryService(IApiClient<CategoryVM> httpClient, ILogger<CategoryService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<CategoryVM> CreateCategoryAsync(CategoryVM role)
        {
            _logger.LogInformation("Create CategoryService Initiated");
            var data = await _httpClient.PostAsync("Category/", role);
            _logger.LogInformation("Create CategoryService Completed");
            return data.Data;
        }

        public async Task<CategoryVM> DeleteCategoryAsync(int id)
        {
            _logger.LogInformation("Delete CategoryService Initiated");

            var getById = await _httpClient.GetByIdAsync($"Category/id?id={id}");
            if (getById == null)
            {
                _logger.LogError("Category  not found.");
                return null;
            }
            var category = getById.Data;
            category.IsActive = false;
            var updatedata = await _httpClient.PutAsync($"Category/id?id={id}", category);
            _logger.LogInformation("Delete CategoryService Completed");

            return updatedata.Data;
        }

        public async Task<CategoryVM> GetByIdAsync(int id)
        {
            _logger.LogInformation("GetById CategoryService Initiated");
            var license = await _httpClient.GetByIdAsync($"Category/id?id={id}");
            _logger.LogInformation("GetById CategoryService Completed");
            return license.Data;
        }

        public async Task<IEnumerable<CategoryVM>> GetCategoryAsync()
        {
            _logger.LogInformation("GetAll LicenseTypeService Initiated");
            var license = await _httpClient.GetAllAsync("Category/all");
            _logger.LogInformation("GetAll LicenseTypeService Completed");

            return license.Data;
        }

        public async Task<CategoryVM> UpdateCategoryAsync(CategoryVM role)
        {
            _logger.LogInformation("Update CategoryService Initiated");
            var category = await _httpClient.PutAsync("Category/id", role);
            _logger.LogInformation("Update CategoryService Completed");
            return category.Data;
        }
    }
    }
