$(document).ready(function () {
    var totalLeadCount = parseInt($('#totalLeadCount').val());

    // Fetch poz3Count
    $.ajax({
        url: '/Lead/Poz3Count',
        type: 'get',
        success: function (poz3Count) {
            var percentage = ((poz3Count / totalLeadCount) * 100).toFixed(1);  // One decimal place
            var value = poz3Count;  // Now, value should be poz3Count

            var gaugeOptions = {
                angle: 0, // The span of the gauge arc
                lineWidth: 0.2, // The line thickness
                radiusScale: 1, // Adjusted radius scale to fill more space
                pointer: {
                    length: 0.6, // Relative to gauge radius
                    strokeWidth: 0.035, // The thickness
                    color: '#333333' // Fill color (darker for better visibility)
                },
                limitMax: false,     // If false, max value increases automatically if value > maxValue
                limitMin: false,     // If true, the min value of the gauge will be fixed
                colorStart: '#6FADCF',   // Start color for gradient
                colorStop: '#8FC0DA',    // Stop color for gradient
                strokeColor: '#E0E0E0',  // Background stroke color
                generateGradient: true,
                highDpiSupport: true,     // High resolution support
                staticZones: [
                    { strokeStyle: "#F44336", min: 0, max: totalLeadCount * 0.5 }, // Green
                    { strokeStyle: "#FFC107", min: totalLeadCount * 0.5, max: totalLeadCount * 0.75 }, // Yellow
                    { strokeStyle: "#4CAF50", min: totalLeadCount * 0.75, max: totalLeadCount }, // Red
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
                    font: "16px sans-serif",  // Specifies font
                    labels: [0, totalLeadCount * 0.25, totalLeadCount * 0.5, totalLeadCount],
                    color: "#000000",
                    fractionDigits: 0
                }
            };

            var target = document.getElementById('myPieChart3'); // your canvas element
            var gauge = new Gauge(target).setOptions(gaugeOptions); // create gauge!
            gauge.maxValue = totalLeadCount; // set max gauge value
            gauge.setMinValue(0);  // set min value
            gauge.animationSpeed = 32; // set animation speed (32 is default value)
            gauge.set(value); // set actual value (poz3Count)

            // Display percentage
            $('#percentage').text(percentage + '%');
        },
        error: function () {
            toastr["error"]("Something went wrong while fetching Poz3 count");
        }
    });
});
