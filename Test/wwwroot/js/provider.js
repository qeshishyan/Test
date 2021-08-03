function addProviderType() {

    const providerName = document.getElementById('provider_type_name').value;

    console.log(providerName);

    $.ajax({
        url: "/Provider/CreateProviderType",
        data: {
            name: providerName
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

function updateProviderType() {

    const providerTypeName = document.getElementById('provider_type_name').value;
    const providerTypeId = document.getElementById('provider_type_id').value;

    console.log(providerTypeId);

    $.ajax({
        url: "/Provider/UpdateProviderType",
        data: {
            name: providerTypeName,
            id: providerTypeId
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

function deleteProviderType(id) {
    $.ajax({
        url: "/Provider/DeleteProviderType" + "?providerTypeId=" + id,
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

//Provider

function addProvider() {
     
    const providerName = document.getElementById('provider_name').value;
    const group_id = document.getElementById('group_id').value;
    const provider_Id = document.getElementById('provider_Id').value;
      
    $.ajax({
        url: "/Provider/CreateProvider",
        data: {
            name: providerName,
            providerTypeId: provider_Id,
            groupId: group_id
        },
        error: function () {
            console.log('errr');
        }, 
        success: function () {
            location.replace('/provider/index');
        },
        type: "Post"
    });
} 

function deleteProvider(id) {
    $.ajax({
        url: "/Provider/DeleteProvider" + "?providerId=" + id,
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

function updateProvider(id) {

    const providerName = document.getElementById('provider_name').value;
    const providerTypeId = document.getElementById('provider_type_Id').value;
    const groupId = document.getElementById('group_id').value;

    console.log(providerTypeId);

    $.ajax({
        url: "/Provider/UpdateProvider",
        data: {
            name: providerName,
            providerTypeId: providerTypeId,
            groupId: groupId,
            id: id
        },
        error: function () {
            console.log('errr');
        },
        success: function (data) {
            console.log('ok')
            location.replace('/provider/index');
        },
        type: "Post"
    });
}

