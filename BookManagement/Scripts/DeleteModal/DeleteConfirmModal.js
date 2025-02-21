
//AddAntiForgeryToken = function (data) {
//    data.__RequestVerificationToken = $('#__AjaxAntiForgeryForm input[name=__RequestVerificationToken]').val();
//    return data;
//};

//$('.delete-btn').click(function () {
//    var id = $(this).data('id');
//    var title = $(this).data('title');
//    var type = $(this).data('type');

//    $('#deleteConfirmationModal').modal('show');
//    $('#deleteConfirmationModal').data('id', id);
//    $('#deleteConfirmationModal').data('title', title);

//    if (type == "Book") {
//        $('#deleteConfirmationModal .title-confirm-delete p').html('Are you sure you want to delete the book <strong>' + title + '</strong>?');
//        $(".confirmDelete").attr("id", "confirmDeleteBook");
//    } else {
//        $('#deleteConfirmationModal .title-confirm-delete p').html('Are you sure you want to delete the category <strong>' + title + '</strong>?');
//        $(".confirmDelete").attr("id", "confirmDeleteCategory");
//    }

//    $('#confirmDeleteBook').off('click').one('click', function () {
//        var bookId = $('#deleteConfirmationModal').data('id');
//        $.ajax({
//            url: '/Book/Delete',
//            type: 'POST',
//            data: AddAntiForgeryToken({ id: bookId }),
//            success: function (response) {
//                $('#deleteConfirmationModal').modal('hide');
//                location.reload();
//            },
//            error: function (xhr, status, error) {
//                alert('Error: ' + error);
//            }
//        });
//    });

//    $('#confirmDeleteCategory').off('click').one('click', function () {
//        var categoryId = $('#deleteConfirmationModal').data('id');
//        $.ajax({
//            url: '/Category/Delete',
//            type: 'POST',
//            async: false,
//            data: AddAntiForgeryToken({ id: categoryId }),
//            success: function (response) {
//                $('#deleteConfirmationModal').modal('hide');
//                location.reload();
//                //console.log(response);
//                //$('#book-content').html(response.asdasdas);

//                //var categoriesTableBody = '';

//                //$.each(response.categories, function (index, category) {
//                //    categoriesTableBody += '<tr>';
//                //    categoriesTableBody += '<td>' + (index + 1) + '</td>';
//                //    categoriesTableBody += '<td>' + category.Id + '</td>';
//                //    categoriesTableBody += '<td>' + category.Name + '</td>';
//                //    categoriesTableBody += '<td>';
//                //    categoriesTableBody += '<a href="/Category/Edit/' + category.Id + '" class="btn btn-warning">Edit</a>';
//                //    categoriesTableBody += '<a href="javascript:void(0);" class="btn btn-danger delete-btn" data-id="' + category.Id + '" data-title="' + category.Name + '" data-type="Category">Delete</a>';
//                //    categoriesTableBody += '</td>';
//                //    categoriesTableBody += '</tr>';
//                //});

//                //$('table tbody').html(categoriesTableBody);
//            },
//            error: function (xhr, status, error) {
//                alert('Error: ' + error);
//            }
//        });
//    });
//});

//$('.cancelDelete').click(function () {
//    $('#deleteConfirmationModal').modal('hide');
//});


//$(document).ready(function () {
//    var toastEl = $('#errorToast')[0];
//    var toast = new bootstrap.Toast(toastEl);
//    toast.show();
//});