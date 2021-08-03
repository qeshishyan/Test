using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.BLL.IService;
using Test.CustomModels.ResponseModel;
using Test.CustomModels.ProviderType;
using Test.DAL.IRepository;
using Test.CustomModels.Provider;

namespace Test.BLL.Service
{
    public class ProviderService : IProviderService
    {
        private readonly IProviderRepository repository;

        public ProviderService(IProviderRepository repository)
        {
            this.repository = repository;
        }

        #region ProviderTypes
        public async Task<ResponseModel<ProviderTypeResponseModel>> CreateProviderTypeAsync(ProviderTypeRequestModel requestModel)
        {
            try
            {
                if(requestModel is null)
                {
                    return new ResponseModel<ProviderTypeResponseModel>
                    {
                        Message = "Request model is null!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }    
                
                ResponseModel<ProviderTypeResponseModel> response = await repository.CreateProviderTypeAsync(requestModel);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProviderTypeResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<bool>> DeleteProviderTypeAsync(int providerId)
        {
            try
            {
                if (providerId is 0)
                {
                    return new ResponseModel<bool>
                    {
                        Message = "Invalid id!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1,
                        Data = false
                    };
                }

                ResponseModel<bool> response = await repository.DeleteProviderTypeAsync(providerId);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1,
                    Data = false
                };
            } 
        }
        public async Task<ResponseModel<IList<ProviderTypeResponseModel>>> GetAllProviderTypesAsync()
        {
            try
            {
                ResponseModel<IList<ProviderTypeResponseModel>> response = await repository.GetAllProviderTypesAsync();

                return response;
            }
            catch(Exception ex)
            {
                return new ResponseModel<IList<ProviderTypeResponseModel>>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<ProviderTypeResponseModel>> GetProviderTypeByIdAsync(int providerId)
        {
            try
            {
                if (providerId is 0)
                {
                    return new ResponseModel<ProviderTypeResponseModel>
                    {
                        Message = "Invalid id!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<ProviderTypeResponseModel> response = await repository.GetProviderTypeByIdAsync(providerId);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProviderTypeResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<ProviderTypeResponseModel>> UpdateProviderTypeAsync(ProviderTypeUpdateModel updateModel)
        {
            try
            {
                if (updateModel is null)
                {
                    return new ResponseModel<ProviderTypeResponseModel>
                    {
                        Message = "Update model is null!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<ProviderTypeResponseModel> response = await repository.UpdateProviderTypeAsync(updateModel);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProviderTypeResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        #endregion

        #region Provider
        public async Task<ResponseModel<ProviderResponseModel>> CreateProviderAsync(ProviderRequestModel requestModel)
        {
            try
            {
                if (requestModel is null)
                {
                    return new ResponseModel<ProviderResponseModel>
                    {
                        Message = "Request model is null!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<ProviderResponseModel> response = await repository.CreateProviderAsync(requestModel);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProviderResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<bool>> DeleteProviderAsync(int ProviderId)
        {
            try
            {
                if (ProviderId is 0)
                {
                    return new ResponseModel<bool>
                    {
                        Message = "Invalid id!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1,
                        Data = false
                    };
                }

                ResponseModel<bool> response = await repository.DeleteProviderAsync(ProviderId);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<bool>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1,
                    Data = false
                };
            }
        }
        public async Task<ResponseModel<IList<ProviderResponseModel>>> GetAllProvidersAsync()
        {
            try
            {
                ResponseModel<IList<ProviderResponseModel>> response = await repository.GetAllProvidersAsync();

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<IList<ProviderResponseModel>>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<ProviderResponseModel>> GetProviderByIdAsync(int ProviderId)
        {
            try
            {
                if (ProviderId is 0)
                {
                    return new ResponseModel<ProviderResponseModel>
                    {
                        Message = "Invalid id!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<ProviderResponseModel> response = await repository.GetProviderByIdAsync(ProviderId);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProviderResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<ProviderResponseModel>> UpdateProviderAsync(ProviderUpdateModel updateModel)
        {
            try
            {
                if (updateModel is null)
                {
                    return new ResponseModel<ProviderResponseModel>
                    {
                        Message = "Update model is null!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<ProviderResponseModel> response = await repository.UpdateProviderAsync(updateModel);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<ProviderResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        #endregion
    }
}
