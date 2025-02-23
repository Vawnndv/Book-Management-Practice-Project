$('.delete-btn').on('click', function (e) {
    e.preventDefault();

    var itemId = $(this).data('id');
    var itemName = $(this).data('title');

    $('.title-confirm-delete p').text('Are you sure you want to delete "' + itemName + '"?');

    $('#itemId').val(itemId);

    $('#deleteConfirmationModal').modal('show');
});

$('.cancelDelete').on('click', function () {
    $('#deleteConfirmationModal').modal('hide');
});

$('.submitConfirmDelete').on('click', function () {
    $('#deleteCategoryForm').submit();
});