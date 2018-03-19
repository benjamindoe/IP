$(function () {

  var $chart = $('#chart');
  console.log($chart);
  var myChart = new Chart($chart, {
      type: 'line',
      data: {
          labels: ["Jan", "Feb", "Mar", "Apr", "May", "Jun"],
          datasets: [{
              label: 'No of orders in past 6 months',
              data: [7, 8, 3, 5, 2, 5],
              backgroundColor: 'rgba(0, 0, 0, 0)',
              pointBackgroundColor :'rgba(255,99,132,1)',
              borderColor: 'rgba(255,99,132,1)',
              borderWidth: 1,
              lineTension: 0
          }]
      },
      options: {
          scales: {
              yAxes: [{
                  ticks: {
                      beginAtZero:true
                  }
              }]
          }
      }
  });

});
