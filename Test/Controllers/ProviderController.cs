using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.BLL.IService;
using Test.CustomModels.Provider;
using Test.CustomModels.ProviderType;
using Test.CustomModels.ResponseModel;

namespace Test.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderService service;
        private readonly IGroupService groupService;

        public ProviderController(IProviderService service, IGroupService groupService)
        {
            this.service = service;
            this.groupService = groupService;
        }

        #region Provider
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ResponseModel<IList<ProviderResponseModel>> Providers = await service.GetAllProvidersAsync();

            return View(Providers);
        }

        [HttpGet]
        public async Task<IActionResult> GetProvider(int providerId)
        {
            ResponseModel<ProviderResponseModel> Provider = await service.GetProviderByIdAsync(providerId);

            return View(Provider);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProvider()
        {
            ViewBag.Groups = await groupService.GetAllGroupsAsync();
            ViewBag.ProviderTypes = await service.GetAllProviderTypesAsync();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateProvider(ProviderRequestModel requestModel)
        {
            ResponseModel<ProviderResponseModel> Provider = await service.CreateProviderAsync(requestModel);

            return View(Provider);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProvider(ProviderUpdateModel updateModel)
        {
            ResponseModel<ProviderResponseModel> Providers = await service.UpdateProviderAsync(updateModel);

            return View(Providers);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProvider(int providerId)
        {
            ResponseModel<bool> Providers = await service.DeleteProviderAsync(providerId);

            return View(Providers);
        }
        #endregion

        #region ProviderType
        [HttpGet]
        public async Task<IActionResult> GetProviderTypes()
        {
            ResponseModel<IList<ProviderTypeResponseModel>> ProviderTypes = await service.GetAllProviderTypesAsync();

            return View(ProviderTypes);
        }

        [HttpGet]
        public async Task<IActionResult> GetProviderType(int ProviderTypeId)
        {
            ResponseModel<ProviderTypeResponseModel> ProviderType = await service.GetProviderTypeByIdAsync(ProviderTypeId);
            ViewBag.ProviderType = ProviderType;

            ResponseModel<IList<ProviderTypeResponseModel>> ProviderTypes = await service.GetAllProviderTypesAsync();

            return View(ProviderTypes);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProviderType()
        {
            ResponseModel<IList<ProviderTypeResponseModel>> ProviderType = await service.GetAllProviderTypesAsync();

            return View(ProviderType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProviderType(ProviderTypeRequestModel requestModel)
        {
            ResponseModel<ProviderTypeResponseModel> ProviderType = await service.CreateProviderTypeAsync(requestModel);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProviderType(ProviderTypeUpdateModel updateModel)
        {
            ResponseModel<ProviderTypeResponseModel> ProviderTypes = await service.UpdateProviderTypeAsync(updateModel);

            return Ok(ProviderTypes);
        }

        [HttpGet]
        public async Task<IActionResult> DeleteProviderType(int ProviderTypeId)
        {
            ResponseModel<bool> ProviderTypes = await service.DeleteProviderTypeAsync(ProviderTypeId);

            return Ok(); 
        }
        #endregion
    }
}
