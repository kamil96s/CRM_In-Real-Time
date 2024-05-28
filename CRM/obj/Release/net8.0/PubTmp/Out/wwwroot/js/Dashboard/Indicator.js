$(document).ready(function () {
    var renderGauge = function () {
        var totalLeadCount = parseInt($('#totalLeadCount').val());

        $.ajax({
            url: '/Lead/Poz3Count',
            type: 'get',
            success: function (poz3Count) {
                var percentage = ((poz3Count / totalLeadCount) * 100).toFixed(1);
                var value = poz3Count;

                var gaugeOptions = {
                    angle: 0,
                    lineWidth: 0.2,
                    radiusScale: 1,
                    pointer: {
                        length: 0.6,
                        strokeWidth: 0.035,
                        color: '#333333'
                    },
                    limitMax: false,
                    limitMin: false,
                    colorStart: '#6FADCF',
                    colorStop: '#8FC0DA',
                    strokeColor: '#E0E0E0',
                    generateGradient: true,
                    highDpiSupport: true,
                    staticZones: [
                        { strokeStyle: "#F44336", min: 0, max: totalLeadCount * 0.5 },
                        { strokeStyle: "#FFC107", min: totalLeadCount * 0.5, max: totalLeadCount * 0.75 },
                        { strokeStyle: "#4CAF50", min: totalLeadCount * 0.75, max: totalLeadCount }
                    ],
                    renderTicks: {
                        divisions: 5,
                        divWidth: 1.1,
                        divLength: 0.7,
                        divColor: "#333333",
                        subDivisions: 3,
                        subLength: 0.5,
                        subWidth: 0.6,
                        subColor: "#666666"
                    },
                    staticLabels: {
                        font: "16px sans-serif",
                        labels: [0, totalLeadCount * 0.25, totalLeadCount * 0.5, totalLeadCount],
                        color: "#000000",
                        fractionDigits: 0
                    }
                };

                var target = document.getElementById('myPieChart3');
                var gauge = new Gauge(target).setOptions(gaugeOptions);
                gauge.maxValue = totalLeadCount;
                gauge.setMinValue(0);
                gauge.animationSpeed = 32;
                gauge.set(value);

                $('#percentage').text(percentage + '%');
            },
            error: function () {
                toastr["error"]("Something went wrong while fetching Poz3 count");
            }
        });
    };

    renderGauge();

    $(window).resize(function () {
        renderGauge();
    });
});
