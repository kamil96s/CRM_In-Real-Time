// In your lead.js
function moveProgress(leadId) {
    const progressBar = document.getElementById('progress-' + leadId);
    const steps = 100 / 3;  // Assuming there are three steps between stages
    let currentProgress = parseFloat(progressBar.style.width, 10) || 0;
    currentProgress += steps;
    if (currentProgress > 100) currentProgress = 100;
    progressBar.style.width = currentProgress + '%';

    // Send an AJAX request to update the progress in the database
    fetch(`/Lead/Update?leadId=${leadId}&progress=${currentProgress}`, {
        method: 'POST'
    }).then(response => {
        if (!response.ok) {
            console.error('Failed to update progress');
        }
    });
}
function removeProgress(leadId) {
    const progressBar = document.getElementById('progress-' + leadId);
    const steps = 100 / 3;  // Assuming there are three steps between stages
    let currentProgress = parseFloat(progressBar.style.width, 10) || 0;
    currentProgress -= steps;
    if (currentProgress < 0) currentProgress = 0;
    progressBar.style.width = currentProgress + '%';
}
