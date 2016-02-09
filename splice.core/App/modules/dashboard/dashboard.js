var dashboard = angular.module('splice.dashboard', []);

dashboard.controller('StoreHealthController', function ($scope) {
    var chart = AmCharts.makeChart("chartdiv", {
        "type": "pie",
        "theme": "light",
        "dataProvider": [{
            "title": "Profit",
            "value": 4852
        }, {
            "title": "Losses",
            "value": 9899,
        }],
        "titleField": "title",
        "valueField": "value",
        "labelRadius": 5,

        "radius": "42%",
        "innerRadius": "60%",
        "labelText": "[[title]]",
        "export": {
            "enabled": true
        }
    });
});