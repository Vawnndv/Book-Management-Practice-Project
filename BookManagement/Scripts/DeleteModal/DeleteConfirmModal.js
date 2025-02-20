$('.delete-btn').click(function () {
    var id = $(this).data('id');
    var title = $(this).data('title');
    var type = $(this).data('type');

    $('#deleteConfirmationModal').modal('show');
    $('#deleteConfirmationModal').data('id', id);
    $('#deleteConfirmationModal').data('title', title);

    if (type == "Book") {
        $('#deleteConfirmationModal .title-confirm-delete p').html('Are you sure you want to delete the book <strong>' + title + '</strong>?');
        $(".confirmDelete").attr("id", "confirmDeleteBook");
    } else {
        $('#deleteConfirmationModal .title-confirm-delete p').html('Are you sure you want to delete the category <strong>' + title + '</strong>?');
        $(".confirmDelete").attr("id", "confirmDeleteCategory");
    }

    $('#confirmDeleteBook').off('click').one('click', function () {
        var bookId = $('#deleteConfirmationModal').data('id');
        $.ajax({
            url: '<%= Url.Action("Delete", "Book") %>',
            type: 'POST',
            data: { id: bookId },
            success: function (response) {
                $('#deleteConfirmationModal').modal('hide');
                location.reload(); // Update record but not reload the page
            },
            error: function (xhr, status, error) {
                alert('Error: ' + error);
            }
        });
    });

    $('#confirmDeleteCategory').off('click').one('click', function () {
        var categoryId = $('#deleteConfirmationModal').data('id');
        $.ajax({
            url: '<%= Url.Action("Delete", "Category") %>',
            type: 'POST',
            data: { id: categoryId },
            success: function (response) {
                $('#deleteConfirmationModal').modal('hide');
                location.reload(); // Update record but not reload the page
            },
            error: function (xhr, status, error) {
                alert('Error: ' + error);
            }
        });
    });
});

$('.cancelDelete').click(function () {
    $('#deleteConfirmationModal').modal('hide');
});


$(document).ready(function () {
    var toastEl = $('#errorToast')[0];
    var toast = new bootstrap.Toast(toastEl);
    toast.show();
});