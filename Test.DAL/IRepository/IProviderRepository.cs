using System.Collections.Generic;
using System.Threading.Tasks;
using Test.CustomModels.ResponseModel;
using Test.CustomModels.ProviderType;
using Test.CustomModels.Provider;

namespace Test.DAL.IRepository
{
    public interface IProviderRepository
    {
        #region Provider
        Task<ResponseModel<ProviderResponseModel>> CreateProviderAsync(ProviderRequestModel requestModel);
        Task<ResponseModel<bool>> DeleteProviderAsync(int providerId);
        Task<ResponseModel<IList<ProviderResponseModel>>> GetAllProvidersAsync();
        Task<ResponseModel<ProviderResponseModel>> GetProviderByIdAsync(int providerId);
        Task<ResponseModel<ProviderResponseModel>> UpdateProviderAsync(ProviderUpdateModel updateModel);
        #endregion

        #region ProviderTypes
        Task<ResponseModel<bool>> DeleteProviderTypeAsync(int providerId);
        Task<ResponseModel<ProviderTypeResponseModel>> CreateProviderTypeAsync(ProviderTypeRequestModel requestModel);
        Task<ResponseModel<IList<ProviderTypeResponseModel>>> GetAllProviderTypesAsync();
        Task<ResponseModel<ProviderTypeResponseModel>> GetProviderTypeByIdAsync(int providerId);
        Task<ResponseModel<ProviderTypeResponseModel>> UpdateProviderTypeAsync(ProviderTypeUpdateModel updateModel);
        #endregion 
    }
}