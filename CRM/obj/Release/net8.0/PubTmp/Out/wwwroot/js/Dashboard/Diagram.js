$(document).ready(function () {
    var nameCount = parseInt($('#nameCount').val());
    var totalNameCount = parseInt($('#totalNameCount').val());
    var ctx = document.getElementById('myPieChart').getContext('2d');

    if (window.myPieChart instanceof Chart) {
        window.myPieChart.destroy();
    }

    window.myPieChart = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['By Me', 'By Colleagues'],
            datasets: [{
                data: [nameCount, totalNameCount - nameCount],
                backgroundColor: ['#000000', '#007bff'],
            }]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'bottom',
                },
            },
        }
    });
});
