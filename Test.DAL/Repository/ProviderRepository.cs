using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.CustomModels.ResponseModel;
using Test.CustomModels.ProviderType;
using Test.DAL.IRepository;
using Test.DomainModels;
using Test.DomainModels.Provider;
using Test.CustomModels.Provider;
using Test.CustomModels.Group;

namespace Test.DAL.Repository
{
    public class ProviderRepository : IProviderRepository
    {
        private readonly AppDbContext dbContext;
        private bool isSave = false;

        public ProviderRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region ProviderType 
        public async Task<ResponseModel<ProviderTypeResponseModel>> CreateProviderTypeAsync(ProviderTypeRequestModel requestModel)
        {
            try
            {
                ProviderTypes providerType = new ProviderTypes
                {
                    Name = requestModel.Name
                };

                await dbContext.ProviderTypes.AddAsync(providerType);

                isSave = await dbContext.SaveChangesAsync() > 0;

                if (!isSave)
                {
                    return new ResponseModel<ProviderTypeResponseModel>
                    {
                        Message = "Save problem!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -2
                    };
                }

                return new ResponseModel<ProviderTypeResponseModel>
                {
                    Data = new ProviderTypeResponseModel
                    {
                        Id = providerType.Id,
                        Name = providerType.Name
                    }
                };
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

        public async Task<ResponseModel<IList<ProviderTypeResponseModel>>> GetAllProviderTypesAsync()
        {
            try
            {
                IList<ProviderTypeResponseModel> result = await dbContext.ProviderTypes
                      .Select(x => new ProviderTypeResponseModel
                      {
                          Id = x.Id,
                          Name = x.Name

                      }).ToListAsync();

                var response = new ResponseModel<IList<ProviderTypeResponseModel>>
                {
                    Data = result
                };

                return response;
            }
            catch (Exception ex)
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
                ProviderTypeResponseModel result = await dbContext.ProviderTypes
                      .Where(x=> x.Id == providerId)
                      .Select(x => new ProviderTypeResponseModel
                      {
                          Id = x.Id,
                          Name = x.Name

                      }).FirstOrDefaultAsync();

                if(result is null)
                {
                    return new ResponseModel<ProviderTypeResponseModel>
                    {
                        Message = "Provider not found!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -5
                    };
                }

                var response = new ResponseModel<ProviderTypeResponseModel>
                {
                    Data = result
                };

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
                ProviderTypes result = await dbContext.ProviderTypes.Where(x=> x.Id == providerId).FirstOrDefaultAsync();

                if(result is null)
                {
                    return new ResponseModel<bool>
                    {
                        Message = "Provider not found!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -5,
                        Data = false
                    };
                }

                dbContext.ProviderTypes.Remove(result);
                await dbContext.SaveChangesAsync();

                var response = new ResponseModel<bool>
                {
                    Data = true
                };

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

        public async Task<ResponseModel<ProviderTypeResponseModel>> UpdateProviderTypeAsync(ProviderTypeUpdateModel updateModel)
        {
            try
            {
                ProviderTypes providerType = new ProviderTypes
                {
                    Name = updateModel.Name,
                    Id = updateModel.Id
                };

                dbContext.ProviderTypes.Update(providerType);

                isSave = await dbContext.SaveChangesAsync() > 0;

                if (!isSave)
                {
                    return new ResponseModel<ProviderTypeResponseModel>
                    {
                        Message = "Save problem!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -2
                    };
                }

                return new ResponseModel<ProviderTypeResponseModel>
                {
                    Data = new ProviderTypeResponseModel
                    {
                        Id = providerType.Id,
                        Name = providerType.Name
                    }
                };
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
                Providers Provider = new Providers
                {
                    Name = requestModel.Name
                };

                await dbContext.Providers.AddAsync(Provider);

                isSave = await dbContext.SaveChangesAsync() > 0;

                if (!isSave)
                {
                    return new ResponseModel<ProviderResponseModel>
                    {
                        Message = "Save problem!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -2
                    };
                }

                return new ResponseModel<ProviderResponseModel>
                {
                    Data = new ProviderResponseModel
                    {
                        Id = Provider.Id,
                        Name = Provider.Name
                    }
                };
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

        public async Task<ResponseModel<IList<ProviderResponseModel>>> GetAllProvidersAsync()
        {
            try
            {
                IList<ProviderResponseModel> result = await dbContext.Providers
                      .Include(x=> x.ProviderTypes)
                      .Include(x=> x.Groups)
                      .Select(x => new ProviderResponseModel
                      {
                          Id = x.Id,
                          Name = x.Name,
                          ProviderType = new ProviderTypeResponseModel
                          {
                              Id = x.ProviderTypes.Id,
                              Name = x.ProviderTypes.Name
                          },
                          Group = new GroupResponseModel
                          {
                              Id = x.Groups.Id,
                              Name = x.Groups.Name
                          }

                      }).ToListAsync();

                var response = new ResponseModel<IList<ProviderResponseModel>>
                {
                    Data = result
                };

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

        public async Task<ResponseModel<ProviderResponseModel>> GetProviderByIdAsync(int providerId)
        {
            try
            {
                ProviderResponseModel result = await dbContext.Providers
                      .Where(x => x.Id == providerId)
                      .Select(x => new ProviderResponseModel
                      {
                          Id = x.Id,
                          Name = x.Name

                      }).FirstOrDefaultAsync();

                if (result is null)
                {
                    return new ResponseModel<ProviderResponseModel>
                    {
                        Message = "Provider not found!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -5
                    };
                }

                var response = new ResponseModel<ProviderResponseModel>
                {
                    Data = result
                };

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

        public async Task<ResponseModel<bool>> DeleteProviderAsync(int providerId)
        {
            try
            {
                Providers result = await dbContext.Providers.Where(x => x.Id == providerId).FirstOrDefaultAsync();

                if (result is null)
                {
                    return new ResponseModel<bool>
                    {
                        Message = "Provider not found!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -5,
                        Data = false
                    };
                }

                dbContext.Providers.Remove(result);
                await dbContext.SaveChangesAsync();

                var response = new ResponseModel<bool>
                {
                    Data = true
                };

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

        public async Task<ResponseModel<ProviderResponseModel>> UpdateProviderAsync(ProviderUpdateModel updateModel)
        {
            try
            {
                Providers Provider = new Providers
                {
                    Name = updateModel.Name,
                    Id = updateModel.Id
                };

                dbContext.Providers.Update(Provider);

                isSave = await dbContext.SaveChangesAsync() > 0;

                if (!isSave)
                {
                    return new ResponseModel<ProviderResponseModel>
                    {
                        Message = "Save problem!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -2
                    };
                }

                return new ResponseModel<ProviderResponseModel>
                {
                    Data = new ProviderResponseModel
                    {
                        Id = Provider.Id,
                        Name = Provider.Name
                    }
                };
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
