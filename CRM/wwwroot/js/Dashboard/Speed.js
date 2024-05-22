$(document).ready(function () {
    var leadCount = parseInt($('#leadCount').val());
    var totalLeadCount = parseInt($('#totalLeadCount').val());

    var ctx = document.getElementById('myPieChart2').getContext('2d');

    // Sprawdü, czy istnieje obiekt wykresu w globalnej zmiennej i zniszcz go, jeúli istnieje
    if (window.myPieChart2 instanceof Chart) {
        window.myPieChart2.destroy();
    }

    window.myPieChart2 = new Chart(ctx, {
        type: 'pie',
        data: {
            labels: ['By Me', 'By Colleagues'],
            datasets: [{
                data: [leadCount, totalLeadCount - leadCount],
                backgroundColor: ['#dc3545', '#28a745'],
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
