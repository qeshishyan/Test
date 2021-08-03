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
            ResponseModel<IList<GroupResponseModel>> group = await service.GetAllGroupsAsync();

            ViewBag.Group = await service.GetGroupByIdAsync(groupId);

            ViewBag.GroupTypes = await service.GetAllGroupTypesAsync();

            if (group.Status == 1)
            {
                return View(group);
            }

            return Redirect("/Error");
        }

        [HttpGet]
        public async Task<IActionResult> CreateGroup()
        {
            ResponseModel<IList<GroupTypeResponseModel>> groupTypes = await service.GetAllGroupTypesAsync();

            ViewBag.Groups = await service.GetAllGroupsAsync();

            return View(groupTypes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroup(GroupRequestModel requestModel)
        {
            ResponseModel<GroupResponseModel> group = await service.CreateGroupAsync(requestModel);

            return Redirect("CreateGroup");
        }

        [HttpPost]
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

            return Ok();
        }
        #endregion

        #region groupType
        [HttpGet]
        public async Task<IActionResult> GetGroupTypes()
        {
            ResponseModel<IList<GroupTypeResponseModel>> groupTypes = await service.GetAllGroupTypesAsync();

            return View(groupTypes);
        }

        [HttpGet]
        public async Task<IActionResult> GetGroupType(int groupTypeId)
        {
            ResponseModel<GroupTypeResponseModel> groupType = await service.GetGroupTypeByIdAsync(groupTypeId);

            ViewBag.GroupType = groupType;

            ResponseModel<IList<GroupTypeResponseModel>> groupTypes = await service.GetAllGroupTypesAsync();

            return View(groupTypes);
        }

        [HttpPost]
        public async Task<IActionResult> CreateGroupType(GroupTypeRequestModel requestModel)
        {
            ResponseModel<GroupTypeResponseModel> groupType = await service.CreateGroupTypeAsync(requestModel);

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateGroupType()
        {
            ResponseModel<IList<GroupTypeResponseModel>> groupTypes = await service.GetAllGroupTypesAsync();

            return View(groupTypes);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateGroupType(GroupTypeUpdateModel updateModel)
        {
            ResponseModel<GroupTypeResponseModel> groupTypes = await service.UpdateGroupTypeAsync(updateModel);

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGroupType(int groupTypeId)
        {
            ResponseModel<bool> groupTypes = await service.DeleteGroupTypeAsync(groupTypeId);

            return Ok();
        }
        #endregion
    }
}
