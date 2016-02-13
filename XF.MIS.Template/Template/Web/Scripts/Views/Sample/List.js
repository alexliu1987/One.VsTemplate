define(['module/layer', 'module/ngapp'],
function (layer, app) {
    'use strict';

    require(['css!../Content/Views/Sample/Index.css']);
    $(function () {
        var table = $('#dataTables-example')
            .DataTable({
                responsive: true,
                "serverSide": true,
                "ajax": {
                    "url": '/$safeprojectname$/Sample/GetDataTable',
                    "type": 'POST',
                    "data": function (d) {
                        return $.extend({}, d, {
                            "filter": [
                                {
                                    "Key": "Id",
                                    "Value": $('#txtId').val()
                                },
                                {
                                    "Key": "Name",
                                    "Value": $('#txtName').val()
                                }
                            ]
                        });
                    }
                },
                "columns": [
                    { "data": 'Id' },
                    { "data": 'Name' }
                ],
                "stateSave": true,
                "lengthChange": false,
                "ordering": false,
                "filter": false,
                "language": {
                    "lengthMenu": "每页显示 _MENU_ 条",
                    "zeroRecords": "很抱歉，没有找到符合条件的数据！",
                    "info": "共 _PAGES_ 页 当前第 _PAGE_ 页",
                    "infoEmpty": "没有数据",
                    "oPaginate": {
                        "sFirst": "首页",
                        "sPrevious": "上一页",
                        "sNext": "下一页",
                        "sLast": "尾页"
                    }
                }
            });
        $("#btnSearch").on("click", function () {
            table.draw();
        });
    });
});