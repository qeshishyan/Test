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
            ResponseModel<IList<ProviderResponseModel>> providers = await service.GetAllProvidersAsync();

            return View(providers);
        }

        [HttpGet]
        public async Task<IActionResult> GetProvider(int providerId)
        {
            ResponseModel<ProviderResponseModel> provider = await service.GetProviderByIdAsync(providerId);

            ViewBag.Groups = await groupService.GetAllGroupsAsync();
            ViewBag.ProviderTypes = await service.GetAllProvidersAsync();
            ViewBag.Providers = await service.GetAllProvidersAsync();

            return View(provider);
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
            ResponseModel<ProviderResponseModel> provider = await service.CreateProviderAsync(requestModel);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProvider(ProviderUpdateModel updateModel)
        {
            ResponseModel<ProviderResponseModel> providers = await service.UpdateProviderAsync(updateModel);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProvider(int providerId)
        {
            ResponseModel<bool> providers = await service.DeleteProviderAsync(providerId);

            return Ok();
        }
        #endregion

        #region ProviderType
        [HttpGet]
        public async Task<IActionResult> GetProviderTypes()
        {
            ResponseModel<IList<ProviderTypeResponseModel>> providerTypes = await service.GetAllProviderTypesAsync();

            return View(providerTypes);
        }

        [HttpGet]
        public async Task<IActionResult> GetProviderType(int ProviderTypeId)
        {
            ResponseModel<ProviderTypeResponseModel> providerType = await service.GetProviderTypeByIdAsync(ProviderTypeId);
            ViewBag.ProviderType = providerType;

            ResponseModel<IList<ProviderTypeResponseModel>> providerTypes = await service.GetAllProviderTypesAsync();

            return View(providerTypes);
        }

        [HttpGet]
        public async Task<IActionResult> CreateProviderType()
        {
            ResponseModel<IList<ProviderTypeResponseModel>> providerType = await service.GetAllProviderTypesAsync();

            return View(providerType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProviderType(ProviderTypeRequestModel requestModel)
        {
            ResponseModel<ProviderTypeResponseModel> providerType = await service.CreateProviderTypeAsync(requestModel);

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProviderType(ProviderTypeUpdateModel updateModel)
        {
            ResponseModel<ProviderTypeResponseModel> providerTypes = await service.UpdateProviderTypeAsync(updateModel);

            return Ok(providerTypes);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProviderType(int providerTypeId)
        {
            ResponseModel<bool> providerTypes = await service.DeleteProviderTypeAsync(providerTypeId);

            return Ok(providerTypes); 
        }
        #endregion
    }
}
