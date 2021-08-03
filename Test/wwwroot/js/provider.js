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
        url: "/Provider/DeleteProviderType" + '?providerTypeId=' + id,
        error: function () {
            console.log('errr');
        },
        success: function (data) {
            console.log('ok')
            location.reload();
        },
        type: "Get"
    });
}