using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Test.BLL.IService;
using Test.CustomModels.Group;
using Test.CustomModels.GroupType;
using Test.CustomModels.ResponseModel;

namespace Test.Controllers
{
    public class GroupController : Controller
    {
        private readonly IGroupService service;

        public GroupController(IGroupService service)
        {
            this.service = service;
        }

        #region Group
        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            ResponseModel<IList<GroupResponseModel>> groups = await service.GetAllGroupsAsync();

            return View(groups);
        }
        
        [HttpGet]
        public async Task<IActionResult> GetGroup(int groupId)
        {
            ResponseModel<GroupResponseModel> group = await service.GetGroupByIdAsync(groupId);

            if (group.Status == 1)
            {
                return View(group);
            }

            return Redirect("/Error"); 
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(GroupRequestModel requestModel)
        {
            ResponseModel<GroupResponseModel> group = await service.CreateGroupAsync(requestModel);

            if(group.Status == 1)
            {
                return Ok(group);
            }

            return BadRequest(group);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroup(GroupUpdateModel updateModel)
        {
            ResponseModel<GroupResponseModel> groups = await service.UpdateGroupAsync(updateModel);


            if (groups.Status == 1)
            {
                return Ok(groups);
            }

            return BadRequest(groups);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            ResponseModel<bool> groups = await service.DeleteGroupAsync(groupId);

            if (groups.Status == 1)
            {
                return Ok(groups);
            }

            return BadRequest(groups);
        }
        #endregion

        #region GroupType
        [HttpGet]
        public async Task<IActionResult> GetGroupTypes()
        {
            ResponseModel<IList<GroupTypeResponseModel>> GroupTypes = await service.GetAllGroupTypesAsync();

            return View(GroupTypes);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupType(int GroupTypeId)
        {
            ResponseModel<GroupTypeResponseModel> GroupType = await service.GetGroupTypeByIdAsync(GroupTypeId);

            return View(GroupType);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroupType(GroupTypeRequestModel requestModel)
        {
            ResponseModel<GroupTypeResponseModel> GroupType = await service.CreateGroupTypeAsync(requestModel);

            return View(GroupType);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGroupType(GroupTypeUpdateModel updateModel)
        {
            ResponseModel<GroupTypeResponseModel> GroupTypes = await service.UpdateGroupTypeAsync(updateModel);

            return View(GroupTypes);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGroupType(int GroupTypeId)
        {
            ResponseModel<bool> GroupTypes = await service.DeleteGroupTypeAsync(GroupTypeId);

            return View(GroupTypes);
        }
        #endregion
    }
}
