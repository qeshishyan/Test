using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Test.CustomModels.Group;
using Test.CustomModels.GroupType;
using Test.CustomModels.ResponseModel;
using Test.DAL.IRepository;
using Test.DomainModels;
using Test.DomainModels.Group;

namespace Test.DAL.Repository
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext dbContext;
        private bool isSave = false;

        public GroupRepository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region GroupType 
        public async Task<ResponseModel<GroupTypeResponseModel>> CreateGroupTypeAsync(GroupTypeRequestModel requestModel)
        {
            try
            {
                GroupTypes GroupType = new GroupTypes
                {
                    Name = requestModel.Name
                };

                await dbContext.GroupTypes.AddAsync(GroupType);

                isSave = await dbContext.SaveChangesAsync() > 0;

                if (!isSave)
                {
                    return new ResponseModel<GroupTypeResponseModel>
                    {
                        Message = "Save problem!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -2
                    };
                }

                return new ResponseModel<GroupTypeResponseModel>
                {
                    Data = new GroupTypeResponseModel
                    {
                        Id = GroupType.Id,
                        Name = GroupType.Name
                    }
                };
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

        public async Task<ResponseModel<IList<GroupTypeResponseModel>>> GetAllGroupTypesAsync()
        {
            try
            {
                IList<GroupTypeResponseModel> result = await dbContext.GroupTypes
                      .Select(x => new GroupTypeResponseModel
                      {
                          Id = x.Id,
                          Name = x.Name

                      }).ToListAsync();

                var response = new ResponseModel<IList<GroupTypeResponseModel>>
                {
                    Data = result
                };

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
                GroupTypeResponseModel result = await dbContext.GroupTypes
                      .Where(x => x.Id == GroupId)
                      .Select(x => new GroupTypeResponseModel
                      {
                          Id = x.Id,
                          Name = x.Name

                      }).FirstOrDefaultAsync();

                if (result is null)
                {
                    return new ResponseModel<GroupTypeResponseModel>
                    {
                        Message = "Group not found!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -5
                    };
                }

                var response = new ResponseModel<GroupTypeResponseModel>
                {
                    Data = result
                };

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
                GroupTypes result = await dbContext.GroupTypes.Where(x => x.Id == GroupId).FirstOrDefaultAsync();

                if (result is null)
                {
                    return new ResponseModel<bool>
                    {
                        Message = "Group not found!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -5,
                        Data = false
                    };
                }

                dbContext.GroupTypes.Remove(result);
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

        public async Task<ResponseModel<GroupTypeResponseModel>> UpdateGroupTypeAsync(GroupTypeUpdateModel updateModel)
        {
            try
            {
                GroupTypes GroupType = new GroupTypes
                {
                    Name = updateModel.Name,
                    Id = updateModel.Id
                };

                dbContext.GroupTypes.Update(GroupType);

                isSave = await dbContext.SaveChangesAsync() > 0;

                if (!isSave)
                {
                    return new ResponseModel<GroupTypeResponseModel>
                    {
                        Message = "Save problem!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -2
                    };
                }

                return new ResponseModel<GroupTypeResponseModel>
                {
                    Data = new GroupTypeResponseModel
                    {
                        Id = GroupType.Id,
                        Name = GroupType.Name
                    }
                };
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
                Groups Group = new Groups
                {
                    Name = requestModel.Name,
                    GroupTypeId = requestModel.GroupTypeId
                };

                await dbContext.Groups.AddAsync(Group);

                isSave = await dbContext.SaveChangesAsync() > 0;

                if (!isSave)
                {
                    return new ResponseModel<GroupResponseModel>
                    {
                        Message = "Save problem!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -2
                    };
                }

                return new ResponseModel<GroupResponseModel>
                {
                    Data = new GroupResponseModel
                    {
                        Id = Group.Id,
                        Name = Group.Name
                    }
                };
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

        public async Task<ResponseModel<IList<GroupResponseModel>>> GetAllGroupsAsync()
        {
            try
            {
                IList<GroupResponseModel> result = await dbContext.Groups
                      .Select(x => new GroupResponseModel
                      {
                          Id = x.Id,
                          Name = x.Name

                      }).ToListAsync();

                var response = new ResponseModel<IList<GroupResponseModel>>
                {
                    Data = result
                };

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
                GroupResponseModel result = await dbContext.Groups
                      .Where(x => x.Id == GroupId)
                      .Select(x => new GroupResponseModel
                      {
                          Id = x.Id,
                          Name = x.Name,
                          GroupType = new GroupTypeResponseModel
                          {
                              Id = x.GroupTypes.Id,
                              Name = x.GroupTypes.Name
                          }

                      }).FirstOrDefaultAsync();

                if (result is null)
                {
                    return new ResponseModel<GroupResponseModel>
                    {
                        Message = "Group not found!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -5
                    };
                }

                var response = new ResponseModel<GroupResponseModel>
                {
                    Data = result
                };

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
                Groups result = await dbContext.Groups.Where(x => x.Id == GroupId).FirstOrDefaultAsync();

                if (result is null)
                {
                    return new ResponseModel<bool>
                    {
                        Message = "Group not found!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -5,
                        Data = false
                    };
                }

                dbContext.Groups.Remove(result);
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

        public async Task<ResponseModel<GroupResponseModel>> UpdateGroupAsync(GroupUpdateModel updateModel)
        {
            try
            {
                Groups Group = new Groups
                {
                    Name = updateModel.Name,
                    Id = updateModel.Id,
                    GroupTypeId = updateModel.GroupTypeId
                };

                dbContext.Groups.Update(Group);

                isSave = await dbContext.SaveChangesAsync() > 0;

                if (!isSave)
                {
                    return new ResponseModel<GroupResponseModel>
                    {
                        Message = "Save problem!",
                        StatusCode = StatusCodes.Status500InternalServerError,
                        Status = -2
                    };
                }

                return new ResponseModel<GroupResponseModel>
                {
                    Data = new GroupResponseModel
                    {
                        Id = Group.Id,
                        Name = Group.Name
                    }
                };
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
