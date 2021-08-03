using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.BLL.IService;
using Test.CustomModels.Group;
using Test.CustomModels.GroupType;
using Test.CustomModels.ResponseModel;
using Test.DAL.IRepository;

namespace Test.BLL.Service
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository repository;

        public GroupService(IGroupRepository repository)
        {
            this.repository = repository;
        }

        #region GroupTypes
        public async Task<ResponseModel<GroupTypeResponseModel>> CreateGroupTypeAsync(GroupTypeRequestModel requestModel)
        {
            try
            {
                if (requestModel is null)
                {
                    return new ResponseModel<GroupTypeResponseModel>
                    {
                        Message = "Request model is null!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<GroupTypeResponseModel> response = await repository.CreateGroupTypeAsync(requestModel);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<GroupTypeResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<bool>> DeleteGroupTypeAsync(int GroupId)
        {
            try
            {
                if (GroupId is 0)
                {
                    return new ResponseModel<bool>
                    {
                        Message = "Invalid id!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1,
                        Data = false
                    };
                }

                ResponseModel<bool> response = await repository.DeleteGroupAsync(GroupId);

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
        public async Task<ResponseModel<IList<GroupTypeResponseModel>>> GetAllGroupTypesAsync()
        {
            try
            {
                ResponseModel<IList<GroupTypeResponseModel>> response = await repository.GetAllGroupTypesAsync();

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<IList<GroupTypeResponseModel>>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<GroupTypeResponseModel>> GetGroupTypeByIdAsync(int GroupId)
        {
            try
            {
                if (GroupId is 0)
                {
                    return new ResponseModel<GroupTypeResponseModel>
                    {
                        Message = "Invalid id!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<GroupTypeResponseModel> response = await repository.GetGroupTypeByIdAsync(GroupId);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<GroupTypeResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<GroupTypeResponseModel>> UpdateGroupTypeAsync(GroupTypeUpdateModel updateModel)
        {
            try
            {
                if (updateModel is null)
                {
                    return new ResponseModel<GroupTypeResponseModel>
                    {
                        Message = "Update model is null!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<GroupTypeResponseModel> response = await repository.UpdateGroupTypeAsync(updateModel);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<GroupTypeResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        #endregion

        #region Group
        public async Task<ResponseModel<GroupResponseModel>> CreateGroupAsync(GroupRequestModel requestModel)
        {
            try
            {
                if (requestModel is null)
                {
                    return new ResponseModel<GroupResponseModel>
                    {
                        Message = "Request model is null!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<GroupResponseModel> response = await repository.CreateGroupAsync(requestModel);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<GroupResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<bool>> DeleteGroupAsync(int GroupId)
        {
            try
            {
                if (GroupId is 0)
                {
                    return new ResponseModel<bool>
                    {
                        Message = "Invalid id!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1,
                        Data = false
                    };
                }

                ResponseModel<bool> response = await repository.DeleteGroupAsync(GroupId);

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
        public async Task<ResponseModel<IList<GroupResponseModel>>> GetAllGroupsAsync()
        {
            try
            {
                ResponseModel<IList<GroupResponseModel>> response = await repository.GetAllGroupsAsync();

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<IList<GroupResponseModel>>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<GroupResponseModel>> GetGroupByIdAsync(int GroupId)
        {
            try
            {
                if (GroupId is 0)
                {
                    return new ResponseModel<GroupResponseModel>
                    {
                        Message = "Invalid id!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<GroupResponseModel> response = await repository.GetGroupByIdAsync(GroupId);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<GroupResponseModel>
                {
                    Message = ex.Message,
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Status = -1
                };
            }
        }
        public async Task<ResponseModel<GroupResponseModel>> UpdateGroupAsync(GroupUpdateModel updateModel)
        {
            try
            {
                if (updateModel is null)
                {
                    return new ResponseModel<GroupResponseModel>
                    {
                        Message = "Update model is null!",
                        StatusCode = StatusCodes.Status400BadRequest,
                        Status = -1
                    };
                }

                ResponseModel<GroupResponseModel> response = await repository.UpdateGroupAsync(updateModel);

                return response;
            }
            catch (Exception ex)
            {
                return new ResponseModel<GroupResponseModel>
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
