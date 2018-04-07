$(function () {
    $('.chart').each(function () {
        var $chart = $(this);
        console.log($chart);
        var myChart = new Chart($chart, {
            type: 'line',
            data: {
                labels: $chart.data('chart-labels'),
                datasets: [{
                    label: $chart.data('chart-label'),
                    data: $chart.data('chart-data'),
                    backgroundColor: 'rgba(0, 0, 0, 0)',
                    pointBackgroundColor: $chart.data("chart-color"),
                    borderColor: $chart.data("chart-color"),
                    borderWidth: 1,
                    lineTension: 0
                }],
            },
            options: {
                scales: {
                    yAxes: [{
                        ticks: {
                            beginAtZero: true,
                            callback: function (value, index, values) {
                                return ($chart.data("chart-yaxis-tick") != undefined ? $chart.data("chart-yaxis-tick") : '') + value;
                            }
                        }
                    }]
                }
            }
        });
    });
});
