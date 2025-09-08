console.log("item.js loaded")
$(function () {
    loadDataTable();
});

function loadDataTable() {
    $('#tblData').DataTable({
        "ajax": {
            url: '/admin/item/getall'
        },
        "columns": [
            { data: 'name', "width": "15%" },
            { data: 'description', "width": "15%" },
            { data: 'price', "width": "15%" },
            { data: 'carBrand.carBrandName', "width": "15%" }//,{ data: '', "width": "15%" }
        ]
    });
}