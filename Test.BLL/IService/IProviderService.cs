using System.Collections.Generic;
using System.Threading.Tasks;
using Test.CustomModels.ResponseModel;
using Test.CustomModels.ProviderType;
using Test.CustomModels.Provider;

namespace Test.BLL.IService
{
    public interface IProviderService
    {
        #region ProviderType
        Task<ResponseModel<ProviderTypeResponseModel>> CreateProviderTypeAsync(ProviderTypeRequestModel requestModel);
        Task<ResponseModel<bool>> DeleteProviderTypeAsync(int providerId);
        Task<ResponseModel<ProviderTypeResponseModel>> GetProviderTypeByIdAsync(int providerId);
        Task<ResponseModel<IList<ProviderTypeResponseModel>>> GetAllProviderTypesAsync();
        Task<ResponseModel<ProviderTypeResponseModel>> UpdateProviderTypeAsync(ProviderTypeUpdateModel updateModel);
        #endregion

        #region Provider
        Task<ResponseModel<ProviderResponseModel>> CreateProviderAsync(ProviderRequestModel requestModel);
        Task<ResponseModel<bool>> DeleteProviderAsync(int ProviderId);
        Task<ResponseModel<IList<ProviderResponseModel>>> GetAllProvidersAsync();
        Task<ResponseModel<ProviderResponseModel>> GetProviderByIdAsync(int ProviderId);
        Task<ResponseModel<ProviderResponseModel>> UpdateProviderAsync(ProviderUpdateModel updateModel);

        #endregion
    }
}