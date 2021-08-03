function addGroupType() {

    const groupName = document.getElementById('group_type_name').value;

    console.log(groupName);

    $.ajax({
        url: "/Group/CreateGroupType",
        data: {
            name: groupName
        },
        error: function () {
            console.log('errr');
        },
        success: function (data) {
            console.log('ok')
            location.reload();
        },
        type: "Post"
    });
}

function updateGroupType() {

    const groupTypeName = document.getElementById('group_type_name').value;
    const groupTypeId = document.getElementById('group_type_id').value;
     

    $.ajax({
        url: "/Group/UpdateGroupType",
        data: {
            name: groupTypeName,
            id: groupTypeId
        },
        error: function () {
            console.log('errr');
        },
        success: function (data) {
            console.log('ok')
            location.reload();
        },
        type: "Post"
    });
}

function deleteGroupType(id) {
    $.ajax({
        url: "/Group/DeleteGroupType" + "?groupTypeId=" + id,
        error: function () {
            console.log('errr');
        },
        contentType: "application/json",
        success: function () {
            location.reload();
        },
        type: "DELETE"
    });
}

function updateGroup() {

    const groupName = document.getElementById('group_name').value;
    const groupId = document.getElementById('group_id').value;
    const group_type_id = document.getElementById('group_type_id').value;

    $.ajax({
        url: "/Group/UpdateGroup",
        data: {
            name: groupName,
            id: groupId,
            groupTypeId: group_type_id
        },
        error: function () {
            console.log('errr');
        },
        success: function (data) {
            console.log('ok')
            location.reload();
        },
        type: "Post"
    });
}

function deleteGroup(id) {
    $.ajax({
        url: "/Group/DeleteGroup" + "?groupId=" + id,
        error: function () {
            console.log('errr');
        },
        contentType: "application/json",
        success: function () {
            location.reload();
        },
        type: "DELETE"
    });
}