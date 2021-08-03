using System.Collections.Generic;
using System.Threading.Tasks;
using Test.CustomModels.Group;
using Test.CustomModels.GroupType;
using Test.CustomModels.ResponseModel;

namespace Test.DAL.IRepository
{
    public interface IGroupRepository
    {
        #region GroupType
        Task<ResponseModel<GroupTypeResponseModel>> CreateGroupTypeAsync(GroupTypeRequestModel requestModel);
        Task<ResponseModel<bool>> DeleteGroupTypeAsync(int GroupId);
        Task<ResponseModel<IList<GroupTypeResponseModel>>> GetAllGroupTypesAsync();
        Task<ResponseModel<GroupTypeResponseModel>> GetGroupTypeByIdAsync(int GroupId);
        Task<ResponseModel<GroupTypeResponseModel>> UpdateGroupTypeAsync(GroupTypeUpdateModel updateModel);
        #endregion

        #region Group
        Task<ResponseModel<GroupResponseModel>> CreateGroupAsync(GroupRequestModel requestModel);
        Task<ResponseModel<GroupResponseModel>> UpdateGroupAsync(GroupUpdateModel updateModel);
        Task<ResponseModel<bool>> DeleteGroupAsync(int GroupId);
        Task<ResponseModel<IList<GroupResponseModel>>> GetAllGroupsAsync();
        Task<ResponseModel<GroupResponseModel>> GetGroupByIdAsync(int GroupId); 
        #endregion 
    }
}