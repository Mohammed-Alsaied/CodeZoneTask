//Purchase Form
$(document).ready(function () {
    $('#ItemId,#StoreId').on('change', function () {

        var itemId = $('#ItemId').val();
        var storeId = $('#StoreId').val();
        var balance = $('#Balance');
        if (storeId !== '' && itemId !== '') {
            $.ajax({
                url: '/Purchase/GetBalance',
                data: {
                    storeId: storeId,
                    itemId: itemId
                },
                success: function (quantity) {
                    balance.attr('value', quantity).text(quantity);
                },
                error: function () {
                    alert('حدث خطأ ما');
                },
            })
        }
    });
});

//Item
$(document).ready(function () {
    $('.js-delete-item').on('click', function () {
        var btn = $(this);
        bootbox.confirm({
            message: "هل انت متأكد من حذف الصنف",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-outline-secondary'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({
                        url: '/items/delete/' + btn.data('id'),
                        success: function () {
                            var itemContainer = btn.parents('.card');
                            itemContainer.addClass('animate__animated animate__zoomOut');
                            setTimeout(function () {
                                itemContainer.remove();
                            }, 500);
                            toastr.success('تم حذف الصنف');
                        },
                        error: function () {
                            toastr.error('حدث خطأ!');
                        }
                    });
                }
            }
        });
    });
});

 //Store
$(document).ready(function () {
    $('.js-delete-store').on('click', function () {
        var btn = $(this);
        bootbox.confirm({
            message: "هل انت متأكد من حذف الفرع؟",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-outline-secondary'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({
                        url: '/stores/delete/' + btn.data('id'),
                        success: function () {
                            var storeContainer = btn.parents('.card');
                            storeContainer.addClass('animate__animated animate__zoomOut');
                            setTimeout(function () {
                                storeContainer.remove();
                            }, 500);
                            toastr.success('تم حذف الفرع');
                        },
                        error: function () {
                            toastr.error('حدث خطأ!');
                        }
                    });
                }
            }
        });
    });
});

//Purchase
$(document).ready(function () {
    $('.js-delete-purchase').on('click', function () {
        var btn = $(this);
        bootbox.confirm({
            message: "هل انت متأكد من حذف المشتريات؟",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-outline-secondary'
                }
            },
            callback: function (result) {
                if (result) {
                    $.ajax({
                        url: '/purchase/delete/' + btn.data('id'),
                        success: function () {
                            var purchaseContainer = btn.parents('.tbl');
                            purchaseContainer.addClass('animate__animated animate__zoomOut');
                            setTimeout(function () {
                                purchaseContainer.remove();
                            }, 500);
                            toastr.success('تم حذف المشتريات');
                        },
                        error: function () {
                            toastr.error('حدث خطأ!');
                        }
                    });
                }
            }
        });
    });
});

//Data Table
$(document).ready(function () {
    $('#datatable').DataTable();
});