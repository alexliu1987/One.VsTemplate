define(['layer'], function (layer) {
    layer.config({
        path: serviceUrl + 'plugins/layer/' //layer.js所在的目录，可以是绝对目录，也可以是相对目录
    });
    return layer;
});